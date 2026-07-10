using System.Windows.Markup;

namespace Semi.WpfUi;

[ContentProperty(nameof(ResourceKey))]
sealed class ResourceAlias
{
    public string? ResourceKey { get; set; }
}
