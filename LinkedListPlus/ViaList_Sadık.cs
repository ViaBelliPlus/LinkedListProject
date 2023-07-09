using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPlus
{
    public partial class ViaList<T> : IEnumerable<T>
    {
        //Methot1
        public IEnumerator<T> GetEnumerator()
        {
            return new ViaListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
