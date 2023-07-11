
using LinkedListPlus;
using System.Collections;

ViaList<int> a = new();
a.AddLast(1);
a.AddLast(2);
a.AddLast(3);
a.AddLast(4);
a.AddLast(4);
a.AddLast(4);
a.AddLast(4);
a.AddLast(5);
a.AddLast(6);
a.AddLast(7);
foreach (var item in a)
{
    Console.WriteLine(item);
}
a.RemoveAll(4);
Console.WriteLine("Silemden sonraki");
foreach (int i in a)
{
    Console.Write(i + " ");
}



Console.WriteLine();