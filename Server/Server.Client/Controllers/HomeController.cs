using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Contracts;
using Server.Data;


namespace Server.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient("api");
            var request = new HttpRequestMessage(HttpMethod.Get, "Employee");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<PagedResult<DbEmployee>>();
                return View(result);
            }

            return View();
        }

        public async Task<IActionResult> Employees(DataRequest pageRequest)
        {
            var client = _clientFactory.CreateClient("api");
            var request = new HttpRequestMessage(HttpMethod.Get, $"Employee?Page={pageRequest.Page}");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<PagedResult<DbEmployee>>();
                return PartialView("Employees", result);
            }

            return PartialView("Employees");
        }
    }
}
