using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoRudnev
{
    public class PDF
    {
        private int ticketNumber = 0;
        private string place;
        public PDF(string ticket, int tickNum)
        {
            place = ticket;
            ticketNumber = tickNum+1;
            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            Image imgQR = qrcode.Draw(ticket, 50);
            imgQR.Save(Paths.CODES_FOLDER + $"qr{ticketNumber}.png");
        }
        public PDF(string info)
        {
            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            Image imgBarcode = barcode.Draw(info, 50);
            imgBarcode.Save(Paths.CODES_FOLDER + "bar.png");
        }
        private void BeginBox(XGraphics gfx, int number, string title)
        {
            const int dEllipse = 15;
            XRect rect = new XRect(0, 20, 300, 200);
            if (number % 2 == 0)
                rect.X = 300 - 5;
            rect.Y = 40 + ((number - 1) / 2) * (200 - 5);
            rect.Inflate(-10, -10);
            XRect rect2 = rect;
            rect2.Offset(2, 2);
            XColor xColor1 = XColors.DarkGoldenrod;
            XColor xColor2 = XColors.Chocolate;
            gfx.DrawRoundedRectangle(new XSolidBrush(XColor.FromArgb(9, XColors.DarkGoldenrod)), rect2, new XSize(dEllipse + 8, dEllipse + 8));
            XLinearGradientBrush brush = new XLinearGradientBrush(rect, xColor1, xColor2, XLinearGradientMode.Vertical);
            gfx.DrawRoundedRectangle(brush, rect, new XSize(dEllipse, dEllipse));
            rect.Inflate(-5, -5);
            XFont font = new XFont("Times New Roman", 14);

            gfx.DrawString(title, font, XBrushes.Black, rect, XStringFormats.TopCenter);
            rect.Inflate(-10, -5);
            rect.Y += 20;
            rect.Height -= 20;
            gfx.Save();
            gfx.TranslateTransform(rect.X, rect.Y);
        }
        private void EndBox(XGraphics gfx)
        {
            gfx.Restore(gfx.Save());
        }
        public void DrawImages(XGraphics gfx, int number, string type = "QR")
        {
            string path = "";
            if (type == "QR")
            {
                BeginBox(gfx, number, $"{place}");
                path = $"qr{ticketNumber}";
            }
            else if (type == "штрих") 
            {
                path = "bar";
                BeginBox(gfx, number, "Штрих код");
            }
            XImage image = XImage.FromFile(Paths.CODES_FOLDER + $"{path}.png");
            double x = (250 - image.PixelWidth * 72 / image.HorizontalResolution) / 2;
            gfx.DrawImage(image, x, 0);
            EndBox(gfx);
        }
        public static void ConcatFiles()
        {
            PdfDocument outputDocument = new PdfDocument();
            foreach (string file in Directory.EnumerateFiles(Paths.TICKET_FOLDER, "*.*", SearchOption.AllDirectories).Where(file => file.EndsWith(".pdf")))
            {
                PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);
                for (int idx = 0; idx < inputDocument.PageCount; idx++)
                {
                    PdfPage page = inputDocument.Pages[idx];
                    outputDocument.AddPage(page);
                }
            }
            outputDocument.Save(Paths.ALL_TICKETS);
        }
        public static void ClearFolders()
        {
            foreach (DirectoryInfo di in new DirectoryInfo(Paths.TICKETS_FOLDER).EnumerateDirectories("*.*", SearchOption.AllDirectories))
            {
                foreach (FileInfo file in di.EnumerateFiles("*.*",SearchOption.AllDirectories))
                {
                    file.Delete();
                }
            }
        }
        public static void CheckFolders()
        {
            if (!Directory.Exists(Paths.TICKETS_FOLDER))
            {
                Directory.CreateDirectory(Paths.TICKETS_FOLDER);
            }
            if (!Directory.Exists(Paths.TICKET_FOLDER))
            {
                Directory.CreateDirectory(Paths.TICKET_FOLDER);
            }
            if (!Directory.Exists(Paths.IMG_FOLDER))
            {
                Directory.CreateDirectory(Paths.IMG_FOLDER);
            }
            if (!Directory.Exists(Paths.CODES_FOLDER))
            {
                Directory.CreateDirectory(Paths.CODES_FOLDER);
            }
            if (!Directory.Exists(Paths.ALL_FOLDER))
            {
                Directory.CreateDirectory(Paths.ALL_FOLDER);
            }
        }
    }
}
