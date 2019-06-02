using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // создать объект разработанного класса и загрузить в него данные из основного файла;
                PurchaseCollection purchaseCollectionOne = new PurchaseCollection(@"..\..\..\" + args[0]);
                Console.WriteLine("\nAfter creating from in.csv:");
                // вывести коллекцию покупок на консоль(метод Print());
                purchaseCollectionOne.Print();
                // создать второй объект разработанного класса и загрузить в него данные из дополнительного файла;
                PurchaseCollection purchaseCollectionTwo = new PurchaseCollection(@"..\..\..\" + args[1]);
                Console.WriteLine("\nAfter creating from addon.csv:");
                purchaseCollectionTwo.Print();
                //вставить последний элемент второй коллекции в позицию 0 первой коллекции покупок;
                purchaseCollectionOne.Insert(0, purchaseCollectionTwo.GetElement(purchaseCollectionTwo.ListPurchases.Count - 1));
                //вставить первый элемент второй коллекции в позицию 1000 первой коллекции покупок;
                purchaseCollectionOne.Insert(1000, purchaseCollectionTwo.GetElement(0));
                //вставить элемент с позицией 2 из второй коллекции в позицию 2 первой коллекции покупок;
                purchaseCollectionOne.Insert(2, purchaseCollectionTwo.GetElement(2));
                //последовательно удалить элементы через метод Delete() с индексами 3, 10 и –5;
                purchaseCollectionOne.Delete(3);
                purchaseCollectionOne.Delete(10);
                purchaseCollectionOne.Delete(-5);
                // вывести первую коллекцию на экран;
                Console.WriteLine("\nBefore sorting:");
                purchaseCollectionOne.Print();
                // отсортировать первую коллекцию методом Sort(…);
                purchaseCollectionOne.Sort(new PurchasesByNamesComparator());
                // вывести первую коллекцию на экран;
                Console.WriteLine("\nAfter sorting:");
                purchaseCollectionOne.Print();
                // найти через метод binarySearch() коллекции List<…> элементы с индексами 1 и 3 из второй коллекции в первой коллекции и вывести результаты поиска.
                Console.WriteLine("\nSearch results:");
                Console.WriteLine(PurchaseCollection.FindItemUseBinarySearch(purchaseCollectionTwo.GetElement(1), purchaseCollectionOne.ListPurchases));
                Console.WriteLine(PurchaseCollection.FindItemUseBinarySearch(purchaseCollectionTwo.GetElement(3), purchaseCollectionOne.ListPurchases));
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }
    }
}
