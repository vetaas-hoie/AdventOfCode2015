using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    public class Grid2
    {
        Light2[,] grid = new Light2[1000, 1000];
        public Grid2()
        {
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    grid[i, j] = new Light2();
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
        public int CountBrightness()
        {
            int count = 0;

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    count += (grid[i, j].get()); 
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

        public class Light2
        {
            int light = 0;

            public Light2() { }
            public void on() { light++; }
            public void toggle() { light += 2; }
            public void off() { if(light > 0)light--; }
            public int get() { return light; }

        }

       
}
