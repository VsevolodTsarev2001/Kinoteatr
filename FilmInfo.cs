using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoRudnev
{
    public partial class FilmInfo : Form
    {
        public FilmInfo(int rowsCount, Film film)
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                int availablePlaces = 0;
                List<string> lines = new List<string>();
                using (StreamReader reader = new StreamReader(File.Open(Paths.TICKETS_FOLDER + "tickets.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                {
                    while (!reader.EndOfStream)
                    {
                        lines.Add(reader.ReadLine());
                    }
                    reader.Close();
                }
                availablePlaces = rowsCount * 20 - lines.Count;
                if (availablePlaces == 0) availablePlaces = rowsCount * 20;
                int placesCount = 1;
                Random rnd = new Random();
                PictureBox pbm = new PictureBox()
                {
                    Location = new Point(0, 0),
                    Size = new Size(Size.Width, Size.Height),
                    Image = Image.FromFile(Paths.IMG_FOLDER + "curtains2.png"),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Enabled = false,
                    Name = "pbmain"
                };
                pbm.SendToBack();
                Controls.Add(pbm);
                lblFilm.Text = "Фильм:" + film.filmName;
                lblPlacesCount.Text = $"Зал: {Math.Floor(GetRandomNumber(1,10))} (" + (rowsCount * 20) + " мест)";
                if (film._3D)
                {
                    lblPlacesCount.Text += " 3D";
                }
                lblAvailablePlaces.Text = "Свободных мест:" + availablePlaces;
                dateTimeSeans.Format = DateTimePickerFormat.Short;
                dateTimeSeans.ShowUpDown = true;
                dateTimeSeans.MinDate = DateTime.Now.AddMinutes(1);
                double GetRandomNumber(double min, double max)
                {
                    return rnd.NextDouble() * (max - min) + min;
                }
                int[] rndminutes = { 0, 5 };
                int filmDuration = 130;
                int hours = filmDuration / 60;
                int remainder = filmDuration % 60;
                void GenerateTimes()
                {
                    listBoxTimes.Items.Clear();
                    List<string> times = new List<string>();
                    int i = 0;
                    for (; i < Math.Floor(GetRandomNumber(1, 10)); i++)
                    {
                        double hour = Math.Floor(GetRandomNumber(11, 22));
                        double tenmins = Math.Floor(GetRandomNumber(0, 5));
                        int IorV = rndminutes[rnd.Next(rndminutes.Length)];
                        string result = $"{hour}:{tenmins}{IorV}-{hour + hours}:{Convert.ToInt32($"{tenmins}{IorV}") + remainder}";
                        if (!times.Contains(result)) times.Add(result);
                        else i--;
                    }
                    times.Sort();
                    listBoxTimes.Items.AddRange(times.ToArray());
                }
                GenerateTimes();
                string hourFormat = "час";
                if (hours>=2 && hours <=4) hourFormat = "часа";
                else if(hours >4) hourFormat = "часов";
                if (hours>0) lblFilmDuration.Text = $"Продолжительность: {hours} {hourFormat} {remainder} минут";
                else lblFilmDuration.Text = $"Продолжительность: {remainder} минут";
                dateTimeSeans.ValueChanged += (se, ee) =>
                {
                    GenerateTimes();
                    MessageBox.Show(dateTimeSeans.Value.ToLongTimeString());
                };
                PlacesNumeric.KeyDown += (se, ee) =>
                {
                    ee.SuppressKeyPress = true;
                    return;
                };
                PlacesNumeric.Controls.Owner.MouseEnter += (se, ee) =>
                {
                    PlacesNumeric.Cursor = Cursors.Hand;
                };
                PlacesNumeric.ValueChanged += (se, ee) =>
                {
                    placesCount = (int)PlacesNumeric.Value;
                    PlacesNumeric.Maximum = availablePlaces;
                };
                btnChoosePlace.Click += (se, ee) =>
                {
                    if (listBoxTimes.SelectedItems.Count!=0)
                    {
                        new Kino(rowsCount, placesCount, 
                            dateTimeSeans.Value.ToString().Replace(" ", "/"), film.filmName).Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Выберите сеанс");
                    }
                };
            };
        }
    }
}
