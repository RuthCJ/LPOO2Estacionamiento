using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{ 

    public class Cliente : IDataErrorInfo
    {
        
 
        private string cli_Telefono;

        public string Cli_Telefono
        {
            get { return cli_Telefono; }
            set { cli_Telefono = value; }
        }

        private string cli_Nombre;

        public string Cli_Nombre
        {
            get { return cli_Nombre; }
            set { cli_Nombre = value; }
        }

        private string cli_Apellido;

        public string Cli_Apellido
        {
            get { return cli_Apellido; }
            set { cli_Apellido = value; }
        }


        private string cli_ClienteDNI;

        public string Cli_ClienteDNI
        {
            get { return cli_ClienteDNI; }
            set { cli_ClienteDNI = value; }
        }


        /*
         @param string text
         @param int maxLenght
         @return: get or null
         * Metodo que devuelve un valor tipo string de acorde a la verificacion si el texto ingresado no supera el tamanio permitido
         */
        public string Error { get { return null; } }

        private bool IsNumeric(string text, int maxLength)
        {
            if (text.Length > maxLength)
            {
                return false;
            }

            long numero;
            return long.TryParse(text, out numero);
        }


        /*
            Metodo que permite verificar los campos de la clase CLiente sean correctos y los limites de tamanio
        */
        public string this[string columnName]
        {
            get
            {
                string error = null;
                switch (columnName)
                {
                    case "Cli_ClienteDNI":
                        if (string.IsNullOrEmpty(cli_ClienteDNI))  //verificar si el campo clienteDni esta vacio
                        {
                            error = "Dni requerido";
                        }
                        else if (!IsNumeric(cli_ClienteDNI, 10))
                        {
                            if (cli_ClienteDNI.Length > 10)   //verificar el tamanio de dni
                                error = "maximo 10 numeros";
                            else
                                error = "El campo solo acepta numeros";
                        }
                        break;
                    case "Cli_Apellido":
                        if (string.IsNullOrEmpty(cli_Apellido))   //verificar si el campo apellido esta vacio
                        {
                            error = "Apellido requerido";
                        }
                        else if (!IsAlphaWithSpaces(cli_Apellido)) // verificar si el campo apellido contiene espacios
                        {
                            error = "El apellido debe contener solo letras";
                        }
                        break;
                    case "Cli_Nombre":
                        if (string.IsNullOrEmpty(cli_Nombre))   //verificar si el campo nombre no esta vacio
                        {
                            error = "Campo nombre obligatorio.";
                        }
                        else if (!IsAlphaWithSpaces(cli_Nombre)) //verificar si el campo nombre tiene espacios
                        {
                            error = "El campo nombre debe contener solo letras";
                        }
                        break;
                    case "Cli_Telefono":
                        if (string.IsNullOrEmpty(cli_Telefono))  //verificar el campo telefeno esta vacio
                        {
                            error = "Campo telefonico requerido";
                        }
                        else if (!IsNumeric(cli_Telefono, 20))  //verificar que el numero de telefeno sea numerico
                        {
                            if (cli_Telefono.Length > 20)
                                error = "Maximo 20 numeros";
                            else
                                error = "campo Telfono solo acepta numeros";
                        }
                        break;
                }
                return error;
            }
        }


        /*
         @param string text
         @return bool
         * Metodo que permite verificar los espacios en los textos recibidos por parametros
         */
        private bool IsAlphaWithSpaces(string text)
        {
            return text.All(char.IsLetter) || text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        public override string ToString()
        {
            return "Dni: "+Cli_ClienteDNI+",\nApellido: "+Cli_Apellido+",\nNombre: "+Cli_Nombre;
        }
    }
}