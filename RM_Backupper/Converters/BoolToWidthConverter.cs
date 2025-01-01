// <copyright file="BoolToWidthConverter.cs" company="Massimo Ronzulli">
// Copyright (c) Massimo Ronzulli. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace RM_Backupper.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// Converts a boolean value to a width value for UI elements.
    /// </summary>
    public class BoolToWidthConverter : IValueConverter
    {
        /// <summary>
        /// Converts a boolean value to a width value.
        /// Returns 0 if the boolean value is true, or <see cref="double.NaN"/> if false.
        /// </summary>
        /// <param name="value">The value produced by the binding source, expected to be a boolean.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use (unused).</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>0 if <paramref name="value"/> is true; otherwise, <see cref="double.NaN"/>.</returns>
        /// <exception cref="InvalidCastException">Thrown when the input value is not a boolean.</exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isCollapsed)
            {
                return isCollapsed ? 0 : double.NaN;
            }

            throw new InvalidCastException("Expected a boolean value for the BoolToWidthConverter.");
        }

        /// <summary>
        /// Not implemented. Converts a width value back to a boolean value.
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
