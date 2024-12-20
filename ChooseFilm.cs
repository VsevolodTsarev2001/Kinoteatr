using Microsoft.VisualBasic;
using PdfSharp.Drawing;
using PdfSharp.Drawing.BarCodes;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoRudnev
{
    public partial class numericPlaces : Form
    {
        public numericPlaces()
        {
            int rowsCount = 0;
            bool filmChoosen = false;
            InitializeComponent();
            Load += (s, e) =>
            {
                /* DB.SQL_CON.Open();
                 SqlCommand sqlCommand = new SqlCommand("SELECT film from Films", DB.SQL_CON);
                 SqlDataReader dataReader = sqlCommand.ExecuteReader();
                 List<string> filmNames = new List<string>();
                 while (dataReader.Read())
                 {
                     result += Convert.ToString(dataReader["film"]);
                      MessageBox.Show(Convert.ToString(dataReader["film"]));
                     for (int i = 0; i < dataReader.FieldCount; i++)
                     {
                         filmNames.Add(dataReader.GetValue(i).ToString());
                     }
                 }
                 DB.SQL_CON.Close();*/
                /*  DB.SQL_CON.Open();
                  SqlCommand sqlCommand1 = new SqlCommand("SELECT * FROM Films", DB.SQL_CON);
                  SqlDataReader dataReader1 = sqlCommand1.ExecuteReader();
                  string result = "";
                  while (dataReader1.Read())
                  {
                      for (int i = 0; i < dataReader1.FieldCount; i++)
                      {
                          result += dataReader1["film"];
                      }
                  }
                  DB.SQL_CON.Close();
                  MessageBox.Show(result);*/
                DB.SQL_CON.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * from Films", DB.SQL_CON);
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Film film = new Film();
                    film.filmName = dataReader["film"].ToString();
                    film.rowsCount = (int)dataReader["rowsCount"];
                    film.duration = (int)dataReader["Duration"];
                    film.rating = (double)dataReader["Rating"];
                    film.year = (int)dataReader["Year"];
                    film._3D = (bool)dataReader["3D"];
                    film.imageSrc = Paths.IMG_FOLDER + dataReader["image"];
                    Film.films.Add(film);
                }
                DB.SQL_CON.Close();
                for (int i = 0; i < Film.films.Count; i++)
                {
                    PictureBox pbx = new PictureBox();
                    pbx.Location = new Point(20 + i * 320, 60);
                    if (i>=4 && i!=0)
                    {
                        pbx.Location = new Point(20 + (i % 4)* 320, 370);
                    }
                    pbx.Image = Image.FromFile(Film.films[i].imageSrc);
                    pbx.Tag = Film.films[i].filmName.ToString();
                    pbx.Size = new Size(270, 287);
                    pbx.SizeMode = PictureBoxSizeMode.StretchImage;
                    Controls.Add(pbx);
                    pbx.BringToFront();
                }
                void SwitchrowsCount(PictureBox pb)
                {
                    Film.films.ForEach(f =>
                    {
                        if (f.filmName.ToLower() == pb.Tag.ToString().ToLower())
                        {
                            rowsCount = f.rowsCount;
                            f.choosen = true;
                        }
                    });
                    foreach (PictureBox box in Controls.OfType<PictureBox>().Where(p => p!=pb && p.Name!="pbmain"))
                    {
                        Film.films.Find(f => f.filmName.ToLower() == box.Tag.ToString().ToLower()).choosen = false;
                    }
                }
                PictureBox pbm = new PictureBox()
                {
                    Enabled = false,
                    Location = new Point(0, 0),
                    Size = new Size(Size.Width, Size.Height),
                    Image = Image.FromFile($"{Paths.IMG_FOLDER}cinemabg.jpg"),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Name = "pbmain"
                };
                pbm.SendToBack();
                Controls.Add(pbm);
                List<PictureBox> pictures = new List<PictureBox>();
                foreach (PictureBox pb in Controls.OfType<PictureBox>().Where(p => p.Name!="pbmain"))
                {
                    pictures.Add(pb);
                    pb.Click += (se, ee) =>
                    {
                        pictures.ForEach(p => {
                            p.BorderStyle = BorderStyle.None;
                            filmChoosen = false;
                        });
                        pb.BorderStyle = BorderStyle.FixedSingle;
                        SwitchrowsCount(pb);
                        filmChoosen = true;
                    };
                }
                btnChoosePlace.Click += (se, ee) =>
                {
                    if (filmChoosen)
                    {
                        new FilmInfo(rowsCount, Film.films.Find(f=>f.choosen)).Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Выберите фильм");
                    }
                };
            };
        }
    }
}
