﻿using CV19.Infrastructure.Converters.Base;
using System;
using System.Globalization;
using System.Windows.Markup;

namespace CV19.Infrastructure.Converters
{
    [MarkupExtensionReturnType(typeof(Add))]
    internal class Add : Converter
    {
        [ConstructorArgument(nameof(Coefficient))]
        public double Coefficient { get; set; } = 1;

        public Add()
        {

        }

        public Add(double coefficient) => Coefficient = coefficient;

        public override object Convert(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            if (value is null)
            {
                return null;
            }

            var x = System.Convert.ToDouble(value, culture);

            return x + Coefficient;
        }

        public override object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            if (value is null)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(value.ToString()))
            {
                return null;
            }

            var x = System.Convert.ToDouble(value, culture);

            return x - Coefficient;
        }
    }
}
