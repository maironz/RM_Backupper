// <copyright file="MenuItem.cs" company="Massimo Ronzulli">
// Copyright (c) Massimo Ronzulli. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace RM_Backupper.Main
{
    /// <summary>
    /// Represents a menu item with an icon and a descriptive label.
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// Gets or sets the icon code for the menu item.
        /// </summary>
        /// <value>The icon code, typically a string identifier for a graphical representation.</value>
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the descriptive label for the menu item.
        /// </summary>
        /// <value>The label text for the menu item.</value>
        public string Label { get; set; }
    }
}
