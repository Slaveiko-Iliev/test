using System;

namespace _05.Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Empty;

            for (int i = username.Length -1; i >= 0; i--)
            {
                char letter = username[i];
                password += letter;
            }

            int attempt = 0;
            bool isLogin = false;

            while (!isLogin)
            {
                for (int i = 1; i <= 3; i++)
                {
                    string currentPass = Console.ReadLine();
                    if (currentPass == password)
                    {
                        isLogin = true;
                        Console.WriteLine($"User {username} logged in.");
                        break;
                    }
                    else if (currentPass != password)
                    {
                        Console.WriteLine("Incorrect password. Try again.");
                        attempt++;
                    }
                    if (attempt == 3)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        return;
                    }
                }
            }
        }
    }
}
