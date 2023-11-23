using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandInfo = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = commandInfo[0];
            string[] commandArguments = commandInfo.Skip(1).ToArray();

            Type commandType = Assembly
                .GetEntryAssembly()
                .GetTypes().FirstOrDefault(t => t.Name == $"{command}Command");

            if (commandType == null)
            {
                throw new InvalidOperationException("Command not found.");
            }

            ICommand commandInatance =
                Activator.CreateInstance(commandType) as ICommand;

            MethodInfo methodInfo = typeof(ICommand).GetMethod("Execute");

            object result = methodInfo.Invoke(commandInatance, new object[] { commandArguments });

            return result.ToString();
        }
    }
}
