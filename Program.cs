using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace AdventOfCode
{
    internal class Program
    {
        public class House
        {
            private static int x = 0;
            private static int y = 0;

            public House(int xPosition, int yPosition)
            {
                x = xPosition; y = yPosition;

            }

        }

        static void Main(string[] args)
        {

            Console.WriteLine("Reading File: ");
            //string[] a = (string[])File.ReadAllLines("C:\\Users\\avetaash\\source\\repos\\AdventOfCode\\text.txt");
            string[] a = (string[])File.ReadAllLines(Directory.GetCurrentDirectory() + "\\..\\..\\..\\text.txt");
            Console.WriteLine("Total lines: " + a.Length);
            Console.WriteLine("Total movements: " + a[0].Length);

            List<House> houses = new List<House>();

            HashSet<string> uniquehouses = new HashSet<string>();

            houses.Add(new House(0, 0));
            uniquehouses.Add($"0,0");

            int x = 0, y = 0;

            foreach (char i in a[0])
            {
                if (i == '^') y++;
                if (i == 'v') y--;
                if (i == '>') x++;
                if (i == '<') x--;

                houses.Add(new House(x, y));
                uniquehouses.Add($"{x},{y}");
            }

            Console.WriteLine("Santa delivery");

            Console.WriteLine("Total presents delivered" + houses.Count);
            Console.WriteLine("Total distict houses: " + uniquehouses.Count);

            //Part 2

            List<House> SantaHouses = new List<House>();
            List<House> RoboHouses = new List<House>();

            HashSet<string> uniquehousesdual = new HashSet<string>();

            SantaHouses.Add(new House(0, 0));
            RoboHouses.Add(new House(0, 0));
            uniquehousesdual.Add($"0,0");

            int xSanta = 0, ySanta = 0, xRobo = 0, yRobo = 0, count = 0;

            foreach (char i in a[0])
            {

                if (count % 2 == 0)
                {
                    if (i == '^') ySanta++;
                    if (i == 'v') ySanta--;
                    if (i == '>') xSanta++;
                    if (i == '<') xSanta--;
                }
                else
                {
                    if (i == '^') yRobo++;
                    if (i == 'v') yRobo--;
                    if (i == '>') xRobo++;
                    if (i == '<') xRobo--;
                }



                uniquehousesdual.Add($"{xSanta},{ySanta}");
                uniquehousesdual.Add($"{xRobo},{yRobo}");


                count++;
            }

            Console.WriteLine();
            Console.WriteLine("Santa and RoboSanta delivery");
            Console.WriteLine("Total distict houses: " + uniquehousesdual.Count);






            Console.ReadKey();
        }


    }
}