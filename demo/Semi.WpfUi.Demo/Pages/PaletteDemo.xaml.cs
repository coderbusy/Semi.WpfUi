using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Semi.WpfUi.Tokens.Palette;

namespace Semi.WpfUi.Demo.Pages;

public partial class PaletteDemo : UserControl, INotifyPropertyChanged
{
    private ColorToken? _selectedColor;

    public PaletteDemo()
    {
        InitializeComponent();
        LightColors = LoadBasicColors(new Light(), true);
        DarkColors = LoadBasicColors(new Dark(), false);
        FunctionalColors = LoadFunctionalColors(new Light());
        DataContext = this;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public ObservableCollection<ColorToken> LightColors { get; }
    public ObservableCollection<ColorToken> DarkColors { get; }
    public ObservableCollection<ColorGroup> FunctionalColors { get; }
    public ColorToken? SelectedColor { get => _selectedColor; private set { _selectedColor = value; PropertyChanged?.Invoke(this, new(nameof(SelectedColor))); PropertyChanged?.Invoke(this, new(nameof(SelectedColorVisibility))); } }
    public Visibility SelectedColorVisibility => SelectedColor is null ? Visibility.Collapsed : Visibility.Visible;

    private void OnColorSelected(object sender, SelectionChangedEventArgs e)
    {
        if (((ListBox)sender).SelectedItem is ColorToken token) SelectedColor = token;
    }

    private void OnCopyClick(object sender, RoutedEventArgs e)
    {
        if (((Button)sender).Tag is string text) Clipboard.SetText(text);
    }

    private static ObservableCollection<ColorToken> LoadBasicColors(ResourceDictionary dictionary, bool light)
    {
        var result = new ObservableCollection<ColorToken>();
        foreach (var name in new[] { "Red", "Pink", "Purple", "Blue", "Cyan", "Green", "Yellow", "Orange", "Grey" })
            for (var i = 0; i < 10; i++) Add(result, dictionary, $"Semi{name}{i}", $"{name} {i}", light, i);
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
        if (dictionary[key] is not SolidColorBrush brush) return;
        target.Add(new ColorToken(name, key, brush, (light && index < 5) || (!light && index >= 5) ? Brushes.Black : Brushes.White));
    }
}

public sealed class ColorGroup(string name, ObservableCollection<ColorToken> colors) { public string Name { get; } = name; public ObservableCollection<ColorToken> Colors { get; } = colors; }
public sealed class ColorToken(string name, string resourceKey, SolidColorBrush brush, Brush textBrush)
{
    public string Name { get; } = name; public string ResourceKey { get; } = resourceKey; public SolidColorBrush Brush { get; } = brush; public Brush TextBrush { get; } = textBrush;
    public string Hex => $"#{Brush.Color.R:X2}{Brush.Color.G:X2}{Brush.Color.B:X2}";
    public string CopyText => $"{{DynamicResource {ResourceKey}}}";
}
