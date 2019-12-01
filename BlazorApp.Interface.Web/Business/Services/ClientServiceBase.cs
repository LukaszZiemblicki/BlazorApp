using System;
using Microsoft.Extensions.Configuration;

namespace BlazorApp.Interface.Web.Business.Services
{
    public abstract class ClientServiceBase
    {
        private const string API_URL = "https://localhost:5004";

        protected string CombineUrl(string path)
        {
            if (path.StartsWith("/"))
                path = path.Remove(0, 1);
            return $"{API_URL}/{path}";
        }
    }
}
