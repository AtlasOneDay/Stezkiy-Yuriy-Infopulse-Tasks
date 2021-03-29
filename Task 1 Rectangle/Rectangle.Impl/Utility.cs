using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Rectangle.Impl
{
    public static class Utility
    {
        public static List<int> ExtractValuesX(List<Point> points)
        {
            List<int> xValues = new List<int>();
            foreach (Point point in points)
            {
                xValues.Add(point.X);               
            }
            return xValues;
        }
        public static List<int> ExtractValuesY(List<Point> points)
        {
            List<int> yValues = new List<int>();
            foreach (Point point in points)
            {
                yValues.Add(point.Y);
            }
            return yValues;
        }
        public static List<Point> FilterOutUnwantedPoint(List<Point> initialPoints)
        {                             
            List<Point> pointsWithoutOne = new List<Point>();
            Point unwantedPoint = FindUnwantedPoint(initialPoints);
            foreach (Point point in initialPoints)
            {
                if(point != unwantedPoint)
                {
                    pointsWithoutOne.Add(point);
                }
            }
            return pointsWithoutOne;          
        }
        public static Point FindUnwantedPoint(List<Point> initialPoints)
        {
            Random random = new Random();
            List<Point> furthestPoints = FindFurthestPoints(initialPoints);
            Point unwantedPoint = furthestPoints[random.Next(furthestPoints.Count)];
            return unwantedPoint;
        }
        public static List<Point> FindFurthestPoints(List<Point> initialPoints)
        {
            List<int> xValues = ExtractValuesX(initialPoints);
            List<int> yValues = ExtractValuesY(initialPoints);
            List<Point> furthestPoints = new List<Point>();
            foreach(Point point in initialPoints) //point is one of the furthest if one of its coords is the biggest/smallest
            {
                if (point.X == xValues.Max())
                {
                    furthestPoints.Add(point);
                }
                else if(point.X == xValues.Min())
                {
                    furthestPoints.Add(point);
                }
                else if(point.Y == yValues.Max())
                {
                    furthestPoints.Add(point);
                }
                else if(point.Y == yValues.Min())
                {
                    furthestPoints.Add(point);
                }
            }
            return furthestPoints;
        }
        public static bool CheckForDuplicates(List<Point> points)
        {
            bool duplicatesFound = false;
            List<int> xValues = ExtractValuesX(points);
            List<int> yValues = ExtractValuesY(points);
            int[,] values = new int[2,points.Count];        //two dimensional with 2 columns of x and y values
            int counter = 0;
            while(counter < points.Count)
            {
                values[0, counter] = xValues[counter];      
                values[1, counter] = yValues[counter];
                counter++;
            }
            for (int valueRowNumber = 0; valueRowNumber < values.Length/2; valueRowNumber++)
            {
                duplicatesFound = false;

                for (int numberOfCompaerd = 0; numberOfCompaerd < values.Length/2; numberOfCompaerd++)
                {
                    if ((valueRowNumber!= numberOfCompaerd) && values[0,valueRowNumber] == values[0,numberOfCompaerd] && values[1,valueRowNumber] == values[1,numberOfCompaerd])
                    {
                        duplicatesFound = true;
                        return duplicatesFound;
                    }
                }
            }
                return duplicatesFound;
        }
    }
}
