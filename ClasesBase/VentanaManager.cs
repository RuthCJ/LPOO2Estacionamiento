using System;
using System.Collections.Generic;
using System.Windows;

namespace ClasesBase
{
    public class VentanaManager
    {
        private List<Window> ventanasAbiertas = new List<Window>();
        private static VentanaManager instance;
       
        public static VentanaManager Instance
        {
            get
            {
             
                if (instance == null)
                {
                    instance = new VentanaManager();
                }
                return instance;
            }
        }
       

        public void agregarVentana(Window ventana)
        {
            ventanasAbiertas.Add(ventana);
        }

        public void cerrarTodasLasVentanas()
        {
            foreach (var ventana in ventanasAbiertas)
            {
                ventana.Close();
            }
            ventanasAbiertas.Clear();
        }

        public void mostrarVentanasAbiertas()
        {
            foreach (var ventana in ventanasAbiertas)
            {
                Console.WriteLine(ventana.Title);
            }
        }


        private VentanaManager()
        {
        }

    }
}
