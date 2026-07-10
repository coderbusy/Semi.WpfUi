using System.Windows.Markup;

namespace Semi.WpfUi;

[ContentProperty(nameof(ResourceKey))]
class ResourceAlias
{
    public string? ResourceKey { get; set; }
}
