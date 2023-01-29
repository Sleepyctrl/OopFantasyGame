using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopFantasyGame
{
    public class Octopus_boss : Entity
    {
        protected const int DefaultHealthPoints = 150;
        protected const int DefaultAttackPowerPoints = 24;
        protected const int DefaultDefencePoints = 3;
        public Octopus_boss() : base(DefaultHealthPoints, DefaultAttackPowerPoints, DefaultDefencePoints)
        {

        }
        //TODO Реализовать спец-способность босса
    }
}
