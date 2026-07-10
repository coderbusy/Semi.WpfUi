using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Semi.WpfUi.Tokens;

namespace Semi.WpfUi.Demo.Pages;

public partial class VariablesDemo : UserControl
{
    public VariablesDemo()
    {
        InitializeComponent();
        GridData = CollectionViewSource.GetDefaultView(CreateItems());
        GridData.GroupDescriptions.Add(new PropertyGroupDescription(nameof(VariableItem.Category)));
        DataContext = this;
    }

    public ICollectionView GridData { get; }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        var search = ((TextBox)sender).Text.Trim();
        GridData.Filter = item => item is VariableItem variable && (string.IsNullOrEmpty(search) || variable.SearchText.Contains(search, StringComparison.OrdinalIgnoreCase));
        GridData.Refresh();
    }

    private void OnCopyClick(object sender, RoutedEventArgs e)
    {
        if (((Button)sender).Tag is string text) Clipboard.SetText(text);
    }

    private static IEnumerable<VariableItem> CreateItems()
    {
        var dictionary = new Variables();
        return Tokens.Select(token => new VariableItem(token.Category, token.Key, dictionary[token.Key], token.Description));
    }

    private static readonly (string Category, string Key, string Description)[] Tokens =
    [
        ("Height", "SemiHeightControlSmall", "Small control height"), ("Height", "SemiHeightControlDefault", "Default control height"), ("Height", "SemiHeightControlLarge", "Large control height"),
        ("Icon Size", "SemiWidthIconExtraSmall", "Extra-small icon width"), ("Icon Size", "SemiWidthIconSmall", "Small icon width"), ("Icon Size", "SemiWidthIconMedium", "Medium icon width"), ("Icon Size", "SemiWidthIconLarge", "Large icon width"), ("Icon Size", "SemiWidthIconExtraLarge", "Extra-large icon width"),
        ("Border Radius", "SemiBorderRadiusExtraSmall", "Extra-small radius"), ("Border Radius", "SemiBorderRadiusSmall", "Small radius"), ("Border Radius", "SemiBorderRadiusMedium", "Medium radius"), ("Border Radius", "SemiBorderRadiusLarge", "Large radius"), ("Border Radius", "SemiBorderRadiusFull", "Full radius"),
        ("Spacing", "SemiSpacingNone", "No spacing"), ("Spacing", "SemiSpacingSuperTight", "Super-tight spacing"), ("Spacing", "SemiSpacingExtraTight", "Extra-tight spacing"), ("Spacing", "SemiSpacingTight", "Tight spacing"), ("Spacing", "SemiSpacingBaseTight", "Base-tight spacing"), ("Spacing", "SemiSpacingBase", "Base spacing"), ("Spacing", "SemiSpacingBaseLoose", "Base-loose spacing"), ("Spacing", "SemiSpacingLoose", "Loose spacing"), ("Spacing", "SemiSpacingExtraLoose", "Extra-loose spacing"), ("Spacing", "SemiSpacingSuperLoose", "Super-loose spacing"),
        ("Font Size", "SemiFontSizeSmall", "Small text size"), ("Font Size", "SemiFontSizeRegular", "Regular text size"), ("Font Size", "SemiFontSizeHeader6", "Header 6 size"), ("Font Size", "SemiFontSizeHeader5", "Header 5 size"), ("Font Size", "SemiFontSizeHeader4", "Header 4 size"), ("Font Size", "SemiFontSizeHeader3", "Header 3 size"), ("Font Size", "SemiFontSizeHeader2", "Header 2 size"), ("Font Size", "SemiFontSizeHeader1", "Header 1 size"),
        ("Font Weight", "SemiFontWeightLight", "Light weight"), ("Font Weight", "SemiFontWeightRegular", "Regular weight"), ("Font Weight", "SemiFontWeightBold", "Bold weight"), ("Font Family", "SemiFontFamilyRegular", "Default font family")
    ];
}

public sealed class VariableItem(string category, string resourceKey, object? value, string description)
{
    public string Category { get; } = category;
    public string ResourceKey { get; } = resourceKey;
    public string TypeName { get; } = value?.GetType().Name ?? string.Empty;
    public string Value { get; } = Convert.ToString(value, CultureInfo.InvariantCulture) ?? string.Empty;
    public string Description { get; } = description;
    public string CopyText => $"{{DynamicResource {ResourceKey}}}";
    public string SearchText => $"{Category} {ResourceKey} {TypeName} {Value} {Description}";
}
