namespace Jeeves.Domain
{
    using System;

    public abstract class MediaResource
    {
        protected MediaResource(
            string name,
            string path,
            MediaResourceType resourceType)
        {
            Name = name;
            Path = path;
            ResourceType = resourceType;
        }

        public string Name { get; }

        public string Path { get; }

        public MediaResourceType ResourceType { get; }

        public string GetSourcePath => IsPlaying()
            ? "Resources/stop.png"
            : "Resources/play.png";

        public abstract void Start();

        public abstract void Stop();

        public abstract bool IsPlaying();

        public static MediaResource Create(
            string name,
            string path,
            MediaResourceType resourceType)
        {
            return resourceType switch
            {
                MediaResourceType.Image => new Image(name, path),
                MediaResourceType.Audio => new Audio(name, path),
                _ => throw new ArgumentOutOfRangeException(nameof(resourceType))
            };
        }

        public static string GetFilter(MediaResourceType mediaResourceType)
        {
            switch (mediaResourceType)
            {
                case MediaResourceType.Audio:
                    return "All Supported Audio |*.mp3;*.wav| MP3s |*.mp3| WAVs |*.wav";
                case MediaResourceType.Image:
                    return "All Supported Image |*.jpg;*.jpeg;*.png;*.gif| JPEGs |*.jpg;*.jpeg| PNGs |*.png| GIFs |*.gif";
                default:
                    throw new ArgumentOutOfRangeException(nameof(mediaResourceType));
            }
        }
    }
}
