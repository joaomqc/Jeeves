namespace Jeeves
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for ImageWindow.xaml
    /// </summary>
    public partial class ImageWindow : Window
    {
        public ImageWindow(string imagePath)
        {
            InitializeComponent();

            var imageUri = new Uri(imagePath);

            mediaElement.Source = imageUri;

            SetupContextMenu();

            MouseDown += Window_MouseDown;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void SetupContextMenu()
        {
            var mainContextMenu = new ContextMenu();

            var exitMenuItem = new MenuItem
            {
                Header = "Exit",
            };

            exitMenuItem.Click += (sender, args) =>
            {
                Close();
            };

            mainContextMenu.Items.Add(exitMenuItem);

            ContextMenu = mainContextMenu;
        }

        private void MediaElement_OnMediaEnded(
            object sender,
            RoutedEventArgs e)
        {
            mediaElement.Position = new TimeSpan(0, 0, 1);
            mediaElement.Play();
        }
    }
}
