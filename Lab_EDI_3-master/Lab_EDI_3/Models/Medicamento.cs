using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_EDI_3.Models
{
    [Serializable]

    public class Medicamento
    {
        private string id;
        private string nombre;
        private string descripcion;
        private string casa_producto;
        private string precio;
        private string existencia;
        private int cantidad_solicitada;
        private double total;

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Casa_producto { get => casa_producto; set => casa_producto = value; }
        public string Precio { get => precio; set => precio = value; }
        public string Existencia { get => existencia; set => existencia = value; }
        public int Cantidad_solicitada { get => cantidad_solicitada; set => cantidad_solicitada = value; }
        public double Total { get => total; set => total = value; }
    }
}