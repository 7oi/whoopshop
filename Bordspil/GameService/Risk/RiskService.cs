﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bordspil.GameLogic.Risk;

namespace Bordspil.GameService
{
    public class RiskService
    {
        //Jón ættlar að focka þessu upp !!!
        
        
        /// <summary>
        /// Generate a number from 1 to 6
        /// </summary>
        /// <returns></returns>
        int Dice1d6()
        {
            var dice = new Random();
            return dice.Next(1, 6);
        }
    }
}