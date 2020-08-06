using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace EdgExplorer.UI
{
    internal class WindowBorderThicknessConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider) => this;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double.TryParse(parameter?.ToString(), out var length);

            return value switch
            {
                WindowState state when state == WindowState.Maximized => new Thickness(0),
                _ => new Thickness(length)
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}