using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    public class CivilPlayer : Player
    {
        private const int LifePointsConst = 50;

        public CivilPlayer(string name) 
            : base(name, LifePointsConst)
        {
        }
    }
}
