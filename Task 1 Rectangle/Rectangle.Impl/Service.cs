using System;
using System.Collections.Generic;
using System.Linq;

namespace Rectangle.Impl
{
	public static class Service
	{    
        /// <summary>
        /// See TODO.txt file for task details.
        /// Do not change contracts: input and output arguments, method name and access modifiers
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        /// 
        public static void DisplayPoints(List<Point> points)
        {
			System.Console.WriteLine("Points:");
			for (int i = 0; i < points.Count; i++)
			{
				System.Console.WriteLine("P{0}({1},{2})", i + 1, points[i].X, points[i].Y);
			}
		}
		public static void DisplayRectangleInfo(Rectangle rectangle)
        {
			System.Console.WriteLine("Rectangle bottom-left point: P({0};{1}) ", rectangle.X, rectangle.Y);
			System.Console.WriteLine("Rectangle Width = {0}, Height = {1}", rectangle.Width, rectangle.Height);
		}
		public static List<Point> GetListOfRandomPoints(int minValue, int maxValue, int listLength)
        {
			Random rand = new Random();
			List<Point> listOfRandomPoints = new List<Point>();
			for(int i = 0; i < listLength; i++)
            {
				Point tempPoint = new Point();
				tempPoint.X = rand.Next(minValue, maxValue);
				tempPoint.Y = rand.Next(minValue, maxValue);
				listOfRandomPoints.Add(tempPoint);
            }
			return listOfRandomPoints;
        }
		public static Rectangle FindRectangle(List<Point> points)
		{			
			if (points.Count < 2)
			{
				throw new ArgumentException("Given List has less than two points");
			}
			else if(Utility.CheckForDuplicates(points)) // Points list has duplicates
			{
				throw new ArgumentException("Given List has duplicate points");
			}
			else if(points.Count == 2) //if only 2 points, create 1x1 square with one of them in bottom-left corner
            {
				Random random = new Random();
				Rectangle returnedRectangle = new Rectangle();
				Point oneOfTwoPoints = points[random.Next(points.Count)];

				returnedRectangle.X = oneOfTwoPoints.X;				//could replace these 4 lines with 1 line of constructor call, but dont know 
				returnedRectangle.Y = oneOfTwoPoints.Y;             //if I'm allowed to change Rectangle.cs
				returnedRectangle.Height = 1;						//
				returnedRectangle.Width = 1;						//
				return returnedRectangle;
			}
			else
			{
				Rectangle returnedRectangle = new Rectangle();

				List<Point> pointsWithoutOne = Utility.FilterOutUnwantedPoint(points);
				List<int> xValues = Utility.ExtractValuesX(pointsWithoutOne);      //split one "points" list in two , one for x and y values
				List<int> yValues = Utility.ExtractValuesY(pointsWithoutOne);

				returnedRectangle.X = xValues.Min();                      // bottom left point of the rectangle will be a point with the smallest X and Y values
				returnedRectangle.Y = yValues.Min();
				returnedRectangle.Height = yValues.Max() - yValues.Min();// subtracting the "highest" point of the rectangle from the "lowest" will give us its height"
				returnedRectangle.Width = xValues.Max() - xValues.Min();

				return returnedRectangle;
			}
		}
	}
}
