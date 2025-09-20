using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Geometry
{
    public class Point2D
    {
        private int X;
        private int Y;

        public Point2D(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        // Конструктор копирования
        public Point2D(Point2D other)
        {
            this.X = other.getX();
            this.Y = other.getY();
        }

        public int getX() => X;
        public int getY() => Y;

        public void addX(int x) => X += x;
        public void addY(int y) => Y += y;
    
    }
}
