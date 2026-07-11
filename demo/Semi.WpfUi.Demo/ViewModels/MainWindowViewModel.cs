using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Semi.WpfUi.Demo.Pages;

namespace Semi.WpfUi.Demo.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly SemiTheme? _semiTheme;

    public MainWindowViewModel()
    {
        _semiTheme = Application.Current.Resources.MergedDictionaries.OfType<SemiTheme>().FirstOrDefault();
        NavigationItems =
        [
            new("Overview", "Overview", "⌂", "Get started with Semi WPF", new OverviewPage()),
            new("Foundation", "Typography & Colors", "Aa", "Text styles and semantic tokens", new FoundationPage()),
            new("Foundation", "TextBlock", "T", "Text styles and semantic classes", new TextBlockDemo()),
            new("Foundation", "Variables", "#", "Sizing, spacing and radius tokens", new VariablesDemo()),
            new("Foundation", "Palette", "●", "Semantic color resources", new PaletteDemo()),
            new("Controls", "Button", "●", "Light, solid, outline and borderless button themes", new ButtonDemo()),
            new("Controls", "CheckBox", "✓", "Checked, indeterminate, disabled, and focus states", new CheckBoxDemo()),
            new("Controls", "GroupBox", "▣", "Card-style grouped content with headers and separators", new GroupBoxDemo()),
            new("Controls", "Border", "□", "CardBorder with default, elevated and hover shadow variants", new BorderDemo()),
            new("Controls", "TabControl", "⊏", "Line, card and button tab themes with placement switching", new TabControlDemo()),
            new("Controls", "Buttons & Selection", "✓", "Actions and choice controls", new ControlsPage()),
            new("Controls", "Inputs & Feedback", "◌", "Forms, progress and content", new InputPage()),
        ];
        NavigationView = CollectionViewSource.GetDefaultView(NavigationItems);
        NavigationView.GroupDescriptions.Add(new PropertyGroupDescription(nameof(NavigationItem.Section)));
        NavigationView.Filter = FilterNavigation;
        SelectedItem = NavigationItems[0];
    }

    public ObservableCollection<NavigationItem> NavigationItems { get; }
    public ICollectionView NavigationView { get; }
    [ObservableProperty] private string _searchText = string.Empty;
    [ObservableProperty] private NavigationItem? _selectedItem;
    public UserControl? SelectedPage => SelectedItem?.Page;
    public string SelectedPageTitle => SelectedItem?.Title ?? "Overview";

    partial void OnSearchTextChanged(string value) => NavigationView.Refresh();
    partial void OnSelectedItemChanged(NavigationItem? value)
    {
        OnPropertyChanged(nameof(SelectedPage));
        OnPropertyChanged(nameof(SelectedPageTitle));
    }

    [RelayCommand] private void SetLightTheme() => SetTheme(SemiThemeMode.Light);
    [RelayCommand] private void SetDarkTheme() => SetTheme(SemiThemeMode.Dark);
    private void SetTheme(SemiThemeMode theme) { if (_semiTheme is not null) _semiTheme.Theme = theme; }
    private bool FilterNavigation(object item) => item is NavigationItem navigationItem && (string.IsNullOrWhiteSpace(SearchText) || navigationItem.Title.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || navigationItem.Section.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
}

public sealed record NavigationItem(string Section, string Title, string Icon, string Description, UserControl Page);
