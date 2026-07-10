using System.Windows.Controls;
using Semi.WpfUi.Demo.ViewModels;

namespace Semi.WpfUi.Demo.Pages;

public partial class TabControlDemo : UserControl
{
    public TabControlDemo()
    {
        InitializeComponent();
        DataContext = new TabControlDemoViewModel();
    }
}
