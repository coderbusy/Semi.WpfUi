using Semi.WpfUi.Data;
using System.Windows;

namespace Semi.WpfUi.Attached;

public class Classes
{

    public static readonly DependencyProperty PrimaryProperty = DependencyProperty.RegisterAttached(
        "Primary", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetPrimary(DependencyObject element, bool value)
        => element.SetValue(PrimaryProperty, ValueBoxes.BooleanBox(value));

    public static bool GetPrimary(DependencyObject element)
        => (bool)element.GetValue(PrimaryProperty);


    public static readonly DependencyProperty SecondaryProperty = DependencyProperty.RegisterAttached(
        "Secondary", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetSecondary(DependencyObject element, bool value)
        => element.SetValue(SecondaryProperty, ValueBoxes.BooleanBox(value));

    public static bool GetSecondary(DependencyObject element)
        => (bool)element.GetValue(SecondaryProperty);


    public static readonly DependencyProperty TertiaryProperty = DependencyProperty.RegisterAttached(
        "Tertiary", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetTertiary(DependencyObject element, bool value)
        => element.SetValue(TertiaryProperty, ValueBoxes.BooleanBox(value));

    public static bool GetTertiary(DependencyObject element)
        => (bool)element.GetValue(TertiaryProperty);


    public static readonly DependencyProperty QuaternaryProperty = DependencyProperty.RegisterAttached(
        "Quaternary", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetQuaternary(DependencyObject element, bool value)
        => element.SetValue(QuaternaryProperty, ValueBoxes.BooleanBox(value));

    public static bool GetQuaternary(DependencyObject element)
        => (bool)element.GetValue(QuaternaryProperty);


    public static readonly DependencyProperty SuccessProperty = DependencyProperty.RegisterAttached(
        "Success", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetSuccess(DependencyObject element, bool value)
        => element.SetValue(SuccessProperty, ValueBoxes.BooleanBox(value));

    public static bool GetSuccess(DependencyObject element)
        => (bool)element.GetValue(SuccessProperty);


    public static readonly DependencyProperty WarningProperty = DependencyProperty.RegisterAttached(
        "Warning", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetWarning(DependencyObject element, bool value)
        => element.SetValue(WarningProperty, ValueBoxes.BooleanBox(value));

    public static bool GetWarning(DependencyObject element)
        => (bool)element.GetValue(WarningProperty);


    public static readonly DependencyProperty DangerProperty = DependencyProperty.RegisterAttached(
        "Danger", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetDanger(DependencyObject element, bool value)
        => element.SetValue(DangerProperty, ValueBoxes.BooleanBox(value));

    public static bool GetDanger(DependencyObject element)
        => (bool)element.GetValue(DangerProperty);


    public static readonly DependencyProperty MarkProperty = DependencyProperty.RegisterAttached(
        "Mark", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetMark(DependencyObject element, bool value)
        => element.SetValue(MarkProperty, ValueBoxes.BooleanBox(value));

    public static bool GetMark(DependencyObject element)
        => (bool)element.GetValue(MarkProperty);


    public static readonly DependencyProperty UnderlineProperty = DependencyProperty.RegisterAttached(
        "Underline", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetUnderline(DependencyObject element, bool value)
        => element.SetValue(UnderlineProperty, ValueBoxes.BooleanBox(value));

    public static bool GetUnderline(DependencyObject element)
        => (bool)element.GetValue(UnderlineProperty);


    public static readonly DependencyProperty DeleteProperty = DependencyProperty.RegisterAttached(
        "Delete", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetDelete(DependencyObject element, bool value)
        => element.SetValue(DeleteProperty, ValueBoxes.BooleanBox(value));

    public static bool GetDelete(DependencyObject element)
        => (bool)element.GetValue(DeleteProperty);


    public static readonly DependencyProperty DisabledProperty = DependencyProperty.RegisterAttached(
        "Disabled", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetDisabled(DependencyObject element, bool value)
        => element.SetValue(DisabledProperty, ValueBoxes.BooleanBox(value));

    public static bool GetDisabled(DependencyObject element)
        => (bool)element.GetValue(DisabledProperty);


    public static readonly DependencyProperty ColorfulProperty = DependencyProperty.RegisterAttached(
        "Colorful", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetColorful(DependencyObject element, bool value)
        => element.SetValue(ColorfulProperty, ValueBoxes.BooleanBox(value));

    public static bool GetColorful(DependencyObject element)
        => (bool)element.GetValue(ColorfulProperty);


    public static readonly DependencyProperty LargeProperty = DependencyProperty.RegisterAttached(
        "Large", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetLarge(DependencyObject element, bool value)
        => element.SetValue(LargeProperty, ValueBoxes.BooleanBox(value));

    public static bool GetLarge(DependencyObject element)
        => (bool)element.GetValue(LargeProperty);


    public static readonly DependencyProperty SmallProperty = DependencyProperty.RegisterAttached(
        "Small", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetSmall(DependencyObject element, bool value)
        => element.SetValue(SmallProperty, ValueBoxes.BooleanBox(value));

    public static bool GetSmall(DependencyObject element)
        => (bool)element.GetValue(SmallProperty);


    public static readonly DependencyProperty H1Property = DependencyProperty.RegisterAttached(
        "H1", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetH1(DependencyObject element, bool value)
        => element.SetValue(H1Property, ValueBoxes.BooleanBox(value));

    public static bool GetH1(DependencyObject element)
        => (bool)element.GetValue(H1Property);


    public static readonly DependencyProperty H2Property = DependencyProperty.RegisterAttached(
        "H2", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetH2(DependencyObject element, bool value)
        => element.SetValue(H2Property, ValueBoxes.BooleanBox(value));

    public static bool GetH2(DependencyObject element)
        => (bool)element.GetValue(H2Property);


    public static readonly DependencyProperty H3Property = DependencyProperty.RegisterAttached(
        "H3", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetH3(DependencyObject element, bool value)
        => element.SetValue(H3Property, ValueBoxes.BooleanBox(value));

    public static bool GetH3(DependencyObject element)
        => (bool)element.GetValue(H3Property);


    public static readonly DependencyProperty H4Property = DependencyProperty.RegisterAttached(
        "H4", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetH4(DependencyObject element, bool value)
        => element.SetValue(H4Property, ValueBoxes.BooleanBox(value));

    public static bool GetH4(DependencyObject element)
        => (bool)element.GetValue(H4Property);


    public static readonly DependencyProperty H5Property = DependencyProperty.RegisterAttached(
        "H5", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetH5(DependencyObject element, bool value)
        => element.SetValue(H5Property, ValueBoxes.BooleanBox(value));

    public static bool GetH5(DependencyObject element)
        => (bool)element.GetValue(H5Property);


    public static readonly DependencyProperty H6Property = DependencyProperty.RegisterAttached(
        "H6", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetH6(DependencyObject element, bool value)
        => element.SetValue(H6Property, ValueBoxes.BooleanBox(value));

    public static bool GetH6(DependencyObject element)
        => (bool)element.GetValue(H6Property);

}
