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
        public Random startPlayer = new Random();
        public int numTroops;
        public Random dice = new Random();
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


        public int ThrowDice()
        {
            return dice.Next(1, 6);
        }

        public int WhoStarts(int numPlayer)
        {
            return startPlayer.Next(1, numPlayer);
        }

        public void AllocateTroops(int numPlayer)
        {
            switch (numPlayer)
            {
                case 2:
                    {
                        numTroops = 40;
                        return;

                    }
                case 3:
                    {
                        numTroops = 35;
                        return;
                    }
                case 4:
                    {
                        numTroops = 30;
                        return;
                    }
                case 5:
                    {
                        numTroops = 25;
                        return;
                    }
            }
        }

        public void PlaceFirstTroops(int numTroops)
        {
            OccupiedBy();
            return;
        }

        
        public void AddTroops()
        {
            CalculateReinforcements ();
            PlaceTroops (reinforcement);
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

        public int PlaceTroops(int reinforcements)
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

            NumberOfAttackingTroops();
            NumberOfDefendingTroops();
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

        public int NumberOfAttackingTroops()
        {
            AttackDiceRoll(numAttackTroops);
            return 0;
        }

        public int NumberOfDefendingTroops()
        {
            DefendDiceRoll(numDefendTroops);
            return 0;
        }

        public List<int> AttackDiceRoll(int numTroops)
        {
            ThrowDice();
            return diceThrows;
        }

        public List<int> DefendDiceRoll(int numTroops)
        {
            ThrowDice();
            return diceThrows;
        }

        public void BattleOutcome()
        {

        }

        public int Winner()
        {
            return 0;
        }

        public void MoveToConquered(int numTroops)
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
        }

        #endregion

    }
