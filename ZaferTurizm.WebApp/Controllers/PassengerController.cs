using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using ZaferTurizm.Business.Services.TicketManagers;
using ZaferTurizm.DTOs.TicketAllDtos;

namespace ZaferTurizm.WebApp.Controllers
{
    public class PassengerController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ITicketService _ticketService;

        public PassengerController(IWebHostEnvironment hostingEnvironment, ITicketService ticketService)
        {
            _hostingEnvironment = hostingEnvironment;
            _ticketService = ticketService;
        }

        public IActionResult TicketList()
        {
            var tickets = _ticketService.GetSummaries();
            return View(tickets);
        }

        public IActionResult TicketInfo(int id)
        {
            var ticket = _ticketService.GetSummaryById(id);
            return View(ticket);
        }

        public ActionResult ExportToPDF(int id)
        {

            var model = _ticketService.GetSummaryById(id);
            MemoryStream memoryStream = new MemoryStream();
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            string imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "OtobusResimleri", "Zafer-Partisi.png");
            Image image = Image.GetInstance(imagePath);
            image.ScaleToFit(150f, 150f);
            image.Alignment = Element.ALIGN_CENTER;
            document.Add(image);

            Paragraph busTripName = new Paragraph(model.BusTripName, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20));
            busTripName.Alignment = Element.ALIGN_CENTER;
            document.Add(busTripName);

            Paragraph route = new Paragraph(model.Route, FontFactory.GetFont(FontFactory.HELVETICA, 16));
            route.Alignment = Element.ALIGN_CENTER;
            document.Add(route);

            Paragraph paidAmount = new Paragraph($"Bilet Fiyatı: {model.PaidAmount}", FontFactory.GetFont(FontFactory.HELVETICA, 14));
            paidAmount.Alignment = Element.ALIGN_CENTER;
            document.Add(paidAmount);

            Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
            Paragraph title = new Paragraph($"{model.PassengerFName} {model.PassengerLName} Bilet Bilgileri", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 10f;
            document.Add(title);

            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 1f, 1f });

            table.AddCell("Sefer Tarihi:");
            table.AddCell(model.Date.ToString());

            table.AddCell("Tc Kimlik Numarası:");
            table.AddCell(model.PassengerIdentityNumber);

            table.AddCell("Ad - Soyad:");
            table.AddCell($"{model.PassengerFName} {model.PassengerLName}");

            table.AddCell("Yolcu Yaşı:");
            table.AddCell(model.Age.ToString());

            table.AddCell("İletişim Bilgileri:");
            table.AddCell(model.PhoneNumber);

            table.AddCell("Koltuk Numarası:");
            table.AddCell(model.SeatNumber.ToString());

            document.Add(table);

            string imagePath2 = Path.Combine(_hostingEnvironment.WebRootPath, "OtobusResimleri", "Barkod.jpg");
            Image image2 = Image.GetInstance(imagePath2);
            image2.ScaleToFit(150f, 150f);
            image2.Alignment = Element.ALIGN_CENTER;
            document.Add(image2);

            document.Close();

            byte[] bytes = memoryStream.ToArray();
            return File(bytes, "application/pdf", "bilet_bilgileri.pdf");
        }
    }
}
