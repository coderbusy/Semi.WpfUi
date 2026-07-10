using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Semi.WpfUi.Controls;

public class Grid : System.Windows.Controls.Grid
{
    public static readonly DependencyProperty ColumnSpacingProperty = DependencyProperty.Register(
        nameof(ColumnSpacing),
        typeof(double),
        typeof(Grid),
        new FrameworkPropertyMetadata(
            0d,
            FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange
            ),
        static value =>
        {
            var spacing = (double)value;
            return !double.IsNaN(spacing) && !double.IsInfinity(spacing) && spacing >= 0;
        });

    public static readonly DependencyProperty RowSpacingProperty = DependencyProperty.Register(
        nameof(RowSpacing),
        typeof(double),
        typeof(Grid),
        new FrameworkPropertyMetadata(
            0d,
            FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange),
        static value =>
        {
            var spacing = (double)value;
            return !double.IsNaN(spacing) && !double.IsInfinity(spacing) && spacing >= 0;
        });

    public double ColumnSpacing
    {
        get => (double)GetValue(ColumnSpacingProperty);
        set => SetValue(ColumnSpacingProperty, value);
    }

    public double RowSpacing
    {
        get => (double)GetValue(RowSpacingProperty);
        set => SetValue(RowSpacingProperty, value);
    }

    protected override Size MeasureOverride(Size constraint)
    {
        var effectiveColumnCount = Math.Max(1, ColumnDefinitions.Count);
        var effectiveRowCount = Math.Max(1, RowDefinitions.Count);

        var totalColumnSpacing = ColumnSpacing * (effectiveColumnCount - 1);
        var totalRowSpacing = RowSpacing * (effectiveRowCount - 1);

        var innerConstraint = new Size(
            SubtractIfFinite(constraint.Width, totalColumnSpacing),
            SubtractIfFinite(constraint.Height, totalRowSpacing));

        var innerDesired = base.MeasureOverride(innerConstraint);

        return new Size(
            innerDesired.Width + totalColumnSpacing,
            innerDesired.Height + totalRowSpacing);
    }

    protected override Size ArrangeOverride(Size arrangeSize)
    {
        var effectiveColumnCount = Math.Max(1, ColumnDefinitions.Count);
        var effectiveRowCount = Math.Max(1, RowDefinitions.Count);

        var totalColumnSpacing = ColumnSpacing * (effectiveColumnCount - 1);
        var totalRowSpacing = RowSpacing * (effectiveRowCount - 1);

        var innerArrangeSize = new Size(
            Math.Max(0d, arrangeSize.Width - totalColumnSpacing),
            Math.Max(0d, arrangeSize.Height - totalRowSpacing));

        _ = base.ArrangeOverride(innerArrangeSize);

        foreach (UIElement child in InternalChildren)
        {
            if (child is null)
            {
                continue;
            }

            var column = Math.Max(0, Math.Min(GetColumn(child), effectiveColumnCount - 1));
            var row = Math.Max(0, Math.Min(GetRow(child), effectiveRowCount - 1));
            var columnSpan = Math.Max(1, Math.Min(GetColumnSpan(child), effectiveColumnCount - column));
            var rowSpan = Math.Max(1, Math.Min(GetRowSpan(child), effectiveRowCount - row));

            var x = GetOffset(ColumnDefinitions, innerArrangeSize.Width, column, ColumnSpacing);
            var y = GetOffset(RowDefinitions, innerArrangeSize.Height, row, RowSpacing);
            var width = GetSizeForRange(ColumnDefinitions, innerArrangeSize.Width, column, columnSpan, ColumnSpacing);
            var height = GetSizeForRange(RowDefinitions, innerArrangeSize.Height, row, rowSpan, RowSpacing);

            child.Arrange(new Rect(x, y, width, height));
        }

        return arrangeSize;
    }

    private static double SubtractIfFinite(double value, double amount)
    {
        if (double.IsPositiveInfinity(value))
        {
            return value;
        }

        return Math.Max(0d, value - amount);
    }

    private static double GetOffset(ColumnDefinitionCollection definitions, double fallbackSize, int index, double spacing)
    {
        if (definitions.Count == 0)
        {
            return index == 0 ? 0d : fallbackSize + spacing;
        }

        var offset = 0d;
        for (var i = 0; i < index; i++)
        {
            offset += definitions[i].ActualWidth + spacing;
        }

        return offset;
    }

    private static double GetOffset(RowDefinitionCollection definitions, double fallbackSize, int index, double spacing)
    {
        if (definitions.Count == 0)
        {
            return index == 0 ? 0d : fallbackSize + spacing;
        }

        var offset = 0d;
        for (var i = 0; i < index; i++)
        {
            offset += definitions[i].ActualHeight + spacing;
        }

        return offset;
    }

    private static double GetSizeForRange(ColumnDefinitionCollection definitions, double fallbackSize, int start, int count, double spacing)
    {
        if (definitions.Count == 0)
        {
            return fallbackSize;
        }

        var size = 0d;
        for (var i = start; i < start + count; i++)
        {
            size += definitions[i].ActualWidth;
        }

        return size + spacing * (count - 1);
    }

    private static double GetSizeForRange(RowDefinitionCollection definitions, double fallbackSize, int start, int count, double spacing)
    {
        if (definitions.Count == 0)
        {
            return fallbackSize;
        }

        var size = 0d;
        for (var i = start; i < start + count; i++)
        {
            size += definitions[i].ActualHeight;
        }

        return size + spacing * (count - 1);
    }
}
