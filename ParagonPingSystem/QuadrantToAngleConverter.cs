using System;
using System.Globalization;
using System.Windows.Data;

namespace ParagonPingSystem {

    [ValueConversion(typeof(int), typeof(double))]
    public class QuadrantToAngleConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is int quadrant)) {
                return 0.0;
            }

            switch (quadrant) {
                case 0:
                    return 0.0;
                case 1:
                    return 90.0;
                case 2:
                    return 180.0;
                case 3:
                    return 270.0;
                default:
                    return 0.0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }
}