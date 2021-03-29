using System;
using System.Linq;
using Rectangle.Impl;
using System.Collections.Generic;

namespace Rectangle.Console
{
	class Program
	{
		/// <summary>
		/// Use this method for local debugging only. The implementation should remain in Rectangle.Impl project.
		/// See TODO.txt file for task details.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			int minimumValueXY = -5;
			int maximumValueXY = 5;
			int amountOfPoints = 10;

			List<Point> points = Service.GetListOfRandomPoints(minimumValueXY, maximumValueXY, amountOfPoints);
			Service.DisplayPoints(points);

			var rectangle = Service.FindRectangle(points);
			Service.DisplayRectangleInfo(rectangle);

			System.Console.ReadKey();
		}
	}
}
