
using AdventOfCode2015;
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

            Grid lightshow = new Grid();
            Grid2 lightshow2 = new Grid2();

            foreach (string s in a) { 
            //lightshow.runCommand(s);
            //    Console.WriteLine(lightshow.CountLightsOn());
            lightshow2.runCommand(s);
                Console.WriteLine(lightshow2.CountBrightness());

            }

            Console.ReadKey();
        }


    }
}
