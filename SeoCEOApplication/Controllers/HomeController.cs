using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SeoCEOApplication.Models;

namespace SeoCEOApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public IActionResult IndexAsync()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SeoViewModel viewModel)
        {
            SeoViewModel members = null;

            using (var client = new HttpClient())
            {
                var url = _configuration["WebApiAddress"];
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var requestJson = new { SearchText = "e-settlements", UrlFilter = "www.sympli.com" };
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url),
                    Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(requestJson), Encoding.UTF8, "application/json")
                };

                var response = await client.SendAsync(request).ConfigureAwait(true);
                response.EnsureSuccessStatusCode();

                var readTask = response.Content.ReadAsAsync<SeoViewModel>();
                readTask.Wait();

                members = readTask.Result;
            }
            return View(members);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
