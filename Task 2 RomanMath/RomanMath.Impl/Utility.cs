using System;
using System.Collections.Generic;
using System.Text;

namespace RomanMath.Impl
{
    public static class Utility
    {
        public static void ExecuteMultiplications(List<int> translatedRomanNumbers, List<char> operators)
        {

            
        }
        public static bool CheckIfHasMultiplicationOperators(List<char> operators)
        {
            bool MultiplicationWasFound = false;
            foreach (char op in operators)
            {
                if (op.Equals('*'))
                    MultiplicationWasFound = true;
            }
            return MultiplicationWasFound;
        }
        public static bool CheckIfHasAdditionOperators(List<char> operators)
        {
            bool AdditionWasFound = false;
            foreach (char op in operators)
            {
                if (op.Equals('+'))
                    AdditionWasFound = true;
            }
            return AdditionWasFound;
        }
        public static bool CheckIfHasSubtractionOperators(List<char> operators)
        {
            bool SubtractionWasFound = false;
            foreach (char op in operators)
            {
                if (op.Equals('-'))
                    SubtractionWasFound = true;
            }
            return SubtractionWasFound;
        }
        public static List<string> GetNumbers(string expression)
        {
            List<string> romanNumbers = new List<string>();
            string tempstring = null;
            foreach (char sign in expression)
            {
                if (sign.Equals('+') || sign.Equals('-') || sign.Equals('*'))
                {
                    romanNumbers.Add(tempstring);
                    tempstring = null;
                }
                else
                {
                    tempstring += sign;
                }
            }
            romanNumbers.Add(tempstring);
            return romanNumbers;
        }
        public static List<char> GetOperators(string expression)
        {
            List<char> operators = new List<char>();
            foreach (char sign in expression)
            {
                if (sign.Equals('+') || sign.Equals('-') || sign.Equals('*'))
                {
                    operators.Add(sign);
                }
            }
            return operators;
        }
        public static void ShowEquasion(string expression)
        {
            List<string> romanNumbers = GetNumbers(expression);
            List<char> operators = GetOperators(expression);
            for (int i = 0; i < romanNumbers.Count; i++)
            {
                Console.Write(romanNumbers[i]);
                if (i < romanNumbers.Count - 1)
                    Console.Write(operators[i]);
            }
        }
        public static List<int> ConvertRomanList(List<string> romanNumbers)
        {
            List<int> translatedRomanNumbers = new List<int>();
            foreach (string romanNumber in romanNumbers)
            {
                translatedRomanNumbers.Add(Utility.ConvertRomanNumber(romanNumber));
            }
            return translatedRomanNumbers;
        }
        public static int ConvertRomanNumber(string number)
        {
            number = number.ToUpper();
            var result = 0;
            foreach (char letter in number)
            {
                result += ConvertRomanLetter(letter);
            }
            if (number.Contains("IV") || number.Contains("IX"))   // subtract 2/20/200 because, for example: IV = 6 according to previous code,
                result -= 2;
            if (number.Contains("XL") || number.Contains("XC"))   // so we subtract 2 , to make it 4
                result -= 20;
            if (number.Contains("CD") || number.Contains("CM"))
                result -= 200;
            return result;
        }

        private static int ConvertRomanLetter(char letter)
        {
            switch (letter)
            {
                case 'M':                   
                        return 1000;                    
                case 'D':                    
                        return 500;                    
                case 'C':                    
                        return 100;                   
                case 'L':                   
                        return 50;               
                case 'X':                    
                        return 10;                
                case 'V':                   
                        return 5;                    
                case 'I':                    
                        return 1;                    
                default:                   
                        throw new ArgumentException("Ivalid character");
                    
            }
        }
    }
}
