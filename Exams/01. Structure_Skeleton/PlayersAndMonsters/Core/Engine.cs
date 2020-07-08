namespace PlayersAndMonsters.Core
{
    using PlayersAndMonsters.Core.Contracts;
    using PlayersAndMonsters.IO.Contracts;
    using System;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IManagerController managerController;

        public Engine(IReader reader, IWriter writer, IManagerController managerController)
        {
            this.reader = reader;
            this.writer = writer;
            this.managerController = managerController;
        }

        public void Run()
        {
            while (true)
            {
                string line = this.reader.ReadLine();

                if (line == "Exit")
                {
                    break;
                }

                string[] lineParts = line.Split(" ");

                string command = lineParts[0];

                string result = string.Empty;

                try
                {
                    result = ExecuteCommand(lineParts, command);
                }
                catch (ArgumentException ae)
                {
                    result = ae.Message;
                }

                this.writer.WriteLine(result);
            }
        }

        private string ExecuteCommand(string[] lineParts, string command)
        {
            string result = string.Empty;

            switch (command)
            {
                case "AddPlayer":
                    string playerType = lineParts[1];
                    string playerUsername = lineParts[2];

                    result = this.managerController.AddPlayer(playerType, playerUsername);
                    break;
                case "AddCard":
                    string cardType = lineParts[1];
                    string cardUsername = lineParts[2];

                    result = this.managerController.AddCard(cardType, cardUsername);
                    break;
                case "AddPlayerCard":
                    string username = lineParts[1];
                    string cardName = lineParts[2];

                    result = this.managerController.AddPlayerCard(username, cardName);
                    break;
                case "Fight":
                    string attacker = lineParts[1];
                    string enemy = lineParts[2];

                    result = this.managerController.Fight(attacker, enemy);
                    break;
                case "Report":
                    result = this.managerController.Report();
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
