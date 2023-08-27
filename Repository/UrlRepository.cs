using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class UrlRepository : RepositoryBase<Url>, IUrlRepository
    {
        public UrlRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateUrl(Url url)
        {
            Create(url);
        }

        public void CreateUrlForUser(string userId, Url url)
        {
            url.UserId = userId;
            Create(url);
        }

        public void DeleteUrl(Url url)
        {
            Delete(url);
        }

        public async Task<IEnumerable<Url>> GetAllUrlsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .ToListAsync();
        }

        public async Task<Url> GetUrlAsync(int urlId, bool trackChanges)
        {
            return await FindByCondition(url => url.Id == urlId, trackChanges)
                .SingleOrDefaultAsync();
        }

        public async Task<Url> GetUrlByCodeAsync(string urlCode, bool trackChanges)
        {
            return await FindByCondition(url => url.ShorterUrl.Equals(urlCode), trackChanges)
                .SingleOrDefaultAsync();
        }

        public async Task<Url> GetUrlByOriginalUrlAsync(string originalUrl, bool trackChanges)
        {
            return await FindByCondition(url => url.OriginalUrl.Equals(originalUrl), trackChanges)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Url>> GetUrlsAsync(string userId, bool trackChanges)
        {
            return await FindByCondition(url => url.UserId.Equals(userId), trackChanges).ToListAsync();
        }
    }
}
