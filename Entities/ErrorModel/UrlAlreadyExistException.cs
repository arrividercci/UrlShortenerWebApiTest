using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ErrorModel
{
    public class UrlAlreadyExistException : Exception
    {
        public UrlAlreadyExistException(int urlId) : base($"Url with id: {urlId} already created.")
        {
        }
    }
}
