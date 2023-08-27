using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record UrlForCreationDto
    {
        public string? OriginalUrl { get; set; }
        public string? UrlCode { get; set; }
    }
}
