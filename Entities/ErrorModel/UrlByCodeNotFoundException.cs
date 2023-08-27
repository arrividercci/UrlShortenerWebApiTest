using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ErrorModel
{
    public class UrlByCodeNotFoundException : NotFoundException
    {
        public UrlByCodeNotFoundException(string urlCode) : base($"Url with code: {urlCode} not found.")
        {
        }
    }
}
