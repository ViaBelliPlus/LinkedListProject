
using LinkedListPlus;


ViaList<int> a = new();

a.AddLast(1);  
a.AddLast(2);
a.AddLast(3);
a.AddLast(4);
a.AddLast(5);
a.AddLast(6);
a.AddLast(7);

ViaList<int> b = new();

b.AddFirst(1);
b.AddFirst(2);
b.AddFirst(3);
b.AddFirst(4);
b.AddFirst(5);
b.AddFirst(6);
b.AddFirst(7);
Console.WriteLine("");
Console.WriteLine("A");

foreach (int i in a)
{
    Console.WriteLine(i);
}
Console.WriteLine("");
Console.WriteLine("B");
foreach (int i in b)
{
    Console.WriteLine(i);
}

Console.WriteLine("------------");

Console.WriteLine("");
a.RemoveBefore(a.SerchNode(5));
Console.WriteLine("A silme");
foreach (int i in a)
{
    Console.WriteLine(i);
}

Console.WriteLine("------------");
Console.WriteLine("");
b.RemoveBefore(b.SerchNode(5));
Console.WriteLine("B silme");
foreach (int i in b)
{
    Console.WriteLine(i);
}

Console.WriteLine("------------");