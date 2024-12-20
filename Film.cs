using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoRudnev
{
    public class Film
    {
        public static List<Film> films = new List<Film>();
        public string filmName;
        public int rowsCount;
        public bool _3D;
        public int year;
        public int duration;
        public double rating;
        public string imageSrc;
        public bool choosen = false;
    }
}
