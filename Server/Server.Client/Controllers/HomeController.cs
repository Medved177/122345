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
            var request = new HttpRequestMessage(HttpMethod.Get, "Vacancy");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<PagedResult<DbVacancy>>();
                return View(result);
            }

            return View();
        }
        public async Task<IActionResult> Section(DataRequest pageRequest)
        {
            var client = _clientFactory.CreateClient("api");
            var request = new HttpRequestMessage(HttpMethod.Get, $"Vacancy?Page={pageRequest.Page}");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<PagedResult<DbVacancy>>();
                return PartialView("Section", result);
            }

            return PartialView("Section");
        }
        public async Task<IActionResult> Vacancy(DataRequest pageRequest)
        {
            var client = _clientFactory.CreateClient("api");
            var request = new HttpRequestMessage(HttpMethod.Get, $"Vacancy?Page={pageRequest.Page}");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<PagedResult<DbVacancy>>();
                return PartialView("Vacancy", result);
            }

            return PartialView("Vacancy");
        }
        public IActionResult AddEmployeeForm()
        {
            return PartialView("AddEmployee");
        }
        public async Task<bool> AddEmployee(DbEmployee employee)
        {
            var client = _clientFactory.CreateClient("api");
            var response = await client.PostAsJsonAsync("Employee", employee);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }
        public IActionResult AddEducationForm()
        {
            return PartialView("AddEducation");
        }
        public async Task<bool> AddEducation(DbEducation education)
        {
            var client = _clientFactory.CreateClient("api");
            var response = await client.PostAsJsonAsync("Education", education);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }
        public IActionResult AddWorkForm()
        {
            return PartialView("AddWork");
        }
        public async Task<bool> AddLastWork(DbLastWork lastWork)
        {
            var client = _clientFactory.CreateClient("api");
            var response = await client.PostAsJsonAsync("LastWork", lastWork);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }
        public IActionResult test(DbVacancy vacancy)
        {
            return PartialView("test", vacancy);
        }
    }
}
