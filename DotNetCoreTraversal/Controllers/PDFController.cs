using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace DotNetCoreTraversal.Controllers
{
    public class PDFController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPDFReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PDFReports/" + "StaticReport.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            var date = DateTime.Now.ToString("dd MMMM yyyy | [HH:mm:ss]");

            Paragraph paragraph = new Paragraph("ISM Traversal - PDF Raporu (" + date + ")");

            document.Add(paragraph);
            document.Close();


            return File("/PDFReports/StaticReport.pdf", "application/pdf", "StaticReport.pdf");
        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PDFReports/" + "StaticCustomerReport.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            //Arial Font'unun Bilgisayarda Bulunduğu Yeri String Olarak Alıyoruz.
            string Arial_TFF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Arial.ttf");

            //iTextSharp için bir BaseFont örneği oluşturuyoruz.
            BaseFont bf = BaseFont.CreateFont(Arial_TFF, BaseFont.IDENTITY_H, true);

            //Yine dökümanda kullanabilmek için bu sefer ana font örneği oluşturuyoruz. Bu örneklemede font büyüklüğünü
            //ve diğer attributelerini de değiştirebilirsiniz.
            Font f = new Font(bf, 12, Font.NORMAL);

            var date = DateTime.Now.ToString("dd MMMM yyyy | [HH:mm:ss]");

            //Döküman için başlık paragrafı oluşturuyoruz, paragrafın sonuna bir f yani Font overloadı ekleyerek
            //Türkçe karakter desteklemesini ve istediğimiz fontu kullanmasını sağlıyoruz.
            Paragraph paragraph = new Paragraph("ISM Traversal - Statik Müşteri Raporu (" + date + ")\n\n", f);

            PdfPTable pdfPTable = new PdfPTable(3);

            //Burada ise AddCell overloadında direkt olarak string ve font belirlenmediğinden
            //new Phrase diyerek bunun bir font alabilmesini sağlıyoruz.
            pdfPTable.AddCell(new Phrase("Müşteri Adı", f));
            pdfPTable.AddCell(new Phrase("Müşteri Soyadı", f));
            pdfPTable.AddCell(new Phrase("Müşteri TC Kimlik", f));

            //Bunu tüm tablodaki elementlere uygulamak lazım. Ben burada
            //bir döngü de kullanabilirdim ama amaç temel mantığı
            //anlatmak olduğundan onun için ekstra bir şey yapmadım.
            pdfPTable.AddCell(new Phrase("Evren", f));
            pdfPTable.AddCell(new Phrase("Aksu", f));
            pdfPTable.AddCell(new Phrase("18840023949", f));

            pdfPTable.AddCell(new Phrase("Mehmet", f));
            pdfPTable.AddCell(new Phrase("Ören", f));
            pdfPTable.AddCell(new Phrase("14822487423", f));

            pdfPTable.AddCell(new Phrase("Ceren", f));
            pdfPTable.AddCell(new Phrase("Sarı", f));
            pdfPTable.AddCell(new Phrase("88529932141", f));

            document.Add(paragraph);
            document.Add(pdfPTable);

            document.Close();

            return File("/PDFReports/StaticCustomerReport.pdf", "application/pdf", "StaticCustomerReport.pdf");
        }
    }
}
