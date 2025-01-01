// <copyright file="BoolToVisibilityConverter.cs" company="Massimo Ronzulli">
// Copyright (c) Massimo Ronzulli. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace RM_Backupper.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// Converts a boolean value to a <see cref="Visibility"/> value.
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts a boolean value to a <see cref="Visibility"/> value.
        /// Returns <see cref="Visibility.Visible"/> if the boolean matches the parameter value; otherwise, <see cref="Visibility.Collapsed"/>.
        /// </summary>
        /// <param name="value">The value produced by the binding source, expected to be a boolean.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use. It should be a boolean in string form, specifying the comparison value.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns><see cref="Visibility.Visible"/> if <paramref name="value"/> matches <paramref name="parameter"/>; otherwise, <see cref="Visibility.Collapsed"/>.</returns>
        /// <exception cref="FormatException">Thrown if <paramref name="parameter"/> cannot be parsed as a boolean.</exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                bool parameterValue = parameter != null && bool.Parse(parameter.ToString());
                return boolValue == parameterValue ? Visibility.Visible : Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }

        /// <summary>
        /// Not implemented. Converts a <see cref="Visibility"/> value back to a boolean value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>This method always throws a <see cref="NotImplementedException"/>.</returns>
        /// <exception cref="NotImplementedException">Always thrown as this method is not implemented.</exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
