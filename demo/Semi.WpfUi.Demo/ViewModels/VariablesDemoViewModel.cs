using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Semi.WpfUi.Tokens;

namespace Semi.WpfUi.Demo.ViewModels;

public partial class VariablesDemoViewModel : ObservableObject
{
    public VariablesDemoViewModel()
    {
        GridData = CollectionViewSource.GetDefaultView(CreateItems());
        GridData.GroupDescriptions.Add(new PropertyGroupDescription(nameof(VariableItem.Category)));
    }

    public ICollectionView GridData { get; }
    [ObservableProperty] private string _searchText = string.Empty;
    partial void OnSearchTextChanged(string value)
    {
        GridData.Filter = item => item is VariableItem variable && (string.IsNullOrWhiteSpace(value) || variable.SearchText.Contains(value, StringComparison.OrdinalIgnoreCase));
        GridData.Refresh();
    }

    [RelayCommand] private static void Copy(string? text) { if (!string.IsNullOrEmpty(text)) Clipboard.SetText(text); }
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
    public string Category { get; } = category; public string ResourceKey { get; } = resourceKey; public string TypeName { get; } = value?.GetType().Name ?? string.Empty; public string Value { get; } = Convert.ToString(value, CultureInfo.InvariantCulture) ?? string.Empty; public string Description { get; } = description;
    public string CopyText => $"{{DynamicResource {ResourceKey}}}"; public string SearchText => $"{Category} {ResourceKey} {TypeName} {Value} {Description}";
}
