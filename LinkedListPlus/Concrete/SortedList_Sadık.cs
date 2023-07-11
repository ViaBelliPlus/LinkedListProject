using System.Collections;

namespace LinkedListPlus
{
    public partial class SortedList<T> : IEnumerable<T>, IViaList<T>
    {
        public SortedList(IEnumerable<T> collection) : this()
        {
            //ilk tanımlanma ısrasında hazır bir listeyi bu listeye ekleme işlemini yapar
            foreach (var item in collection)
            {
                AddFirst(item);
            }
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
            count--;
            return value; // Kaldırılan değeri dön
        }

        /// <summary>
        /// Verilen index dizinin boyutunu geçmemelidir okuma ve yazma işlemleri yapabilirsiniz
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public T this[int index]
        {

            get
            {
                if (count >= index)
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
                if (value != null && count >= index) //listemizin boyutundan buyuk olammalıdır ındex degeri
                {
                    var data = Head;
                    for (int i = 0; i < index; i++)
                    { //istenilen index den 1 fazlası kadar düğümü ileriye alıyoruz
                        data = data.Next;
                    }
                    data.Value = value;
                }
                else if (count + 1 == index)
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
                count--; //count azaltılıyor
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
                count--;//count azaltılıyor
                return new SuccessResult("Remove After metodu başarılı çalıştı");
            }
            //arada biyerde ise normal atlıycak sekilde yazzılır
            node.Next.Next.Back = node;
            node.Next = node.Next.Next;
            delete.Invalidate(); //silincek değerin tüm bağlantıları koparılıyor garbic collector daha kolay yakalasın diye
            count--;//count azaltılıyor
            return new SuccessResult("Remove After metodu başarılı çalıştı");

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
            count--;
            return value; // Saklanan değeri döndürürüz
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
                count--;
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
                count--;
                return new SuccessResult("Remove Before başarılı çalıştı");
            }
            //Arada biyer ise
            node.Back.Back.Next = node;
            node.Back = node.Back.Back;
            delete.Invalidate();//silincek değerin tüm bağlantıları koparılıyor garbic collector daha kolay yakalasın diye
            count--;
            return new SuccessResult("Remove Before başarılı çalıştı");
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

            count--;
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

        public IEnumerator<T> GetEnumerator() //IEnumerable<T> den inplament edilince gelir burası
        {
            //bunun yazılmasının sonucunda foreach ve linq sorgularının yapılmasını sağlar
            return new ViaListEnumerator<T>(Head); // Yeni bir ViaListEnumerator oluşturarak başlangıç düğümünü parametre olarak veriyoruz ve bu numaralandırıcıyı döndürüyoruz.
        }

        IEnumerator IEnumerable.GetEnumerator()//IEnumerable<T> den inplament edilince gelir burası
        {
            return GetEnumerator();
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
            if (endİndex > count - 1) //elemansayısından buyuk bir değerde silme işlemi olamaz -1 dememizin sebebi index olarak düşünmek
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
    }
}
