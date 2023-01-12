using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DotNetCoreTraversal.Models;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DotNetCoreTraversal.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();
            using(var c = new Context())
            {
                destinationModels = c.Destinations.Select(x => new DestinationModel
                {
                    City = x.CityName,
                    DayNight = x.DayNight,
                    Price = x.Price,
                    Capacity = x.Capacity
                }).ToList();
            }
            return destinationModels;
        }

        public IActionResult DatabaseExcelReport()
        {
            var excelList = _excelService.ExcelList(DestinationList());
            return File(excelList, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ExcelRapor.xlsx");
            //application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
        }

        public IActionResult DestinationExcelReport()
        {
            using(var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Tur Listesi");

                worksheet.Cell(1, 1).Value = "Şehir";
                worksheet.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.BlueGray;
                worksheet.Cell(1, 2).Value = "Konaklama Süresi";
                worksheet.Cell(1, 2).Style.Fill.BackgroundColor = XLColor.BlueBell;
                worksheet.Cell(1, 3).Value = "Fiyat";
                worksheet.Cell(1, 3).Style.Fill.BackgroundColor = XLColor.Aqua;
                worksheet.Cell(1, 4).Value = "Kapasite";
                worksheet.Cell(1, 4).Style.Fill.BackgroundColor = XLColor.Turquoise;

                int rowCount = 2;
                foreach (var item in DestinationList())
                {
                    worksheet.Cell(rowCount, 1).Value = item.City;
                    worksheet.Cell(rowCount, 1).Style.Fill.BackgroundColor = XLColor.LightGray;

                    worksheet.Cell(rowCount, 2).Value = item.DayNight;
                    worksheet.Cell(rowCount, 2).Style.Fill.BackgroundColor = XLColor.LightPastelPurple;

                    worksheet.Cell(rowCount, 3).Value = "$" + item.Price;
                    worksheet.Cell(rowCount, 3).Style.Fill.BackgroundColor = XLColor.PaleAqua;

                    worksheet.Cell(rowCount, 4).Value = item.Capacity + " Kişi";
                    worksheet.Cell(rowCount, 4).Style.Fill.BackgroundColor = XLColor.LightBlue;

                    rowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TraversalRapor.xlsx");
                }

            }
        }
    }
}
