using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras__De__Datos
{
    public class Lista<T>
    {
        public Nodo<T> Inicial;
        public Nodo<T> Final;

        public Lista()
        {
            Inicial = null;
            Final = null;
        }

        void Insertar_Final(Nodo<T> nuevo)
        {
            if (EstaVacia())
            {
                Inicial = nuevo;
                Final = nuevo;
            }
            else
            {
                Final.Siguiente = nuevo;
                Final = nuevo;
            }
        }

        public void Insertar_Inicial(Nodo<T> nuevo)
        {
            if (EstaVacia())
            {
                Inicial = nuevo;
                Final = nuevo;
            }
            else
            {
                nuevo.Siguiente = Inicial;
                Inicial = nuevo;
            }
        }

        void Eliminar_Final()
        {
            if (EstaVacia())
            {
                return;
            }

            Nodo<T> actual = Inicial;

            //Tenemos un solo Nodo<T>
            if (actual.Siguiente == null)
            {
                Inicial = null;
                Final = null;
                return;
            }

            while (actual.Siguiente != Final)
            {
                actual = actual.Siguiente;
            }

            actual.Siguiente = null;
            Final = actual;
        }

        public void Eliminar_Inicial()
        {

        }

        public bool Eliminar_elemento(int value)
        {
            throw new NotImplementedException();
        }

        public int Cantidad_elementos()
        {
            throw new NotImplementedException();
        }

        public int[] Copia_lista()
        {
            throw new NotImplementedException();
        }

        public bool EstaVacia()
        {
            return (Inicial == null) && (Final == null);
        }

        public T Mostrar()
        {
            Nodo<T> Aux = Inicial;
            return Aux.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Nodo<T> current = Inicial;

            while (current != null)
            {
                yield return current.Data;
                current = current.Siguiente;
            }
        }
    }
}

