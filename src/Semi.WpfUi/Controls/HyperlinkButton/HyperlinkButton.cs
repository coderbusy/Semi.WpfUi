using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Semi.WpfUi.Controls;

public class HyperlinkButton : Button
{
    public static readonly DependencyProperty NavigateUriProperty = DependencyProperty.Register(
        nameof(NavigateUri),
        typeof(Uri),
        typeof(HyperlinkButton));

    public static readonly DependencyProperty IsVisitedProperty = DependencyProperty.Register(
        nameof(IsVisited),
        typeof(bool),
        typeof(HyperlinkButton),
        new FrameworkPropertyMetadata(false));

    public Uri? NavigateUri
    {
        get => (Uri?)GetValue(NavigateUriProperty);
        set => SetValue(NavigateUriProperty, value);
    }

    public bool IsVisited
    {
        get => (bool)GetValue(IsVisitedProperty);
        set => SetValue(IsVisitedProperty, value);
    }

    protected override void OnClick()
    {
        base.OnClick();

        if (NavigateUri is null)
        {
            return;
        }

        try
        {
            Process.Start(new ProcessStartInfo(NavigateUri.AbsoluteUri)
            {
                UseShellExecute = true,
            });
            IsVisited = true;
        }
        catch (InvalidOperationException)
        {
            // The URI could not be opened by the current operating system.
        }
        catch (System.ComponentModel.Win32Exception)
        {
            // No registered application is available to handle the URI.
        }
    }
}
