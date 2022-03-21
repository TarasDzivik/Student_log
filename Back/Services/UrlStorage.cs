using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Services
{
    public class UrlStorage
    {
        private string Scheme;
        private string DomainName;
        private string Port;
        private string FilePath;

        public UrlStorage(string scheme, string domainName, string port, string filePath)
        {
            Scheme = scheme;
            DomainName = domainName;
            Port = port;
            FilePath = filePath;
        }
    }
}