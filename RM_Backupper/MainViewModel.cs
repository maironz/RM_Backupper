// <copyright file="MainViewModel.cs" company="Massimo Ronzulli">
// Copyright (c) Massimo Ronzulli. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace RM_Backupper
{
    using System.ComponentModel;

    public class MainViewModel : INotifyPropertyChanged
    {
        private bool isVertical = false;
        private bool isBottombarVisible = false; // modalità Bottombar
        private bool isSidebarCollapsed = true; // Impostato inizialmente su true per nascondere il menu laterale

        public MainViewModel()
        {
            // Initial logic can go here
        }

        public event PropertyChangedEventHandler PropertyChanged; // INotifyPropertyChanged

        public bool IsBottombarVisible
        {
            get => this.isBottombarVisible;
            set
            {
                this.isBottombarVisible = value;
                this.OnPropertyChanged(nameof(this.IsBottombarVisible));
            }
        }

        public bool IsSidebarCollapsed
        {
            get => this.isSidebarCollapsed;
            set
            {
                this.isSidebarCollapsed = value;
                this.OnPropertyChanged(nameof(this.IsSidebarCollapsed));
            }
        }

        public bool IsVertical
        {
            get => this.isVertical;
            set
            {
                this.isVertical = value;
                this.OnPropertyChanged(nameof(this.IsVertical));
            }
        }

        public void UpdateOrientation(double actualWidth, double actualHeight)
        {
            this.IsVertical = actualWidth < actualHeight || actualWidth < 500;
            this.IsBottombarVisible = this.IsVertical;
        }

        public void ToggleSidebar()
        {
            this.IsSidebarCollapsed = !this.IsSidebarCollapsed;
        }

        protected void OnPropertyChanged(string propertyName) // INotifyPropertyChanged
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
