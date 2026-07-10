using System.Windows;
using Semi.WpfUi.Demo.ViewModels;

namespace Semi.WpfUi.Demo;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}
