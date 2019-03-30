using System;
using System.Windows;
using DeviceRestartLib;

namespace DeviceRestart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class MainWindow : Window
    {
        #region Static

        private static void Disable()
        {
            try
            {
                Device.Disable("USB Composite Device", @"USB\VID_1FD2&PID_6103");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Disable failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static void Enable()
        {
            try
            {
                Device.Enable("USB Composite Device", @"USB\VID_1FD2&PID_6103");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Enable failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion Static

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Disable_OnClick(object sender, RoutedEventArgs e) => Disable();

        private void Enable_OnClick(object sender, RoutedEventArgs e) => Enable();

        private void ReEnable_OnClick(object sender, RoutedEventArgs e)
        {
            Disable();
            Enable();
        }
    }
}
