﻿using System;
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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for MenuPrincipalWindow.xaml

    /// </summary>
    /// 

    public partial class Main : Window
    {

        private Usuario usuarioLogueado;
        private ABMVehiculo ventanaVehiculo;
        private ABMUsuario ventanaUsuario;
        private ABMCliente ventanaCliente;
        private Ventas ventanaVentas;
        private Zonas ventanaZonas;

        public Main()
        {
            Usuario u = Login.usuarioLogueado;

            InitializeComponent();
            usuarioLogueado = u;
            VentanaManager.Instance.agregarVentana(this);
            VentanaManager.Instance.mostrarVentanasAbiertas();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            switch (usuarioLogueado.Usr_Rol)
            {
                case "Admin": // Administrador
                    // Oculta elementos del menú que no necesita

                    // menuGestionClientes.Visibility = Visibility.Collapsed;
                    // menuGestionEstacionamiento.Visibility = Visibility.Collapsed;

                    break;

                case "Operador": // Operador
                    // Oculta elementos del menú que no necesita
                    btnSectores.Visibility = Visibility.Collapsed;
                    btnTiposVehiculo.Visibility = Visibility.Collapsed;
                    btnUsuarios.Visibility = Visibility.Collapsed;
                    break;

                default:
                    // Oculta todos los elementos del menú si el rol no coincide con ninguno de los casos anteriores
                    btnSectores.Visibility = Visibility.Collapsed;
                    btnTiposVehiculo.Visibility = Visibility.Collapsed;
                    btnUsuarios.Visibility = Visibility.Collapsed;
                    break;
            }


        }

        private void menuSectores_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ABMSector ofrm = new ABMSector();
            ofrm.Closed += (s, args) => this.Close();
            ofrm.Show();


        }

        private void btnUsuarioActual_Click(object sender, RoutedEventArgs e)
        {
            if (usuarioLogueado != null)
            {
                MessageBox.Show(usuarioLogueado.ToString(), "Datos del Usuario Logueado");
            }
            else
            {
                MessageBox.Show("No hay usuario logueado.", "Error");
            }

        }

        private void btnSectores_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ABMSector ofrm = new ABMSector();
            ofrm.Closed += (s, args) => this.Close();
            ofrm.Show();
        }

        private void btnTiposVehiculo_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ABMVehiculo ofrm = new ABMVehiculo();
            ofrm.Closed += (s, args) => this.Close();
            ofrm.Show();
        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            // Verificar si la ventana ya está abierta o si la instancia es nula
            if (ventanaUsuario == null || !ventanaUsuario.IsVisible)
            {
                // Crear una nueva instancia de ABMUsuario
                ventanaUsuario = new ABMUsuario();

                // Manejar el evento Closed para establecer la instancia en nula cuando se cierre la ventana
                ventanaUsuario.Closed += (s, args) => ventanaUsuario = null;

                // Mostrar la ventana
                ventanaUsuario.ShowDialog();
            }
            else
            {
                // Si la ventana está abierta, enfocarla
                ventanaUsuario.Focus();
            }
        }

        private void btnZonas_Click(object sender, RoutedEventArgs e)
        {
            if (ventanaZonas == null || !ventanaZonas.IsVisible)
            {
                // Crear una nueva instancia de ABMUsuario
                ventanaZonas = new Zonas();

                // Manejar el evento Closed para establecer la instancia en nula cuando se cierre la ventana
                ventanaZonas.Closed += (s, args) => ventanaZonas = null;

                // Mostrar la ventana
                ventanaZonas.ShowDialog();
            }
        }

        private void btnVentaTickets_Click(object sender, RoutedEventArgs e)
        {

            if (ventanaVentas == null || !ventanaVentas.IsVisible)
            {
                // Crear una nueva instancia de ABMUsuario
                ventanaVentas = new Ventas();

                // Manejar el evento Closed para establecer la instancia en nula cuando se cierre la ventana
                ventanaVentas.Closed += (s, args) => ventanaVentas = null;

                // Mostrar la ventana
                ventanaVentas.ShowDialog();
            }


        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            // Cargar el UserControl de gestión de clientes
            // ABMCliente clienteWindow = new ABMCliente();
            // contentControl.Content = clienteUserControl;

            // Verificar si la ventana ya está abierta o si la instancia es nula
            if (ventanaCliente == null || !ventanaCliente.IsVisible)
            {
                // Crear una nueva instancia de ABMUsuario
                ventanaCliente = new ABMCliente();

                // Manejar el evento Closed para establecer la instancia en nula cuando se cierre la ventana
                ventanaCliente.Closed += (s, args) => ventanaCliente = null;

                // Mostrar la ventana
                ventanaCliente.ShowDialog();
            }
        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login ofrm = new Login();
            ofrm.Closed += (s, args) => this.Close();
            ofrm.Show();
        }
    }
}