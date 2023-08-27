using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext context;
        private readonly Lazy<IUrlRepository> urlRepository;
        public RepositoryManager(RepositoryContext context)
        {
            this.context = context;
            urlRepository = new Lazy<IUrlRepository>(() => new UrlRepository(this.context));
        }
        public IUrlRepository Url => urlRepository.Value;

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
