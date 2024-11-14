using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    public class Grid
    {
        Light[,] grid = new Light[1000, 1000];
        public Grid()
        {
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    grid[i, j] = new Light();
                }
            }
        }

        public void runCommand(string a)
        {
            Command cmd = parseCommand(a);

            for (int i = cmd.FromX; i <= cmd.ToX; i++)
            {
                for (int j = cmd.FromY; j <= cmd.ToY; j++)
                {
                    if (cmd.Action == "on") grid[i, j].on();
                    if (cmd.Action == "off") grid[i, j].off();
                    if (cmd.Action == "toggle") grid[i, j].toggle();

                }


            }

        }
        public int CountLightsOn()
        {
            int count = 0;

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (grid[i, j].get()) count++; 
                }
            }
            return count;
        }

         private Command parseCommand(string a)
            {
                Command cmd = new Command();
                if (a.Split(" ").Length == 5)
                {
                    cmd.Action = a.Split(" ")[1];
                    cmd.FromX = Int32.Parse(a.Split(" ")[2].Split(",")[0]);
                    cmd.FromY = Int32.Parse(a.Split(" ")[2].Split(",")[1]);
                    cmd.ToX = Int32.Parse(a.Split(" ")[4].Split(",")[0]);
                    cmd.ToY = Int32.Parse(a.Split(" ")[4].Split(",")[1]);
                }
                if (a.Split(" ").Length == 4)
                {
                    cmd.Action = a.Split(" ")[0];
                    cmd.FromX = Int32.Parse(a.Split(" ")[1].Split(",")[0]);
                    cmd.FromY = Int32.Parse(a.Split(" ")[1].Split(",")[1]);
                    cmd.ToX = Int32.Parse(a.Split(" ")[3].Split(",")[0]);
                    cmd.ToY = Int32.Parse(a.Split(" ")[3].Split(",")[1]);
                }
                return cmd;
            }

    }

        public class Light
        {
            bool light = false;

            public Light() { }

            public void on() { light = true; }
            public void toggle() { light = !light; }
            public void off() { light = false; }
            public bool get() { return light; }

        }

        public class Command
        {
            public string Action { get; set; } = "";
            public int FromX { get; set; } = 0;
            public int ToX { get; set; } = 0;
            public int FromY { get; set; } = 0;
            public int ToY { get; set; } = 0;

        }
}
