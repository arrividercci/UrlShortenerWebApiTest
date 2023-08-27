using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ErrorModel
{
    public class UrlNotFoundException : NotFoundException
    {
        public UrlNotFoundException(int urlId) : base($"Url with id: {urlId} is not found.")
        {
        }
    }
}
