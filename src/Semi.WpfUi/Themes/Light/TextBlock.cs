using System.Windows;

namespace Semi.WpfUi.Themes.Light;

public partial class TextBlock : ResourceDictionary
{
    protected override void OnGettingValue(object key, ref object value, out bool canCache)
    {
        
        base.OnGettingValue(key, ref value, out canCache);
    }
}
