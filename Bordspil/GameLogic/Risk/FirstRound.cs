﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bordspil.GameLogic.Risk
{
    public class FirstRound
    {
        /// <summary>
        /// AllocateTroops distrubute the troops in the first round depending on how many players are playing.
        /// There can be 2 to 6 players, otherwise it return 0;
        /// </summary>
        /// <param name="numPlayer"></param>
        /// <returns></returns>
        int AllocateTroops(int numPlayer)
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
                case 6:
                    {
                        return 20;
                    }
            }
            return 0;
        }
    }
}