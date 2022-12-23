using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DotNetCoreTraversal.Areas.Admin.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace DotNetCoreTraversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class APIController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> GetApiMovies()
        {
            List<ApiMovieViewModel> apiMovies = new List<ApiMovieViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "9a34f18727msh692f0d4767cd775p19307djsn551ab0a30c21" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiMovies = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
            }
            return View(apiMovies);
        }

        public async Task<IActionResult> ApiExchange()
        {
            List<ApiExchangeViewModel> apiExchange = new List<ApiExchangeViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
                Headers =
    {
        { "X-RapidAPI-Key", "9a34f18727msh692f0d4767cd775p19307djsn551ab0a30c21" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ApiExchangeViewModel>(body);
                return View(values.exchange_rates);
            }
        }

        public async Task<IActionResult> ApiHotels()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?room_number=1&dest_type=city&order_by=popularity&dest_id=-1746443&locale=tr&checkin_date=2023-05-20&filter_by_currency=TRY&checkout_date=2023-05-28&adults_number=2&units=metric&children_ages=5%2C0&include_adjacency=true&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&children_number=2&page_number=0"),
                Headers =
    {
        { "X-RapidAPI-Key", "9a34f18727msh692f0d4767cd775p19307djsn551ab0a30c21" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var bodyReplace = body.Replace(".", "");
                var values = JsonConvert.DeserializeObject<ApiHotelListViewModel>(bodyReplace);
                return View(values.result);
            }
        }

        public async Task<IActionResult> GetCityDestID(string p)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=tr&name=" + p),
                Headers =
    {
        { "X-RapidAPI-Key", "9a34f18727msh692f0d4767cd775p19307djsn551ab0a30c21" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return Json(body);
            }
        }
    }
}
