using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bordspil.GameService
{
    public class BJService
    {
        #region Variables
        static Random randomCard = new Random();
        static int pot;
        #endregion

        #region ProperFunctions

        #endregion

        #region HelperFunctions

        /// <summary>
        /// GiveRandomCard deals a random number between 0 and 51, which will be treated as an id for each card
        /// </summary>
        /// <returns></returns>
        public int GiveRandomCard()
        {
            // Returns a number between 0 and 51, which acts as an id for each card
            return randomCard.Next(0, 51);
        }

        /// <summary>
        /// ResetRandom is for making the dealer less predictable
        /// </summary>
        public void ResetRandom()
        {
            randomCard = new Random();
        }

        /// <summary>
        /// Bet accepts an integer with the amount the user wants to bet
        /// </summary>
        /// <param name="betAmount"></param>
        public void Bet(int betAmount)
        {
            // Adds betAmount to the pot
            pot += betAmount;
        }

        /// <summary>
        /// IsBlackJack accepts a List of integers and checks if player has BlackJack
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public bool IsBlackJack(List<int> cards)
        {
            // If 
            if (cards.Count == 2 && CalculateSum(cards) == 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// IsAce checks if a card is an Ace
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool IsAce(int card)
        {
            if (card % 13 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// IsBust checks if the players sum exceeds 21
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public bool IsBust(List<int> cards)
        {
            int sum = CalculateSum(cards);
            // IsBust checks if user is bust
            // It starts by checking if the users sum exceeds 21
            if (sum > 21)
            {
                // If so, it loops through the list of cards
                foreach (int card in cards)
                {
                    // Then it checks for aces and if the 
                    if (IsAce(card) == true && sum > 21)
                    {
                        sum -= 10;
                    }
                }
                if (sum > 21)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// CalculateSum just calculates the sum of the cards
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public int CalculateSum(List<int> cards)
        {
            // CalculateSum does what it says it does
            int sum = 0;
            // It loops through the cards that get passed to it
            foreach (int card in cards)
            {
                // Then it runs a switch sentence to determine the cards value
                switch (card % 13)
                {
                    // If it's 0, the card is an Ace
                    case 0:
                        // The sum is checked to make sure the player wont go bust
                        if (sum < 11)
                        {
                            sum += 11;
                        }
                        else
                        {
                            sum += 1;
                        }
                        break;
                    // In case of royalty (10, 11, 12), do the same...
                    case 10:
                    case 11:
                    case 12:
                        // ...and add 10 to the sum.
                        sum += 10;
                        break;
                    // The rest of the cards are simple
                    default:
                        // They all get their own values
                        sum += ((card % 13) + 1);
                        break;
                }
            }

            return sum;
        }

        

        #endregion
    }
}