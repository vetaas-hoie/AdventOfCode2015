using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading File...");
            string[] a = (string[])File.ReadAllLines("D:\\Git\\vetaas-hoie\\AdventOfCode2015\\text.txt");

            Console.WriteLine("Ended up in floor: " + Day1(a[0]));
            Console.WriteLine("First time in basement: " + Day1_2(a[0]));


            Console.ReadKey();
        }

        static int Day1(string a)
        {
            int floor = 0;

            foreach (char c in a)
            {

                if (c == '(') floor++;
                if (c == ')') floor--;

            }
            return floor;
        }
        static int Day1_2(string a)
        {
            int floor = 0;
            int count = 0;
            foreach (char c in a)
            {
                count++;
                if (c == '(') floor++;
                if (c == ')') floor--;
                if (floor == -1) return count;   //added for part two 
            }
            return floor;
        }


    }
}