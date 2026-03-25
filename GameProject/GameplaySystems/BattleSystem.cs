using GameProject.Models.Characters;
using GameProject.Models.Items.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.GameplaySystems
{
    public class BattleSystem
    {
        public readonly Random _random = new Random();

        public void BattleStatus(Player player, Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine($"  {player.Name} — HP: {player.Health}/{player.MaxHealth}");
            Console.WriteLine($"  {enemy.Name} — HP: {enemy.Health}/{enemy.MaxHealth}");
            Console.WriteLine();
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
                    Console.WriteLine(used ? $"You heal. HP: {player.Health}/{player.MaxHealth}" : "Nothing to use.");
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
                Console.WriteLine($"You hit the torso for {player.Damage} damage.");
            }
            else
            {
                bool hit = _random.Next(0, 2) == 0;
                if (hit)
                {
                    int dmg = player.Damage * 2;
                    enemy.TakeDamage(dmg);
                    Console.Clear();
                    Console.WriteLine($"You hit {enemy.Name}'s head and deal {dmg} damage.");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You aimed for the head but missed.");
                }
            }
            Console.ReadKey();
        }

        public void EnemyTurn(Enemy enemy, Player player)
        {
            player.TakeDamage(enemy.Damage);
            Console.WriteLine($"{enemy.Name} attacks you for {enemy.Damage} damage.");
            Console.WriteLine("\n[Press any key...]");
            Console.ReadKey();
        }

        public bool StartBattle(Player player, Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine($"An enemy appears: {enemy.Name}!");

            while (player.IsAlive && enemy.IsAlive)
            {
                BattleStatus(player, enemy);
                ShowPlayerOptions(player);

                string input = Console.ReadLine();
                PlayerInput(input, player, enemy);

                if (!enemy.IsAlive)
                {
                    Console.WriteLine($"\nYou defeated {enemy.Name}!");
                    Console.WriteLine("\n[Press any key...]");
                    Console.ReadKey();
                    return true;
                }

                EnemyTurn(enemy, player);

                if (!player.IsAlive)
                {
                    Console.WriteLine("\nYou died.");
                    Console.WriteLine("\n[Press any key...]");
                    Console.ReadKey();
                    return false;
                }
            }

            return player.IsAlive;
        }
    }
}
