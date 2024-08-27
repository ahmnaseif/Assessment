using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class PalindromeChecker
    {
        public bool CheckPalindrome(string inputString, string trashSymbolsString)
        {
            string filteredString = "";

            foreach (char ch in inputString)
            {
                if (!trashSymbolsString.Contains(ch))
                {
                    filteredString += char.ToLower(ch);
                }
            }

            int length = filteredString.Length;
            for (int i = 0; i < length / 2; i++)
            {
                if (filteredString[i] != filteredString[length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            PalindromeChecker checker = new PalindromeChecker();

            Console.WriteLine("Please Enter Your String");
            string userInput = Console.ReadLine();
            Console.WriteLine("Please Enter the trashsymbols of your string");
            string trashSymbols = Console.ReadLine();

            Console.WriteLine("Your string is a Palindrome: "+ checker.CheckPalindrome(userInput, trashSymbols));

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
