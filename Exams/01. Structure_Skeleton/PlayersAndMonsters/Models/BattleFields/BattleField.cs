namespace PlayersAndMonsters.Models.BattleFields
{
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using System;
    using System.Linq;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            if (attackPlayer.GetType().Name == "Beginner")
            {
                BoostBeginnerPlayer(attackPlayer);
            }

            if (enemyPlayer.GetType().Name == "Beginner")
            {
                BoostBeginnerPlayer(enemyPlayer);
            }

            BoostPlayersHp(attackPlayer);
            BoostPlayersHp(enemyPlayer);

            int attackPlayerDamage = attackPlayer
                                .CardRepository
                                .Cards
                                .Sum(c => c.DamagePoints);

            int enemyPlayerDamage = enemyPlayer
                                .CardRepository
                                .Cards
                                .Sum(c => c.DamagePoints);

            while (true)
            {
                enemyPlayer.TakeDamage(attackPlayerDamage);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPlayerDamage);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

        private void BoostPlayersHp(IPlayer player)
        {
            int playerBonusHealth = player
                            .CardRepository
                            .Cards
                            .Sum(c => c.HealthPoints);

            player.Health += playerBonusHealth;
        }

        private void BoostBeginnerPlayer(IPlayer player)
        {
            player.Health += 40;

            foreach (var card in player.CardRepository.Cards)
            {
                card.DamagePoints += 30;
            }
        }
    }
}
