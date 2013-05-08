using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bordspil.Models;
using Bordspil.GameLogic.Risk;

namespace Bordspil.GameService
{
    public class RiskService
    {
        #region Variables
        public Random startPlayer = new Random();
        public int numTroops;
        #endregion

        #region ProperFunctions
        /// <summary>

        int StartGame(int startPlayer)
        {
            return 0;
            return dice.Next(1, 6);
        }

        #endregion

        #region HelperFunctions

        int WhoStarts(int numPlayer)
        {
            return startPlayer.Next(1, numPlayer);
        }

        void AllocateTroops(int numPlayer)
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

        void PlaceFirstTroops(int numTroops)
        {

        }

    }
}
    #endregion