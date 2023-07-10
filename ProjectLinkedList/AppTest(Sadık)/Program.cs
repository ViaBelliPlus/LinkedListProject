
using LinkedListPlus;
using System.Collections;

Regular<int> a = new();
a.AddLast(1);
a.AddLast(2);
a.AddLast(3);
a.AddLast(4);
a.AddLast(5);
a.AddLast(6);
a.AddLast(7);
a[8] = 90;
a[9] = 20;
foreach (int i in a)
{
    Console.Write(i+" ");
}

a.RemoveBefore(a.SearchNode(2));
Console.WriteLine("Silemden sonraki");
foreach (int i in a)
{
    Console.Write(i + " ");
}


Console.WriteLine();