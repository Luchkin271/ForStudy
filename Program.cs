using System.Reflection.Metadata;
using ForStady.Structures;


//Для Начала вспомним базовый материал на примере задачи: 
//Создать класс реализующий простое дерево сфункциями добавления и пойска
//Усложним и поставим задачу более конкретно: 
//Реализовать красно-черное дерево.

//var tree = new RedBlackTree<int>();
//tree.Insert(10);
//tree.Insert(20);
//tree.Insert(30);
//tree.Insert(15);
//tree.Insert(25);

//Console.WriteLine("In-order traversal:");
//foreach (var item in tree.InOrderTraversal())
//{
//    Console.WriteLine(item);
//}

//Console.WriteLine("Contains 15: " + tree.Contains(15));
//Console.WriteLine("Contains 99: " + tree.Contains(99));

//Следующей задачей выберем стандартные сортировки: пузырьковая и быстрая

//using ForStady.Sorts;

//int[] ints2 = new int[] { 1, 5, 6, 2, 3 };
//int[] ints = new int[] { 1, 5, 6, 2, 3 };
//ISortingClasses Sorter = new QuickSort<int>();
//Sorter.Sort(ints);
//Console.WriteLine($"{ints[0]}{ints[1]}{ints[2]}{ints[3]}{ints[4]}");
//ints = ints;
//Sorter = new BubbleSort<int>();
//Sorter.Sort(ints);
//Console.WriteLine($"{ints[0]}{ints[1]}{ints[2]}{ints[3]}{ints[4]}");


//Следующей задачей напишем HashMap
//var map = new HashTable<string, int>();
//map.Add("apple", 10);
//map.Add("banana", 20);

//Console.WriteLine(map.Get("apple"));  // 10
//Console.WriteLine(map.Get("banana")); // 20

//map.Remove("apple");
//Console.WriteLine(map.Count); // 1