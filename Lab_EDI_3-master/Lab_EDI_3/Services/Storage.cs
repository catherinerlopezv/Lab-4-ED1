using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_EDI_3.Services
{
    public class Storage
    {
        private static Storage _instance = null;

        public static Storage GetInstance()
        {
            if (_instance == null) _instance = new Storage();
            return _instance;
        }

        public CustomEstructure.Lista<Medicamento> MiInventario;
        public CustomEstructure.Lista<Cliente> MiListadoCliente;
        public CustomEstructure.ArbolB MiArbol;
        public int CantidadClientes;
        public Pedido MiPedido;
        public Cliente Nuevo;
    }
}