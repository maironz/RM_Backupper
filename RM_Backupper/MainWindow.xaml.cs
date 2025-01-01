// <copyright file="MainWindow.xaml.cs" company="Massimo Ronzulli">
// Copyright (c) Massimo Ronzulli. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace RM_Backupper
{
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Media.Animation;
    using RM_Backupper.DB;

    /// <summary>
    /// Logica di interazione per MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel viewModel;
        private Storyboard collapseStoryboard;
        private Storyboard expandStoryboard;
        private double collapsingSize = 200;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.viewModel = new MainViewModel();
            this.DataContext = this.viewModel;
            this.Loaded += this.MainWindow_Loaded;
            this.SizeChanged += this.MainWindow_SizeChanged;
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Debug.WriteLine("MainWindow_SizeChanged");
            // e.PreviousSize - e.NewSize
            if (sender is Window)
            {
                this.viewModel.UpdateOrientation(this.ActualWidth, this.ActualHeight);
                this.HamburgerButton.Visibility = this.viewModel.IsVertical ? Visibility.Hidden : Visibility.Visible;

                // keep the normal width
                if (this.Sidebar.ActualWidth > 0)
                {
                    this.collapsingSize = this.Sidebar.ActualWidth;
                }

                this.Sidebar.Visibility = this.viewModel.IsVertical ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Recupera gli storyboard dalle risorse
            this.collapseStoryboard = (Storyboard)this.FindResource("CollapseSidebar");
            this.expandStoryboard = (Storyboard)this.FindResource("ExpandSidebar");
            this.collapseStoryboard.Completed += this.CollapseStoryboard_Completed;
            this.expandStoryboard.Completed += this.ExpandStoryboard_Completed;

            // set width
            this.Sidebar.Width = 0;
        }

        private void ToggleSidebar(object sender, RoutedEventArgs e)
        {
            if (this.Sidebar.ActualWidth > 0)
            {
                this.collapsingSize = this.Sidebar.ActualWidth;
            }

            if (!this.viewModel.IsSidebarCollapsed)
            {
                // Ottieni l'animazione di scomparsa
                DoubleAnimation widthAnimation = this.collapseStoryboard.Children[0] as DoubleAnimation;

                // Imposta il valore di partenza basato sulla larghezza corrente.
                widthAnimation.From = this.collapsingSize;
                widthAnimation.To = 0;

                // Avvia l'animazione
                this.collapseStoryboard.Begin();
           }
           else
           {
                this.Sidebar.Visibility = Visibility.Visible;

                // Ottieni l'animazione di riapparizione
                DoubleAnimation widthAnimation = this.expandStoryboard.Children[0] as DoubleAnimation;

                // Imposta il valore di partenza e quello finale
                widthAnimation.From = 0;
                widthAnimation.To = this.collapsingSize; // Oppure un valore calcolato dinamicamente

                // Avvia l'animazione
                this.expandStoryboard.Begin();
            }
        }

        private void CollapseStoryboard_Completed(object sender, EventArgs e)
        {
            Debug.WriteLine("Collapsing End");
            this.viewModel.ToggleSidebar();
            this.Sidebar.Visibility = Visibility.Collapsed;
            this.viewModel.IsSidebarCollapsed = true;
            Debug.WriteLine("CollapseStoryboard_Completed Il valore di IsSidebarCollapsed è: " + this.viewModel.IsSidebarCollapsed);
        }

        private void ExpandStoryboard_Completed(object sender, EventArgs e)
        {
            Debug.WriteLine("Expanding End");
            this.viewModel.ToggleSidebar();
            this.Sidebar.Visibility = Visibility.Visible;
            this.viewModel.IsSidebarCollapsed = false;
            Debug.WriteLine("ExpandStoryboard_Completed Il valore di IsSidebarCollapsed è: " + this.viewModel.IsSidebarCollapsed);
        }

        private void Incremental_Backup_Button_Click(object sender, RoutedEventArgs e)
        {
            var backupService = new BackupService();

            // Ensure database is created
            backupService.InitializeDatabase();

            // Perform other operations, e.g., create a backup
            var newBackup = backupService.CreateBackup("MyBackup", "Full", "Device1", "Device2");
            Console.WriteLine($"Backup created with ID: {newBackup.BackupId}");
            Incremental_Backup incrementalBackupWindow = new Incremental_Backup();
            incrementalBackupWindow.Show();
        }
    }
}
