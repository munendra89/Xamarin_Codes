using System;
using System.Globalization;
using Xamarin.Forms;

namespace MyTube.Helpers
{
	public class ItemTapperEventArgsConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var eventArgs = value as ItemTappedEventArgs;
            return eventArgs.Item;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
