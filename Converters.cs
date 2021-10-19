using System;
using System.Globalization;
using System.Windows.Data;
using TicTacToe.Models;

namespace TicTacToe
{
    public class CellValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Choices cellValue = (values[0] as Choices[,])[(int)values[1], (int)values[2]];
            return cellValue == Choices.Blank ? string.Empty : cellValue.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    
    public class EnableSelectionConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty(value[0] as string);
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    
    public class WinnerLabelConverter : IValueConverter
    {
        private const string X_WIN = "X WINS!!!";
        private const string O_WIN = "O WINS!!!";
        private const string TIE = "IT'S A TIE!!!";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string)value == Choices.X.ToString()) ? X_WIN : ((string)value == Choices.O.ToString()) ? O_WIN : TIE;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}