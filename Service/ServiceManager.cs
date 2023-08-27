using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUrlService> urlService;
        private readonly Lazy<IUserService> userService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, UserManager<User> userManager, IConfiguration configuration, IUrlCodeGenerator urlCodeGenerator, IUrlGenerator urlGenerator)
        {
            urlService = new Lazy<IUrlService>(() => new UrlService(repositoryManager, mapper, urlCodeGenerator, urlGenerator));
            userService = new Lazy<IUserService>(() => new UserService(userManager, configuration));
        }

        public IUrlService UrlService => urlService.Value;

        public IUserService UserService => userService.Value;
    }
}
