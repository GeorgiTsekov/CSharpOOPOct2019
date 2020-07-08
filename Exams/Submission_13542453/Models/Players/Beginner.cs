namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public class Beginner : Player, IPlayer
    {
        private const int HealthConst = 50;

        public Beginner(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, HealthConst)
        {
        }
    }
}
