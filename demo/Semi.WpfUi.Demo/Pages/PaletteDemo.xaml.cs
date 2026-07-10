using System.Windows;
using System.Windows.Controls;
using Semi.WpfUi.Demo.ViewModels;

namespace Semi.WpfUi.Demo.Pages;

public partial class PaletteDemo : UserControl
{
    private readonly PaletteDemoViewModel _viewModel = new();
    public PaletteDemo()
    {
        InitializeComponent();
        DataContext = _viewModel;
    }

    private void OnColorSelected(object sender, SelectionChangedEventArgs e)
    {
        if (((ListBox)sender).SelectedItem is ColorToken token) _viewModel.SelectedColor = token;
    }

    private void OnCopyClick(object sender, RoutedEventArgs e) => _viewModel.CopyCommand.Execute(((Button)sender).Tag);
}
