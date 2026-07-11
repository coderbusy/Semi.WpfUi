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


    public static readonly DependencyProperty ShadowProperty = DependencyProperty.RegisterAttached(
        "Shadow", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetShadow(DependencyObject element, bool value)
        => element.SetValue(ShadowProperty, ValueBoxes.BooleanBox(value));

    public static bool GetShadow(DependencyObject element)
        => (bool)element.GetValue(ShadowProperty);


    public static readonly DependencyProperty HoverProperty = DependencyProperty.RegisterAttached(
        "Hover", typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

    public static void SetHover(DependencyObject element, bool value)
        => element.SetValue(HoverProperty, ValueBoxes.BooleanBox(value));

    public static bool GetHover(DependencyObject element)
        => (bool)element.GetValue(HoverProperty);


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

    public static readonly DependencyProperty GradientProperty = Register("Gradient");
    public static void SetGradient(DependencyObject element, bool value) => element.SetValue(GradientProperty, ValueBoxes.BooleanBox(value));
    public static bool GetGradient(DependencyObject element) => (bool)element.GetValue(GradientProperty);

    public static readonly DependencyProperty CircleProperty = Register("Circle");
    public static void SetCircle(DependencyObject element, bool value) => element.SetValue(CircleProperty, ValueBoxes.BooleanBox(value));
    public static bool GetCircle(DependencyObject element) => (bool)element.GetValue(CircleProperty);

    public static readonly DependencyProperty GhostProperty = Register("Ghost");
    public static void SetGhost(DependencyObject element, bool value) => element.SetValue(GhostProperty, ValueBoxes.BooleanBox(value));
    public static bool GetGhost(DependencyObject element) => (bool)element.GetValue(GhostProperty);

    public static readonly DependencyProperty SolidProperty = Register("Solid");
    public static void SetSolid(DependencyObject element, bool value) => element.SetValue(SolidProperty, ValueBoxes.BooleanBox(value));
    public static bool GetSolid(DependencyObject element) => (bool)element.GetValue(SolidProperty);

    public static readonly DependencyProperty CodeProperty = Register("Code");
    public static void SetCode(DependencyObject element, bool value) => element.SetValue(CodeProperty, ValueBoxes.BooleanBox(value));
    public static bool GetCode(DependencyObject element) => (bool)element.GetValue(CodeProperty);

    public static readonly DependencyProperty RedProperty = Register("Red");
    public static void SetRed(DependencyObject element, bool value) => element.SetValue(RedProperty, ValueBoxes.BooleanBox(value));
    public static bool GetRed(DependencyObject element) => (bool)element.GetValue(RedProperty);

    public static readonly DependencyProperty PinkProperty = Register("Pink");
    public static void SetPink(DependencyObject element, bool value) => element.SetValue(PinkProperty, ValueBoxes.BooleanBox(value));
    public static bool GetPink(DependencyObject element) => (bool)element.GetValue(PinkProperty);

    public static readonly DependencyProperty PurpleProperty = Register("Purple");
    public static void SetPurple(DependencyObject element, bool value) => element.SetValue(PurpleProperty, ValueBoxes.BooleanBox(value));
    public static bool GetPurple(DependencyObject element) => (bool)element.GetValue(PurpleProperty);

    public static readonly DependencyProperty VioletProperty = Register("Violet");
    public static void SetViolet(DependencyObject element, bool value) => element.SetValue(VioletProperty, ValueBoxes.BooleanBox(value));
    public static bool GetViolet(DependencyObject element) => (bool)element.GetValue(VioletProperty);

    public static readonly DependencyProperty IndigoProperty = Register("Indigo");
    public static void SetIndigo(DependencyObject element, bool value) => element.SetValue(IndigoProperty, ValueBoxes.BooleanBox(value));
    public static bool GetIndigo(DependencyObject element) => (bool)element.GetValue(IndigoProperty);

    public static readonly DependencyProperty BlueProperty = Register("Blue");
    public static void SetBlue(DependencyObject element, bool value) => element.SetValue(BlueProperty, ValueBoxes.BooleanBox(value));
    public static bool GetBlue(DependencyObject element) => (bool)element.GetValue(BlueProperty);

    public static readonly DependencyProperty LightBlueProperty = Register("LightBlue");
    public static void SetLightBlue(DependencyObject element, bool value) => element.SetValue(LightBlueProperty, ValueBoxes.BooleanBox(value));
    public static bool GetLightBlue(DependencyObject element) => (bool)element.GetValue(LightBlueProperty);

    public static readonly DependencyProperty CyanProperty = Register("Cyan");
    public static void SetCyan(DependencyObject element, bool value) => element.SetValue(CyanProperty, ValueBoxes.BooleanBox(value));
    public static bool GetCyan(DependencyObject element) => (bool)element.GetValue(CyanProperty);

    public static readonly DependencyProperty TealProperty = Register("Teal");
    public static void SetTeal(DependencyObject element, bool value) => element.SetValue(TealProperty, ValueBoxes.BooleanBox(value));
    public static bool GetTeal(DependencyObject element) => (bool)element.GetValue(TealProperty);

    public static readonly DependencyProperty GreenProperty = Register("Green");
    public static void SetGreen(DependencyObject element, bool value) => element.SetValue(GreenProperty, ValueBoxes.BooleanBox(value));
    public static bool GetGreen(DependencyObject element) => (bool)element.GetValue(GreenProperty);

    public static readonly DependencyProperty LightGreenProperty = Register("LightGreen");
    public static void SetLightGreen(DependencyObject element, bool value) => element.SetValue(LightGreenProperty, ValueBoxes.BooleanBox(value));
    public static bool GetLightGreen(DependencyObject element) => (bool)element.GetValue(LightGreenProperty);

    public static readonly DependencyProperty LimeProperty = Register("Lime");
    public static void SetLime(DependencyObject element, bool value) => element.SetValue(LimeProperty, ValueBoxes.BooleanBox(value));
    public static bool GetLime(DependencyObject element) => (bool)element.GetValue(LimeProperty);

    public static readonly DependencyProperty YellowProperty = Register("Yellow");
    public static void SetYellow(DependencyObject element, bool value) => element.SetValue(YellowProperty, ValueBoxes.BooleanBox(value));
    public static bool GetYellow(DependencyObject element) => (bool)element.GetValue(YellowProperty);

    public static readonly DependencyProperty AmberProperty = Register("Amber");
    public static void SetAmber(DependencyObject element, bool value) => element.SetValue(AmberProperty, ValueBoxes.BooleanBox(value));
    public static bool GetAmber(DependencyObject element) => (bool)element.GetValue(AmberProperty);

    public static readonly DependencyProperty OrangeProperty = Register("Orange");
    public static void SetOrange(DependencyObject element, bool value) => element.SetValue(OrangeProperty, ValueBoxes.BooleanBox(value));
    public static bool GetOrange(DependencyObject element) => (bool)element.GetValue(OrangeProperty);

    public static readonly DependencyProperty GreyProperty = Register("Grey");
    public static void SetGrey(DependencyObject element, bool value) => element.SetValue(GreyProperty, ValueBoxes.BooleanBox(value));
    public static bool GetGrey(DependencyObject element) => (bool)element.GetValue(GreyProperty);

    public static readonly DependencyProperty WhiteProperty = Register("White");
    public static void SetWhite(DependencyObject element, bool value) => element.SetValue(WhiteProperty, ValueBoxes.BooleanBox(value));
    public static bool GetWhite(DependencyObject element) => (bool)element.GetValue(WhiteProperty);

    private static DependencyProperty Register(string name)
        => DependencyProperty.RegisterAttached(name, typeof(bool), typeof(Classes), new PropertyMetadata(ValueBoxes.FalseBox));

}
