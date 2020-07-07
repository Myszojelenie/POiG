﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using POiG_lista_TO_DO.Model;
namespace POiG_lista_TO_DO.ViewModels
{
    class AssignmentToStringConverter : BaseVM,IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Studies.WhichSubject((Assignment)value) +";" + value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new Assignment();
        }
    }
}
