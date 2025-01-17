﻿namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerFactory playerFactory;
        private IPlayerRepository playerRepository;
        private ICardFactory cardFactory;
        private ICardRepository cardRepository;
        private IBattleField battleField;

        public ManagerController(
            IPlayerFactory playerFactory, 
            IPlayerRepository playerRepository, 
            ICardFactory cardFactory, 
            ICardRepository cardRepository,
            IBattleField battleField)
        {
            this.playerFactory = playerFactory;
            this.playerRepository = playerRepository;
            this.cardFactory = cardFactory;
            this.cardRepository = cardRepository;
            this.battleField = battleField;
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = this.playerFactory.CreatePlayer(type, username);

            this.playerRepository.Add(player);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            ICard card = this.cardFactory.CreateCard(type, name);

            this.cardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this.playerRepository.Find(username);
            ICard card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attackPlayer = this.playerRepository.Find(attackUser);
            var enemyPlayer = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attackPlayer, enemyPlayer);

            return string.Format(ConstantMessages.FightInfo, attackPlayer.Health, enemyPlayer.Health);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in this.playerRepository.Players)
            {
                sb.AppendLine(string.Format(ConstantMessages.PlayerReportInfo, 
                    player.Username, 
                    player.Health,
                    player.CardRepository.Cards.Count));

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(string.Format(ConstantMessages.CardReportInfo,
                    card.Name,
                    card.DamagePoints,
                    player.CardRepository.Cards.Count));
                }

                sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
