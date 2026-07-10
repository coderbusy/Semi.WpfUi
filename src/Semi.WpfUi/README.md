# Semi.WpfUi

A WPF control theme library implementing [Semi Design](https://semi.design/), inspired by [Semi.Avalonia](https://github.com/irihitech/Semi.Avalonia).

## Features

- **Semi Design** color system — full palette with semantic tokens
- **Light and Dark themes** — easy runtime switching
- **Styled WPF controls**: Button, TextBox, CheckBox, RadioButton, ComboBox, ListBox, ProgressBar, Slider, TabControl, ToggleButton
- **Design tokens** — spacing, typography, border-radius values matching the Semi Design spec

## Project Structure

```
src/
  Semi.WpfUi/           ← Main theme library
    Controls/           ← Control styles (Button, TextBox, …)
    Themes/
      Light/            ← Semantic light-theme tokens
      Dark/             ← Semantic dark-theme tokens
    Tokens/
      Palette/          ← Raw color palette (Light / Dark)
      Variables.xaml    ← Sizing, spacing, typography tokens
    SemiTheme.cs        ← Theme entry-point class
demo/
  Semi.WpfUi.Demo/      ← WPF demo application
```

## Getting Started

1. Reference `Semi.WpfUi` in your WPF project.
2. In `App.xaml`, merge the `SemiTheme` resource dictionary:

```xml
<Application xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:semi="clr-namespace:Semi.WpfUi;assembly=Semi.WpfUi">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <!-- Use Theme="Light" or Theme="Dark" -->
                <semi:SemiTheme Theme="Light" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

3. All WPF controls in your application will automatically pick up the Semi Design styles.

### Switching Themes at Runtime

```csharp
var semiTheme = Application.Current.Resources.MergedDictionaries
    .OfType<SemiTheme>()
    .FirstOrDefault();

if (semiTheme is not null)
    semiTheme.Theme = SemiThemeMode.Dark;
```

## Named Button Styles

In addition to the implicit `Button` style, you can explicitly reference:

| Style Key              | Appearance         |
|------------------------|--------------------|
| `SemiButton`           | Default (outlined) |
| `SemiButtonPrimary`    | Blue filled        |
| `SemiButtonDanger`     | Red filled         |
| `SemiButtonLight`      | Blue tinted        |

```xml
<Button Style="{StaticResource SemiButtonPrimary}" Content="Save" />
```

## Semantic Color Keys

| Key                    | Usage              |
|------------------------|--------------------|
| `SemiColorBg0`         | Background         |
| `SemiColorText0`       | Primary text       |
| `SemiColorPrimary`     | Brand / action     |
| `SemiColorSuccess`     | Positive feedback  |
| `SemiColorWarning`     | Caution            |
| `SemiColorDanger`      | Destructive action |
| `SemiColorBorder`      | Default border     |

## License

MIT — see [LICENSE](LICENSE).
