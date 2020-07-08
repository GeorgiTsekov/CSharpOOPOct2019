using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card, ICard
    {
        private const int DamagePointsConst = 5;
        private const int HealthPointsConst = 80;

        public MagicCard(string name) 
            : base(name, DamagePointsConst, HealthPointsConst)
        {
        }
    }
}
