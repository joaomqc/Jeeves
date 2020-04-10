namespace Jeeves.Domain
{
    using System;
    using System.Windows.Media;

    public class Audio : MediaResource
    {
        private static readonly MediaPlayerWrapper MediaPlayer = new MediaPlayerWrapper();

        public Audio(
            string name,
            string path)
            : base(name, path, MediaResourceType.Audio)
        {
        }

        public override void Start()
        {
            MediaPlayer.Stop();

            MediaPlayer.Open(Path);

            MediaPlayer.Play();
        }

        public override void Stop()
        {
            if (IsPlaying())
            {
                MediaPlayer.Stop();
            }
        }

        public override bool IsPlaying()
        {
            return MediaPlayer.IsPlaying && MediaPlayer.CurrentPath == Path;
        }
    }
}
