using System;
using System.Collections.Generic;
using System.Text;

namespace ZorkProject
{
    class Location : GameObject
    {
        public bool visited;

        public int[] exits = new int[12]; // NORTH, NORTHEAST, EAST, SOUTHEAST, SOUTH, SOUTHWEST, WEST, NORTHWEST, UP, DOWN, IN, OUT

        public Location()
        {
            //visited = false;
        }
     }
}
