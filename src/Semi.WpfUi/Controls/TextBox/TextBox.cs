using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Semi.WpfUi.Controls;

public class TextBox : System.Windows.Controls.TextBox
{
    public static readonly DependencyProperty InnerLeftContentProperty = DependencyProperty.Register(
        nameof(InnerLeftContent), typeof(object), typeof(TextBox), new FrameworkPropertyMetadata(null));

    public static readonly DependencyProperty InnerRightContentProperty = DependencyProperty.Register(
        nameof(InnerRightContent), typeof(object), typeof(TextBox), new FrameworkPropertyMetadata(null));


    public static readonly DependencyProperty PlaceholderTextProperty = DependencyProperty.Register(
        nameof(PlaceholderText), typeof(string), typeof(TextBox), new PropertyMetadata(default(string)));

    public static readonly DependencyProperty PlaceholderForegroundPropertyProperty =
        DependencyProperty.Register(nameof(PlaceholderForegroundProperty), typeof(Brush), typeof(TextBox), new PropertyMetadata(SystemColors.GrayTextBrush));

    public Brush PlaceholderForegroundProperty
    {
        get { return (Brush)GetValue(PlaceholderForegroundPropertyProperty); }
        set { SetValue(PlaceholderForegroundPropertyProperty, value); }
    }

    public string PlaceholderText
    {
        get => (string)GetValue(PlaceholderTextProperty);
        set => SetValue(PlaceholderTextProperty, value);
    }

    public object? InnerLeftContent
    {
        get => GetValue(InnerLeftContentProperty);
        set => SetValue(InnerLeftContentProperty, value);
    }

    public object? InnerRightContent
    {
        get => GetValue(InnerRightContentProperty);
        set => SetValue(InnerRightContentProperty, value);
    }
}
