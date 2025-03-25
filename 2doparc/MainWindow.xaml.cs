using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data.SqlClient;

namespace _2doparc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlDataReader dr;
            SqlConnection con;
            SqlCommand cmd;
            try
            {
                con = Conexion.agregarConexion();
                cmd = new SqlCommand(String.Format("select contraseña from Usuario u where u.nomUsuario = '{0}' and u.tipo = 'Admins'", adimTxtBox.Text), con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr.GetString(0).Equals(contraTxtBox.Text))
                    {
                        Pagina1 p1 = new Pagina1();
                        p1.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("contraseña equivocada :)");
                    }
                }
                else
                {
                    MessageBox.Show("usuario equivocado :)");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error:" + ex);
            }

        }
    }
}
