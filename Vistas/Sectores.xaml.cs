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
using System.Data;
using System.Data.SqlClient;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for VEP.xaml
    /// </summary>
    public partial class Sectores : Window
    {
        private SolidColorBrush greenBrush;
        private SolidColorBrush redBrush;
        private SolidColorBrush grayBrush;

        public int zona;
        // Crear una lista de sectores extendidos
        List<Sector> listaDeSectores = new List<Sector>();
        List<SectorExtendido> listaDeSectoresExtendidos = new List<SectorExtendido>();

        public Sectores(int zonaCodigo)
        {
            InitializeComponent();

            redBrush = new SolidColorBrush(Colors.Red);
            greenBrush = new SolidColorBrush(Colors.Green);
            grayBrush = new SolidColorBrush(Colors.Gray);

            this.zona = zonaCodigo;


            DataTable dtSectores = TrabajarSector.TraerSectoresPorZona(this.zona);
            foreach (DataRow row in dtSectores.Rows)
                listaDeSectores.Add(new Sector(Convert.ToInt32(row["Sec_SectorCodigo"]),
                             row["Sec_Descripcion"].ToString(),
                             row["Sec_Identificador"].ToString(),
                             Convert.ToBoolean(row["Sec_Habilitado"]),
                             Convert.ToInt32(row["Sec_ZonaCodigo"]),
                             row["Sec_Estado"].ToString()));

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Sector sector in listaDeSectores)
            {
                Button btn = ObtenerBotonPorIdentificador(sector.Sec_Identificador);

                if (sector.Sec_Habilitado)
                {
                    if (sector.Sec_Estado == "libre")
                    {
                        btn.Background = greenBrush; // Verde para sectores habilitados y libres
                    }
                    else if (sector.Sec_Estado == "ocupado")
                    {
                        btn.Background = redBrush; // Rojo para sectores habilitados y ocupados
                    }
                }
                else
                {
                    btn.Background = grayBrush; // Gris para sectores deshabilitados
                }
            }
        }


        private Button ObtenerBotonPorIdentificador(string identificador)
        {
            // Implementa la lógica para obtener el botón según el identificador.
            // Puedes utilizar un diccionario, una búsqueda en la interfaz gráfica, o alguna otra estructura de datos.
            // Por ejemplo, puedes tener un diccionario donde las claves sean los identificadores y los valores sean los botones correspondientes.
            // Este método debe devolver el botón asociado al identificador.

            // Ejemplo con un diccionario (asegúrate de inicializarlo previamente):
            Dictionary<string, Button> diccionarioBotones = new Dictionary<string, Button>
                {
                    {"E1", btnE1},
                    {"E2", btnE2},
                    {"E3", btnE3},
                    {"E4", btnE4},
                    {"E5", btnE5},
                    {"E6", btnE6},
                    {"E7", btnE7},
                    {"E8", btnE8},
                    {"E9", btnE9},
                    {"E10", btnE10},

                    // Agrega los demás botones aquí...
                };

            return diccionarioBotones[identificador];
        }

        private void btnE1_Click(object sender, RoutedEventArgs e)
        {
            if (btnE1.Background == greenBrush)
            {
                string contenidoBtnE1 = btnE1.Content.ToString();
                Sector sectorEncontrado = listaDeSectores.FirstOrDefault(s => s.Sec_Identificador == contenidoBtnE1);
                RegistrarEntrada registrarEntrada = new RegistrarEntrada(sectorEncontrado.Sec_SectorCodigo, this.zona);
                registrarEntrada.Show();
            }
            else if (btnE1.Background == redBrush)
            {
                string contenidoBtnE1 = btnE1.Content.ToString();
                Sector sectorEncontrado = listaDeSectores.FirstOrDefault(s => s.Sec_Identificador == contenidoBtnE1);
                RegistrarSalida registrarSalida = new RegistrarSalida(sectorEncontrado.Sec_SectorCodigo, this.zona);
                registrarSalida.Show();

            }
            else if (btnE1.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE2_Click(object sender, RoutedEventArgs e)
        {
            if (btnE2.Background == greenBrush)
            {
                string contenidoBtnE2 = btnE2.Content.ToString();
                Sector sectorEncontrado = listaDeSectores.FirstOrDefault(s => s.Sec_Identificador == contenidoBtnE2);
                RegistrarEntrada registrarEntrada = new RegistrarEntrada(sectorEncontrado.Sec_SectorCodigo, this.zona);
                registrarEntrada.Show();
            }
            else if (btnE2.Background == redBrush)
            {
                string contenidoBtnE2 = btnE2.Content.ToString();
                Sector sectorEncontrado = listaDeSectores.FirstOrDefault(s => s.Sec_Identificador == contenidoBtnE2);
                RegistrarSalida registrarSalida = new RegistrarSalida(sectorEncontrado.Sec_SectorCodigo, this.zona);
                registrarSalida.Show();
            }
            else if (btnE2.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE3_Click(object sender, RoutedEventArgs e)
        {
            if (btnE3.Background == greenBrush)
            {
                string contenidoBtnE3 = btnE3.Content.ToString();
                Sector sectorEncontrado = listaDeSectores.FirstOrDefault(s => s.Sec_Identificador == contenidoBtnE3);
                RegistrarEntrada registrarEntrada = new RegistrarEntrada(sectorEncontrado.Sec_SectorCodigo, this.zona);
                registrarEntrada.Show();
            }
            else if (btnE3.Background == redBrush)
            {
                string contenidoBtnE3 = btnE3.Content.ToString();
                Sector sectorEncontrado = listaDeSectores.FirstOrDefault(s => s.Sec_Identificador == contenidoBtnE3);
                RegistrarSalida registrarSalida = new RegistrarSalida(sectorEncontrado.Sec_SectorCodigo, this.zona);
                registrarSalida.Show();
            }
            else if (btnE3.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE4_Click(object sender, RoutedEventArgs e)
        {
            if (btnE4.Background == greenBrush)
            {
                string contenidoBtnE4 = btnE4.Content.ToString();
                Sector sectorEncontrado = listaDeSectores.FirstOrDefault(s => s.Sec_Identificador == contenidoBtnE4);
                RegistrarEntrada registrarEntrada = new RegistrarEntrada(sectorEncontrado.Sec_SectorCodigo, this.zona);
                registrarEntrada.Show();
            }
            else if (btnE4.Background == redBrush)
            {
                string contenidoBtnE4 = btnE4.Content.ToString();
                Sector sectorEncontrado = listaDeSectores.FirstOrDefault(s => s.Sec_Identificador == contenidoBtnE4);
                RegistrarSalida registrarSalida = new RegistrarSalida(sectorEncontrado.Sec_SectorCodigo, this.zona);
                registrarSalida.Show();
            }
            else if (btnE4.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE5_Click(object sender, RoutedEventArgs e)
        {
            if (btnE5.Background == greenBrush)
            {
                string contenidoBtnE5 = btnE5.Content.ToString();
                Sector sectorEncontrado = listaDeSectores.FirstOrDefault(s => s.Sec_Identificador == contenidoBtnE5);
                RegistrarEntrada registrarEntrada = new RegistrarEntrada(sectorEncontrado.Sec_SectorCodigo, this.zona);
                registrarEntrada.Show();
            }
            else if (btnE5.Background == redBrush)
            {
                string contenidoBtnE5 = btnE5.Content.ToString();
                Sector sectorEncontrado = listaDeSectores.FirstOrDefault(s => s.Sec_Identificador == contenidoBtnE5);
                RegistrarSalida registrarSalida = new RegistrarSalida(sectorEncontrado.Sec_SectorCodigo, this.zona);
                registrarSalida.Show();
            }
            else if (btnE5.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE6_Click(object sender, RoutedEventArgs e)
        {
            if (btnE6.Background == greenBrush)
            {
                string contenidoBtnE6 = btnE6.Content.ToString();
                Sector sectorEncontrado = listaDeSectores.FirstOrDefault(s => s.Sec_Identificador == contenidoBtnE6);
                RegistrarEntrada registrarEntrada = new RegistrarEntrada(sectorEncontrado.Sec_SectorCodigo, this.zona);
                registrarEntrada.Show();
            }
            else if (btnE6.Background == redBrush)
            {
                string contenidoBtnE6 = btnE6.Content.ToString();
                Sector sectorEncontrado = listaDeSectores.FirstOrDefault(s => s.Sec_Identificador == contenidoBtnE6);
                RegistrarSalida registrarSalida = new RegistrarSalida(sectorEncontrado.Sec_SectorCodigo, this.zona);
                registrarSalida.Show();
            }
            else if (btnE6.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE7_Click(object sender, RoutedEventArgs e)
        {
            if (btnE7.Background == greenBrush)
            {
                string contenidoBtnE7 = btnE7.Content.ToString();
                Sector sectorEncontrado = listaDeSectores.FirstOrDefault(s => s.Sec_Identificador == contenidoBtnE7);
                RegistrarEntrada registrarEntrada = new RegistrarEntrada(sectorEncontrado.Sec_SectorCodigo, this.zona);
                registrarEntrada.Show();
            }
            else if (btnE7.Background == redBrush)
            {
                string contenidoBtnE7 = btnE7.Content.ToString();
                Sector sectorEncontrado = listaDeSectores.FirstOrDefault(s => s.Sec_Identificador == contenidoBtnE7);
                RegistrarSalida registrarSalida = new RegistrarSalida(sectorEncontrado.Sec_SectorCodigo, this.zona);
                registrarSalida.Show();
            }
            else if (btnE7.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE8_Click(object sender, RoutedEventArgs e)
        {
            if (btnE8.Background == greenBrush)
            {
                string contenidoBtnE8 = btnE8.Content.ToString();
                Sector sectorEncontrado = listaDeSectores.FirstOrDefault(s => s.Sec_Identificador == contenidoBtnE8);
                RegistrarEntrada registrarEntrada = new RegistrarEntrada(sectorEncontrado.Sec_SectorCodigo, this.zona);
                registrarEntrada.Show();
            }
            else if (btnE8.Background == redBrush)
            {
                string contenidoBtnE8 = btnE8.Content.ToString();
                Sector sectorEncontrado = listaDeSectores.FirstOrDefault(s => s.Sec_Identificador == contenidoBtnE8);
                RegistrarSalida registrarSalida = new RegistrarSalida(sectorEncontrado.Sec_SectorCodigo, this.zona);
                registrarSalida.Show();
            }
            else if (btnE8.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE9_Click(object sender, RoutedEventArgs e)
        {
            if (btnE9.Background == greenBrush)
            {
                string contenidoBtnE9 = btnE9.Content.ToString();
                Sector sectorEncontrado = listaDeSectores.FirstOrDefault(s => s.Sec_Identificador == contenidoBtnE9);
                RegistrarEntrada registrarEntrada = new RegistrarEntrada(sectorEncontrado.Sec_SectorCodigo, this.zona);
                registrarEntrada.Show();
            }
            else if (btnE9.Background == redBrush)
            {
                string contenidoBtnE9 = btnE9.Content.ToString();
                Sector sectorEncontrado = listaDeSectores.FirstOrDefault(s => s.Sec_Identificador == contenidoBtnE9);
                RegistrarSalida registrarSalida = new RegistrarSalida(sectorEncontrado.Sec_SectorCodigo, this.zona);
                registrarSalida.Show();
            }
            else if (btnE9.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE10_Click(object sender, RoutedEventArgs e)
        {
            if (btnE10.Background == greenBrush)
            {
                string contenidoBtnE10 = btnE10.Content.ToString();
                Sector sectorEncontrado = listaDeSectores.FirstOrDefault(s => s.Sec_Identificador == contenidoBtnE10);
                RegistrarEntrada registrarEntrada = new RegistrarEntrada(sectorEncontrado.Sec_SectorCodigo, this.zona);
                registrarEntrada.Show();
            }
            else if (btnE10.Background == redBrush)
            {
                string contenidoBtnE10 = btnE10.Content.ToString();
                Sector sectorEncontrado = listaDeSectores.FirstOrDefault(s => s.Sec_Identificador == contenidoBtnE10);
                RegistrarSalida registrarSalida = new RegistrarSalida(sectorEncontrado.Sec_SectorCodigo, this.zona);
                registrarSalida.Show();
            }
            else if (btnE10.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnE1_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E1");
        }

        private void btnE2_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E2");
        }

        private void btnE3_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E3");
        }

        private void btnE4_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E4");
        }

        private void btnE5_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E5");
        }

        private void btnE6_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E6");
        }

        private void btnE7_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E7");
        }

        private void btnE8_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E8");
        }

        private void btnE9_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E9");
        }

        private void btnE10_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E10");
        }


        private decimal CalcularMontoPagar(TimeSpan tiempoOcupado, decimal tarifaPorHora)
        {
            // Calcular el monto a pagar multiplicando la tarifa por la cantidad de horas ocupadas
            decimal montoTotal = tarifaPorHora * (decimal)tiempoOcupado.TotalHours;

            return montoTotal;
        }


        private void mostrarEstadoSector(string identificadorSector)
        {
            // Filtra la lista por identificador
            Sector sectorEncontrado = listaDeSectores.FirstOrDefault(s => s.Sec_Identificador == identificadorSector);


            if (sectorEncontrado != null)
            {
                Button boton = ObtenerBotonPorIdentificador(identificadorSector);
                if (boton != null)
                {
                    if (sectorEncontrado.Sec_Habilitado)
                    {

                        if (sectorEncontrado.Sec_Estado == "libre")
                        {
                            boton.ToolTip = new ToolTip { Content = "Estado: " + sectorEncontrado.Sec_Estado };

                        }
                        else if (sectorEncontrado.Sec_Estado == "ocupado")
                        {
                            boton.ToolTip = new ToolTip { Content = "Estado: " + sectorEncontrado.Sec_Estado };
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No se encontró ningún sector con el identificador " + identificadorSector);
            }

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Sectores sector = new Sectores(this.zona);
            sector.Show();
            this.Close();

        }




    }
}