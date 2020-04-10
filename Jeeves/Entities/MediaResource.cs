namespace Jeeves.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Domain;

    public class MediaResource
    {
        public MediaResource(
            string name,
            string path,
            MediaResourceType resourceType)
        {
            Name = name;
            Path = path;
            ResourceType = resourceType;
        }

        [Key]
        public string Name { get; set; }
        public string Path { get; set; }
        public MediaResourceType ResourceType { get; set; }

        public Domain.MediaResource ToDomain()
        {
            return ResourceType switch
            {
                MediaResourceType.Image => new Image(Name, Path),
                MediaResourceType.Audio => new Audio(Name,Path),
                _ => throw new ArgumentOutOfRangeException(nameof(ResourceType))
            };
        }
    }
}
