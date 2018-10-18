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
            switch (cmd)
            {
                case "LOOK":
                    Console.WriteLine(locations[currentLocation].longDesc);
                    break;
                case "NORTH":
                case "N":
                    direction = locations[currentLocation].NORTH;
                    validateDirection(direction);
                    break;
                case "NORTHEAST":
                case "NE":
                    direction = locations[currentLocation].NORTHEAST;
                    validateDirection(direction);
                    break;
                case "EAST":
                case "E":
                    direction = locations[currentLocation].EAST;
                    validateDirection(direction);
                    break;
                case "SOUTHEAST":
                case "SE":
                    direction = locations[currentLocation].SOUTHEAST;
                    validateDirection(direction);
                    break;
                case "SOUTH":
                case "S":
                    direction = locations[currentLocation].SOUTH;
                    validateDirection(direction);
                    break;
                case "SOUTHWEST":
                case "SW":
                    direction = locations[currentLocation].SOUTHWEST;
                    validateDirection(direction);
                    break;
                case "WEST":
                case "W":
                    direction = locations[currentLocation].WEST;
                    validateDirection(direction);
                    break;
                case "NORTHWEST":
                case "NW":
                    direction = locations[currentLocation].NORTHWEST;
                    validateDirection(direction);
                    break;
                case "UP":
                case "U":
                    direction = locations[currentLocation].UP;
                    validateDirection(direction);
                    break;
                case "DOWN":
                case "D":
                    direction = locations[currentLocation].DOWN;
                    validateDirection(direction);
                    break;
                default:
                    Console.WriteLine("Bad Command");
                    break;
            }
        }

        static void validateDirection(int d)
        {
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

        static void LoadLocations()
        {
            string posLine;
            string[] posFields;
            locations.Add(null); // [0] is blank
            StreamReader sr = new StreamReader("C:\\Users\\Shadow\\Desktop\\CW Post\\CS 116\\Zork Project\\ZorkInfo.tbf");
            while((posLine = sr.ReadLine()) != null)
            {
                posFields = posLine.Split('\t');
                Location loc = new Location(Convert.ToInt32(posFields[0]), posFields[1], posFields[2], posFields[3], Convert.ToInt32(posFields[4]), Convert.ToInt32(posFields[5]), Convert.ToInt32(posFields[6]), Convert.ToInt32(posFields[7]), Convert.ToInt32(posFields[8]), Convert.ToInt32(posFields[9]), Convert.ToInt32(posFields[10]), Convert.ToInt32(posFields[11]), Convert.ToInt32(posFields[12]), Convert.ToInt32(posFields[13]));
                locations.Add(loc);
            }
        }
    }
}
