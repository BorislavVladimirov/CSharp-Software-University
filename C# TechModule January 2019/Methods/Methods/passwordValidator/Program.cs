﻿using System;

namespace passwordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPassword = Console.ReadLine();

            bool isBetweenSixAndTenChars = StringLenghtChecker(inputPassword);
            bool isOnlyLettersAndDigits = StringCharsCheckers(inputPassword);
            bool haveAtLeastTwoDigits = DigitCountChecker(inputPassword);

            if (!isBetweenSixAndTenChars)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!isOnlyLettersAndDigits)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!haveAtLeastTwoDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isBetweenSixAndTenChars && isOnlyLettersAndDigits && haveAtLeastTwoDigits)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool DigitCountChecker(string inputPassword)
        {
            int count = 0;

            for (int i = 0; i < inputPassword.Length; i++)
            {
                if (char.IsDigit(inputPassword[i]))
                {
                    count++;
                }
            }
            if (count >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool StringCharsCheckers(string inputPassword)
        {
            for (int i = 0; i < inputPassword.Length; i++)
            {
                if (!char.IsLetterOrDigit(inputPassword[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool StringLenghtChecker(string inputPassword)
        {
            if (inputPassword.Length >= 6 && inputPassword.Length <=10) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
