using System;
using System.Collections.Generic;
using System.Linq;

namespace Islands
{
    public class IslandDetector
    {
        public int GetIslandCount(char[,] sea)
        {
            var countedCoordinates = new List<Coordinate>();
            int result = 0;

            List<Coordinate> allCoordinates = Coordinate.GetAllCoordinates(sea.GetLength(0), sea.GetLength(1));
            // We only need to analyze coordinates that are already land
            foreach (Coordinate coordinate in allCoordinates.Where(x => sea[x.X, x.Y] == 'X'))
            {
                if (countedCoordinates.Contains(coordinate)) continue;

                result++; 

                //Any coordinates belonging to this island no longer need to be counted
                var connectedCoordinates = new List<Coordinate>();
                GetIsland(coordinate, sea, connectedCoordinates);
                countedCoordinates.AddRange(connectedCoordinates);
            }
            return result;
        }

        /// <summary>
        /// Returns the coordinates for the entire island that the given coordinate is a part of
        /// </summary>
        /// <param name="coordinate"></param>
        /// <param name="sea"></param>
        /// <param name="islandCoordinates"></param>
        private void GetIsland(Coordinate coordinate, char[,] sea, List<Coordinate> islandCoordinates)
        {
            if (islandCoordinates.Contains(coordinate)) return;

            islandCoordinates.Add(coordinate);
            List<Coordinate> siblings = GetConnectedCoordinates(coordinate, sea);
            foreach (Coordinate sibling in siblings)
            {
                if (sea[sibling.X,sibling.Y] == 'X')
                {
                    GetIsland(sibling, sea, islandCoordinates);
                }
            }
        }

        /// <summary>
        /// Returns the immediately connected coordinates to the provided coordinate (N, S, E, W, NE, NW, SE, SW)
        /// </summary>
        /// <param name="coordinate"></param>
        /// <param name="sea"></param>
        /// <returns></returns>
        private List<Coordinate> GetConnectedCoordinates(Coordinate coordinate, char[,] sea)
        {
            var list = new List<Coordinate>
            {
                new Coordinate(coordinate.X - 1, coordinate.Y - 1),
                new Coordinate(coordinate.X, coordinate.Y - 1),
                new Coordinate(coordinate.X + 1, coordinate.Y - 1),
                new Coordinate(coordinate.X - 1, coordinate.Y),
                new Coordinate(coordinate.X + 1, coordinate.Y),
                new Coordinate(coordinate.X - 1, coordinate.Y + 1),
                new Coordinate(coordinate.X, coordinate.Y + 1),
                new Coordinate(coordinate.X + 1, coordinate.Y + 1)
            };

            list = list.Where(x => x.X != -1 && x.X < sea.GetLength(0))
                .Where(x => x.Y != -1 && x.Y < sea.GetLength(1))
                .ToList();
            return list;
        }
    }
}
