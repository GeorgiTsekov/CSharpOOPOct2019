using CommandPattern.Core.Contracts;
using System;
using System.IO;
using System.Linq;

namespace CommandPattern.Core.Commands
{
    public class CreateFileCommand : ICommand
    {
        public string Execute(string[] args)
        {
            string fileName = args[0];

            string content = "";

            if (args.Length > 1)
            {
                string[] arrayContent = args
                    .Skip(1)
                    .ToArray();

                content += String.Join(" ", arrayContent);

                File.WriteAllText(fileName, content);
            }

            return $"File {fileName} created successfully";
        }

        public string CurrentPath { get; set; }
    }
}
