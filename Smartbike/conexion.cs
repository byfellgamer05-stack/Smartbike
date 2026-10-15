using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartbike
{
    internal class conexion
    {
        public static 
            SQLiteConnection conectar() 
        {
            string cadenaConexion = @"Data Source=elite.db;Version=3;Busy Timeout=10000;Journal Mode=WAL;";
            SQLiteConnection con = new SQLiteConnection(cadenaConexion);
            con.Open(); 
            return con; 
        }
    }

}
    









