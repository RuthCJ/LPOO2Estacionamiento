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
using System.IO;
using System.Windows.Controls.Primitives;
using ClasesBase;

namespace Vistas
{
    public partial class AcercaDe : Window
    {
        public AcercaDe()
        {
            InitializeComponent();
            
            string carpetaBase = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine("carpetaBase: " + carpetaBase);

            string rutaDirecta = Path.Combine(carpetaBase, "..", "..", "Media", "video.wmv");
            Console.WriteLine("rutaDirecta: " + rutaDirecta);

            mediaElement.Source = new Uri(rutaDirecta);

            // Configurar la reproducción no en bucle
            mediaElement.MediaEnded += (sender, e) => RestartMedia();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            RestartMedia();
            mediaElement.Play(); // Iniciar automáticamente después de reiniciar
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedEventArgs e)
        {
            mediaElement.Volume = volumeSlider.Value;
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;
        }
        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow; // Cambiar a la flecha cuando se sale del botón
        }

        private void RestartMedia()
        {
            mediaElement.Stop();
            mediaElement.Position = TimeSpan.Zero;
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();

            this.Close();
        }


    }
}