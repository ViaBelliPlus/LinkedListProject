using LinkedListPlus;
internal class Program
{
    private static void Main(string[] args)
    {
        Random rnd = new Random();
        int[] into = new int[20000];
        ViaList<object> list1 = new ViaList<object>();
        list1.AddFirst(1);
        list1.Clear();
        ViaList<int> a = new ViaList<int>(10, 20, 30);
        ViaList<int> list = new();
        for (int i = 0; i < 100000; i++)
        {
            list.Add(rnd.Next(0,800000));
        }
        list.AddFirst(1);
        list.AddFirst(2);
        list.AddLast(3);
        list.AddAfter(list.Head, 12);
        list.AddBefore(list.Tail, 120);
        list.AddRange(a);
        //list.Sort();
        //list.CopyTo(into, 80);
        Console.WriteLine(list.Count);
        list.Clear();
        Console.WriteLine(list.Count);

        ViaList<int> ints = new(TypeList.SortedList);
        for (int i = 0; i < 100000; i++)
        {
            ints.Add(rnd.Next(0, 90000));
        }
        ints.Add(100);
        ints.Add(150);
        ints.Add(200);
        ints.Add(50);
        ints.Add(75);
        ints.Add(300);

        Console.ReadLine();
    }
    public class NotIComparableClass 
    {
        public NotIComparableClass(int value)
        {
            
        }
    }
}