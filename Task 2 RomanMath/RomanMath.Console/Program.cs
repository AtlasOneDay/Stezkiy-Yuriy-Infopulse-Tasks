using System;
using RomanMath.Impl;

namespace RomanMath.Console
{
	class Program
	{
		/// <summary>
		/// Use this method for local debugging only. The implementation should remain in RomanMath.Impl project.
		/// See TODO.txt file for task details.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			string expression = "C+XV*II-X";
            var result = Service.Evaluate(expression);

            System.Console.WriteLine(expression + " = " + result);
            //System.Console.WriteLine(Service.ToRoman(2021)); ;

			System.Console.ReadKey();
		}
	}
}
