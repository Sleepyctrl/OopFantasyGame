# A simple task to implement the basic principles of OOP in console fantasy game.

### The game has only one mission - defeat the boss, the player chooses the class for which he wants to play and then enters into a turn-based battle, where each move chooses what he will do from the proposed actions:
1. Аttack
2. Defend yourself
3. Use special ability

### The program defines a class inheritance hierarchy which consists of 2 parent classes and 3 child classes:
* Entity
* Character (Entity parent)
* Boss (Entity parent)
* Heal (Character parent)
* Warrior (Character parent)
# Entity
### The Entity class is the parent of all other classes.
### The class defines 3 properties and constructor:
* HealthPoints
* AttackPowerPoints
* DefensePowerPoints 

### Constructor:
* Constructor that takes these parameters.

### Damage method 
* RecieveDamage

### Method where damage is calculated
* Deal damage

## Example
```C#
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

        public virtual int RecieveDamage(int damage)
        {
            int FinalDamage = damage - this.DefencePowerPoints;

            this.HealthPoints -= FinalDamage;
            return FinalDamage;
        }

        public virtual int DealDamage()
        {
            return AttackPowerPoints;
        }
    }
}
```
# Character 
### The Character class is inherited from the Entity class.
### This class declares two properties:
* IsInProtectiveStand
* SpecialAbilityPowerPoints

### Constructor
* Constructor that takes all properties and calls the base class constructor

### Abstract Method
* Special Ability

### Overridden method for calculating damage
* RecieveDamage

### Method that determines whether the character is in a defensive stance and takes less damage
* Protective_stand
### Example
```c#
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
```
# Boss

### The Boss class inherits from the Entity class.
### This class declares 3 constants:
* DefaultHealthPoints
* DefaultAttackPowerPoints
* DefaultDefencePoints
### Constructor that calling base class constructor with 3 parameters
### Example
```c#
public class Octopus_boss : Entity
    {
        protected const int DefaultHealthPoints = 150;
        protected const int DefaultAttackPowerPoints = 24;
        protected const int DefaultDefencePoints = 3;
        public Octopus_boss() : base(DefaultHealthPoints, DefaultAttackPowerPoints, DefaultDefencePoints)
        { }
    }
```

# Heal
### The Heal class inherits from the Character class.
### This class declares 5 constants:
* DefaultHealthPoints
* DefaultAttackPowerPoints
* DefaultDefencePoints
* DefaultIsInProtectiveStand
* DefaultSpecialAbilityPowerPoints
### Constructor calling base class constructor with 5 parameters

### Overridden method
* Special Ability

### Example
```c#
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
```
# Warrior
### The Warrior class is derived from the Character class.
### This class declares 5 constants:
* DefaultHealthPoints
* DefaultAttackPowerPoints
* DefaultDefencePoints
* DefaultIsInProtectiveStand
* DefaultSpecialAbilityPowerPoints
### Constructor calling base class constructor with 5 parameters
### Overridden method
* Special Ability

### Example
```c#
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
```
