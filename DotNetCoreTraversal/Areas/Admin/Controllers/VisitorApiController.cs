using DotNetCoreTraversal.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class VisitorApiController : Controller
    {
        private readonly IHttpClientFactory _httpCF;

        public VisitorApiController(IHttpClientFactory httpCF)
        {
            _httpCF = httpCF;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var client = _httpCF.CreateClient();
            var response = await client.GetAsync("http://localhost:51633/api/Visitor/");
            if (response.IsSuccessStatusCode)
            {
                var jsonValues = await response.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject<List<VisitorViewModel>>(jsonValues);
                return Json(jsonValues);
            }
            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddData(VisitorViewModel p)
        {
            var client = _httpCF.CreateClient();
            var jsonData = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:51633/api/Visitor/", content);
            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }
            return Json(content);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteData(int id)
        {
            var client = _httpCF.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:51633/api/Visitor/{id}");
            if (response.IsSuccessStatusCode)
            {
                return NoContent();
            }
            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetDataByID(int id)
        {
            var client = _httpCF.CreateClient();
            var response = await client.GetAsync($"http://localhost:51633/api/Visitor/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonValues = await response.Content.ReadAsStringAsync();
                return Json(jsonValues);
            }
            return Json(response);
        }

        public async Task<IActionResult> UpdateData(VisitorViewModel p)
        {
            var client = _httpCF.CreateClient();
            var jsonValues = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonValues, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"http://localhost:51633/api/Visitor/", content);
            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }
            return Json(response);
        }
    }
}
