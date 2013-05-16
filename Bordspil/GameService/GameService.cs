using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bordspil.GameService
{

    public class Player
    {
        #region Properties
        public string name { get; set; }
        public int points { get; set; }
        public int seat { get; set; }
        public int bet { get; set; }
        public List<Card> cards { get; set; }
        public bool hitMe { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Takes in players name, points and seats and sets othe properties to
        /// default values
        /// </summary>
        /// <param name="n"></param>
        /// <param name="p"></param>
        /// <param name="s"></param>
        public Player(string n, int p, int s)
        {
            this.name = n;
            this.points = p;
            this.seat = s;
            this.hitMe = true;
            this.bet = 0;
        }
        #endregion

        #region Functions
        /// <summary>
        /// Takes care of the players bet
        /// </summary>
        /// <param name="b"></param>
        public void MakeBet(int b)
        {
            if (b < 0)
            {
                b = 0;
            }
            if (this.points >= b)
            {
                this.bet += b;
                this.points -= b;
            }
            else
            {
                this.bet = this.points;
                this.points = 0;
            }
        } 
        #endregion

    }

    public class Card
    {
        #region Properties
        public int value { get; set; }
        public int suit { get; set; } 
        #endregion

        #region Constructor
        public Card(int v, int s)
        {
            value = v;
            suit = s;
        } 
        #endregion
    }

    public class Deck
    {
        #region Properties
        public List<Card> cards;
        public int cardsLeft;

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor for the CardService class. Basically makes a new, ordered deck.
        /// </summary>
        public Deck()
        {
            for (int v = 1; v < 14; v++)
            {
                for (int s = 1; s < 5; s++)
                {
                    this.cards.Add(new Card(v, s));
                }
            }
            this.cardsLeft = 52;
            this.Shuffle();
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
            for (int i = (this.cards.Count - 1); i > 0; --i)
            {
                int randNum = r.Next(i + 1);
                Card temp = this.cards[i];
                this.cards[i] = this.cards[randNum];
                this.cards[randNum] = temp;
            }
            this.cardsLeft = 52;
        }

        /// <summary>
        /// Returns a Card object from the top of the deck
        /// </summary>
        /// <returns></returns>
        public Card DealCard()
        {
            this.cardsLeft--;
            if (this.cardsLeft >= 0)
            {
                return this.cards[this.cardsLeft];
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
        #region Properties
        // Represents the number of sides on a dice
        public int sides; 
        #endregion

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