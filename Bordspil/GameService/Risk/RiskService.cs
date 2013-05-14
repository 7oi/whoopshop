using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bordspil.DAL;

namespace Bordspil.GameService
{
    public class RiskService
    {
        /*
        #region StartGameVariables
        Risk riskDB = new Risk();
        #endregion

        #region OneTurnVariables
        
        #endregion


        #region ProperFunctions

        #endregion

        #region To Do Function

        public void CalculateReinforcements()
        {

        }

        

        public void Attack()
        {

        }

        

        public void BattleOutcome()
        {

        }

        public int Winner()
        {
            return 0;
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

        #region Attack and Defence function
        /// <summary>
        /// return how many trops are on country
        /// </summary>
        /// <param name="landId"></param>
        /// <returns></returns>
        public int NumberOfTroops(int landId)
        {
            var country = (from db in riskDB.countries
                           where db.countryID.Equals(landId)
                           select db).SingleOrDefault();
            return country.numberOfTroops;
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

        #region True or False function
        /// <summary>
        /// Check if the current country is a neighbouring country
        /// </summary>
        /// <param name="curretn"></param>
        /// <param name="goToCountry"></param>
        /// <returns></returns>
        public bool IsNeighbour(int curretn, int goToCountry)
        {
            var contry = (from db in riskDB.countries
                          where db.countryID.Equals(curretn)
                          select db).SingleOrDefault();
            if (contry.neighbouringCountries.Equals(goToCountry))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// check if player on that land is an enemy
        /// </summary>
        /// <param name="player"></param>
        /// <param name="landId"></param>
        /// <returns></returns>
        public bool IsEnemy(UserProfile player, int landId)
        {
            if (player != OccupiedBy(landId))
            {
                return true;
            }
            return false;
        }

        public void ContinentConquerer(int contient, UserProfile user)
        {

        }
        #endregion

        #region Other game function
        /// <summary>
        /// take in what country and return the profile of the user that ocupide that country
        /// </summary>
        /// <param name="whatCountry"></param>
        /// <returns></returns>
        public UserProfile OccupiedBy(int whatCountry)
        {
            var country = (from db in riskDB.countries
                           where db.countryID.Equals(whatCountry)
                           select db).SingleOrDefault();
            return country.occupierID;
        }
        #endregion
        */
    }

}
