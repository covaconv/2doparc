using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _2doparc
{
    class Conexion
    {
        public static SqlConnection agregarConexion()
        {
            SqlConnection cnn;
            try
            {
                cnn = new SqlConnection("Data Source=macareno;Initial Catalog =dbComida; User ID = sa; Password = sqladmin21"); //String conexión Ro: 
                //cnn = new SqlConnection("Data Source=LapAniel;Initial Catalog =dbComida; User ID = sa; Password = sqladmin21");
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

        public static void busquedaClientes(string nombre, DataGrid dgClientes)
        {
            try
            {
                string query = "";
                if (nombre == "nomUsuario")
                {
                    query = String.Format("select c.nomUsuario, c.nomPila, c.apellidoPat, c.apellidoMat from Cliente c");
                }
                else
                {
                    query = String.Format("select c.nomUsuario, c.nomPila, c.apellidoPat, c.apellidoMat from Cliente c where nomUsuario like '%{0}%'", nombre);
                }
                SqlConnection cnn = agregarConexion();
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dgClientes.ItemsSource = dr;
                    dgClientes.Items.Refresh();
                }
                else
                {
                    dgClientes.ItemsSource = null;
                    dgClientes.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló búsqueda Clientes. " + ex);

            }
        }

        public static void busquedaEmpresas(string nombre, DataGrid dgEmpresas)
        {
            try
            {
                string query = "";
                if (nombre == "nomUsuario")
                {
                    query = String.Format("select e.nomUsuario from Empresa e");
                }
                else
                {
                    query = String.Format("select e.nomUsuario from Empresa e where nomUsuario like '%{0}%'", nombre);
                }
                SqlConnection cnn = agregarConexion();
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dgEmpresas.ItemsSource = dr;
                    dgEmpresas.Items.Refresh();
                }
                else
                {
                    dgEmpresas.ItemsSource = null;
                    dgEmpresas.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló búsqueda Empresas. " + ex);
            }
        }
    }
}
