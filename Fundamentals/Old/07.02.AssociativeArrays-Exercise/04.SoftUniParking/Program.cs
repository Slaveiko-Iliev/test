int number = int.Parse(Console.ReadLine());

Dictionary<string, string> registeredUsers = new Dictionary<string, string>();

for (int i = 0; i < number; i++)
{
    string[] commandInfo = Console.ReadLine()
        .Split();

    string command = commandInfo[0];
    string username = commandInfo[1];
    

    if (command == "register")
    {

        string licensePlateNumber = commandInfo[2];
        if (!registeredUsers.ContainsKey(username))
        {
            registeredUsers.Add(username, licensePlateNumber);
            Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
        }
        else
        {
            Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
        }
    }
    else if (command == "unregister")
    {
        if (registeredUsers.ContainsKey(username))
        {
            registeredUsers.Remove(username);
            Console.WriteLine($"{username} unregistered successfully");
        }
        else
        {
            Console.WriteLine($"ERROR: user {username} not found");
        }
    }
}

foreach (KeyValuePair<string, string> item in registeredUsers)
{
    Console.WriteLine($"{item.Key} => {item.Value}");
}