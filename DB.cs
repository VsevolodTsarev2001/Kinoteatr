using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoRudnev
{
    public class DB
    {
        public static SqlConnection SQL_CON  = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Paths.DB_PATH};Integrated Security=True;Connect Timeout=30");
    }
}
