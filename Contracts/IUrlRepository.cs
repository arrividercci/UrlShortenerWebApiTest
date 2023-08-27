using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Contracts
{
    public interface IUrlRepository
    {
        Task<IEnumerable<Url>> GetAllUrlsAsync(bool trackChanges);
        Task<IEnumerable<Url>> GetUrlsAsync(string userId, bool trackChanges);
        Task<Url> GetUrlByCodeAsync(string urlCode, bool trackChanges);
        Task<Url> GetUrlAsync(int urlId, bool trackChanges);
        Task<Url> GetUrlByOriginalUrlAsync(string originalUrl, bool trackChanges);
        void CreateUrl(Url url);
        void CreateUrlForUser(string userId, Url url);
        void DeleteUrl(Url url);
    }
}
