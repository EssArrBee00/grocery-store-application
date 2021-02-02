using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Data;
using System.Globalization;

namespace Assignment02.Convertor
{
    class myConverterr : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Clone(); //return a copy of binded objects
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
