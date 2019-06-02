using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"..\..\..\in.txt");
            List<Segment> listSegments = new List<Segment>();
            string str;
            try
            {
                while ((str = reader.ReadLine()) != null)
                {
                    string[] numbers = Regex.Split(str, @"\s*\(\s*|\s*;\s*|\s*\)\s*");
                    double x1 = double.Parse(numbers[1]);
                    double y1 = double.Parse(numbers[2]);
                    double x2 = double.Parse(numbers[4]);
                    double y2 = double.Parse(numbers[5]);
                    int len = (int)(Math.Round(Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2)), MidpointRounding.AwayFromZero));
                    Segment segment = new Segment(len);
                    int index = listSegments.BinarySearch(segment);
                    if (index < 0)
                    {
                        listSegments.Insert(~index, segment);
                    }
                    else
                    {
                        listSegments[index].Num++;
                    }
                }
                listSegments.Sort(new Segment());
                foreach (Segment item in listSegments)
                {
                    Console.WriteLine(item);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }
    }
}
