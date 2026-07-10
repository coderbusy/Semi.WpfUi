# Repository Guidelines

## Project Structure & Module Organization

`Semi.WpfUi.sln` contains the theme library and its demonstration app. Production code is in `src/Semi.WpfUi/`: `Controls/` holds control resource dictionaries, `Tokens/` defines palette and sizing resources, and `Themes/Light` and `Themes/Dark` provide semantic theme values. `SemiTheme.cs` is the public resource-dictionary entry point. `demo/Semi.WpfUi.Demo/` is the WPF app used to exercise and showcase the library. Keep usage documentation in `src/Semi.WpfUi/README.md` alongside the packaged project.

## Build, Test, and Development Commands

Run commands from the repository root:

```powershell
dotnet restore Semi.WpfUi.sln       # restore dependencies
dotnet build Semi.WpfUi.sln         # build library and demo (Debug)
dotnet build Semi.WpfUi.sln -c Release
dotnet run --project demo/Semi.WpfUi.Demo
dotnet test Semi.WpfUi.sln          # runs tests when test projects are added
```

The library targets `net8.0-windows` and `net9.0-windows`; the demo targets `net8.0-windows`. WPF commands may require Windows or Windows targeting support.

## Coding Style & Naming Conventions

Use four spaces for C# indentation and the existing file-scoped namespace style. Enable nullable-safe code: use `?` for nullable references and guard values before use. Name public types, methods, properties, enums, and XAML resource keys in PascalCase; use `_camelCase` for private fields (for example, `_semiTheme`). Follow the existing XAML organization: one control dictionary per `Controls/<Control>.xaml`, aggregate through `_index.xaml`, and use descriptive `Semi...` resource keys such as `SemiButtonPrimary`. No formatter or linter is currently configured; preserve the surrounding formatting.

## Testing Guidelines

There is currently no automated test project or coverage threshold. Before submitting UI changes, build the solution and run the demo to verify both Light and Dark themes, resource dictionary loading, and affected controls. Add focused test projects for non-visual C# behavior when introducing logic; name tests after the behavior, such as `Theme_WhenSetToDark_LoadsDarkResources`.

## Commit & Pull Request Guidelines

History uses short, imperative, sentence-style subjects (for example, `Add Semi.WpfUi WPF theme library implementing Semi Design`). Keep commits scoped and describe the user-visible change. Pull requests should explain the affected controls or tokens, link relevant issues, note verification commands, and include screenshots for visual changes in both themes when applicable.
