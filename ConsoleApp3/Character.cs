namespace OopFantasyGame
{
    public abstract class Character : Entity
    {
        public bool IsInProtectiveStand { get; protected set; }
        public int SpecialAbilityPowerPoints { get; protected set; }

        protected Character(bool isInProtectiveStand,
            int specialAbilityPowerPoints,
            int healthPoints,
            int attackPowerPoints,
            int defencePowerPoints) : base(healthPoints, attackPowerPoints, defencePowerPoints)
        {   
            IsInProtectiveStand = isInProtectiveStand;
            SpecialAbilityPowerPoints = specialAbilityPowerPoints;
        }

        public abstract int SpecialAbility();
        public override int RecieveDamage(int damage)
        {
            if(IsInProtectiveStand)
            {
                int FinalDamage = damage - this.DefencePowerPoints * 2;

                this.HealthPoints -= FinalDamage;
                return FinalDamage;
            }
            else
            {
              return base.RecieveDamage(damage);
            }
        }
        public void Protective_stand()
        {
            IsInProtectiveStand = true;
        }
    }
}
