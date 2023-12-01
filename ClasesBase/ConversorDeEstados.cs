using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using System.Xml;
using System.Windows;

namespace ClasesBase
{
    /*
     interfaz que permite la conversión de un tipo de datos a otro durante la comunicación entre la interfaz de usuario y la lógica de negocio. 
     Se utiliza para transformar el valor de una propiedad en un formato adecuado para su presentación en la interfaz de usuario, o viceversa
     */
    public class ConversorDeEstados : IValueConverter  
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                int duracionEnMinutos;
                if (int.TryParse(value.ToString(), out duracionEnMinutos))
                {
                    if (duracionEnMinutos == 0)
                    {
                        return new SolidColorBrush(Colors.DarkMagenta);  //0 min
                    }
                    else if (duracionEnMinutos > 0 && duracionEnMinutos <= 30)  //30min
                    {
                        return new SolidColorBrush(Colors.Azure);
                    }
                    else if (duracionEnMinutos > 30 && duracionEnMinutos <= 60)  //60min
                    {
                        return new SolidColorBrush(Colors.BlueViolet);
                    }
                    else
                    {
                        return new SolidColorBrush(Colors.Crimson);
                    }
                }
            }

            return new SolidColorBrush(Colors.Gray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
