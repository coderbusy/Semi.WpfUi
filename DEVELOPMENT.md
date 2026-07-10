# Semi.WpfUi 开发指南

本仓库的目标是将 [Semi.Avalonia](https://github.com/irihitech/Semi.Avalonia) 的设计令牌和控件体验，以符合 WPF 惯例的方式重新实现。`irihitech/Semi.Avalonia/` 是迁移行为、资源键和视觉效果的首要对照来源；它不是 WPF 项目的构建输入。

## 核心原则

- 保持 Semi 的设计语义和资源命名，适配 WPF 的控件、属性系统和模板机制。
- 样式引用控件语义资源，语义资源引用全局设计令牌；不要在控件样式中直接写色值或调色板资源。
- 每次迁移都同时交付 Light、Dark、Shared 资源、控件样式和 Demo 示例。
- 仅迁移 WPF 能自然支持的能力。框架模型存在差异时，先定义清晰的 WPF API，再实现等价的用户体验。

## 目录与职责

```text
irihitech/Semi.Avalonia/       Avalonia 对照实现
src/Semi.WpfUi/
  Tokens/
    Palette/                   Light/Dark 原始调色板与全局语义颜色
    Variables.xaml             尺寸、间距、圆角、字体等非颜色令牌
  Themes/
    Shared/                    控件无关主题值及跨主题控件语义资源
    Light/                     Light 控件颜色语义资源
    Dark/                      Dark 控件颜色语义资源
  Controls/                    WPF 控件样式；一个控件一个字典
  Attached/Classes.cs          Avalonia class 的 WPF 附加属性替代方案
  SemiTheme.cs                 主题资源入口和运行时切换
demo/Semi.WpfUi.Demo/          展示与人工视觉验证
```

每新增一个 `Controls/<Control>.xaml`、`Themes/Shared/<Control>.xaml`、`Themes/Light/<Control>.xaml` 或 `Themes/Dark/<Control>.xaml`，都必须加入对应目录的 `_index.xaml`。

## 资源分层与加载顺序

资源依赖方向固定如下：

```text
Tokens/Variables + Tokens/Palette
              ↓
Themes/Shared + Themes/Light 或 Themes/Dark
              ↓
Controls
              ↓
应用与 Demo
```

`SemiTheme` 必须先加载令牌，再加载 Shared 和当前主题的语义资源，最后加载控件样式。控件样式应使用 `{DynamicResource ...}` 读取会随主题变化的画刷；无需随主题变化的固定样式基类可使用 `{StaticResource ...}`。

主题资源中应通过 `ResourceAlias` 将控件语义键绑定到全局令牌，例如：

```xml
<local:ResourceAlias x:Key="TextBlockSecondaryForeground" ResourceKey="SemiColorText1" />
```

Avalonia 中以下带键资源转发写法不能直接照搬到 WPF：

```xml
<StaticResource x:Key="NotificationCardLightBackground" ResourceKey="SemiColorBackground0" />
```

在 WPF 中必须改为：

```xml
<local:ResourceAlias x:Key="NotificationCardLightBackground" ResourceKey="SemiColorBackground0" />
```

资源键（这里的 `NotificationCardLightBackground` 和 `SemiColorBackground0`）必须完全沿用 Semi.Avalonia 原始仓库的名称；迁移时只替换 WPF 不支持的资源表达方式，不得重命名资源键。

不要将 `SemiColorText1` 直接写入 `Controls/TextBlock.xaml`。这样可在不修改控件模板的前提下替换 Light/Dark 映射。`ResourceAlias` 由 `SemiTheme` 在资源字典合并完成后解析，故主题字典只能由 `SemiTheme` 这一正式入口加载。

## Avalonia 到 WPF 的映射

| Avalonia 概念 | WPF 实现 |
| --- | --- |
| `ControlTheme` | `Style`；默认 `ControlTheme` 翻译为隐式样式，键使用 `{x:Type ControlType}`；具名 `ControlTheme` 翻译为同名具名样式 |
| `BasedOn` 控件主题 | `Style BasedOn` |
| `.Secondary` 等 class selector | `Classes` 附加布尔属性和 `Trigger` |
| `:disabled` | `Trigger Property="IsEnabled" Value="False"` |
| 组合 selector，例如 `.Underline.Delete` | `MultiTrigger` |
| `ResourceInclude` | `ResourceDictionary Source` |
| ThemeDictionaries | `SemiTheme.Theme` 重新合并 Light/Dark 字典 |

`Classes` 仅用于表达 Semi 的视觉变体，如 `Secondary`、`Danger`、`H1`。新增或删除 class 时，必须同时修改 `Attached/Classes.linq` 中的 `names` 列表，并重新生成、提交 `Attached/Classes.cs`；`Classes.linq` 是附加属性列表的源文件。它不是 WPF 控件状态的替代品：禁用、悬停、焦点、选中、按下等状态必须优先使用原生 WPF 属性和触发器。

### XAML 值语法转换

迁移时保留 Avalonia 的资源键、颜色和视觉语义，但必须转换 WPF 不支持的值语法。例如 Avalonia 渐变画刷的百分比坐标：

```xml
StartPoint="99%,93%" EndPoint="1%,7%"
```

在 WPF 中必须写为等价的小数坐标：

```xml
StartPoint="0.99,0.93" EndPoint="0.01,0.07"
```

仅执行 `dotnet build` 不足以验证所有延迟加载的资源值。涉及资源字典、画刷、转换器或主题切换的迁移，必须启动 Demo 并至少加载受影响的主题和控件，确保不会在 `SemiTheme.SetRef` 解析资源时发生 `XamlParseException`。

## 标准控件迁移流程

1. 在 Avalonia 源码中定位 `Controls/<Control>.axaml`，以及 `Themes/Shared`、`Themes/Light`、`Themes/Dark` 下的同名资源；同时检查其 Demo 页面。
2. 列出源实现的公开样式键、状态、变体 class、模板部件和所用资源键。确认哪些是 WPF 原生控件能力，哪些需要新增控件或附加属性。
3. 先迁移缺失的全局令牌；随后建立 `<Control>` 的 Shared、Light、Dark 语义资源。资源键沿用源项目名称，除非 WPF 平台差异要求另行命名。
4. 创建 `Controls/<Control>.xaml`：先写隐式基础样式，再写具名变体样式；样式内不得硬编码颜色、字号、圆角和间距。
5. 将新字典加入三个主题 `_index.xaml` 和 `Controls/_index.xaml`，确保 `SemiTheme` 能完整加载它们。
6. 在 Demo 增加单独页面或扩展示例，至少覆盖默认样式、每个公开变体、关键交互状态、Light 与 Dark。
7. 运行构建，并手工运行 Demo 验证资源解析、主题切换和关键状态。

## TextBlock 范式

TextBlock 是首个完整迁移样例。其实现不是重新设计 WPF 文本样式，而是将 Semi.Avalonia 中 `Controls/TextBlock.axaml` 及对应 Shared、Light、Dark 主题资源逐项翻译为 WPF 的资源字典、样式和触发器：保留原有资源键、变体语义和视觉结果，仅替换 Avalonia 平台专属的 XAML 和状态表达方式。

- `Controls/TextBlock.xaml` 提供隐式 `TextBlock` 样式，以及基于它的 `TitleTextBlock`。
- `Secondary`、`Tertiary`、`Quaternary`、`Success`、`Warning`、`Danger`、`Mark`、`Underline`、`Delete` 使用 `Classes` 附加属性触发。
- `H1` 至 `H6` 在 `TitleTextBlock` 中选择标题字号；标题字重来自 `TextBlockTitleFontWeight`。
- `Themes/Shared/TextBlock.xaml` 提供字号、字重、代码文本等共享资源；Light/Dark 同名字典提供前景色、标记背景和选择色映射。
- `demo/Semi.WpfUi.Demo/Pages/TextBlockDemo.xaml` 是迁移行为的最小验收样例。

后续控件应遵循这一拆分，而不是把全部 Setter、色值和主题分支集中在单个控件字典中。

TextBlock 还有两项待保持的正确性要求，其他控件同样适用：

- 禁用样式应以 `IsEnabled="False"` 触发；`Classes.Disabled` 只能作为明确的视觉变体，不能替代真实禁用状态。
- 多个文本装饰必须用 `MultiTrigger` 设置一个包含 Underline 与 Strikethrough 的 `TextDecorationCollection`，不能依赖多个 Trigger 对同一属性的覆盖顺序。

## 命名与 XAML 约定

- 公共资源键、样式键和附加属性使用 PascalCase。
- 全局设计令牌使用 `Semi...` 前缀，例如 `SemiColorText0`、`SemiFontSizeRegular`。
- 控件语义资源使用 `<Control><Role>`，例如 `TextBlockWarningForeground`。
- 控件具名样式采用描述性名称，例如 `TitleTextBlock`、`SemiButtonPrimary`。
- 迁移资源键时必须保持与 Semi.Avalonia 原始仓库完全一致；仅在 WPF 不支持原有 XAML 语法时，替换为等价的 WPF 表达方式，例如 `ResourceAlias`。
- 一个控件对应一个 `Controls/<Control>.xaml`，不要为单一控件创建跨文件的临时样式片段。
- 保留周边文件的四空格缩进和 XAML 属性排列方式。

## 验收清单

- [ ] Avalonia 的公开变体、关键状态和必要资源均已盘点。
- [ ] Light、Dark、Shared 资源已实现并已加入索引。
- [ ] 控件样式已加入 `Controls/_index.xaml`。
- [ ] 样式不包含硬编码的设计色、尺寸、圆角或间距。
- [ ] 原生状态使用 WPF 属性或模板触发器，组合状态使用 `MultiTrigger`。
- [ ] Demo 覆盖默认、变体、关键状态和双主题。
- [ ] `dotnet build Semi.WpfUi.sln` 通过。
- [ ] 已运行 Demo 并验证 Light/Dark 切换和受影响控件。

## 常用命令

```powershell
dotnet restore Semi.WpfUi.sln
dotnet build Semi.WpfUi.sln
dotnet build Semi.WpfUi.sln -c Release
dotnet run --project demo/Semi.WpfUi.Demo
dotnet test Semi.WpfUi.sln
```
