using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office.Drawing;
using Microsoft.VisualBasic;
using PdfSharp.Charting;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;

namespace KinoRudnev
{
    public partial class Kino : Form
    {

        int rowsCount; int placesCount; string date; string filmName;

        public Kino(int rowsCount, int placesCount, string date, string filmName)
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                /*  string commandStr = $"If not exists (select name from sysobjects where name = ${filmName + date})" +
                  $" CREATE TABLE {filmName + date}(Date datetime(50), Film(50), Places(int), AvailablePlaces(int), Hall(int))";
                  DB.SQL_CON.Open();
                  SqlCommand command = new SqlCommand(commandStr, DB.SQL_CON);
                  command.ExecuteNonQuery();
                  DB.SQL_CON.Close();*/
                string MY_MAIL = "styx1338@gmail.com";
                List<string> picInfo = new List<string>();
                Random rnd = new Random();
                List<PictureBox> boxes = new List<PictureBox>();
                int nameCounter = 0;
                PictureBox[,] pictures = new PictureBox[rowsCount, rowsCount];
                Label[] rows = new Label[rowsCount];
                Label[] columns = new Label[rowsCount * 2];
                CinemaActions cinema = new CinemaActions(rowsCount, picInfo);
                for (int c = 0; c < rowsCount * 2; c++)
                {
                    columns[c] = new Label();
                    columns[c].Text = Convert.ToString(c + 1);
                    columns[c].Size = new Size(50, 50);
                    columns[c].Font = new System.Drawing.Font("Consolas", 20, FontStyle.Bold);
                    columns[c].Location = new System.Drawing.Point(80 + c * 50, 15);
                    columns[c].Name = $"Column{c + 1}";
                    if (c < 9)
                    {
                        columns[c].Padding = new Padding(5, 0, 0, 0);
                    }
                    Controls.Add(columns[c]);
                    cinema.LabelEvents(this,columns[c], cinema);
                }
                for (int i = 0; i < rowsCount; i++)
                {
                    rows[i] = new Label();
                    rows[i].Text = Convert.ToString(i + 1);
                    rows[i].Size = new Size(50, 50);
                    rows[i].Font = new System.Drawing.Font("Consolas", 20, FontStyle.Bold);
                    rows[i].Location = new System.Drawing.Point(10, i * 52 + 70);
                    rows[i].Name = $"Row{i + 1}";
                    Controls.Add(rows[i]);
                    cinema.LabelEvents(this, rows[i], cinema, "row");
                    cinema.columns = columns;
                    cinema.rows = rows;
                    for (int j = 0; j < rowsCount *2; j++)
                    {
                        PictureBox pb = new PictureBox()
                        {
                            Size = new Size(50, 50),
                            Location = new System.Drawing.Point(j * 50 + 70, i * 52 + 60),
                            Padding = new Padding(7, 7, 0, 0),
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Name = $"PBox-{++nameCounter}"
                        };
                        cinema.SetImg(pb);
                        Controls.Add(pb);
                        picInfo.Add($"false/{pb.Name}/");
                        boxes.Add(pb);
                        pb.Click += (se, ee) =>
                        {
                            cinema.getPlaceStatus(cinema, pb);
                        };
                        pb.MouseEnter += (se, ee) =>
                        {
                            pb.Cursor = Cursors.Hand;
                            lblPlace.Visible = true;
                            string[] rightPlace = cinema.getPlace(pb);
                            string column = rightPlace[0].Remove(rightPlace[0].IndexOf("Column"), 6);
                            string row = rightPlace[1].Remove(rightPlace[1].IndexOf("Row"), 3);
                            lblPlace.Text = $"Ряд: { row }, Место: { column }";
                        };
                        pb.MouseLeave += (se, ee) =>
                        {
                            pb.Cursor = Cursors.Default;
                            lblPlace.Visible = false;
                            lblPlace.Text = "";
                        };
                    }
                }
                btnOrder.Click += (se, ee) =>
                {
                    List<string> allPlaces = picInfo.FindAll(f => f.Contains("Column") && f.Contains("Row"));
                    if (allPlaces.Count != 0)
                    {
                        List<PictureBox> choosenPlaces = new List<PictureBox>();
                        foreach (PictureBox pb in Controls.OfType<PictureBox>())
                        {
                            if (allPlaces.ToList().Any(t => cinema.rightPic(t, pb)))
                            {
                                choosenPlaces.Add(pb);
                            }
                        }
                        List<string> tickets = new List<string>();
                        foreach (PictureBox pb in choosenPlaces)
                        {
                            string[] rightPlace = cinema.getPlace(pb);
                            string column = rightPlace[0].Remove(rightPlace[0].IndexOf("Column"), 6);
                            string row = rightPlace[1].Remove(rightPlace[1].IndexOf("Row"), 3);
                            tickets.Add($"Место: {column} Ряд: {row}");
                        }
                        string ticketsStringMail = "";
                        string ticketsStringPDF = tickets[0].Replace("Место", "PLACE").Replace("Ряд", "ROW").Replace(@"/", "");
                        tickets.ForEach(t=> {
                            ticketsStringMail += "<b>" + t + "</b>" + "<br> \n";
                        });
                        ticketsStringMail = "Ваши места: <br>" + ticketsStringMail;
                        string userMail = Interaction.InputBox("Email", "Введите email", "");
                        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                        {
                            Port = 587,
                            Credentials = new NetworkCredential(MY_MAIL, Interaction.InputBox("Пароль", "Введите пароль", "")),
                            EnableSsl = true,
                        };
                        MailMessage mail = new MailMessage()
                        {
                            From = new MailAddress(MY_MAIL),
                            Subject = "Ваши билет в кинотеатре Nikita Apollo",
                            Body = ticketsStringMail,
                            IsBodyHtml = true,
                        };
                        /*PdfDocument document = new PdfDocument();
                        PdfPage page = document.AddPage();
                        XGraphics gfx = XGraphics.FromPdfPage(page);
                        XFont font = new XFont("Verdana", 18, XFontStyle.Regular);
                        XTextFormatter tf = new XTextFormatter(gfx);
                        XRect rect = new XRect(0, 0, page.Width.Point, page.Height.Point);
                        tf.DrawString(ticketsStringPDF, font, XBrushes.Black, rect, XStringFormats.TopLeft);
                        document.Save(Paths.TICKETS_FOLDER + "ticket.pdf");

                         */
                        PDF.CheckFolders();
                        PDF.ClearFolders();
                        for (int i = 0; i < tickets.Count; i++)
                        {
                            PDF pdf = new PDF(tickets[i], i);
                            PdfDocument document = new PdfDocument();
                            PdfPage page = document.AddPage();
                            XGraphics gf = XGraphics.FromPdfPage(page);
                            pdf.DrawImages(gf, 2);
                            document.Save(Paths.TICKET_FOLDER + $"ticket{i}.pdf");
                        }
                        PdfDocument barCode = new PdfDocument();
                        PdfPage pageBarcode = barCode.AddPage();
                        XGraphics gf2 = XGraphics.FromPdfPage(pageBarcode);
                        new PDF(ticketsStringPDF).DrawImages(gf2, 2, "штрих");
                        barCode.Save(Paths.TICKET_FOLDER+"BarCode.pdf");
                        PDF.ConcatFiles();
                        Attachment attachment = new Attachment(Paths.ALL_TICKETS);
                        attachment.Name = "Tickets.pdf";
                        mail.Attachments.Add(attachment);
                        mail.To.Add(userMail);
                        smtpClient.Send(mail);
                        File.AppendAllLines(Paths.TICKETS_FOLDER + "tickets.txt", allPlaces);
                        foreach (PictureBox pb in choosenPlaces)
                        {
                            cinema.OrderPlace(pb);
                            string currentpic = picInfo.Find(p => cinema.rightPic(p, pb));
                            picInfo[picInfo.FindIndex(p => cinema.rightPic(p, pb))] = currentpic.Remove(currentpic.IndexOf("place="));
                        }
                        MessageBox.Show($"Билеты куплены и отправлены на email: {userMail}");
                    }
                    else
                    {
                        MessageBox.Show("Выберите места");
                    }
                };
                List<string> places = File.ReadAllLines(Paths.TICKETS_FOLDER + "tickets.txt", Encoding.UTF8).ToList();
                foreach (PictureBox pb in Controls.OfType<PictureBox>())
                {
                        if (places.Any(pl => pl.Contains("Column") && pl.Contains("Row") && cinema.rightPic(pl,pb)))
                        {
                            cinema.OrderPlace(pb);
                            boxes.Remove(pb);
                        }
                }
                for (int i = 0; i < placesCount; i++)
                {
                    PictureBox randomPlace = boxes[rnd.Next(boxes.Count)];
                    cinema.getPlaceStatus(cinema, randomPlace);
                    boxes.Remove(randomPlace);
                }
            };
        }
    }
}
