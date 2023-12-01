using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClasesBase;
using Vistas;
namespace Vistas
{
    /// <summary>
    /// Interaction logic for WinWelcome.xaml
    /// </summary>
    public partial class Login : Window
    {

        public static Usuario usuarioLogueado;

        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            string username = ctrlLogin.Usuario;
            string password = ctrlLogin.Password;
            Console.WriteLine("\nCredenciales: " + username + " " + password + "\n");
            if (username != "" && password != "")
            {
                usuarioLogueado = ClasesBase.TrabajarUsuario.findUserByCredentials(username, password);
                if (usuarioLogueado != null)
                {

                    MessageBox.Show("Bienvenido Usuario:" + ctrlLogin.Usuario);

                    this.Hide();
                    Main ofrmMain = new Main();
                    VentanaPresentacion presentacion = new VentanaPresentacion();
                    presentacion.Show();
                    ofrmMain.Closed += (s, args) => this.Close();
                    ofrmMain.Show();
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas", "Ingresar Usuario");
                    Console.WriteLine("No se encontro el usuario: " + username);
                }
            }

            else
                MessageBox.Show("Ingrese un usuario y contraseña");
        }

        private void aboutUs_Click(object sender, RoutedEventArgs e)
        {
            AcercaDe acercaDe = new AcercaDe();
            acercaDe.Show();
            this.Close();
        }


    }
}
