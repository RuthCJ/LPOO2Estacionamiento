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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for ABMSector.xaml
    /// </summary>
    public partial class ABMSector : Window
    {
        public ABMSector()
        {
            InitializeComponent();
            VentanaManager.Instance.agregarVentana(this);
            VentanaManager.Instance.mostrarVentanasAbiertas();
            loadZonas();
            btnEliminar.IsEnabled = false;
            btnModificar.IsEnabled = false;
            btnRegistrar.IsEnabled = false;
            btnBuscar.IsEnabled = false;
        }

        private void loadZonas()
        {
            List<Zona> zonas = TrabajarZonas.TraerZonas();
            cmbCodZona.ItemsSource = zonas;
            cmbCodZona.DisplayMemberPath = "Zona_ZonaCodigo";
            cmbCodZona.SelectedValuePath = "Zona_ZonaCodigo";
        }


        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (formLleno())
            {
                int codigoSector = 0;
                if (int.TryParse(txtCodSector.Text, out codigoSector))
                {
                    int zonaCodigo = (int)cmbCodZona.SelectedValue;

                    Sector nuevoSector = new Sector
                    {
                        Sec_SectorCodigo = codigoSector,
                        Sec_ZonaCodigo = zonaCodigo,
                        Sec_Identificador = txtId.Text,
                        Sec_Descripcion = txtDesc.Text,
                        Sec_Habilitado = chkHabilitado.IsChecked ?? false 
                    };

                    Console.WriteLine(nuevoSector);

                    if (nuevoSector != null)
                    {
                        if (MessageBox.Show("¿Desea registrar el sector?", "Registrar Sector", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            TrabajarSector.AgregarSector(nuevoSector);
                            LimpiarCampos();
                            MessageBox.Show("Sector Guardado con Éxito!\nDatos del Sector Guardado: \n" + nuevoSector, "Éxito");
                            btnRegistrar.IsEnabled = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese valores numéricos válidos para Código y Zona Código", "Error");
                }
            }
            else
            {
                MessageBox.Show("Ingrese datos en todos los campos", "Error");
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (formLleno() && btnModificar.IsEnabled==true)
            {
                int codigoSector = 0;
                if (int.TryParse(txtCodSector.Text, out codigoSector))
                {
                    int zonaCodigo = (int)cmbCodZona.SelectedValue;

                    Sector nuevoSector = new Sector
                    {
                        Sec_SectorCodigo = codigoSector,
                        Sec_ZonaCodigo = zonaCodigo,
                        Sec_Identificador = txtId.Text,
                        Sec_Descripcion = txtDesc.Text,
                        Sec_Habilitado = chkHabilitado.IsChecked ?? false
                    };

                    Console.WriteLine(nuevoSector);

                    if (nuevoSector != null)
                    {
                        if (MessageBox.Show("¿Desea modificar el sector?", "Modificar Sector", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            TrabajarSector.ModificarSector(nuevoSector);
                            LimpiarCampos();
                            MessageBox.Show("Sector Modificado con Éxito!\nDatos del Sector Modificado: \n" + nuevoSector, "Éxito");
                            btnRegistrar.IsEnabled = false;
                            btnBuscar.IsEnabled = false;
                            btnModificar.IsEnabled = false;
                            btnEliminar.IsEnabled = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese valores numéricos válidos para Código y Zona Código", "Error");
                }
            }
            else
            {
                MessageBox.Show("Ingrese datos en todos los campos", "Error");
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int codigoSector = 0;

            if (int.TryParse(txtCodSector.Text, out codigoSector) && btnEliminar.IsEnabled == true)
            {
                Sector sectorEncontrado = TrabajarSector.BuscarSectorPorCodigo(codigoSector);

                if (sectorEncontrado != null)
                {
                    if (MessageBox.Show("¿Desea eliminar el sector?", "Eliminar Sector", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        TrabajarSector.EliminarSector(sectorEncontrado.Sec_SectorCodigo);
                        LimpiarCampos();
                        MessageBox.Show("Sector Eliminado");

                        btnEliminar.IsEnabled = false;
                        btnModificar.IsEnabled = false;
                        btnRegistrar.IsEnabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró un sector con el codigo proporcionado", "Sector no encontrado");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un codigo válido antes de intentar eliminar", "Error de Validación");
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            int codigoABuscar = 0;
            if (int.TryParse(textBuscar.Text, out codigoABuscar))
            {

                Sector sectorEncontrado = TrabajarSector.BuscarSectorPorCodigo(codigoABuscar);

                if (sectorEncontrado != null)
                {
                    txtCodSector.Text = sectorEncontrado.Sec_SectorCodigo.ToString();
                    txtId.Text = sectorEncontrado.Sec_Identificador;
                    txtDesc.Text = sectorEncontrado.Sec_Descripcion;
                    chkHabilitado.IsChecked = sectorEncontrado.Sec_Habilitado;
                    cmbCodZona.SelectedValue = sectorEncontrado.Sec_ZonaCodigo;

                    MessageBox.Show("Sector encontrado:\n" + sectorEncontrado, "Éxito");

                    btnRegistrar.IsEnabled = false;
                    btnEliminar.IsEnabled = true;
                    btnModificar.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("No se encontró ningún Sector con el código proporcionado.", "Información");
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Ingrese un código válido para buscar el Sector.", "Error");
                LimpiarCampos();
            }
            textBuscar.Clear();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
            btnRegistrar.IsEnabled = false;
        }


        private void btnSectores_Click(object sender, RoutedEventArgs e)
        {
            GrillaSectores sectores = new GrillaSectores();
            sectores.ShowDialog();
            // Sectores sectores2 = new Sectores(1);
            // sectores2.Show();
        }

        private void btnSectoresOcupados_Click(object sender, RoutedEventArgs e)
        {
            SectoresOcupados sectoresOcupadosWindow = new SectoresOcupados();
            sectoresOcupadosWindow.ShowDialog();
        }

        private void btnEstadoSector_Click(object sender, RoutedEventArgs e)
        {
            EstadoSector estadoSector = new EstadoSector();
            estadoSector.ShowDialog();
        }


        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Main ofrmMain = new Main();
            ofrmMain.Closed += (s, args) => this.Close();
            ofrmMain.Show();
        }

        private void LimpiarCampos()
        {
            txtCodSector.Clear();
            cmbCodZona.SelectedItem = null;
            txtId.Clear();
            txtDesc.Clear();
            chkHabilitado.IsChecked = false;
        }

        private bool formLleno()
        {
            return !string.IsNullOrEmpty(txtCodSector.Text) && cmbCodZona.SelectedItem != null &&
           !string.IsNullOrEmpty(txtId.Text) && !string.IsNullOrEmpty(txtDesc.Text);
        }

        private void textBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnBuscar.IsEnabled = !string.IsNullOrEmpty(textBuscar.Text);
        }


        private void cmbCodZona_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (btnModificar.IsEnabled != true)
                btnRegistrar.IsEnabled = formLleno();
        }

        private void txtChanged(object sender, TextChangedEventArgs e)
        {
            if (btnModificar.IsEnabled != true)
                btnRegistrar.IsEnabled = formLleno();
        }


    }
}
