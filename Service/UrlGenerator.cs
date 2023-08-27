using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UrlGenerator : IUrlGenerator
    {
        public async Task<string> GetUrlByCodeAsync(string mapString)
        {
            return await Task<string>.Run(() =>
            {
                var size = mapString.Length;
                var random = new Random();
                var url = new StringBuilder();
                for (int i = 0; i < 8; i++)
                {
                    url.Append(mapString[random.Next(size)]);
                }
                return url.ToString();
            });
        }
    }
}
