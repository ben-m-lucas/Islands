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

            foreach (Coordinate coordinate in Coordinate.GetAllCoordinates(sea.GetLength(0), sea.GetLength(1)))
            {
                if (countedCoordinates.Contains(coordinate)) continue;

                if (sea[coordinate.X, coordinate.Y] == 'X')
                {
                    result++;
                }
                var connectedCoordinates = new List<Coordinate>();
                GetConnectedCoordinates(coordinate, sea, connectedCoordinates);
                countedCoordinates.AddRange(connectedCoordinates);
            }
            return result;
        }

        private void GetConnectedCoordinates(Coordinate coordinate, char[,] sea, List<Coordinate> connectedCoordinates)
        {
            if (connectedCoordinates.Contains(coordinate)) return;

            connectedCoordinates.Add(coordinate);
            if (sea[coordinate.X, coordinate.Y] != 'X') return;

            List<Coordinate> siblings = GetSiblingCoordinates(coordinate, sea);
            foreach (Coordinate sibling in siblings)
            {
                if (sea[sibling.X,sibling.Y] == 'X')
                {
                    GetConnectedCoordinates(sibling, sea, connectedCoordinates);
                }
            }

        }

        private List<Coordinate> GetSiblingCoordinates(Coordinate coordinate, char[,] sea)
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
