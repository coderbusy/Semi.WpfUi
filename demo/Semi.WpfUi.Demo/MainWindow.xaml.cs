using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Semi.WpfUi.Demo.Pages;

namespace Semi.WpfUi.Demo;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private readonly SemiTheme? _semiTheme;
    private NavigationItem? _selectedItem;

    public MainWindow()
    {
        InitializeComponent();
        _semiTheme = Application.Current.Resources.MergedDictionaries.OfType<SemiTheme>().FirstOrDefault();

        NavigationItems =
        [
            new("Overview", "Overview", "⌂", "Get started with Semi WPF", new OverviewPage()),
            new("Foundation", "Typography & Colors", "Aa", "Text styles and semantic tokens", new FoundationPage()),
            new("Foundation", "TextBlock", "T", "Text styles and semantic classes", new TextBlockDemo()),
            new("Foundation", "Variables", "#", "Sizing, spacing and radius tokens", new VariablesDemo()),
            new("Foundation", "Palette", "●", "Semantic color resources", new PaletteDemo()),
            new("Controls", "Buttons & Selection", "✓", "Actions and choice controls", new ControlsPage()),
            new("Controls", "Inputs & Feedback", "◌", "Forms, progress and content", new InputPage()),
        ];
        NavigationView = CollectionViewSource.GetDefaultView(NavigationItems);
        NavigationView.GroupDescriptions.Add(new PropertyGroupDescription(nameof(NavigationItem.Section)));
        NavigationView.Filter = FilterNavigation;
        DataContext = this;
        NavigationList.SelectedIndex = 0;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<NavigationItem> NavigationItems { get; }
    public ICollectionView NavigationView { get; }
    public UserControl? SelectedPage => _selectedItem?.Page;
    public string SelectedPageTitle => _selectedItem?.Title ?? "Overview";

    private bool FilterNavigation(object item)
    {
        if (item is not NavigationItem navigationItem) return false;
        var search = SearchBox?.Text?.Trim();
        return string.IsNullOrEmpty(search) ||
               navigationItem.Title.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               navigationItem.Section.Contains(search, StringComparison.OrdinalIgnoreCase);
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e) => NavigationView.Refresh();

    private void OnNavigationSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (NavigationList.SelectedItem is not NavigationItem item) return;
        _selectedItem = item;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedPage)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedPageTitle)));
    }

    private void OnLightThemeClick(object sender, RoutedEventArgs e) => SetTheme(SemiThemeMode.Light);
    private void OnDarkThemeClick(object sender, RoutedEventArgs e) => SetTheme(SemiThemeMode.Dark);

    private void SetTheme(SemiThemeMode theme)
    {
        if (_semiTheme is not null) _semiTheme.Theme = theme;
    }
}

public sealed record NavigationItem(
    string Section,
    string Title,
    string Icon,
    string Description,
    UserControl Page);
