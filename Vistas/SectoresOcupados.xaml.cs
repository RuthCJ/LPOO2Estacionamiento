using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for SectoresOcupados.xaml
    /// </summary>
    public partial class SectoresOcupados : Window
    {
        private List<DataRow> _data;

        public SectoresOcupados()
        {
            InitializeComponent();
            CargarSectoresOcupados();
        }

        private void CargarSectoresOcupados()
        {
            try
            {
                // Obtener DataTable con los sectores ocupados
                DataTable dtSectoresOcupados = TrabajarSector.TraerSectoresOcupados();

                // Calcular tiempo transcurrido
                foreach (DataRow row in dtSectoresOcupados.Rows)
                {
                    if (row["tkt_FechaHoraEnt"] != DBNull.Value)
                    {
                        DateTime fechaEntrada = Convert.ToDateTime(row["tkt_FechaHoraEnt"]);
                        TimeSpan tiempoTranscurrido = DateTime.Now - fechaEntrada;
                        row["TiempoTranscurrido"] = String.Format("{0}hs {1}m", tiempoTranscurrido.Hours, tiempoTranscurrido.Minutes);
                    }
                }
                // Asignar el DataTable al DataGrid


                dtSectoresOcupados.Columns["sec_Descripcion"].SetOrdinal(0);
                dtSectoresOcupados.Columns["sec_Descripcion"].ColumnName = "Sector";

                dtSectoresOcupados.Columns["tkt_FechaHoraEnt"].SetOrdinal(1);
                dtSectoresOcupados.Columns["tkt_FechaHoraEnt"].ColumnName = "Hora de Entrada";

                dtSectoresOcupados.Columns["Cliente"].SetOrdinal(2);
                dtSectoresOcupados.Columns["Cliente"].ColumnName = "Cliente";

                dtSectoresOcupados.Columns["TipoVehiculo"].SetOrdinal(3);
                dtSectoresOcupados.Columns["TipoVehiculo"].ColumnName = "Tipo de Vehículo";

                dtSectoresOcupados.Columns["tkt_Patente"].SetOrdinal(4);
                dtSectoresOcupados.Columns["tkt_Patente"].ColumnName = "Patente";

                dtSectoresOcupados.Columns["TiempoTranscurrido"].SetOrdinal(5);
                dtSectoresOcupados.Columns["TiempoTranscurrido"].ColumnName = "Tiempo Transcurrido";

                dtSectoresOcupados.Columns.RemoveAt(6);
                dtSectoresOcupados.Columns.RemoveAt(6);
                dtSectoresOcupados.Columns.RemoveAt(6);
                dtSectoresOcupados.Columns.RemoveAt(6);

                dgSecOcupados.ItemsSource = dtSectoresOcupados.DefaultView;

                // Guardar los datos para imprimir
                _data = new List<DataRow>();
                foreach (DataRow row in dtSectoresOcupados.Rows)
                {
                    _data.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar sectores ocupados: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private FlowDocument CrearFlowDocument(List<DataRow> data)
        {
            FlowDocument flowDocument = new FlowDocument();

            foreach (DataRow row in data)
            {
                Paragraph paragraph = new Paragraph();

                paragraph.Inlines.Add(new Run("Sector: " + row["Sector"]));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run("Fecha y Hora de Entrada: " + row["Hora de Entrada"]));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run("Apellido y Nombre del Cliente: " + row["Cliente"]));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run("Tipo de Vehículo: " + row["Tipo de Vehículo"] ));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run("Patente: " + row["Patente"]));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run("Tiempo Transcurrido: " + row["Tiempo Transcurrido"]));


                flowDocument.Blocks.Add(paragraph);
            }

            return flowDocument;
        }

        private void btnImprimirListado_Click(object sender, RoutedEventArgs e)
        {
            ImprimirListado(_data);
        }

        private void ImprimirListado(List<DataRow> data)
        {
            FlowDocument flowDocument = CrearFlowDocument(data);

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                IDocumentPaginatorSource paginatorSource = flowDocument;
                printDialog.PrintDocument(paginatorSource.DocumentPaginator, "Listado de Sectores Ocupados");
            }
        }

    }
}