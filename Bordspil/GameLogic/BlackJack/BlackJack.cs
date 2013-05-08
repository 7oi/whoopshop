using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bordspil.GameLogic
{
    public class BlackJack
    {
        #region Variables
        static Random randomCard = new Random();
        #endregion

        #region Functions
        public int GiveRandomCard()
        {
            return randomCard.Next(1, 52);
        }


        #endregion
    }
}