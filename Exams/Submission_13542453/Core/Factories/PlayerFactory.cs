namespace PlayersAndMonsters.Core.Factories
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class PlayerFactory : IPlayerFactory
    {
        private IPlayerRepository playerRepository;

        public PlayerFactory()
        {
            this.playerRepository = new PlayerRepository();
        }

        public IPlayer CreatePlayer(string type, string username)
        {
            if (type == "Beginner")
            {
                IPlayer player = new Beginner(new CardRepository(), username);
                playerRepository.Add(player);
                return player;
            }
            else if (type == "Advanced")
            {
                IPlayer player = new Advanced(new CardRepository(), username);
                playerRepository.Add(player);
                return player;
            }
            else
            {
                return null;
            }
        }
    }
}
