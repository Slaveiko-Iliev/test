using System;
using System.Collections.Generic;
using System.Text;

int countOfOperations = int.Parse(Console.ReadLine());

string text = string.Empty;
Stack<string> stackToUndo = new();

for (int i = 0; i < countOfOperations; i++)
{
    string[] commandInfo = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

    string command = commandInfo[0];

    switch (command)  //h o h P
    {
        case "1":
            string textToAdd = commandInfo[1];
            stackToUndo.Push(text);
            text += textToAdd;
            break;
        case "2":
            int countToErases = int.Parse(commandInfo[1]);
            stackToUndo.Push(text);
            text = text.Substring(0, text.Length - countToErases);
            break;
        case "3":
            int index = int.Parse(commandInfo[1]);

            if (text.Length > 0)
            {
                Console.WriteLine(text[index-1]);
            }

            break;
        case "4":
            //string currentText = stackToUndo.Peek();
            text = stackToUndo.Pop();
            //stackToUndo.Push(currentText);
            break;
    }
}
