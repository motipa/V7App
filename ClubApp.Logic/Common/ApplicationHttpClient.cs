using Marvin.StreamExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ClubApp.Common;
using ClubApp.Common.Exceptions;

using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClubApp.Logic.Common
{
    public class ApplicationHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly ApiPrincipal _apiPrincipal;

        public ApplicationHttpClient(HttpClient httpClient, IConfiguration config, IApiPrincipalResolver apiPrincipalResolver)
        {
            _httpClient = httpClient;
            _config = config;

            _apiPrincipal = apiPrincipalResolver.Resolve();

            _httpClient.DefaultRequestHeaders.Clear();

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

     
    }
}
