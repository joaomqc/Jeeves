namespace Jeeves.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Domain;
    using Infrastructure;
    using Microsoft.EntityFrameworkCore;

    public class MediaResourceRepository
    {
        private readonly DatabaseContext _databaseContext;

        public MediaResourceRepository()
        {
            _databaseContext = new DatabaseContext();
        }

        public IEnumerable<MediaResource> GetByResourceType(MediaResourceType resourceType)
        {
            return _databaseContext.MediaResources
                .AsNoTracking()
                .Where(r => r.ResourceType == resourceType)
                .Select(r => r.ToDomain())
                .ToList();
        }

        public void Add(MediaResource mediaResource)
        {
            _databaseContext.MediaResources
                .Add(new Entities.MediaResource(
                    name: mediaResource.Name,
                    path: mediaResource.Path,
                    resourceType: mediaResource.ResourceType));

            _databaseContext.SaveChanges();
        }

        public void Remove(MediaResource mediaResource)
        {
            var entity = _databaseContext.MediaResources
                .FirstOrDefault(r => r.Path == mediaResource.Path);

            if(entity == null)
            {
                return;
            }

            _databaseContext.MediaResources
                .Remove(entity);

            _databaseContext.SaveChanges();
        }
    }
}
