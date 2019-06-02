using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Task1
{
    class PurchaseCollection : IEnumerable, IEnumerator
    {
        enum CountOfPurchaseClassFields
        {
            Purchase = 3,
            PricePurchase = 4
        }
        private List<Purchase> listPurchases;
        private int position = -1;
        public List<Purchase> ListPurchases { get => listPurchases; }
        public PurchaseCollection() { }
        public PurchaseCollection(string inFile)
        {
            StreamReader reader = new StreamReader(inFile + ".csv");
            listPurchases = new List<Purchase>();
            string str;
            while ((str = reader.ReadLine()) != null)
            {
                try
                {
                    listPurchases.Add(CreatePurchase(str));
                }
                catch (CsvLineException ex)
                {
                    Console.Write(ex.CsvString + " - ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }
        }
        private Purchase CreatePurchase(string stringInCSV)
        {
            string[] data = stringInCSV.Split(';');
            if (String.IsNullOrEmpty(data[0]))
            {
                throw new CsvLineException(stringInCSV, "purchase name not specified");
            }
            try
            {
                switch (data.Length)
                {
                    case (int)CountOfPurchaseClassFields.Purchase:
                        return new Purchase(data[0], decimal.Parse(data[1]), int.Parse(data[2]));
                    case (int)CountOfPurchaseClassFields.PricePurchase:
                        {
                            decimal price = decimal.Parse(data[1]);
                            decimal discount = decimal.Parse(data[3]);
                            if (price <= discount)
                            {
                                throw new CsvLineException(stringInCSV, "incorrect discount");
                            }
                            return new PricePurchase(data[0], price, int.Parse(data[2]), discount);
                        }
                    default:
                        throw new CsvLineException(stringInCSV, "invalid amount of data");
                }
            }
            catch (FormatException)
            {
                throw new CsvLineException(stringInCSV, "invalid data format");
            }
        }
        public Purchase GetElement(int index)
        {
            if (index < 0 || index >= listPurchases.Count)
                return null;
            return listPurchases[index];
        }
        public static string FindItemUseBinarySearch(Purchase purchase, List<Purchase> collection)
        {
            int index = collection.BinarySearch(purchase, new PurchasesByNamesComparator());
            if (index >= 0)
            {
                return ("Element " + purchase + " found in position " + index);
            }
            else
            {
                return ("Element " + purchase + " not found");
            }
        }
        public void Insert(int index, Purchase purchase)
        {
            if (index < 0 || index >= listPurchases.Count)
            {
                listPurchases.Add(purchase);
            }
            else
            {
                listPurchases.Insert(index, purchase);
            }
        }
        public int Delete(int index)
        {
            if (index < 0 || index >= listPurchases.Count)
            {
                return -1;
            }
            else
            {
                listPurchases.RemoveAt(index);
                return index;
            }
        }
        public decimal TotalCost()
        {
            decimal sum = 0;
            foreach (Purchase item in listPurchases)
            {
                sum += item.GetCost();
            }
            return sum;
        }
        public void Sort(IComparer<Purchase> comparer)
        {
            listPurchases.Sort(comparer);
        }
        public void Print()
        {
            Console.WriteLine(String.Format("{0,10}{1,10}{2,10}{3,10}{4,10}", "Name", "Price", "Number", "Cost", "Discount"));
            foreach (Purchase item in listPurchases)
            {
                Console.WriteLine(item.GetTableRow());
            }
            Console.WriteLine(String.Format("{0,-10}{1,30:N0}", "Total cost", TotalCost()));
        }
        public IEnumerator GetEnumerator()
        {
            return this;
        }
        public object Current { get => listPurchases[position]; }
        public bool MoveNext()
        {
            if (position < listPurchases.Count - 1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }
        public void Reset()
        {
            position = -1;
        }
    }
}
