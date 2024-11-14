using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static System.Net.Mime.MediaTypeNames;

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

            int totalPaper = 0, totalRibbon = 0;

            foreach (string line in a)
            {
                totalPaper = totalPaper + CalculatePaper(line);
            }

            foreach (string line in a)
            {
                totalRibbon = totalRibbon + CalculateRibbon(line);
            }

            Console.WriteLine("Total paper: " + totalPaper);
            Console.WriteLine("Total Ribbon: " + totalRibbon);


            Console.ReadKey();
        }


        static int CalculatePaper(string a)
        {
            int l = 0, w = 0, h = 0;

            l = Int32.Parse(a.Split('x')[0]);
            w = Int32.Parse(a.Split('x')[1]);
            h = Int32.Parse(a.Split('x')[2]);
            int[] b = { l * w, w * h, h * l };

            return (2 * l * w) + (2 * w * h) + (2 * h * l) + b.Min();

        }

        static int CalculateRibbon(string a)
        {
            int l = 0, w = 0, h = 0;

            l = Int32.Parse(a.Split('x')[0]);
            w = Int32.Parse(a.Split('x')[1]);
            h = Int32.Parse(a.Split('x')[2]);
            int[] b = { l, w, h };
            b = b.OrderBy(x => x).ToArray();
            //Console.WriteLine("----------");
            //Console.WriteLine("Dimension: " + a);
            //Console.WriteLine("Parsed: " + l + "x" + w + "x" + h);
            //Console.WriteLine("Ribbon: 2x" + b[0] + " + 2x " + b[1]);
            //Console.WriteLine("Bow: " + l * w * h);
            int total = (2 * b[0]) + (2 * b[1]) + (l * w * h);
            //Console.WriteLine("Total: " + total);

            return total;
        }
    }
}