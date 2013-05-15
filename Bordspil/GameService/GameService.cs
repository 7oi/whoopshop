using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bordspil.GameService
{
    
    public class CardService
    {
        #region Property Classes

        public class Card
        {
            public int value;
            public int suit;

            public Card(int v, int s)
            {
                value = v;
                suit = s;
            }
        }

        public class Cards
        {
            public List<Card> cards;
            public int cardsLeft;
        } 
        #endregion

        #region Properties
        public Cards deck;
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor for the CardService class. Basically makes a new, ordered deck.
        /// </summary>
        public CardService()
        {
            for (int v = 1; v < 14; v++)
            {
                for (int s = 1; s < 5; s++)
                {
                    deck.cards.Add(new Card(v, s));
                }
            }
            deck.cardsLeft = 51;
        } 
        #endregion

        #region Functions
        
        /// <summary>
        /// Shuffles the deck and resets the cardsLeft value
        /// </summary>
        public void Shuffle()
        {
            Random r = new Random();
            // Based on the Fisher-Yates shuffle
            for (int i = (this.deck.cards.Count - 1); i > 0; --i)
            {
                int randNum = r.Next(i + 1);
                Card temp = this.deck.cards[i];
                this.deck.cards[i] = this.deck.cards[randNum];
                this.deck.cards[randNum] = temp;
            }
            this.deck.cardsLeft = 51;
        }

        /// <summary>
        /// Returns a Card object from the top of the deck
        /// </summary>
        /// <returns></returns>
        public Card DealCard()
        {
            this.deck.cardsLeft--;
            if (this.deck.cardsLeft >= 0)
            {
                return this.deck.cards[this.deck.cardsLeft];
            }
            else
            {
                return null;
            }
        } 
        #endregion
    }

    public class Dice
    {
        // Represents the number of sides on a dice
        public int sides;

        #region Constructors
        /// <summary>
        /// Default constructor returns a dice that has 6 sides
        /// </summary>
        /// <param name="s"></param>
        public Dice()
        {
            this.sides = 6;
        }

        /// <summary>
        /// Constructor which takes in an argument which determines the number of sides on the dice
        /// </summary>
        /// <param name="s"></param>
        public Dice(int s)
        {
            this.sides = s;
        } 
        #endregion

        #region Functions
        /// <summary>
        /// Returns a random value between 1 and the number of sides on the dice
        /// </summary>
        /// <returns></returns>
        public int Throw()
        {
            Random r = new Random();
            return r.Next(1, this.sides);
        } 
        #endregion
    }
}