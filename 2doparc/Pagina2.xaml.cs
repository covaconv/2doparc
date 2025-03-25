using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
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
    /// Lógica de interacción para Pagina2.xaml
    /// </summary>
    public partial class Pagina2 : Window
    {
        public static string nomUsuario= "aniel"; //Application.Current.Properties["nomUsuario"].ToString();
        public static string tipo= "Cliente"; //Application.Current.Properties["tipo"].ToString();
        //public static int idCompra = 5;
        

        [Obsolete]
        public Pagina2()
        {
            InitializeComponent();
            try
            {
                //líneas temp
                Application.Current.Properties["nomUsuario"] = "aniel";
                Application.Current.Properties["tipo"] = "Cliente";
                //--------------------------------------------------
                SqlConnection con = Conexion.agregarConexion();
                if (tipo.Equals("Cliente"))
                {
                    lbTit.Content = "Compras: ";
              
                    //Añadir teléfono
                    string queryTel = String.Format("select Cliente.tel from Cliente where Cliente.nomUsuario = '{0}'", nomUsuario);
                    SqlCommand cmdTel = new SqlCommand(queryTel, con);
                    SqlDataReader drTel = cmdTel.ExecuteReader();
                    if (drTel.Read())
                    {
                        lBoxTel.Items.Add(drTel.GetString(0));
                    }


                    drTel.Close();

                    //Añadir nombre del cliente
                    string queryNombre = String.Format("select nomPila, apellidoPat, apellidoMat from Cliente where Cliente.nomUsuario = 'aniel'", nomUsuario);
                    SqlCommand cmdNombre = new SqlCommand(queryNombre, con);
                    SqlDataReader drNombre = cmdNombre.ExecuteReader();
                    if (drNombre.Read())
                    {
                        string nom = String.Format("{0} {1} {2}", drNombre.GetString(0), drNombre.GetString(1), drNombre.GetString(2));
                        tbNombre.Text = nom;
                    }
                    else
                    {
                        tbNombre.Text = "No existe el usuario";
                    }
                    drNombre.Close();

                    //Añadir datos tabla
                    string queryTabla = String.Format("select Compra.idCompra, Compra.fecha, Compra.monto, COUNT(*) as cantidadProductos from Compra inner join CompraProducto on CompraProducto.idCompra=Compra.idCompra where Compra.nomUsuario = '{0}' group by Compra.idCompra, Compra.fecha, Compra.monto", nomUsuario);
                    SqlCommand cmdTabla = new SqlCommand(queryTabla, con);
                    SqlDataAdapter daTabla = new SqlDataAdapter(cmdTabla);
                    DataTable dtTabla = new DataTable();
                    daTabla.Fill(dtTabla);
                    dgDatos.ItemsSource = dtTabla.DefaultView;
                    

                }
                else
                {
                    tboxID.Text = "No es necesario ingresar id";
                    //Añadir nombre de la empresa
                    lbTit.Content = "Merma ofrecida: ";
                    string queryNombre = String.Format("select Empresa.nombre from Empresa where Empresa.nomUsuario='ITAM'", nomUsuario);
                    SqlCommand cmdNombre = new SqlCommand(queryNombre, con);
                    SqlDataReader drNombre = cmdNombre.ExecuteReader();
                    if (drNombre.Read())
                    {
                        string nom = String.Format("{0}", drNombre.GetString(0));
                        tbNombre.Text = nom;
                    }
                    else
                    {
                        tbNombre.Text = "No existe el usuario";
                    }
                    drNombre.Close();

                    //Añadir teléfonos
                    string queryTel = String.Format("select Telefono.telefono from Telefono where Telefono.nomUsuario = 'ITAM'", nomUsuario);
                    SqlCommand cmdTel = new SqlCommand(queryTel, con);
                    SqlDataReader drTel = cmdTel.ExecuteReader();

                    while (drTel.Read())
                    {
                        lBoxTel.Items.Add(drTel.GetString(0));
                    }
                    drTel.Close();

                    //Añadir dirección
                    string queryDir = String.Format("select Empresa.estado, Empresa.municipio, Empresa.colonia, Empresa.calle, Empresa.CP from Empresa where Empresa.nomUsuario = '{0}'",nomUsuario);
                    SqlCommand cmdDir = new SqlCommand(queryDir, con);
                    SqlDataReader dDir = cmdDir.ExecuteReader();
                    if (dDir.Read())
                    {
                        string dir = String.Format("{0} {1} {2} {3} {4}", dDir.GetString(0), dDir.GetString(1), dDir.GetString(2), dDir.GetString(3), dDir.GetInt32(4));
                        tbDireccion.Text = dir;
                    }
                    dDir.Close();

                    //Añadir administrador
                    string queryAdmin = String.Format("select Empresa.administrador from Empresa where Empresa.nomUsuario = '{0}'", nomUsuario);
                    SqlCommand cmdAdmin = new SqlCommand(queryAdmin, con);
                    SqlDataReader drAdmin = cmdAdmin.ExecuteReader();
                    if (drAdmin.Read())
                    {
                        tbAdmin.Text = drAdmin.GetString(0);
                    }
                    drAdmin.Close();
                    //Añadir datos tabla
                    string queryTabla = String.Format("select Producto.idProd, Producto.precioFinal, Producto.fechaPosteo from Producto inner join Empresa on Empresa.nomUsuario=Producto.nomUsuario where Empresa.nomUsuario = '{0}'", nomUsuario);
                    SqlCommand cmdTabla = new SqlCommand(queryTabla, con);
                    SqlDataAdapter daTabla = new SqlDataAdapter(cmdTabla);
                    DataTable dtTabla = new DataTable();
                    daTabla.Fill(dtTabla);
                    dgDatos.ItemsSource = dtTabla.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error " + ex);
            }
        }

        private void dgDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listBoxTel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btRegresar_Click(object sender, RoutedEventArgs e)
        {
            Pagina2 pagina = new Pagina2();
            pagina.Show();
            this.Close();
        }

        private void btDetalles_Click(object sender, RoutedEventArgs e)
        {
           
                if (tipo.Equals("Cliente"))
                {
                    int idCompra = int.Parse(tboxID.Text);
                    Application.Current.Properties["idCompra"] = idCompra;
                }
                else
                {
                    Application.Current.Properties["idCompra"] = 0;
                }
                Pagina3 pagina = new Pagina3();
                pagina.Show();
                this.Close();
            
            }
        

        private void lBoxTel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
