using System;
using System.Windows;
using System.Windows.Controls;

namespace Semi.WpfUi.Controls;

public class StackPanel : System.Windows.Controls.StackPanel
{
    /// <summary>
    /// Defines the <see cref="Spacing"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty SpacingProperty = DependencyProperty.Register(
        nameof(Spacing),
        typeof(double),
        typeof(StackPanel),
        new FrameworkPropertyMetadata(
            0d,
            FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange),
        static value =>
        {
            var spacing = (double)value;
            return !double.IsNaN(spacing) && !double.IsInfinity(spacing) && spacing >= 0;
        });

    public double Spacing
    {
        get => (double)GetValue(SpacingProperty);
        set => SetValue(SpacingProperty, value);
    }

    protected override Size MeasureOverride(Size constraint)
    {
        var isHorizontal = Orientation == Orientation.Horizontal;
        var childConstraint = isHorizontal
            ? new Size(double.PositiveInfinity, constraint.Height)
            : new Size(constraint.Width, double.PositiveInfinity);

        var desiredSize = new Size();
        var visibleChildren = 0;

        foreach (UIElement child in InternalChildren)
        {
            if (child is null || child.Visibility == Visibility.Collapsed)
            {
                continue;
            }

            child.Measure(childConstraint);

            if (visibleChildren > 0)
            {
                if (isHorizontal)
                {
                    desiredSize.Width += Spacing;
                }
                else
                {
                    desiredSize.Height += Spacing;
                }
            }

            if (isHorizontal)
            {
                desiredSize.Width += child.DesiredSize.Width;
                desiredSize.Height = Math.Max(desiredSize.Height, child.DesiredSize.Height);
            }
            else
            {
                desiredSize.Width = Math.Max(desiredSize.Width, child.DesiredSize.Width);
                desiredSize.Height += child.DesiredSize.Height;
            }

            visibleChildren++;
        }

        return desiredSize;
    }

    protected override Size ArrangeOverride(Size arrangeSize)
    {
        var isHorizontal = Orientation == Orientation.Horizontal;
        var offset = 0d;
        var visibleChildren = 0;

        foreach (UIElement child in InternalChildren)
        {
            if (child is null || child.Visibility == Visibility.Collapsed)
            {
                continue;
            }

            if (visibleChildren > 0)
            {
                offset += Spacing;
            }

            if (isHorizontal)
            {
                var childWidth = child.DesiredSize.Width;
                child.Arrange(new Rect(offset, 0, childWidth, arrangeSize.Height));
                offset += childWidth;
            }
            else
            {
                var childHeight = child.DesiredSize.Height;
                child.Arrange(new Rect(0, offset, arrangeSize.Width, childHeight));
                offset += childHeight;
            }

            visibleChildren++;
        }

        return arrangeSize;
    }
}
