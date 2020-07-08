using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card, ICard
    {
        private const int DamagePointsConst = 120;
        private const int HealthPointsConst = 5;

        public TrapCard(string name) 
            : base(name, DamagePointsConst, HealthPointsConst)
        {
        }
    }
}
