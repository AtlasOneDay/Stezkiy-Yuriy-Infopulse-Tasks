using System;
using System.Collections.Generic;

namespace RomanMath.Impl
{
	public static class Service
	{
       
        
        /// <summary>
        /// See TODO.txt file for task details.
        /// Do not change contracts: input and output arguments, method name and access modifiers
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
     
        public static int Evaluate(string expression)
		{
            List<string> romanNumbers = Utility.GetNumbers(expression);
            List<int> translatedRomanNumbers = Utility.ConvertRomanList(romanNumbers);
            List<char> operators = Utility.GetOperators(expression);

            // didn't have enough time to come up with idea of making while loops more readable, couldn't put them inside class , because they are changing 2 lists(maybe ref/out would help)
            while (Utility.CheckIfHasMultiplicationOperators(operators) == true)  //Execute all multiplications
            {
                for (int i = 0; i < translatedRomanNumbers.Count - 1; i++)
                {

                    if (operators[i].Equals('*'))
                    {
                        translatedRomanNumbers[i] = translatedRomanNumbers[i] * translatedRomanNumbers[i + 1];
                        for (int j = i + 1; j < translatedRomanNumbers.Count; j++)
                        {
                            if (j != translatedRomanNumbers.Count - 1)
                            {
                                translatedRomanNumbers[j] = translatedRomanNumbers[j + 1];
                            }
                            else
                            {
                                translatedRomanNumbers.RemoveAt(j);
                            }
                        }
                        operators.RemoveAt(i);
                        break;
                    }

                }          
                
            }
            while (Utility.CheckIfHasAdditionOperators(operators) == true || Utility.CheckIfHasSubtractionOperators(operators) == true) //Execute all additions/subtractions
            {
                for (int i = 0; i < translatedRomanNumbers.Count - 1; i++)
                {

                    if (operators[i].Equals('+'))
                    {
                        translatedRomanNumbers[i] = translatedRomanNumbers[i] + translatedRomanNumbers[i + 1];
                        for (int j = i + 1; j < translatedRomanNumbers.Count; j++)
                        {
                            if (j != translatedRomanNumbers.Count - 1)
                            {
                                translatedRomanNumbers[j] = translatedRomanNumbers[j + 1];
                            }
                            else
                            {
                                translatedRomanNumbers.RemoveAt(j);
                            }
                        }
                        operators.RemoveAt(i);
                        break;
                    }
                    else if(operators[i].Equals('-'))
                    {
                        translatedRomanNumbers[i] = translatedRomanNumbers[i] - translatedRomanNumbers[i + 1];
                        for (int j = i + 1; j < translatedRomanNumbers.Count; j++)
                        {
                            if (j != translatedRomanNumbers.Count - 1)
                            {
                                translatedRomanNumbers[j] = translatedRomanNumbers[j + 1];
                            }
                            else
                            {
                                translatedRomanNumbers.RemoveAt(j);
                            }
                        }
                        operators.RemoveAt(i);
                        break;
                    }

                }

            }




            
            return translatedRomanNumbers[0];
            
		}
	}
}
