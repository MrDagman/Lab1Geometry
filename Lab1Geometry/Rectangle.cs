using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Geometry
{
    public class Rectangle
    {
        private Point2D startPoint;
        private int width;
        private int height;
        public Rectangle(Point2D startPoint, int width, int height)
        {
            this.startPoint = startPoint;
            this.width = width;
            this.height = height;
        }
        public Point2D getP1()
        {
            return startPoint;
        }
        public Point2D getP2()
        {
            return new Point2D(startPoint.getX() + width, startPoint.getY());
        }
        public Point2D getP3()
        {
            return new Point2D(startPoint.getX() + width, startPoint.getY() + height);
        }
        public Point2D getP4()
        {
            return new Point2D(startPoint.getX(), startPoint.getY() + height);
        }
        public void addX(int X)
        {
            startPoint.addX(X);
        }
        public void addY(int Y)
        {
            startPoint.addY(Y);
        }
        public int getWidth()
        {
            return width;
        }
        public int getHeight()
        {
            return height;
        }
    }
}