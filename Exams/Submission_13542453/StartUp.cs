namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.IO;
    using PlayersAndMonsters.IO.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IPlayerFactory playerFactory = new PlayerFactory();
            IPlayerRepository playerRepository = new PlayerRepository();
            ICardFactory cardFactory = new CardFactory();
            ICardRepository cardRepository = new CardRepository();
            IBattleField battleField = new BattleField();

            IManagerController managerController = new ManagerController(
                playerFactory, 
                playerRepository,
                cardFactory, 
                cardRepository, 
                battleField);

            IEngine engine = new Engine(reader, writer, managerController);

            engine.Run();
        }
    }
}