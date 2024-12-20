using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoRudnev
{
    public static class Paths
    {
        private static string START_PATH = Application.StartupPath.Remove(Application.StartupPath.IndexOf("bin"));
        public static string DB_PATH = START_PATH.Replace(@"/", "\\") + "Properties/db/Cinema.mdf".Replace(@"/", "\\");
        public static string IMG_FOLDER = START_PATH.Replace(@"\", "/") + "Properties/img/";
        public static string TICKETS_FOLDER = START_PATH.Replace(@"\", "/") + "Properties/tickets/";
        public static string TICKET_FOLDER = START_PATH.Replace(@"\", "/") + "Properties/tickets/ticket/";
        public static string CODES_FOLDER = START_PATH.Replace(@"\", "/") + "Properties/tickets/codes/";
        public static string ALL_TICKETS = START_PATH.Replace(@"\", "/") + "Properties/tickets/allTickets/Tickets.pdf";
        public static string ALL_FOLDER = START_PATH.Replace(@"\", "/") + "Properties/tickets/allTickets/";
    }
}
