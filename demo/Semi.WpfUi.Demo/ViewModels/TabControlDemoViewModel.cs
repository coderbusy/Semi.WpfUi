using System.Collections.ObjectModel;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Semi.WpfUi.Demo.ViewModels;

public partial class TabControlDemoViewModel : ObservableObject
{
    public TabControlDemoViewModel()
    {
        Placements =
        [
            Dock.Top,
            Dock.Bottom,
            Dock.Left,
            Dock.Right
        ];
    }

    public ObservableCollection<Dock> Placements { get; }

    [ObservableProperty]
    private Dock _selectedPlacement = Dock.Top;
}
