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
        public ViaList(IEnumerable<T> collection)
        {
            //ilk tanımlanma ısrasında hazır bir listeyi bu listeye ekleme işlemini yapar
            foreach (var item in collection)
            {
                //this.Add(item);
                throw new NotImplementedException();
            }
        }

        public T Removelast()
        {
            throw new NotImplementedException();
        }
        public T Remove()
        {
            throw new NotImplementedException();
        }
       

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
