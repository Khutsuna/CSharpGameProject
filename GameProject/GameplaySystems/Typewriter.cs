using GameProject.CoreGame;
using GameProject.CoreGame.Saves;
using GameProject.Models.Characters;
using GameProject.Models.Enums;
using GameProject.Models.Items.Base;

namespace GameProject.GameplaySystems
{
    public class Typewriter : IInteractible
    {
        private readonly SaveSystem _saveSystem = new SaveSystem();

        public void Interact(Player player, LocationType currentLocation)
        {
            Console.Clear();
            Console.WriteLine("Typewriter");
            Console.WriteLine("Save game?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");

            string input = Console.ReadLine()?.Trim();

            if (input != "1")
            {
                Console.WriteLine("Cancelled.");
                Console.ReadKey();
                return;
            }

            SaveData data = new SaveData
            {
                PlayerName = player.Name,
                PlayerHealth = player.Health,
                PlayerMaxHealth = player.MaxHealth,
                PlayerDamage = player.Damage,
                CurrentLocation = currentLocation,
                Inventory = player.Inventory.Select(item => new ItemSaveData
                {
                    Name = item.Name,
                    Quantity = item.Quantity,
                    IsKey = item.IsKey,
                    HealAmount = item is HealingItem h ? h.HealAmount : 0
                }).ToList()
            };

            _saveSystem.Save(data);

            Console.Clear();
            Console.WriteLine("Game Saved.");
            Console.WriteLine("\n[Press any key...]");
            Console.ReadKey();
        }
    }
}
