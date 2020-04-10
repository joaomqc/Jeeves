namespace Jeeves
{
    using System;
    using System.Windows.Media;

    public class MediaPlayerWrapper
    {
        private readonly MediaPlayer _mediaPlayer;

        public MediaPlayerWrapper()
        {
            _mediaPlayer = new MediaPlayer();
        }

        public bool IsPlaying { get; private set; }

        public string CurrentPath { get; private set; }

        public void Play()
        {
            _mediaPlayer.Play();
            IsPlaying = true;
        }

        public void Stop()
        {
            _mediaPlayer.Stop();
            IsPlaying = false;
        }

        public void Open(string path)
        {
            CurrentPath = path;
            _mediaPlayer.Open(new Uri(path));
        }
    }
}
