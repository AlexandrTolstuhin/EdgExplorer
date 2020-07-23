using EdgExplorer.Shared.ViewModels;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace EdgExplorer.UI
{
    internal class FileEntityToImageConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider) => this;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var resource = value switch
            {
                DirectoryViewModel _ => Application.Current.TryFindResource("FolderImage"),
                FileViewModel _ => Application.Current.TryFindResource("FileImage"),
                _ => null
            };

            if (resource is ImageSource imageSource)
                return imageSource;

            return new DrawingImage();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}