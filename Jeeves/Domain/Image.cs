namespace Jeeves.Domain
{
    public class Image : MediaResource
    {
        private ImageWindow _window;

        public Image(
            string name,
            string path)
            : base(name, path, MediaResourceType.Image)
        {
        }

        public override void Start()
        {
            if (!IsPlaying())
            {
                _window = new ImageWindow(Path);
                _window.Show();
            }
        }

        public override void Stop()
        {
            _window?.Close();
            _window = null;
        }

        public override bool IsPlaying()
        {
            return _window != null;
        }
    }
}
