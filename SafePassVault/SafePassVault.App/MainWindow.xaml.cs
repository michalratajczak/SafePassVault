﻿using SafePassVault.App.Pages;
using SafePassVault.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using Newtonsoft.Json;
using System.IO;
using SafePassVault.App.Helpers;

namespace SafePassVault.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static StartPage StartPage;
        public static ServiceListPage ServiceListPage;

        public Notifier Notifier { get; set; }

        public MainWindow()
        {
            Notifier = new Notifier(cfg =>
            {
                cfg.PositionProvider = new ControlPositionProvider(
                    parentWindow: this,
                    trackingElement: MainGrid,
                    corner: Corner.BottomRight,
                    offsetX: 5,
                    offsetY: 5);

                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(1.5),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(5));

                cfg.DisplayOptions.Width = 230;

                cfg.Dispatcher = Application.Current.Dispatcher;
            });

            StartPage = new StartPage();
            ServiceListPage = new ServiceListPage(Notifier);

            InitializeComponent();
            ApplicationFrame.Content = StartPage;
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.LoginWindow = new LoginWindow();
            Windows.LoginWindow.Show();
            Close();            
        }

        private void ServiceListButton_Click(object sender, RoutedEventArgs e)
        {
            ApplicationFrame.Content = ServiceListPage;
        }
    }
}
