using System;
using System.Runtime.InteropServices;

namespace OopFantasyGame
{
class Program 
{
        static void Main(string[] args)
        {
            Entity Boss = new Octopus_boss();
            Character Player = null;
            int CharacterChoice = 0;
            int Round_counter = 1;

            Greet();
            Player = AcceptClass(SelectClass(CharacterChoice), Player);
            do
            {
                TakeAction(Player, Boss);
                DealDamageToPlayer(Player, Boss);

                Round_counter++;
                Console.ReadKey();
            } while (Player.HealthPoints > 0 && Boss.HealthPoints > 0);

        }
        protected static void Greet()
        {
            Console.WriteLine("Привет, сейчас тебе предстоит битва с боссом, предлагаю подготовится. \r\n");
            Console.WriteLine("У тебя на выбор есть 2 класса: \r\n" +
                "1. Целитель \r\n" +
                "2. Воин \r\n" +
                "Введите порядковый номер класса, которым вы хотите быть, и помните, что выбор останется за вами до перезапуска игры.");
        }
        protected static int SelectClass(int CharacterChoice)
        {
            do
            {
                //TODO Вынести в метод 
                try
                {
                    CharacterChoice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Поздравляю, с окончанием выбора класса!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Пожалуйста, напишите порядковый номер класса, которым вы хотите играть !");
                }
            } while (CharacterChoice < 1 || CharacterChoice > 2);
            return CharacterChoice;
        }
        protected static Character AcceptClass (int CharacterChoice,Character player)
        {
            switch(CharacterChoice)
            {
                case 1:
                     player = new Heal();

                Console.WriteLine("Теперь ты целитель ! \r\n" +
                    "Посмотрим, как долго ты сможешь им оставаться :) ");
                Console.WriteLine("Здоровье :" + player.HealthPoints 
                    + " \r\nУрон :" + player.AttackPowerPoints
                    + " Особая способность -  выпить особый отвар, чтобы восстановить кол-во хп равное от 0-20");

                    return player;

                case 2:
                     player = new Warrior();

                Console.WriteLine("Ты стал воином! \r\n" +
                    "Интересно, бросишь ли ты свой меч, спасая свою шкуру ?  ");
                Console.WriteLine("Здоровье :" + player.HealthPoints + " \r\nУрон :" + player.AttackPowerPoints
                    + "\r\n Особая способность - выпить особый отвар, чтобы увеличить силу атаки на кол-во равное от 0-6 ");

                    return player;

                default:
                    throw new ArgumentException("Неккорректный выбор класса");

            }
        }
        protected static void TakeAction(Character player, Entity boss)
        {
            TakeAction(player,boss,ChooseAction(player, boss));
        }
        protected static int ChooseAction(Character player, Entity boss)
        {
            int ActionType=0;
            try
            {
                Console.WriteLine("Ваше хп: " + player.HealthPoints +
                    "\r\nВаш урон: " + player.AttackPowerPoints +
                    "\r\n\r\nЗдоровье чудища: " + boss.HealthPoints +
                    "\r\n\r\nВыберете, что вы хотите сделать! \r\n" +
                    "1.Напасть на противника.\r\n" +
                    "2.Защищаться (на следующий ход вы получить в двое меньше урона)\r\n" +
                    "3.Использовать способность");

                ActionType = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Вы потратили свои силы в пустую, в следующий раз постарайтесь не ошибиться !");
            }
            return ActionType;
        }
        protected static void TakeAction(Character player, Entity boss, int actionType)
        {
            //TODO Enum вместо ActionType
            switch (actionType)
            {
                case 1:
                    Console.WriteLine("Вы атаковали, нанеся " + boss.RecieveDamage(player.DealDamage()) + "урона");
                    break;

                case 2:
                    player.Protective_stand();
                    Console.WriteLine("Встав в защитную стойку, вы готовитесь к удару врага!");
                    break;

                case 3:
                    player.SpecialAbility();
                    Console.WriteLine("Выпив батькиных трав, вы готовы продолжить бой!");
                    break;

                default:
                    break;
            }
        }
        protected static void DealDamageToPlayer(Character player,Entity boss)
        {
            Console.WriteLine("Огромное чудище выпускает в вас струю воды, нанося " + player.RecieveDamage(boss.DealDamage()) + " урона");
        }
        
    }
}
