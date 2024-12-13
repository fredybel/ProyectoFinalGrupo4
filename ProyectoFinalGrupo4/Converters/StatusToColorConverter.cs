using ProyectoFinalGrupo4.Models;
using System.Globalization;

namespace ProyectoFinalGrupo4.Converters
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TaskItemStatus status)
            {
                return status switch
                {
                    TaskItemStatus.PorHacer => Colors.Red,
                    TaskItemStatus.EnProceso => Colors.Orange,
                    TaskItemStatus.Finalizada => Colors.Green,
                    _ => Colors.Gray
                };
            }
            return Colors.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}