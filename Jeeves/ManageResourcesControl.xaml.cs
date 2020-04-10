namespace Jeeves
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    using Domain;
    using Microsoft.Win32;
    using Repositories;

    /// <summary>
    /// Interaction logic for ManageResourcesControl.xaml
    /// </summary>
    public partial class ManageResourcesControl : UserControl
    {
        private readonly MediaResourceRepository _mediaResourceRepository;
        private readonly MediaResourceType _mediaResourceType;
        private readonly ObservableCollection<MediaResource> _mediaResources;
        private readonly Window _owner;

        public ManageResourcesControl(
            Window owner,
            MediaResourceType mediaResourceType)
        {
            _owner = owner;
            _mediaResourceRepository = new MediaResourceRepository();
            _mediaResourceType = mediaResourceType;

            InitializeComponent();

            var mediaResources = _mediaResourceRepository.GetByResourceType(_mediaResourceType).ToList();
            _mediaResources = new ObservableCollection<MediaResource>(mediaResources);

            resourcesList.ItemsSource = _mediaResources;

            addResourceButton.Content = $"Add {mediaResourceType}";
        }

        private void addResourceButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = MediaResource.GetFilter(_mediaResourceType)
            };

            openFileDialog.FileOk += AddResourceFile;

            openFileDialog.ShowDialog(_owner);
        }

        private void AddResourceFile(object sender, CancelEventArgs e)
        {
            var dialog = (OpenFileDialog)sender;

            AddResources(dialog.FileNames);
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var resource = (MediaResource)button.DataContext;

            resource.Start();
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var resource = (MediaResource)button.DataContext;

            if (resource.IsPlaying())
            {
                resource.Stop();
            }

            RemoveResource(resource);
        }

        private void RemoveResource(MediaResource mediaResource)
        {
            _mediaResources.Remove(mediaResource);

            _mediaResourceRepository.Remove(mediaResource);
        }

        private void AddResources(string[] filenames)
        {
            foreach (var filename in filenames)
            {
                var resource = MediaResource.Create(System.IO.Path.GetFileName(filename), filename, _mediaResourceType);
                
                _mediaResources.Add(resource);

                _mediaResourceRepository.Add(resource);
            }
        }

        private void stopAllButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(var item in resourcesList.Items)
            {
                var resource = (MediaResource) item;
                resource.Stop();
            }
        }
    }
}
