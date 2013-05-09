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
        public Random startPlayer = new Random();
        public int numTroops;
        #endregion

        #region OneTurnVariables
        public int reinforcement;
        List<int> diceThrows;
        int numAttackTroops;
        int numDefendTroops;
        #endregion


        #region ProperFunctions

        #endregion

        #region HelperFunctions


        public int WhoStarts(int numPlayer)
        {
            return startPlayer.Next(1, numPlayer);
        }


        public void PlaceFirstTroops(int numTroops)
        {
            OccupiedBy();
            return;
        }


        public void AddTroops()
        {
            CalculateReinforcements();
            PlaceTroops(reinforcement);
        }

        public int CalculateReinforcements()
        {
            ContinentConquerer();
            return 0;
        }

        public int ContinentConquerer()
        {
            return 0;
        }

        

        public int OccupiedBy()
        {
            return 0;
        }

        public void Attack()
        {
            IsNeighbour();
            OccupiedBy();

            
            Winner();

            if (numDefendTroops == 0)
            {
                //select how many troops to move
            }

        }

        public bool IsNeighbour()
        {
            return true;
        }

        public bool IsEnemy()
        {
            return true;
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
        public void PlaceTroops(int reinforcements)
        {
            
        }

        public void MoveTroops()
        {
            if (IsNeighbour() == true)
            {
                if (OccupiedBy() == 0)
                {
                }
            }

        }

        public void MoveToConquered(int numTroops)
        {

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


        #endregion
    }

}
