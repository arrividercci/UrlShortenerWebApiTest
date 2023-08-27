using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface IUrlService
    {
        Task<IEnumerable<UrlDto>> GetAllUrlAsync(bool trackChanges)
        Task<UrlDto> GetUrlAsync(int urlId, bool trackChanges);
        Task<UrlDto> GetUrlByCodeAsync(string urlCode, bool trackChanges);
        Task<IEnumerable<UrlDto>> GetUrlsAsync(string userId, bool trackChanges);
        Task<UrlDto> CreateUrlForUserAsync(string userId, UrlForCreationDto url);
        Task DeleteUrlAsync(string userId, int urlId, bool trackChanges);
        Task UpdateUrlAsync(string userId, int urlId, UrlForUpdateDto url, bool trackChangesForUpdate);
    }
}
