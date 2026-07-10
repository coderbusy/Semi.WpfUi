using System.Windows.Controls;
using Semi.WpfUi.Demo.ViewModels;

namespace Semi.WpfUi.Demo.Pages;

public partial class VariablesDemo : UserControl
{
    public VariablesDemo()
    {
        InitializeComponent();
        DataContext = new VariablesDemoViewModel();
    }
}
