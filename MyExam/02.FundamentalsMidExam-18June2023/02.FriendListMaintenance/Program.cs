using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace _02.FriendListMaintenance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> friendsList = Console.ReadLine()
                .Split(", ")
                .ToList();

            string input = string.Empty;
            int blacklisted = 0;
            int lostNames = 0;

            while ((input = Console.ReadLine()) != "Report")
            {
                string[] fullCommand = input.Split().ToArray();
                
                string command = fullCommand[0];

                if (command == "Blacklist")
                {
                    string friendsName = fullCommand[1];

                    if (friendsList.Contains(friendsName))
                    {
                        int indexOfFriendsName = friendsList.IndexOf(friendsName);

                        friendsList[indexOfFriendsName] = "Blacklisted";
                        blacklisted++;
                        Console.WriteLine($"{friendsName} was blacklisted.");
                    }
                    else
                    {
                        Console.WriteLine($"{friendsName} was not found.");
                    }
                }
                else if (command == "Error")
                {
                    int index = int.Parse(fullCommand[1]);

                    if (IsValidIndex(friendsList, index))
                    {
                        string friendsName = friendsList[index];

                        if (IsValidIndex(friendsList, index) && friendsList[index] != "Blacklisted" && friendsList[index] != "Lost")
                        {
                            friendsList[index] = "Lost";
                            Console.WriteLine($"{friendsName} was lost due to an error.");
                            lostNames++;
                        }
                    }
                }
                else if (command == "Change")
                {
                    int index = int.Parse(fullCommand[1]);
                    string newName = fullCommand[2];

                    if (IsValidIndex(friendsList, index))
                    {
                        string currentName = friendsList[index];

                        friendsList[index] = newName;
                        Console.WriteLine($"{currentName} changed his username to {newName}.");
                    }
                }
            }
            Console.WriteLine($"Blacklisted names: {blacklisted}");
            Console.WriteLine($"Lost names: {lostNames}");
            Console.WriteLine(string.Join(" ", friendsList));
        }

        static bool IsValidIndex(List<string> friendsList, int index)
        {
            if (index >= 0 && index < friendsList.Count)
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
