using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras__De__Datos
{
    public class Entry<TK, TP> : IEquatable<Entry<TK, TP>>
    {
        public TK Key { get; set; }

        public TP Pointer { get; set; }

        public bool Equals(Entry<TK, TP> other)
        {
            return this.Key.Equals(other.Key) && this.Pointer.Equals(other.Pointer);
        }
    }
}
