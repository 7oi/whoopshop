using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bordspil.Models;

namespace Bordspil.GameService
{
    public class RiskService
    {
        #region StartGameVariables
        Risk riskDB = new Risk();
        Country countryDB = new Country();
        #endregion

        #region OneTurnVariables
        
        #endregion


        #region ProperFunctions

        #endregion

        #region To Do Function

        public void PlaceFirstTroops(int numTroops)
        {

        }

        public void AddTroops()
        {

        }

        public void CalculateReinforcements()
        {

        }

        public void ContinentConquerer()
        {
            
        }        

        public void OccupiedBy()
        {
            
        }

        public void Attack()
        {

        }

        public bool IsNeighbour()
        {
            return true;
        }

        public bool IsEnemy()
        {
            return true;
        }

        public int NumberOfAttackingTroops()
        {
            return 0;
        }

        public int NumberOfDefendingTroops()
        {
            return 0;
        }

        public void BattleOutcome()
        {

        }

        public int Winner()
        {
            return 0;
        }


        public void MoveTroops()
        {
            if (IsNeighbour() == true)
            {

            }

        }

        public void MoveToConquered(int numTroops)
        {

        }


        #endregion

        #region Move Function
        /// <summary>
        /// Place number of troops on country 
        /// </summary>
        /// <param name="numTroops"></param>
        /// <param name="whatCountry"></param>
        public Country PlaceTroops(int numTroops, int whatCountry)
        {
            var country = (from con in riskDB.countries
                           where con.countryID == whatCountry
                           select con).SingleOrDefault();
            country.numberOfTroops += numTroops;
            return country;
        }

       
        #endregion

        #region First Round Function

        /// <summary>
        /// Resturn number of troops after how many players are playing
        /// </summary>
        /// <param name="numPlayer"></param>
        /// <returns></returns>
        public int AllocateTroops(int numPlayer)
        {
            switch (numPlayer)
            {
                case 2:
                    {
                        return 40;
                    }
                case 3:
                    {
                        return 35;
                    }
                case 4:
                    {
                        return 30;
                    }
                case 5:
                    {
                        return 25;
                    }
            }
            return 0;
        }

        #endregion

        #region RandomFunction

        /// <summary>
        /// Behave like 6 side dice
        /// </summary>
        /// <returns></returns>
        public int ThrowDice()
        {
            Random dice = new Random();
            return dice.Next(1, 6);
        }

        /// <summary>
        /// Take in number of dice and return List of dice role
        /// </summary>
        /// <param name="numTroops"></param>
        /// <returns></returns>
        public List<int> MultipleThrowDice(int numDice)
        {
            List<int> dices = new List<int>();
            for (int i = 0; i < numDice; i++)
            {
                dices.Add(ThrowDice());
            }
            return dices;
        }

        public void WhoStarts(int numPlayer)
        {

        }
        #endregion
    }

}
