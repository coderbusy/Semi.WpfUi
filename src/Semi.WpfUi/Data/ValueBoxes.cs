namespace Semi.WpfUi.Data;

internal static class ValueBoxes
{
    internal static object TrueBox = true;

    internal static object FalseBox = false;
    internal static object BooleanBox(bool value) => value ? TrueBox : FalseBox;
}
