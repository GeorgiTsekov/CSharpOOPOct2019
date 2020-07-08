using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        private ICardRepository cardRepository;

        public CardFactory()
        {
            this.cardRepository = new CardRepository();
        }

        public ICard CreateCard(string type, string name)
        {
            if (type == "Magic")
            {
                ICard card = new MagicCard(name);
                this.cardRepository.Add(card);
                return card;
            }
            else if (type == "Trap")
            {
                ICard card = new TrapCard(name);
                this.cardRepository.Add(card);
                return card;
            }
            else
            {
                return null;
            }
        }
    }
}
