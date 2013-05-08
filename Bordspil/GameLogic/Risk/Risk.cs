using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bordspil.GameLogic.Risk;

namespace Bordspil.Games
{
    public class Risk
    {
        //Jón ættlar að focka þessu upp !!!
        
        
        /// <summary>
        /// Genirate number from 1 to 6
        /// </summary>
        /// <returns></returns>
        int Dice1d6()
        {
            var dice = new Random();
            return dice.Next(1, 6);
        }
    }
}