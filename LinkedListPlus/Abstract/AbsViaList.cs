using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPlus
{
    public abstract class AbsViaList<T> : IViaList<T>
    {
        public abstract T this[int index] { get; set; }

        public ViaListNode<T> Tail { get;  set; }

        public ViaListNode<T> Head { get;  set; }

        public abstract bool IsDecimalTypeList { get; init; }

        public bool IsEmpty => Count == 0 ? true : false;

        /// <summary>
        /// Listenin uzunluğunu döner.
        /// </summary>
        public uint Count { get; set; }

        public abstract void AddAfter(ViaListNode<T> node, T item);

        public abstract void AddAfter(ViaListNode<T> node, ViaListNode<T> newNode);

        public abstract void AddBefore(ViaListNode<T> node, T item);

        public abstract void AddBefore(ViaListNode<T> node, ViaListNode<T> newNode);

        public abstract void AddFirst(T item);

        public abstract void AddLast(T item);

        public abstract void AddRange(IEnumerable<T> collection);

        public virtual IResult AddSort(T Value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Tüm listeyi siler.s
        /// </summary>
        public void Clear()
        {
            ViaListNode<T> currentHead = Head;
            ViaListNode<T> currentTail = Tail;
            while (currentHead != currentTail && (currentHead != null && currentTail != null))
            {
                ViaListNode<T> tempHead = currentHead;
                ViaListNode<T> tempTail = currentTail;
                currentHead = currentHead.Next;
                currentTail = currentTail.Back;
                tempHead.Invalidate();
                tempTail.Invalidate();
            }
            currentHead?.Invalidate();
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Verilen diziye, belirtilen indexten itibaren, ilgili listeyi kopyalar. Deep copy yapar. 
        /// </summary>
        /// <param name="toCopy">Kopyanın kaydedileceği dizi.</param>
        /// <param name="index">Beliritlen dizinin hangi index değerinden itibaren kopyalama işlemini yapacağını belirten index değeri.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public T[] CopyTo(T[] toCopy, int index)
        {
            Validate(toCopy, Head);
            if (Count > toCopy.Length - index) throw new ArgumentException("There is not enough space in the specified array");
            var ptr = Head;
            for (int i = index; ptr != null; i++)
            {
                try
                {
                    toCopy[i] = ptr.Value; ptr = ptr.Next;
                }
                catch (Exception)
                {
                    throw new IndexOutOfRangeException();
                }
            }
            return toCopy;
        }

        /// <summary>
        /// İlgili diziyi sabit ve tek boyutlu bir arraye kopyalar. Deep copy yapar.
        /// </summary>
        /// <returns>Kopya diziyi döndürür.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public T[] CopyToOneDimensionalArray()
        {
            Validate(Head);
            var ptr = Head;
            T[] tempArray = new T[Count];
            for (int i = 0; i < tempArray.Length; i++)
            {
                try
                {
                    tempArray[i] = ptr.Value; ptr = ptr.Next;
                }
                catch (Exception)
                {
                    throw new IndexOutOfRangeException();
                }
            }
            return tempArray;
        }
        public void DecreaseCount()
        {
            Count--;
        }

        public IEnumerator<T> GetEnumerator() //IEnumerable<T> den inplament edilince gelir burası
        {
            //bunun yazılmasının sonucunda foreach ve linq sorgularının yapılmasını sağlar
            return new ViaListEnumerator<T>(Head); // Yeni bir ViaListEnumerator oluşturarak başlangıç düğümünü parametre olarak veriyoruz ve bu numaralandırıcıyı döndürüyoruz.
        }

        public void IncreaseCount()
        {
            Count++;
        }

        public virtual bool IsDecimalType(Type type)
        {
            if (type == typeof(IComparable))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Girilen ViaListNode<T> den sonraki değeri siler ve void döner
        /// </summary>
        /// <param name="node"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public IResult RemoveAfter(ViaListNode<T> node)
        {
            // Belirtilen düğümden sonraki düğümü kaldırma işlemi
            var delete = node.Next;
            // İlk olarak, düğümün null olup olmadığını kontrol ediyoruz.
            Validate(node); //node boş ise hata veriri
            if (node == Head) //head e eşit ise bi sonrasını silicez 
            {
                //buradaki işlemde headin bi sonrakinin atlıayarak bağlantılar yapılıyor
                Head.Next = Head.Next.Next;
                Head.Next.Next.Back = Head;
                delete.Invalidate(); //silincek değerin tüm bağlantıları koparılıyor garbic collector daha kolay yakalasın diye
                DecreaseCount(); //count azaltılıyor
                return new SuccessResult("Remove After metodu başarılı çalıştı");
            }
            if (node == Tail) //tailden sonrası olmadığı için bişey yapmıycaz
            {
                return new SuccessResult("Son değerden sonrası olmadığı için silme işlemi yapılmadı"); //sonrası yok 
            }
            if (node == Tail.Back) //tailin 1 öncesine eşit isen 
            {
                Tail = Tail.Back; //taili güncelle
                Tail.Next = null; //bunu işaretlediğini silmez isek garbic collector oncekı taılın referansını tutugu ıcın sılmıycektır onu 
                delete.Invalidate(); //silincek değerin tüm bağlantıları koparılıyor garbic collector daha kolay yakalasın diye
                DecreaseCount();//count azaltılıyor
                return new SuccessResult("Remove After metodu başarılı çalıştı");
            }
            //arada biyerde ise normal atlıycak sekilde yazzılır
            node.Next.Next.Back = node;
            node.Next = node.Next.Next;
            delete.Invalidate(); //silincek değerin tüm bağlantıları koparılıyor garbic collector daha kolay yakalasın diye
            DecreaseCount();//count azaltılıyor
            return new SuccessResult("Remove After metodu başarılı çalıştı");

        }

        /// <summary>
        /// Gireln değeri listede nekadar var ise hepsini siler
        /// </summary>
        /// <param name="number"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void RemoveAll(T value)
        {
            Validate(value);//null kontrolu yapıldı
            while (true)
            {
                try
                {
                    RemoveAtValue(value); //buradaki kod ilk gelen değeri silmeye yarıyor
                    //buradaki kodda herhangibir hata olduğuzaman yani oda ilgili silincek değeri bulamaz ise ilgili değer bitmiş demektir
                }
                catch (Exception)
                {
                    break; //silme işlemi tamamlanmıştır
                }
            }
        }

        /// <summary>
        /// Verilen ViaListNode<T> listeden siler void döner
        /// </summary>
        /// <param name="node"></param>
        /// <exception cref="ArgumentException"></exception>
        public IResult RemoveAt(ViaListNode<T> node)
        {
            Validate(node);//null kontrolü
            if (node.Next == null && node.Back == null)
            {
                throw new ArgumentException();
            }
            if (node == Head && node == Tail)
            {
                // Sadece bir düğüm varsa, listeyi boşalt
                Head = null;
                Tail = null;
            }
            else if (node == Head)
            {
                // İlk düğümü kaldırma
                Head = Head.Next;
                Head.Back = null;
            }
            else if (node == Tail)
            {
                // Son düğümü kaldırma
                Tail = Tail.Back;
                Tail.Next = null;
            }
            else
            {
                // Aradaki bir düğümü kaldırma
                ViaListNode<T> prevNode = node.Back;
                ViaListNode<T> nextNode = node.Next;
                prevNode.Next = nextNode;
                nextNode.Back = prevNode;
            }

            DecreaseCount();
            return new SuccessResult("Silme işlemi başarılı");
        }

        /// <summary>
        /// Bir T  değeri alır ve verilen değer var ise siler void döner
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public IResult RemoveAtValue(T value)
        {
            Validate(value);//null  kontrolü
            return RemoveAt(SearchNode(value)); //girilen değeri arayan ve nod dönene arama algorıtmasına yazılır gelen nod u da removeat a gönderip silme işlemi tamamlanır
                                                //count--; //bunu yapamayız cunku usteki removeat de de orası calışmış olucak normalden 1 eksık eleman gosterıcektır 
        }

        /// <summary>
        /// Girilen ViaListNode<T> den önceki değeri siler ve void döner
        /// </summary>
        /// <param name="node"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public IResult RemoveBefore(ViaListNode<T> node)
        {
            // Belirtilen düğümden sonraki düğümü kaldırma işlemi
            var delete = node.Back;
            // İlk olarak, düğümün null olup olmadığını kontrol ediyoruz.
            Validate(node); //null kontrolü
            if (node == Tail)
            {
                Tail.Back = Tail.Back.Back;
                Tail.Back.Next = Tail;
                // disconnection(delete);//silincek değerin tüm bağlantıları koparılıyor garbic collector daha kolay yakalasın diye
                DecreaseCount();
                return new SuccessResult("Remove Before başarılı çalıştı");
            }
            if (node == Head)
            {
                return new SuccessResult("Öncesi olmıyan bir değer verdiniz silme işlemi yapılmadı"); //öncesi yok bişey yapmaya gerek yoktur
            }
            if (node == Head.Next) //Tailin sonraki ise oncesi tail yapar 
            {
                Head = Head.Next; //Tail güncellenir
                Head.Back = null; //Tamamen bağ kopsun diye yapıldı garbic collector oncekı head referansını tutugu ıcın sılmıycektır onu
                delete.Invalidate();//silincek değerin tüm bağlantıları koparılıyor garbic collector daha kolay yakalasın diye
                DecreaseCount();
                return new SuccessResult("Remove Before başarılı çalıştı");
            }
            //Arada biyer ise
            node.Back.Back.Next = node;
            node.Back = node.Back.Back;
            delete.Invalidate();//silincek değerin tüm bağlantıları koparılıyor garbic collector daha kolay yakalasın diye
            DecreaseCount();
            return new SuccessResult("Remove Before başarılı çalıştı");
        }

        /// <summary>
        /// Bağlı listenin ilk elemanını siler ve değerini döndürür
        /// </summary>
        /// <returns></returns>
        public T RemoveFirst()
        {
            var value = Head.Value; // Değeri dönmek için geçici bir değişkende sakla
            Validate(Head);// Liste boş değilse devam et
            if (Head.Next != null) // Başka bir öğe varsa
            {
                Head.Next.Back = null; // İkinci öğenin öncesini null yap
                Head = Head.Next; // Yeni başlangıç değerimizi ikinci öğe olarak güncelle
            }
            else // Sadece bir öğe varsa
            {
                Head = null; // Listeyi boşalt
            }
            DecreaseCount();
            return value; // Kaldırılan değeri dön
        }
        /// <summary>
        /// Bağlı listenin sondaki degerini siler ve değerini döndürür
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public T RemoveLast()
        {
            Validate(Tail); //boş ise hata verir
            var value = Tail.Value; // Silinen düğümün değerini saklamak için bir değişkende tutarız
            // Listenin sadece bir düğümü varsa, Head ve Tail'e null atanır
            if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail.Back.Next = null; // Sondan bir önceki düğümün sonraki referansını null yaparız
                Tail = Tail.Back; // Yeni tail, bir önceki düğüm olur
            }
            DecreaseCount();
            return value; // Saklanan değeri döndürürüz
        }

        /// <summary>
        /// Gönderilen IEnumerable<T> türündeki koleksiyon içerisindeki tüm değerleri siler
        /// </summary>
        /// <param name="collection"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void RemoveRange(IEnumerable<T> collection)
        {
            Validate(collection);//null kontrol
            foreach (var item in collection) //gelen koleksiyonu dönerek değerleri siliyoruz
            {
                RemoveAtValue(item);
            }
        }

        /// <summary>
        /// Verilen indexler dahil edilerek silme işlemi yapılır
        /// </summary>
        /// <param name="startİndex"></param>
        /// <param name="endİndex"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public IResult RemoveRange(int startİndex, int endİndex)
        {
            Validate(startİndex, endİndex);//null kontrolleri yapılıyor 
            if (endİndex > Count - 1) //elemansayısından buyuk bir değerde silme işlemi olamaz -1 dememizin sebebi index olarak düşünmek
            {
                return new ErrorResult("hatalı index girişi listenin uzunlugunu gecen bir değer verdiniz");
            }
            if (endİndex < startİndex) //end index buyuk olmalı 
            {
                return new ErrorResult("hatalı index girişi son indexin değeri ilk indexten büyük olmalıdır");
            }
            var current = Head;
            for (int i = 0; i < startİndex; i++) //ilk önce silmeey başlıyacağımız noudu bulduk
            {
                current = current.Next;
            }
            if (current == Head) //current head e eşit ise 
            {
                for (int i = 0; i <= endİndex - startİndex; i++) //arasındakı fark kadar baştan silme işlemi yaptık
                {
                    RemoveFirst();
                }
                return new SuccessResult();
            }
            var temp = current.Back; //startİndexin baci ni tutyoruz
            for (int i = 1; i <= endİndex - startİndex; i++) //arasındakı kadar ilerleyip hem currenti artırıp sonİndexin nex ini bulmak için
            {
                var temp1 = current;
                current = current.Next;
                temp1.Invalidate(); //burada aradaki tüm elemanların bağlantısını koparıyoruz
                DecreaseCount();
            }
            //burada 
            if (current == Tail) //current son ise bağlama işlemi yapılmasına gerek yoktur
            {
                return new SuccessResult();
            }
            temp.Next = current;
            current.Back = temp;
            return new SuccessResult();
        }

        public void ResetCount()
        {
            Count = 0;
        }

        public ViaList<ViaListNode<T>> SearchAll(T value)
        {
            ViaList<ViaListNode<T>> nodes = new();
            var ptr = Head;
            while (ptr != null) { if (value.Equals(ptr.Value)) { nodes.AddLast(ptr); } }
            return nodes;
        }

        /// <summary>
        /// Verilen T değerini alır kendi ViaList'inizde var mı yok mu kontrol eder ve ViaListNode<T> döner
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public ViaListNode<T> SearchNode(T value)
        {
            Validate(value);//null kontrolü
            var _current = Head; // Başlangıç düğümü başa ayarlanır.
            while (_current != null)
            {
                if (_current.Value.Equals(value))
                {
                    return _current; // Aranan değer bulunduğunda ilgili düğüm döndürülür.
                }
                _current = _current.Next; // Bir sonraki düğüme geçilir.
            }
            throw new Exception("Aranan değer bulunamadı"); // Döngü tamamlandığında hata fırlatılır çünkü aranan değer bulunamadı.
        }

        /// <summary>
        ///Verilen T değerini alır kendi ViaList'inizde var mı yok mu kontrol eder ve bool döner
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SerachFirst(T value) => SearchNode(value) != null ? true : false;

        public abstract IResult Sort();

        public void Validate(object? toValidate)
        {
            if (toValidate == null) throw new NullReferenceException("One of the related object is null");
        }
        public void Validate(object? toValidate, object? toValidate2)
        {
            if (toValidate == null || toValidate2 == null) throw new NullReferenceException("One or both of the related objects are null");
        }
    }
}
