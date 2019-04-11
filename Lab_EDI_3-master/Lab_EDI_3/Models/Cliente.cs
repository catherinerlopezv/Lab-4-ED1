using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_EDI_3.Models
{
    public class Cliente
    {
        private int NumeroCliente;
        private string nombre;
        private string direccion;
        private string nit;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Nit { get => nit; set => nit = value; }
        public int NumeroCliente1 { get => NumeroCliente; set => NumeroCliente = value; }

    }
}