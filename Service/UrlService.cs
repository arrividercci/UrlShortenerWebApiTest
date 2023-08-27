using AutoMapper;
using Contracts;
using Entities.ErrorModel;
using Entities.Models;
using Service.Contract;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class UrlService : IUrlService
    {
        private readonly IRepositoryManager repository;
        private readonly IMapper mapper;
        private readonly IUrlCodeGenerator urlCodeGenerator;
        private readonly IUrlGenerator urlGenerator;

        public UrlService(IRepositoryManager repository, IMapper mapper, IUrlCodeGenerator urlCodeGenerator, IUrlGenerator urlGenerator)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.urlCodeGenerator = urlCodeGenerator;
            this.urlGenerator = urlGenerator;
        }

        public async Task<UrlDto> CreateUrlForUserAsync(string userId, UrlForCreationDto url)
        {
            var urlToCheck = await repository.Url.GetUrlByOriginalUrlAsync(url.OriginalUrl, false);

            if (urlToCheck is not null) 
            {
                throw new UrlAlreadyExistException(urlToCheck.Id);
            }
            var urlEntity = mapper.Map<Url>(url);

            if (string.IsNullOrEmpty(url.UrlCode))
            {
                var urlMapString = await urlCodeGenerator.GetUrlMapStringAsync(urlEntity.OriginalUrl);

                var shorterUrlCode = await urlGenerator.GetUrlByCodeAsync(urlMapString);

                urlEntity.ShorterUrl = shorterUrlCode;
            }
            else
            {
                urlEntity.ShorterUrl = url.UrlCode;
            }

            urlEntity.UserId = userId;

            urlEntity.CreationDate = DateTime.Now;

            repository.Url.CreateUrl(urlEntity);

            await repository.SaveAsync();

            var urlToReturn = mapper.Map<UrlDto>(urlEntity);

            return urlToReturn;
        }

        public async Task DeleteUrlAsync(string userId, int urlId, bool trackChanges)
        {
            var urlEntity = await repository.Url.GetUrlAsync(urlId, trackChanges);

            if (urlEntity is null)
            {
                throw new UrlNotFoundException(urlId);
            }

            repository.Url.DeleteUrl(urlEntity);

            await repository.SaveAsync();
        }

        public async Task<IEnumerable<UrlDto>> GetAllUrlAsync(bool trackChanges)
        {
            var urlsEntities = await repository.Url.GetAllUrlsAsync(trackChanges);

            var urlsToReturn = mapper.Map<IEnumerable<UrlDto>>(urlsEntities);

            return urlsToReturn;
        }

        public async Task<UrlDto> GetUrlAsync(int urlId, bool trackChanges)
        {
            var urlEntity = await repository.Url.GetUrlAsync(urlId, trackChanges);

            var urlToReturn = mapper.Map<UrlDto>(urlEntity);

            return urlToReturn;
        }

        public async Task<UrlDto> GetUrlByCodeAsync(string urlCode, bool trackChanges)
        {
            var urlEntity = await repository.Url.GetUrlByCodeAsync(urlCode, trackChanges);

            if (urlEntity is null)
            {
                throw new UrlByCodeNotFoundException(urlCode);
            }

            var urlToReturn = mapper.Map<UrlDto>(urlEntity);

            return urlToReturn;
        }

        public async Task<IEnumerable<UrlDto>> GetUrlsAsync(string userId, bool trackChanges)
        {
            var urlsEntity = await repository.Url.GetUrlsAsync(userId, trackChanges);

            var urlsToReturn = mapper.Map<IEnumerable<UrlDto>>(urlsEntity);

            return urlsToReturn;
        }

        public async Task UpdateUrlAsync(string userId, int urlId, UrlForUpdateDto url, bool trackChangesForUpdate)
        {
            var urlEntity = await repository.Url.GetUrlAsync(urlId, trackChangesForUpdate);
            
            if (urlEntity is null)
            {
                throw new UrlNotFoundException(urlId);
            }

            mapper.Map(url, urlEntity);

            await repository.SaveAsync();
        }
    }
}
