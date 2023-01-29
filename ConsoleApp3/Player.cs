using System;

namespace OopFantasyGame
{
    public class Heal : Character
    {
       const int DefaultHealthPoints = 100;
       const int DefaultAttacksPowerPoints = 20;
       const int DefaulDefencePowerPoints = 3;
       const bool DefaultIsInProtectiveStand = false;
       const int DefaultSpecialAbilityPowerPoints = 3;
        public Heal() : base(
            DefaultIsInProtectiveStand,
            DefaultSpecialAbilityPowerPoints, 
            DefaultHealthPoints,
            DefaultAttacksPowerPoints,
            DefaulDefencePowerPoints)
        { }

        public override int SpecialAbility()
        {
            Random rnd = new Random();
            int RandomAbilityPower = rnd.Next(0, SpecialAbilityPowerPoints);
            return HealthPoints += (RandomAbilityPower * 4);
        }
    }

    public class Warrior : Character
    {
        const int DefaultHealthPoints = 150;
        const int DefaultAttacksPowerPoints = 15;
        const int DefaulDefencePowerPoints = 6;
        const bool DefaultIsInProtectiveStand = false;
        const int DefaultSpecialAbilityPowerPoints = 3;
        public Warrior() : base(
            DefaultIsInProtectiveStand,
            DefaultSpecialAbilityPowerPoints, 
            DefaultHealthPoints,
            DefaultAttacksPowerPoints,
            DefaulDefencePowerPoints)
        { }

        public override int SpecialAbility()
        {
            Random rnd = new Random();
            int RandomAbilityPower = rnd.Next(0, SpecialAbilityPowerPoints);
            return AttackPowerPoints += (RandomAbilityPower * 2);
        }
    }
}
