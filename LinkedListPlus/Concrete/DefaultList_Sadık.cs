using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPlus
{
    public partial class DefaultList<T> : AbsViaList<T> ,IEnumerable<T>
    {
        public DefaultList(IEnumerable<T> collection) : this()
        {
            //ilk tanımlanma ısrasında hazır bir listeyi bu listeye ekleme işlemini yapar
            foreach (var item in collection)
            {
                AddFirst(item);
            }
        } 
        /// <summary>
        /// Verilen index dizinin boyutunu geçmemelidir okuma ve yazma işlemleri yapabilirsiniz
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public override T this[int index]
        {

            get
            {
                if (Count >= index)
                {
                    var value = Head;
                    for (int i = 0; i < index; i++)
                    { //istenilen index den 1 fazlası kadar düğümü ileriye alıyoruz
                        value = value.Next;
                    }
                    return value.Value; //değeri döndürüyoruz
                }
                else
                {
                    throw new Exception();
                }
            }
            set
            {
                if (value != null && Count >= index) //listemizin boyutundan buyuk olammalıdır ındex degeri
                {
                    var data = Head;
                    for (int i = 0; i < index; i++)
                    { //istenilen index den 1 fazlası kadar düğümü ileriye alıyoruz
                        data = data.Next;
                    }
                    data.Value = value;
                }
                else if (Count + 1 == index)
                {
                    if (value != null)
                    {
                        AddLast(value);
                    }
                }
                else
                {
                    throw new Exception();
                }

            }

        }

        IEnumerator IEnumerable.GetEnumerator()//IEnumerable<T> den inplament edilince gelir burası
        {
            return GetEnumerator();
        }
        
    }
}
