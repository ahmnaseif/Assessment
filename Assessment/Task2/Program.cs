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
            int left = 0;
            int right = inputString.Length - 1;

            while (left < right)
            {
                while (trashSymbolsString.Contains(inputString[left]) || trashSymbolsString.Contains(inputString[right]))
                {
                    if(trashSymbolsString.Contains(inputString[left]))
                        left++;

                    if(left < right  && trashSymbolsString.Contains(inputString[right]))
                        right--;    

                }

                if (left < right  && char.ToLower(inputString[left]) != char.ToLower(inputString[right]))
                {
                    return false;
                }

                left++;
                right--;
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
