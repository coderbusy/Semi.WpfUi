using System;
using System.Windows;

namespace Semi.WpfUi;

/// <summary>
/// The Semi Design WPF theme. Merge this ResourceDictionary into your application resources to apply the theme.
/// </summary>
/// <remarks>
/// Usage in App.xaml:
/// <code>
/// &lt;Application.Resources&gt;
///   &lt;ResourceDictionary&gt;
///     &lt;ResourceDictionary.MergedDictionaries&gt;
///       &lt;semi:SemiTheme Theme="Light" /&gt;
///     &lt;/ResourceDictionary.MergedDictionaries&gt;
///   &lt;/ResourceDictionary&gt;
/// &lt;/Application.Resources&gt;
/// </code>
/// </remarks>
public class SemiTheme : ResourceDictionary
{
    private SemiThemeMode _theme = SemiThemeMode.Light;

    /// <summary>
    /// Gets or sets the active theme mode (Light or Dark).
    /// </summary>
    public SemiThemeMode Theme
    {
        get => _theme;
        set
        {
            _theme = value;
            UpdateTheme();
        }
    }

    public SemiTheme()
    {
        UpdateTheme();
    }

    private void UpdateTheme()
    {
        MergedDictionaries.Clear();

        // Apply semantic color tokens for the selected theme
        var semanticColors = new ResourceDictionary
        {
            Source = _theme == SemiThemeMode.Dark
                ? new Uri("pack://application:,,,/Semi.WpfUi;component/Themes/Dark/_index.xaml", UriKind.Absolute)
                : new Uri("pack://application:,,,/Semi.WpfUi;component/Themes/Light/_index.xaml", UriKind.Absolute)
        };
        MergedDictionaries.Add(semanticColors);

        // Apply sizing/spacing/typography tokens
        MergedDictionaries.Add(new ResourceDictionary
        {
            Source = new Uri("pack://application:,,,/Semi.WpfUi;component/Tokens/Variables.xaml", UriKind.Absolute)
        });

        // Apply control styles
        MergedDictionaries.Add(new ResourceDictionary
        {
            Source = new Uri("pack://application:,,,/Semi.WpfUi;component/Controls/_index.xaml", UriKind.Absolute)
        });
    }
}

/// <summary>
/// Specifies the theme mode for the Semi WPF UI theme.
/// </summary>
public enum SemiThemeMode
{
    /// <summary>Light theme.</summary>
    Light,
    /// <summary>Dark theme.</summary>
    Dark
}
