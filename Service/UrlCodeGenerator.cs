using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UrlCodeGenerator : IUrlCodeGenerator
    {
        public async Task<string> GetUrlMapStringAsync(string url)
        {
            return await Task<string>.Run(() =>
            {
                MD5 md5Hash = MD5.Create();
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(url));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in data)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            });
        }
    }
}
