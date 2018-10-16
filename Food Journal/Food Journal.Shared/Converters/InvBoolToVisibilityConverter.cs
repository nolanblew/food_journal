using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Food_Journal.Shared.Converters
{
    public class InvBoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var boolean = value as bool?;
            return boolean != true ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
