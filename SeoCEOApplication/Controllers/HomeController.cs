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
        public IActionResult IndexAsync(SeoViewModel viewModel)
        {
            SeoViewModel members = null;

            using (var client = new HttpClient())
            {
                var url = _configuration["WebApiAddress"];
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url),
                    Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json")
                };

                var response = client.SendAsync(request);
                response.Wait();
                //response.();

                var readTask = response.Result.Content.ReadAsAsync<SeoViewModel>();
                readTask.Wait();

                members = readTask.Result;
                members.SearchText = viewModel.SearchText;
                members.UrlFilter = viewModel.UrlFilter;

            }
            return View("Positions", members);
        }

        [HttpGet]
        public IActionResult PositionsAsync([FromBody] SeoViewModel viewModel)
        {
            return View(viewModel);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
