using System;
using System.Collections.Generic;
using System.Data;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _2doparc
{
    /// <summary>
    /// Lógica de interacción para Pagina1.xaml
    /// </summary>
    public partial class Pagina1 : Window
    {
        public Pagina1()
        {
            InitializeComponent();
        }

        private void txClientes_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btClientes_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txClientes.Text;
            Conexion.busquedaClientes(nombre, dgClientes);
        }

        private void btEmpresas_Click(object sender, RoutedEventArgs e)
        {
            string nomEmpresa = txEmpresas.Text;
            Conexion.busquedaEmpresas(nomEmpresa, dgEmpresas);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string nombre = txClientes.Text;
            Conexion.busquedaClientes(nombre, dgClientes);
            string nomEmpresa = txEmpresas.Text;
            Conexion.busquedaEmpresas(nomEmpresa, dgEmpresas);
        }

        private void btTodosClientes_Click(object sender, RoutedEventArgs e)
        {
            Conexion.busquedaClientes("nomUsuario", dgClientes);
        }

        private void btTodosEmpresas_Click(object sender, RoutedEventArgs e)
        {
            Conexion.busquedaEmpresas("nomUsuario", dgEmpresas);
        }

        private void btDetallesClientes_Click(object sender, RoutedEventArgs e)
        {
            string nomUsuario = txClientes.Text;
            Application.Current.Properties["nomUsuario"] = nomUsuario;
            Application.Current.Properties["tipo"] = "Cliente";
            Pagina2 pagina = new Pagina2();
            pagina.Show();
            this.Close();
        }

        private void dgClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btDetallesEmpresas_Click(object sender, RoutedEventArgs e)
        {
            string nomUsuario = txEmpresas.Text;
            Application.Current.Properties["nomUsuario"] = nomUsuario;
            Application.Current.Properties["tipo"] = "Empresa";
            Pagina2 pagina = new();
            pagina.Show();
            this.Hide();
        }
    }
}
