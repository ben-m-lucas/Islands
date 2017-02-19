using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Islands
{
    public struct Coordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X;
        public int Y;

        public static List<Coordinate> GetAllCoordinates(int width, int height)
        {
            var result = new List<Coordinate>();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    result.Add(new Coordinate(x, y));
                }
            }
            return result;
        }
    }
}
