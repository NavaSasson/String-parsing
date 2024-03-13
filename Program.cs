using System;
using System.Linq;

namespace Ex01_04
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter a string of length 8, which contains only English letters or only digits");
            string inputFromUser = GetValidStrFromUser();
            CheckIfStrIsPolindrom(inputFromUser);
            CheckIfNumberDivisibleByFive(inputFromUser);
            CountLowerCase(inputFromUser);
        }

        private static string GetValidStrFromUser()
        {
            string inputFromUser = Console.ReadLine();
            bool isVailidStr = CheckIfValidInput(inputFromUser);

            if (!isVailidStr)
            {
                Console.WriteLine("Invalid string, try again!");
                inputFromUser = GetValidStrFromUser();
            }

            return inputFromUser;
        }

        private static bool CheckIfValidInput(string i_InputStr)
        {
            bool isValidLength = i_InputStr.Length == 8;
            bool isValidStrOfNumbers = i_InputStr.All(char.IsDigit);
            bool isValidStrOfLetters = i_InputStr.All(char.IsLetter);

            return isValidLength && (isValidStrOfLetters || isValidStrOfNumbers);
        }

        private static void CheckIfNumberDivisibleByFive(string i_InputStr)
        {
            bool isContainOnlyDigits = i_InputStr.All(char.IsDigit);
            string isDivisibleByFiveStr = "";

            if (isContainOnlyDigits)
            {
                bool isNumberDivisibleByFive = int.Parse(i_InputStr, System.Globalization.NumberStyles.Integer) % 5 == 0;
                if (!isNumberDivisibleByFive)
                {
                    isDivisibleByFiveStr = "not ";
                }
                
                Console.WriteLine(string.Format("The number is {0}divisble by 5", isDivisibleByFiveStr));
            }
        }

        private static void CountLowerCase(string i_InputStr)
        {
            bool isValidStrOfLetters = i_InputStr.All(char.IsLetter);

            if (isValidStrOfLetters)
            {
                int lowerCaseCounter = 0;
                for (int i = 0; i < i_InputStr.Length; i++)
                {
                    if (char.IsLower(i_InputStr[i]))
                    {
                        lowerCaseCounter += 1;
                    }
                }

                Console.WriteLine(string.Format("Your string contains {0} lower case", lowerCaseCounter));
            }
        }

        private static void CheckIfStrIsPolindrom(string i_InputStr)
        {
            string isPolindromStr = "";

            for (int i = 0, j = i_InputStr.Length - 1; i < j; i++, j--)
            {
                if (i_InputStr[i] != i_InputStr[j])
                {
                    isPolindromStr = "not ";
                    break;
                }
            }

            Console.WriteLine(string.Format("Your string is {0}a polindrom", isPolindromStr));
        }
    }
}