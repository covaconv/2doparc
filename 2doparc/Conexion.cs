using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2doparc
{
    class Conexion
    {
        public static SqlConnection agregarConexion()
        {
            SqlConnection cnn;
            try
            {
                //cnn = new SqlConnection("Data Source=macareno;Initial Catalog =dbComida; User ID = sa; Password = sqladmin21"); //String conexión Ro: 
                cnn = new SqlConnection("Data Source=LapAniel;Initial Catalog =dbComida; User ID = sa; Password = sqladmin21");
                cnn.Open();
                //MessageBox.Show("Se conecto");
            }
            catch (Exception ex)
            {
                cnn = null;
                MessageBox.Show("no se pudo conectar" + ex);
            }
            return cnn;
        }
    }
}
