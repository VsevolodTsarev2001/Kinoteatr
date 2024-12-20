using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoRudnev
{
    public  class CinemaActions
    {
        public int rowsCount;
        public Label[] rows;
        public Label[] columns;
        List<string> picInfo;
        public CinemaActions(int RowsCount, List<string> PicInfo)
        {
            rowsCount = RowsCount;
            rows = new Label[rowsCount];
            columns = new Label[rowsCount * 2];
            picInfo = PicInfo;
        }
        public void OrderPlace(PictureBox pb)
        {
            SetImg(pb, "red");
            pb.Enabled = false;
        }
        public  void SetImg(PictureBox pb, string type = "green", string ext = "png")
        {
            pb.Image = Image.FromFile($"{Paths.IMG_FOLDER + "chair" + type + "." + ext}");
            pb.Image.Tag = type;
        }
        public string[] getPlace(PictureBox pb)
        {
            string column = columns.ToList().Find(f => f.Location.X - pb.Location.X == 10 || f.Location.X - pb.Location.X == 8).Name;
            string row = rows.ToList().Find(f => f.Location.Y - pb.Location.Y == 10).Name;
            string[] prms = { column, row };
            return prms;
        }
        public bool rightPic(string p, PictureBox pb)
        {
                return p.Substring(p.IndexOf("/") + 1,
                p.LastIndexOf('/') - p.IndexOf('/') - 1) == pb.Name;
        }
        public void getPlaceStatus(CinemaActions cinema, PictureBox pb)
        {
            string currentpic = picInfo.Find(p => cinema.rightPic(p, pb));
            if (currentpic.StartsWith("false"))
            {
                currentpic = currentpic.Replace("false", "true");
                cinema.SetImg(pb, "yellow");
                string[] rightPlace = cinema.getPlace(pb);
                string column = rightPlace[0];
                string row = rightPlace[1];
                picInfo[picInfo.FindIndex(p => cinema.rightPic(p, pb))] = currentpic + "place=" + column + row;
            }
            else
            {
                currentpic = currentpic.Replace("true", "false");
                cinema.SetImg(pb);
                picInfo[picInfo.FindIndex(p => cinema.rightPic(p, pb))] = currentpic.Remove(currentpic.IndexOf("place="));
            }
        }
        private int GetResult(string type, Label lbl, PictureBox pb)
        {
            int result = 0;
            if (type == "column")
            {
                result = lbl.Location.X - pb.Location.X;
            }
            else if (type == "row")
            {
                result = lbl.Location.Y - pb.Location.Y;
            }
            return result;
        }
        public void LabelEvents(Form form, Label lbl, CinemaActions cinema, string type = "column")
        {
            lbl.MouseEnter += (se, ee) =>
            {
                foreach (PictureBox pb in form.Controls.OfType<PictureBox>())
                {
                    int result = GetResult(type, lbl, pb);
                    if (result == 10 || result == 8)
                    {
                        pb.BackColor = Color.LightGray;
                        lbl.ForeColor = Color.Goldenrod;
                    }
                }
            };
            lbl.MouseLeave += (se, ee) =>
            {
                foreach (PictureBox pb in form.Controls.OfType<PictureBox>())
                {
                    int result = GetResult(type, lbl, pb);
                    if (result == 10 || result == 8)
                    {
                        pb.BackColor = Color.Transparent;
                        lbl.ForeColor = Color.Black;
                    }
                }
            };
            lbl.Click += async (se, ee) =>
            {
                await Task.Run(() =>
                {
                    List<PictureBox> rightPics = new List<PictureBox>();
                    foreach (PictureBox pb in form.Controls.OfType<PictureBox>())
                    {
                        int result = GetResult(type,lbl,pb);
                        if (result == 10 || result == 8)
                        {
                            if (pb.Image.Tag.ToString() != "red")
                            {
                                rightPics.Add(pb);
                            }
                        }
                    }
                    void setPlaces()
                    {
                        if (rightPics.Where(p => p.Image.Tag.ToString() == "green").Count() >= rightPics.Where(p => p.Image.Tag.ToString() == "yellow").Count())
                        {
                            rightPics.ForEach(pb =>
                            {
                                string currentpic = picInfo.Find(p => cinema.rightPic(p, pb)).Replace("false", "true");
                                cinema.SetImg(pb, "yellow");
                                string[] rightPlace = cinema.getPlace(pb);
                                string column = rightPlace[0];
                                string row = rightPlace[1];
                                picInfo[picInfo.FindIndex(p => cinema.rightPic(p, pb))] = currentpic + "place=" + column + row;
                            });
                        }
                        else
                        {
                            rightPics.ForEach(pb =>
                            {
                                string currentpic = picInfo.Find(p => cinema.rightPic(p, pb)).Replace("true", "false");
                                cinema.SetImg(pb);
                                picInfo[picInfo.FindIndex(p => cinema.rightPic(p, pb))] = currentpic.Remove(currentpic.IndexOf("place="));
                            });
                        }
                    }
                    if (type=="row")
                    {
                        if (rightPics.Count == rowsCount * 2)
                        {
                            setPlaces();
                        }
                    }
                    else if (type == "column")
                    {
                        if (rightPics.Count == rowsCount)
                        {
                            setPlaces();
                        }
                    }
                });
            };
        }
    }
}
