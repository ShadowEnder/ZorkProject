using System;
using System.Collections.Generic;
using System.IO;

namespace ZorkProject
{
    class Program
    {
        static List<Location> locations = new List<Location>();
        static int currentLocation;
        static int direction;
        static string[] directions = new string[]
        {
            "NORTH", "NORTHEAST", "EAST", "SOUTHEAST", "SOUTH", "SOUTHWEST", "WEST", "NORTHWEST", "UP", "DOWN", "IN", "OUT",
            "N", "NE", "E", "SE", "S", "SW", "W", "NW", "U", "D", "I", "O"
        }; // 24 total
        static void Main(string[] args)
        {
            GameSetup();
            LoadLocations();
            Run();

            Console.ReadKey();
        }

        static void GameSetup()
        {
            currentLocation = 0;
        }

        static void Run()
        {
            if (currentLocation == 0)
            {
                currentLocation = 1;
                Console.WriteLine(locations[1].shortDesc);
                if(locations[1].visited == false)
                {
                    Console.WriteLine(locations[1].longDesc);
                    locations[1].visited = true;
                }
                
            }
            string input = Console.ReadLine();
            while (!(input.ToUpper().Equals("QUIT")))
            {
                ProcessCmd(input.ToUpper());
                input = Console.ReadLine();
            }
        }

        static void ProcessCmd(string cmd)
        {
            if(cmd == "LOOK")
            {
                Console.WriteLine(locations[currentLocation].longDesc);
            }
            else if (locations[currentLocation].directionsDict.ContainsKey(cmd))
            {
                int d;
                locations[currentLocation].directionsDict.TryGetValue(cmd, out d);

                if (d < 0)
                {
                    Console.WriteLine("The way is blocked");
                }
                else if (d == 0)
                {
                    Console.WriteLine("Can't go that way");
                }
                else
                {
                    currentLocation = d;
                    Console.WriteLine(locations[currentLocation].shortDesc);
                    if (locations[currentLocation].visited == false)
                    {
                        Console.WriteLine(locations[currentLocation].longDesc);
                        locations[currentLocation].visited = true;
                    }
                }
            }
            else
            {
                Console.WriteLine("Bad Command");
            }
        }      

        static void LoadLocations()
        {
            string posLine;
            string[] posFields;
            locations.Add(null); // [0] is blank
            StreamReader sr = new StreamReader("C:\\Users\\Shadow\\Desktop\\CW Post\\CS 116\\Zork Project\\ZorkInfo.tbf");
            while((posLine = sr.ReadLine()) != null)
            {
                posFields = posLine.Split('\t');
                Location loc = new Location();
                loc.ID = Convert.ToInt32(posFields[0]);
                loc.shortDesc = posFields[1];
                loc.longDesc = posFields[2];
                loc.initDesc = posFields[3];
                for(int i=0; i<12; i++)
                {
                    int num = 0;
                    int.TryParse(posFields[5+i], out num); // parse exits, converting to int, and adding exits[] array
                    loc.exits[i] = num;
                }
                for(int i=0; i<24; i++)
                {
                    loc.directionsDict.Add(directions[i], loc.exits[i]); // add [directionName, exit#]
                }
                locations.Add(loc);
            }
        }
    }
}
