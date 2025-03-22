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
        public static string idUsuario = "aniel";
        public static string tipo = "Cliente";
        public static int idCompra = 6;
        public Pagina3()
        {
            InitializeComponent();
            try
            {
                //se despliegan todos los productos de la Compra
                SqlConnection con1;
                con1 = Conexion.agregarConexion();
                string query1 = String.Format("select cp.idProd, c.monto, c.fecha from CompraProducto cp inner join compra c on cp.idCompra = c.idCompra where c.idCompra = {0}", idCompra);
                SqlCommand cmd1 = new SqlCommand(query1, con1);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dGDisplay.ItemsSource = dt.DefaultView;
                con1.Close();

                //Obtengo el id en la primera fila y columna
                object firstColumnValue = null;
                int primerDato = 0;
                if (dGDisplay.Items.Count > 0)
                {
                    DataRowView firstRow = dGDisplay.Items[0] as DataRowView;
                    if (firstRow != null)
                    {
                        firstColumnValue = firstRow[0];
                        primerDato = Convert.ToInt32(firstColumnValue);
                    }
                }
                displayDatosProducto(primerDato);

            }
            catch (Exception ex) 
            {
                MessageBox.Show("algo fallo" + ex);
            }

        }

        private void displayDatosProducto(int idProd)
        {
            //Display datos del primerDato
            SqlConnection con2;
            con2 = Conexion.agregarConexion();
            string query2 = String.Format("select p.fechaPosteo, p.fechaVenta, p.precioBase, p.caducidad, p.descuento, p.cantidadStock, p.precioFinal from Producto p where p.idProd = {0}", idProd);
            SqlCommand cmd2 = new SqlCommand(query2, con2);
            SqlDataReader lector = cmd2.ExecuteReader();
            if (lector != null)
            {
                lector.Read();
                txBkDatePost.Text = lector.GetDateTime(0).ToString();
                txBkSellDate.Text = lector.GetDateTime(1).ToString();
                txBkPrecioBase.Text = lector.GetInt16(2).ToString();
                txBkCaducidad.Text = lector.GetDateTime(3).ToString();
                txBkDescuento.Text = lector.GetDecimal(4).ToString();
                txBkCantidad.Text = lector.GetInt16(5).ToString();
                txBkPrecioFinal.Text = lector.GetDecimal(6).ToString();

            }
            con2.Close();
        }

        private void tbID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btMasInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int idProd = Convert.ToInt32(tbID.Text);
                displayDatosProducto(idProd);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Revisa que el id sea correcto" + ex);
            }
        }
    }
}
