using System;
using System.Windows;
using System.Windows.Media;

namespace Semi.WpfUi.Attached;

public static class ResCopy
{
    public static readonly DependencyProperty FromProperty = DependencyProperty.RegisterAttached(
        "From", typeof(object), typeof(ResCopy), new PropertyMetadata(null, OnFromChanged));

    private static void OnFromChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is SolidColorBrush brush)
        {
            if (e.NewValue is SolidColorBrush originalBrush)
            {
                brush.Color = originalBrush.Color;
            }
        }
    }

    public static void SetFrom(DependencyObject element, object value)
        => element.SetValue(FromProperty, value);

    public static object GetFrom(DependencyObject element)
        => element.GetValue(FromProperty);
}
