using System;

namespace _04.PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isCorrectLength = GetLength(password);
            if (!isCorrectLength)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            bool isOnlyLettersAndDigits = GetSymbolType(password);
            if (!isOnlyLettersAndDigits)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            bool isEnoughDigits = GetNumberOfDigits(password);
            if (!isEnoughDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isCorrectLength && isOnlyLettersAndDigits && isEnoughDigits)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool GetLength(string password)
        {
            bool isLengthCorrect = true;

            if (password.Length < 6 || password.Length > 10)
            {
                isLengthCorrect = false;
            }
            return isLengthCorrect;
        }

        private static bool GetSymbolType(string password)
        {
            bool isLettersOrDigits = true;

            foreach (char c in password)
            {
                if (c >= 0 &&  c <= 47 || c >= 58 && c <= 64 || c >= 91 && c <= 96 || c >= 123)
                {
                    isLettersOrDigits = false;
                }
            }
            return isLettersOrDigits;
        }

        private static bool GetNumberOfDigits(string password)
        {
            int countOfDigits = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]) == true)
                {
                    countOfDigits++;
                }
            }
            if (countOfDigits >= 2)
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
