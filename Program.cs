
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

            Console.WriteLine("Reading File: ");
            //string[] a = (string[])File.ReadAllLines("C:\\Users\\avetaash\\source\\repos\\AdventOfCode\\text.txt");
            string[] a = (string[])File.ReadAllLines(Directory.GetCurrentDirectory() + "\\..\\..\\..\\text.txt");
            Console.WriteLine("Total lines: " + a.Length);
            int nice = 0;
            foreach (string s in a) {
                //if (Contains3vovelNotdisctinct(s) && ContainsDoubleLetter(s) && NotContains(s)) nice++;
                //Console.WriteLine(s + " - " + Contains3vovelNotdisctinct(s) + " " + ContainsDoubleLetter(s) + " " + NotContains(s));
                if (Repeat(s) && RepeatTwoLetter(s)) nice++;
                Console.WriteLine(s + " - " + Repeat(s) + " " + RepeatTwoLetter(s));
            }
            Console.WriteLine("Antall Nice: " + nice);

            Console.ReadKey();
        }

        static bool Contains3vovelNotdisctinct(string a)
        {
            int count = 0;

            foreach (char s in a)
            {
                if (s == 'a') count++;
                if (s == 'e') count++;
                if (s == 'i') count++;
                if (s == 'o') count++;
                if (s == 'u') count++;
                //if (s == 'y') count++;
            }

            return count >= 3;
        }
        static bool ContainsDoubleLetter(string a)
        {
            int i = 1;

            for (int j = 0; j < a.Length-1; j++)
            {
                
                if (a[j] == a[j+1]) return true;
            }
                       
            return false;
        }

        static bool NotContains(string a)
        {
            if (a.Contains("ab")) return false;
            if (a.Contains("cd")) return false;
            if (a.Contains("pq")) return false;
            if (a.Contains("xy")) return false;

            return true;
        }

        static bool Repeat(string a) //Part 2
        {
            for (int j = 0; j < a.Length - 2; j++)
            {

                if (a[j] == a[j + 2]) return true;
            }
            return false;
        }

        static bool RepeatTwoLetter(string a) //Part2
        {
            for (int j = 0; j < a.Length - 2; j++)
            {

                if (a.Substring(j+2,a.Length-j-2).Contains(a.Substring(j,2))) return true;
            }
            return false;
        }

    }
}
