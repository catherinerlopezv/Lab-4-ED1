using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using Lab_EDI_3.Models;
using Estructuras__De__Datos;

namespace Lab_EDI_3.Services
{
    public class Process
    {
        //Lista<Medicamento> MiInventario = new Lista<Medicamento>();
        //Lista<Cliente> MiListadoClientes = new Lista<Cliente>();
        //Lista<Medicamento> MiListadoMedicamentos = new Lista<Medicamento>();
        Random numero = new Random();
        ArbolB<TK,TP> MiArbol<Medicamento> = new (ArbolB<TK, TP>());
        public int Contador = 0;
        public string[] Ordenamientos;

        public Lista<Cliente> AgregarUnCliente(Cliente Nuevo)
        {
            MiListadoClientes.Insertar_Inicial(new Nodo<Cliente>(Nuevo));
            return MiListadoClientes;
        }

        public Lista<Medicamento> AgregarUnMedicamento(Medicamento Nuevo, Lista<Medicamento> Almacenada)
        {
            if (Almacenada != null)
            {
                MiListadoMedicamentos = Almacenada;
            }
            MiListadoMedicamentos.Insertar_Inicial(new Nodo<Medicamento>(Nuevo));
            return MiListadoMedicamentos;
        }

        public Lista<Medicamento> CargarInventario()
        {
            string filePath = string.Empty;
            string path = System.Web.HttpContext.Current.Server.MapPath("~/MOCK_DATA (4).csv");
            string csvData = System.IO.File.ReadAllText(path);
            string[] separadas = null;
            string dato_dos = null;
            string dato_tres = null;
            string dato_cuatro = null;
            string dato_cinco = null;
            string dato_seis = null;
            foreach (string row in csvData.Split('\n'))
            {
                if (row.Length != 1 & row.Length != 0)
                {
                    if (row.Contains('"'))
                    {
                        string dato_uno;
                        string linea = row;
                        int pos = linea.IndexOf(",");
                        dato_uno = linea.Substring(0, pos);
                        linea = linea.Substring(pos + 1);
                        if (linea[0] == '"')
                        {
                            pos = linea.IndexOf('"');
                            linea = linea.Substring(pos + 1);
                            pos = linea.IndexOf('"');
                            dato_dos = linea.Substring(0, pos);
                            linea = linea.Substring(pos + 1);
                            pos = linea.IndexOf('"');
                            if (pos == 1)
                            {
                                linea = linea.Substring(pos + 1);
                                pos = linea.IndexOf('"');
                                dato_tres = linea.Substring(0, pos);
                                linea = linea.Substring(pos + 1);
                                separadas = linea.Split(',');
                                dato_cuatro = separadas[1];
                                dato_cinco = separadas[2];
                                dato_seis = separadas[3];
                            }
                            else
                            {
                                separadas = linea.Split(',');
                                dato_cuatro = separadas[0];
                                dato_cinco = separadas[1];
                                dato_seis = separadas[2];
                            }
                        }
                        else
                        {
                            pos = linea.IndexOf(",");
                            dato_dos = linea.Substring(0, pos);
                            linea = linea.Substring(pos + 1);
                            if (linea[0] == '"')
                            {
                                pos = linea.IndexOf('"');
                                linea = linea.Substring(pos + 1);
                                pos = linea.IndexOf('"');
                                dato_tres = linea.Substring(0, pos);
                                linea = linea.Substring(pos + 1);
                                pos = linea.IndexOf('"');
                                if (pos == 1)
                                {
                                    linea = linea.Substring(pos + 1);
                                    pos = linea.IndexOf('"');
                                    dato_cuatro = linea.Substring(0, pos);
                                    linea = linea.Substring(pos + 1);
                                    separadas = linea.Split(',');
                                    dato_cinco = separadas[1];
                                    dato_seis = separadas[2];
                                }
                                else
                                {
                                    separadas = linea.Split(',');
                                    dato_cuatro = separadas[1];
                                    dato_cinco = separadas[2];
                                    dato_seis = separadas[3];
                                }
                            }
                            else
                            {
                                pos = linea.IndexOf(",");
                                dato_tres = linea.Substring(0, pos);
                                linea = linea.Substring(pos + 1);
                                pos = linea.IndexOf('"');
                                if (pos == 0)
                                {
                                    linea = linea.Substring(pos + 1);
                                    pos = linea.IndexOf('"');
                                    dato_cuatro = linea.Substring(0, pos);
                                    linea = linea.Substring(pos + 1);
                                    separadas = linea.Split(',');
                                    dato_cinco = separadas[1];
                                    dato_seis = separadas[2];
                                }
                                else
                                {

                                }
                            }
                        }
                        Medicamento MiMedicamento = new Medicamento
                        {
                            Id = dato_uno,
                            Nombre = dato_dos,
                            Descripcion = dato_tres,
                            Casa_producto = dato_cuatro,
                            Precio = dato_cinco,
                            Existencia = dato_seis
                        };
                        MiInventario.Insertar_Inicial(new Nodo<Medicamento>(MiMedicamento));
                    }
                    else
                    {
                        separadas = row.Split(',');
                        Medicamento MiMedicamento = new Medicamento
                        {
                            Id = separadas[0],
                            Nombre = separadas[1],
                            Descripcion = separadas[2],
                            Casa_producto = separadas[3],
                            Precio = separadas[4],
                            Existencia = separadas[5]
                        };
                        MiInventario.Insertar_Inicial(new Nodo<Medicamento>(MiMedicamento));
                    }
                }
            }
            return MiInventario;
        }

