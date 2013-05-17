using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bordspil.GameService
{

    public class ConnectedPlayer
    {
        #region Properties
        public string Name { get; set; }
        public string ConnectionID { get; set; }
        public int Points { get; set; }
        public int Seat { get; set; }
        public int Bet { get; set; }
        public Card[] Cards { get; set; }
        public bool HitMe { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Takes in players name, points and seats and sets othe properties to
        /// default values
        /// </summary>
        /// <param name="n"></param>
        /// <param name="p"></param>
        /// <param name="s"></param>
        public ConnectedPlayer(string n, string c, int p, int s = -1)
        {
            this.Name = n;
            this.ConnectionID = c;
            this.Points = p;
            this.Seat = s;
            this.HitMe = true;
            this.Bet = 0;
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
            if (this.Points >= b)
            {
                this.Bet += b;
                this.Points -= b;
            }
            else
            {
                this.Bet = this.Points;
                this.Points = 0;
            }
        } 
        #endregion

    }

    public class Card
    {
        #region Properties
        public int Value { get; set; }
        public int Suit { get; set; } 
        #endregion

        #region Constructor
        public Card(int v, int s)
        {
            Value = v;
            Suit = s;
        } 
        #endregion
    }

    public class Deck
    {
        #region Properties
        public Card[] Cards;
        public int CardsLeft;

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor for the CardService class. Basically makes a new, ordered deck.
        /// </summary>
        public Deck()
        {
            for (int i = 1; i < 53; i++)
            {
                int v = i % 13;
                int s = (int)Math.Ceiling(i / 13.0);
                this.Cards[i] = new Card(v, s);
            }
            this.CardsLeft = 52;
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
            for (int i = (this.Cards.Length); i > 0; --i)
            {
                int randNum = r.Next(i + 1);
                Card temp = this.Cards[i];
                this.Cards[i] = this.Cards[randNum];
                this.Cards[randNum] = temp;
            }
            this.CardsLeft = 52;
        }

        /// <summary>
        /// Returns a Card object from the top of the deck
        /// </summary>
        /// <returns></returns>
        public Card DealCard()
        {
            this.CardsLeft--;
            if (this.CardsLeft >= 0)
            {
                return this.Cards[this.CardsLeft];
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