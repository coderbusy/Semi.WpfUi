using System.Linq;
using System.Windows;

namespace Semi.WpfUi.Demo;

public partial class MainWindow : Window
{
    private SemiTheme? _semiTheme;

    public MainWindow()
    {
        InitializeComponent();
        _semiTheme = Application.Current.Resources.MergedDictionaries
            .OfType<SemiTheme>()
            .FirstOrDefault();
    }

    private void OnLightThemeClick(object sender, RoutedEventArgs e)
    {
        if (_semiTheme is not null)
            _semiTheme.Theme = SemiThemeMode.Light;
    }

    private void OnDarkThemeClick(object sender, RoutedEventArgs e)
    {
        if (_semiTheme is not null)
            _semiTheme.Theme = SemiThemeMode.Dark;
    }
}
