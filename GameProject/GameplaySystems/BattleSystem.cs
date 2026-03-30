using GameProject.Models.Characters;
using GameProject.Models.Enums;
using GameProject.Models.Items.Base;

namespace GameProject.GameplaySystems
{
    public class BattleSystem
    {
        public readonly Random _random = new Random();

        public void BattleStatus(Player player, Enemy enemy)
        {
            Console.Clear();

            // player bar top right row 0
            string playerBar = "";
            int playerFilled = player.Health * 20 / player.MaxHealth;
            for (int i = 0; i < 20; i++)
            {
                if (i < playerFilled)
                    playerBar += "|";
                else
                    playerBar += "-";
            }
            string playerFull = player.Name + " HP [" + playerBar + "] " + player.Health + "/" + player.MaxHealth;
            Console.SetCursorPosition(Console.WindowWidth - playerFull.Length - 1, 0);
            Console.Write(player.Name + " HP [");
            if (player.Health > player.MaxHealth / 2)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (player.Health > player.MaxHealth / 4)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(playerBar);
            Console.ResetColor();
            Console.Write("] " + player.Health + "/" + player.MaxHealth);

            // enemy bar top right row 1
            string enemyBar = "";
            int enemyFilled = enemy.Health * 20 / enemy.MaxHealth;
            for (int i = 0; i < 20; i++)
            {
                if (i < enemyFilled)
                    enemyBar += "|";
                else
                    enemyBar += "-";
            }
            string enemyFull = enemy.Name + " HP [" + enemyBar + "] " + enemy.Health + "/" + enemy.MaxHealth;
            Console.SetCursorPosition(Console.WindowWidth - enemyFull.Length - 1, 1);
            Console.Write(enemy.Name + " HP [");
            if (enemy.Health > enemy.MaxHealth / 2)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (enemy.Health > enemy.MaxHealth / 4)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(enemyBar);
            Console.ResetColor();
            Console.Write("] " + enemy.Health + "/" + enemy.MaxHealth);

            Console.SetCursorPosition(0, 3);
        }

        public void ShowPlayerOptions(Player player)
        {
            Console.WriteLine("1. Attack Torso");
            Console.WriteLine("2. Attack Head (50% chance, x2 damage)");
            bool hasHealing = player.Inventory.OfType<HealingItem>().Any(i => i.Quantity > 0);
            if (hasHealing)
                Console.WriteLine("3. Use Healing Item");
        }

        public void PlayerInput(string input, Player player, Enemy enemy)
        {
            switch (input)
            {
                case "1":
                    PlayerAttack(player, enemy, BodyTarget.Torso);
                    break;
                case "2":
                    PlayerAttack(player, enemy, BodyTarget.Head);
                    break;
                case "3":
                    bool used = player.UseHealingItem();
                    if (used)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You heal. HP: " + player.Health + "/" + player.MaxHealth);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("Nothing to use.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input, you hesitate.");
                    break;
            }
        }

        public void PlayerAttack(Player player, Enemy enemy, BodyTarget target)
        {
            if (target == BodyTarget.Torso)
            {
                enemy.TakeDamage(player.Damage);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You hit the torso for " + player.Damage + " damage.");
                Console.ResetColor();
            }
            else
            {
                bool hit = _random.Next(0, 2) == 0;
                if (hit)
                {
                    int dmg = player.Damage * 2;
                    enemy.TakeDamage(dmg);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Critical! You hit " + enemy.Name + "'s head and deal " + dmg + " damage.");
                    Console.ResetColor();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("You aimed for the head but missed.");
                    Console.ResetColor();
                }
            }
            Console.ReadKey();
        }

        public void EnemyTurn(Enemy enemy, Player player)
        {
            player.TakeDamage(enemy.Damage);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(enemy.Name + " attacks you for " + enemy.Damage + " damage.");
            Console.ResetColor();
            Console.WriteLine("\n[Press any key...]");
            Console.ReadKey();
        }

        public bool StartBattle(Player player, Enemy enemy)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("!! " + enemy.Name + " attacks !!");
            Console.ResetColor();
            Console.WriteLine();
            Console.ReadKey();

            while (player.IsAlive && enemy.IsAlive)
            {
                BattleStatus(player, enemy);
                ShowPlayerOptions(player);

                string input = Console.ReadLine();
                PlayerInput(input, player, enemy);

                if (!enemy.IsAlive)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nYou defeated " + enemy.Name + "!");
                    Console.ResetColor();
                    Console.WriteLine("\n[Press any key...]");
                    Console.ReadKey();
                    return true;
                }

                EnemyTurn(enemy, player);

                if (!player.IsAlive)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nYou died.");
                    Console.ResetColor();
                    Console.WriteLine("\n[Press any key...]");
                    Console.ReadKey();
                    return false;
                }
            }

            return player.IsAlive;
        }
    }
}
