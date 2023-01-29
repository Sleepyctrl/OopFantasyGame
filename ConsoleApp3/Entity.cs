namespace OopFantasyGame
{
    public abstract class Entity
    {
        public int HealthPoints { get; protected set; }
        public int AttackPowerPoints { get; protected set; }
        public int DefencePowerPoints { get; protected set; }

        protected Entity(int healthPoints,
            int attackPowerPoints, int defencePowerPoints)
        {
            HealthPoints = healthPoints;
            AttackPowerPoints = attackPowerPoints;
            DefencePowerPoints = defencePowerPoints;
        }

        //мы избегаем прямого взаимодействия с инициатором действия,
        //чтобы облегчить взаимодействие двух объектов из разных классов
        public virtual int RecieveDamage(int damage)
        {
            int FinalDamage = damage - this.DefencePowerPoints;

            this.HealthPoints -= FinalDamage;
            return FinalDamage;
        }

        //TODO Сделать доп расчёт силы атаки для война, от спец-навыка
        public virtual int DealDamage()
        {
            return AttackPowerPoints;
        }
    }
}
