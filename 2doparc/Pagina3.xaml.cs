using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _2doparc
{
    /// <summary>
    /// Lógica de interacción para Pagina3.xaml
    /// </summary>
    public partial class Pagina3 : Window
    {
        public Pagina3()
        {
            InitializeComponent();
            try
            {
                SqlConnection con1;
                con1 = Conexion.agregarConexion();
                string query1 = "select cp.idProd, c.monto, c.fecha from CompraProducto cp inner join compra c on cp.idCompra = c.idCompra where c.idCompra = 1";
                SqlCommand cmd1 = new SqlCommand(query1, con1);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dGDisplay.ItemsSource = dt.DefaultView;
                con1.Close();
                /*
                try
                {
                    SqlConnection con2;
                    con2 = Conexion.agregarConexion();
                    string query2 = "select c.idCompra, c.monto, c.fecha from Compra c inner join Cliente cl on c.nomUsuario = cl.nomUsuario where cl.nomUsuario = 'aniel'";
                    SqlCommand cmd2 = new SqlCommand(query2, con2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("algo fallo" + ex);
                } */
            }
            catch (Exception ex) 
            {
                MessageBox.Show("algo fallo" + ex);
            }

        }

        private void tbID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btMasInfo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
