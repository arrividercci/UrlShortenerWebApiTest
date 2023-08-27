using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record UrlForUpdateDto
    {
        public string? OriginalUrl { get; set; }
        public string? ShorterUrl { get; set; }
    }
}
