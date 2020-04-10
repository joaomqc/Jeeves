namespace Jeeves
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Domain;
    using Repositories;
    using Image = System.Windows.Controls.Image;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetupTabControl();
        }

        private void SetupTabControl()
        {
            TabControl.Items.Add(BuildMediaResourceTabItem(MediaResourceType.Image));
            TabControl.Items.Add(BuildMediaResourceTabItem(MediaResourceType.Audio));
        }

        private TabItem BuildMediaResourceTabItem(MediaResourceType resourceType)
        {
            return new TabItem
            {
                Header = resourceType.ToString(),
                Content = new ManageResourcesControl(this, resourceType)
            };
        }
    }
}
