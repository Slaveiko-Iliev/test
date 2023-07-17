string input = string.Empty;
Dictionary<string, int> playerPositions = new Dictionary<string, int>();
Dictionary<string, Dictionary<string, int>> listOfPlayers = new Dictionary<string, Dictionary<string, int>>();


while ((input = Console.ReadLine()) != "Season end")
{
    string[] infoOrCommand = input.Split();

    if (infoOrCommand.Length == 5 )
    {
        string player = infoOrCommand[0];
        string position = infoOrCommand[2];
        int skill = int.Parse(infoOrCommand[4]);

        if (!listOfPlayers.ContainsKey(player) )
        {
            listOfPlayers.Add(player, new Dictionary<string, int>());
        }

        if (!listOfPlayers[player].ContainsKey(position) )
        {
            listOfPlayers[player].Add(position, skill);
        }
        else
        {
            if (listOfPlayers[player][position] < skill)
            {
                listOfPlayers[player][position] = skill;
            }
        }

    }
    else if (infoOrCommand.Length == 3 )
    {
        string playerOne = infoOrCommand[0];
        string playerTwo = infoOrCommand[2];

        if (!listOfPlayers.ContainsKey(playerOne) || !listOfPlayers.ContainsKey(playerTwo))
        {
            break;
        }

        bool didFight = false;

        foreach (var itemOne in listOfPlayers[playerOne])
        {
            if (!didFight)
            {
                foreach (var itemTwo in listOfPlayers[playerTwo])
                {
                    if (itemOne.Key.Equals(itemTwo.Key))
                    {
                        int sumOfSkillsPlayerOne = listOfPlayers[playerOne].Values.Sum();
                        int sumOfSkillsPlayerTwo = listOfPlayers[playerTwo].Values.Sum();

                        if (sumOfSkillsPlayerOne > sumOfSkillsPlayerTwo)
                        {
                            listOfPlayers.Remove(playerTwo);
                            didFight = true;
                            break;
                        }
                        else if (sumOfSkillsPlayerOne < sumOfSkillsPlayerTwo)
                        {
                            listOfPlayers.Remove(playerOne);
                            didFight = true;
                            break;
                        }
                    }
                }
            }
        }
    }
}

//"{player}: {totalSkill} skill"
//"- {position} <::> {skill}"

foreach (var player in listOfPlayers.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
{
    Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

    foreach (var position in listOfPlayers[player.Key].OrderByDescending(x => x.Value).ThenBy(x => x.Key))
    {
        Console.WriteLine($"- {position.Key} <::> {position.Value}");

    }
}