        public ArbolAVL CargarArbol(Lista<Medicamento> nueva)
        {
            Lista<Medicamento> Temp = nueva;
            foreach (var productos in Temp)
            {
                MiArbol = MiArbol.Insertar(productos.Id, productos.Nombre, MiArbol);
            }

            return MiArbol;
        }

        public void Guardar(Pedido nuevo, string contador)
        {
            if (nuevo != null)
            {
                var dataFile = System.Web.HttpContext.Current.Server.MapPath("~/" + contador + "_Pedido.csv");
                var dataPedido = nuevo;
                int numero_linea = 4;
                string[] factura = new string[1000];
                factura[0] = "Nombre: " + dataPedido.MiCliente.Nombre;
                factura[1] = "Dirección: " + dataPedido.MiCliente.Direccion;
                factura[2] = "Nit: " + dataPedido.MiCliente.Nit;
                factura[3] = "--- Descripción de medicinas ---";
                foreach (Medicamento producto in nuevo.MisMedicamentos)
                {
                    factura[numero_linea] = "Nombre: " + producto.Nombre;
                    numero_linea++;
                    factura[numero_linea] = "Descripción: " + producto.Descripcion;
                    numero_linea++;
                    factura[numero_linea] = "Casa producto: " + producto.Casa_producto;
                    numero_linea++;
                    factura[numero_linea] = "Cantidad: " + producto.Cantidad_solicitada;
                    numero_linea++;
                }
                factura[numero_linea] = "Cantidad a pagar: " + dataPedido.total;
                File.WriteAllLines(@dataFile, factura);
            }
        }

       /* public void GuardaImprimirPrer(ArbolAVL nuevo)
        {
            var dataFilePre = System.Web.HttpContext.Current.Server.MapPath("~/ImprimirPre.csv");
            var dataPedidoPre = nuevo;
            string resultadosPre = nuevo.RecorridoPreorden(dataPedidoPre);
            File.WriteAllText(@dataFilePre, resultadosPre);
        }

        public void GuardaImprimirIn(ArbolAVL nuevo)
        {
            var dataFileIn = System.Web.HttpContext.Current.Server.MapPath("~/ImprimirIn.csv");
            var dataPedidoIn = nuevo;
            string resultadosIn = nuevo.RecorridoInorden(dataPedidoIn);
            File.WriteAllText(@dataFileIn, resultadosIn);
        }

        public void GuardaImprimirPost(ArbolAVL nuevo)
        {
            var dataFilePost = System.Web.HttpContext.Current.Server.MapPath("~/ImprimirPost.csv");
            var dataPedidoPost = nuevo;
            string resultadosPost = nuevo.RecorridoPostorden(dataPedidoPost);
            File.WriteAllText(@dataFilePost, resultadosPost);
        }*/
    }
}
