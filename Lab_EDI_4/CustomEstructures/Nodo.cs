using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEstructure
{
    public class Nodo<TK,TP>
    {
        private int degree;

        public Nodo(int degree)
        {
            this.degree = degree;
            this.Children = new List<Nodo<TK, TP>>(degree);
            this.Entries = new List<Entry<TK, TP>>(degree);

        }

        public List<Nodo<TK, TP>> Children { get; set; }

        public List<Entry<TK, TP>> Entries { get; set; }

        public bool IsLeaf
        {
            get
            {
                return this.Children.Count == 0;
            }
        }

        public bool HasReachedMaxEntries
        {
            get
            {
                return this.Entries.Count == (2 * this.degree) - 1;
            }
        }

        public bool HasReachedMinEntries
        {
            get
            {
                return this.Entries.Count == this.degree - 1;
            }
        }
    }
}
