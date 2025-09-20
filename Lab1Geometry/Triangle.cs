using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Geometry
{
    public class Triangle
    {
        //Атрибуты класса
        private Point2D p1;
        private Point2D p2;
        private Point2D p3;
        //Конструктор класса
        public Triangle(Point2D p1, Point2D p2, Point2D p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }
        public Point2D getP1()
        {
            return p1;
        }
        public Point2D getP2()
        {
            return p2;
        }
        public Point2D getP3()
        {
            return p3;
        }
    }
}