using System.Collections;

namespace LinkedListPlus
{
    public class ViaListEnumerator<T> : IEnumerator<T>
    {
        private ViaListNode<T> Head;
        private ViaListNode<T> _current;

        public ViaListEnumerator(ViaListNode<T> head)
        {
            Head = head;
            _current = null;
        }

        public T Current => _current.Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Head = null; //head i kaybederisek silinmiiş olur
        }

        public bool MoveNext()
        {
            if (_current == null) //current boş ise uygulama daha yeni başlamış demektir head i ata
            {
                _current = Head;
                return true;
            }
            else
            {
                _current = _current.Next;
                return _current != null ? true : false;  //Eleman var ise true dön yoksa false dön
            }
        }

        public void Reset()
        {
            _current = null;  //resetlemek için current null olmalıdır MoneNext() de en baştan başlasın diye
        }
    }
}