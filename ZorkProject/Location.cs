using System;
using System.Collections.Generic;
using System.Text;

namespace ZorkProject
{
    class Location
    {
        public int locID;
        public string shortDesc;
        public string longDesc;
        public string initDesc;
        public int NORTH;
        public int NORTHEAST;
        public int EAST;
        public int SOUTHEAST;
        public int SOUTH;
        public int SOUTHWEST;
        public int WEST;
        public int NORTHWEST;
        public int UP;
        public int DOWN;
        public bool visited;
        public enum Directions
        {
            NORTH = 1, NORTHEAST, EAST, SOUTHEAST, SOUTH, SOUTHWEST, WEST, NORTHWEST, UP, DOWN,
            N = 1, NE, E, SE, S, SW, W, NW, U, D
        }

        public Location(int locID, string shortDesc, string longDesc, string initDesc, int NORTH, int NORTHEAST, int EAST, int SOUTHEAST, int SOUTH, int SOUTHWEST, int WEST, int NORTHWEST, int UP, int DOWN)
        {
            this.locID = locID;
            this.shortDesc = shortDesc;
            this.longDesc = longDesc;
            this.initDesc = initDesc;
            this.NORTH = NORTH;
            this.NORTHEAST = NORTHEAST;
            this.EAST = EAST;
            this.SOUTHEAST = SOUTHEAST;
            this.SOUTH = SOUTH;
            this.SOUTHWEST = SOUTHWEST;
            this.WEST = WEST;
            this.NORTHWEST = NORTHWEST;
            this.UP = UP;
            this.DOWN = DOWN;
            visited = false;
        }
     }
}
