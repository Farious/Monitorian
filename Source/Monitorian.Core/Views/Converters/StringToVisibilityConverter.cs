﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Monitorian.Core.Views.Converters
{
	[ValueConversion(typeof(string), typeof(Visibility))]
	public class StringToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ((value is null) || string.IsNullOrWhiteSpace(value as string ?? value.ToString()))
				? Visibility.Collapsed
				: Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}