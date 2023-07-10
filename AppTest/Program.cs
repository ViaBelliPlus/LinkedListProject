using LinkedListPlus;
internal class Program
{
    private static void Main(string[] args)
    {
        int[] into = new int[100];
        Regular<int> a = new Regular<int>(10, 20, 30);
        Regular<int> list = new();
        list.AddFirst(1);
        list.AddFirst(2);
        list.AddLast(3);
        list.AddAfter(list.Head, 12);
        list.AddBefore(list.Tail, 120);
        list.AddRange(a);
        list.CopyTo(into, 80);
        list.Clear();
        Console.WriteLine(list.Count);
        Console.ReadLine();
    }
}