using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Semi.WpfUi.Demo.Pages;

public partial class HyperlinkButtonDemo : UserControl
{
    public static readonly RoutedUICommand MarkCommand = new("Mark command", nameof(MarkCommand), typeof(HyperlinkButtonDemo));

    public HyperlinkButtonDemo()
    {
        InitializeComponent();
    }

    private void MarkCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        CommandStatusText.Text = e.Parameter as string ?? "Command executed";
    }
}
