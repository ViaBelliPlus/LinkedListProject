
using LinkedListPlus;


ViaList<int> a = new();

a.AddFirst(1);  
a.AddFirst(2);
a.AddFirst(3);
a.AddFirst(4);
a.AddFirst(5);

foreach (int i in a)
{
    Console.WriteLine(i);
}

a.RemoveFirst();
Console.WriteLine("a----------------");
foreach (int i in a)
{
    Console.WriteLine(i);
}
a.RemoveLast();
Console.WriteLine("a----------------");
foreach (int i in a)
{
    Console.WriteLine(i);
}

