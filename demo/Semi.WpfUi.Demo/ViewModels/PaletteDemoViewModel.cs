using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Semi.WpfUi.Tokens.Palette;

namespace Semi.WpfUi.Demo.ViewModels;

public partial class PaletteDemoViewModel : ObservableObject
{
    public PaletteDemoViewModel()
    {
        LightColors = LoadBasicColors(new Light(), true);
        DarkColors = LoadBasicColors(new Dark(), false);
        FunctionalColors = LoadFunctionalColors(new Light());
    }

    public ObservableCollection<ColorToken> LightColors { get; }
    public ObservableCollection<ColorToken> DarkColors { get; }
    public ObservableCollection<ColorGroup> FunctionalColors { get; }
    [ObservableProperty] private ColorToken? _selectedColor;
    public Visibility SelectedColorVisibility => SelectedColor is null ? Visibility.Collapsed : Visibility.Visible;
    partial void OnSelectedColorChanged(ColorToken? value) => OnPropertyChanged(nameof(SelectedColorVisibility));
    [RelayCommand] private static void Copy(string? text) { if (!string.IsNullOrEmpty(text)) Clipboard.SetText(text); }

    private static ObservableCollection<ColorToken> LoadBasicColors(ResourceDictionary dictionary, bool light)
    {
        var result = new ObservableCollection<ColorToken>();
        foreach (var name in new[] { "Red", "Pink", "Purple", "Blue", "Cyan", "Green", "Yellow", "Orange", "Grey" }) for (var i = 0; i < 10; i++) Add(result, dictionary, $"Semi{name}{i}", $"{name} {i}", light, i);
        return result;
    }
    private static ObservableCollection<ColorGroup> LoadFunctionalColors(ResourceDictionary dictionary)
    {
        var result = new ObservableCollection<ColorGroup>();
        foreach (var group in new[] { "Primary", "Secondary", "Tertiary", "Information", "Success", "Warning", "Danger", "Text", "Background", "Fill", "Border", "Disabled" })
        {
            var colors = new ObservableCollection<ColorToken>();
            foreach (var suffix in new[] { "", "Pointerover", "Active", "Disabled", "Light", "LightPointerover", "LightActive" }) Add(colors, dictionary, $"SemiColor{group}{suffix}", suffix.Length == 0 ? group : $"{group} {suffix}", true, 0);
            if (colors.Count > 0) result.Add(new ColorGroup(group, colors));
        }
        return result;
    }
    private static void Add(ICollection<ColorToken> target, ResourceDictionary dictionary, string key, string name, bool light, int index)
    {
        if (dictionary[key] is SolidColorBrush brush) target.Add(new ColorToken(name, key, brush, (light && index < 5) || (!light && index >= 5) ? Brushes.Black : Brushes.White));
    }
}

public sealed class ColorGroup(string name, ObservableCollection<ColorToken> colors) { public string Name { get; } = name; public ObservableCollection<ColorToken> Colors { get; } = colors; }
public sealed class ColorToken(string name, string resourceKey, SolidColorBrush brush, Brush textBrush)
{
    public string Name { get; } = name; public string ResourceKey { get; } = resourceKey; public SolidColorBrush Brush { get; } = brush; public Brush TextBrush { get; } = textBrush;
    public string Hex => $"#{Brush.Color.R:X2}{Brush.Color.G:X2}{Brush.Color.B:X2}"; public string CopyText => $"{{DynamicResource {ResourceKey}}}";
}
