using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab1Geometry
{
    public partial class MainWindow : Window
    {
        private Random rnd = new Random();
        private Triangle currentTriangle;
        private Rectangle currentRectangle;
        private Rectangle currentSquare;

        // Оригинальные координаты фигур (для перемещения)
        private Point2D[] originalTrianglePoints;
        private Point2D originalRectPoint;
        private Point2D originalSquarePoint;
        private int originalRectWidth, originalRectHeight, originalSquareSize;

        public MainWindow()
        {
            InitializeComponent();
            InitializeEventHandlers();

            // Установим размеры Canvas после загрузки
            Loaded += (s, e) =>
            {
                Scene.Width = ((Border)Scene.Parent).ActualWidth - 2;
                Scene.Height = ((Border)Scene.Parent).ActualHeight - 2;
            };
        }

        private void InitializeEventHandlers()
        {
            Triangle.Click += (s, e) => CreateRandomTriangle();
            Rectange.Click += (s, e) => CreateRandomRectangle();
            Square.Click += (s, e) => CreateRandomSquare();

            Slider1.ValueChanged += (s, e) => MoveShapes();
            Slider2.ValueChanged += (s, e) => MoveShapes();
        }

        private void CreateRandomTriangle()
        {
            ClearScene();

            // Получаем доступные размеры с учетом отступов
            double maxX = Scene.ActualWidth - 50;
            double maxY = Scene.ActualHeight - 50;

            if (maxX < 100 || maxY < 100) return; // Проверка на минимальный размер

            Point2D p1 = new Point2D(rnd.Next(50, (int)maxX), rnd.Next(50, (int)maxY));
            Point2D p2 = new Point2D(rnd.Next(50, (int)maxX), rnd.Next(50, (int)maxY));
            Point2D p3 = new Point2D(rnd.Next(50, (int)maxX), rnd.Next(50, (int)maxY));

            currentTriangle = new Triangle(p1, p2, p3);

            // Сохраняем оригинальные координаты
            originalTrianglePoints = new Point2D[]
            {
                new Point2D(p1.getX(), p1.getY()),
                new Point2D(p2.getX(), p2.getY()),
                new Point2D(p3.getX(), p3.getY())
            };

            DrawTriangle(currentTriangle);

            // Сбрасываем слайдеры
            Slider1.Value = 0;
            Slider2.Value = 0;
        }

        private void CreateRandomRectangle()
        {
            ClearScene();

            double maxX = Scene.ActualWidth - 100;
            double maxY = Scene.ActualHeight - 100;

            if (maxX < 50 || maxY < 50) return;

            Point2D startPoint = new Point2D(rnd.Next(20, (int)maxX), rnd.Next(20, (int)maxY));
            int width = rnd.Next(30, 100);
            int height = rnd.Next(30, 100);

            currentRectangle = new Rectangle(startPoint, width, height);

            // Сохраняем оригинальные параметры
            originalRectPoint = new Point2D(startPoint.getX(), startPoint.getY());
            originalRectWidth = width;
            originalRectHeight = height;

            DrawRectangle(currentRectangle);

            Slider1.Value = 0;
            Slider2.Value = 0;
        }

        private void CreateRandomSquare()
        {
            ClearScene();

            double maxX = Scene.ActualWidth - 100;
            double maxY = Scene.ActualHeight - 100;

            if (maxX < 50 || maxY < 50) return;

            Point2D startPoint = new Point2D(rnd.Next(20, (int)maxX), rnd.Next(20, (int)maxY));
            int size = rnd.Next(30, 100);

            currentSquare = new Rectangle(startPoint, size, size);

            // Сохраняем оригинальные параметры
            originalSquarePoint = new Point2D(startPoint.getX(), startPoint.getY());
            originalSquareSize = size;

            DrawRectangle(currentSquare);

            Slider1.Value = 0;
            Slider2.Value = 0;
        }

        public void DrawLine(Point2D p1, Point2D p2, Brush strokeColor)
        {
            Line line = new Line();
            line.Stroke = strokeColor;
            line.StrokeThickness = 2;
            line.X1 = p1.getX();
            line.Y1 = p1.getY();
            line.X2 = p2.getX();
            line.Y2 = p2.getY();
            Scene.Children.Add(line);
        }

        public void DrawTriangle(Triangle tr)
        {
            DrawLine(tr.getP1(), tr.getP2(), Brushes.Red);
            DrawLine(tr.getP2(), tr.getP3(), Brushes.Red);
            DrawLine(tr.getP3(), tr.getP1(), Brushes.Red);
        }

        public void DrawRectangle(Rectangle rect)
        {
            DrawLine(rect.getP1(), rect.getP2(), Brushes.Blue);
            DrawLine(rect.getP2(), rect.getP3(), Brushes.Blue);
            DrawLine(rect.getP3(), rect.getP4(), Brushes.Blue);
            DrawLine(rect.getP4(), rect.getP1(), Brushes.Blue);
        }

        private void MoveShapes()
        {
            ClearScene();
            int deltaX = (int)Slider1.Value;
            int deltaY = (int)Slider2.Value;

            // Перемещаем треугольник
            if (currentTriangle != null && originalTrianglePoints != null)
            {
                Point2D p1 = new Point2D(
                    originalTrianglePoints[0].getX() + deltaX,
                    originalTrianglePoints[0].getY() + deltaY);
                Point2D p2 = new Point2D(
                    originalTrianglePoints[1].getX() + deltaX,
                    originalTrianglePoints[1].getY() + deltaY);
                Point2D p3 = new Point2D(
                    originalTrianglePoints[2].getX() + deltaX,
                    originalTrianglePoints[2].getY() + deltaY);

                currentTriangle = new Triangle(p1, p2, p3);
                DrawTriangle(currentTriangle);
            }

            // Перемещаем прямоугольник
            if (currentRectangle != null && originalRectPoint != null)
            {
                Point2D newPoint = new Point2D(
                    originalRectPoint.getX() + deltaX,
                    originalRectPoint.getY() + deltaY);

                currentRectangle = new Rectangle(newPoint, originalRectWidth, originalRectHeight);
                DrawRectangle(currentRectangle);
            }

            // Перемещаем квадрат
            if (currentSquare != null && originalSquarePoint != null)
            {
                Point2D newPoint = new Point2D(
                    originalSquarePoint.getX() + deltaX,
                    originalSquarePoint.getY() + deltaY);

                currentSquare = new Rectangle(newPoint, originalSquareSize, originalSquareSize);
                DrawRectangle(currentSquare);
            }
        }

        public void ClearScene()
        {
            Scene.Children.Clear();
        }
    }
}