﻿namespace CommandPattern.Core.Commands
{
    using CommandPattern.Core.Contracts;
    using System.Diagnostics;

    public class OpenCommand : ICommand
    {
        public string Execute(string[] args)
        {
            string path = args[0];

            Process.Start("cmd", $"/c start {path}");

            return "Started successfully!";
        }
    }
}
