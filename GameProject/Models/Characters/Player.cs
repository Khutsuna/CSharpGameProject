using GameProject.Models.Items.Base;
using System.Runtime.CompilerServices;

namespace GameProject.Models.Characters
{
    public class Player : Character
    {
        public List<BaseItem> Inventory { get; set; } = new List<BaseItem>();
        public Player (string name, int health, int damage, int levelXP) : base(name, health, damage)        
        {
            Inventory = new List<BaseItem>();
        }

        

        public void AddItem(BaseItem item)
        {
            Inventory.Add(item);
            Console.WriteLine($"{item.Name} Added to inventory");
        }

        public bool HasKey()
        {
            return Inventory.Any(item => item.IsKey);
        }

        public bool UseHealingItem()
        {
            var item = Inventory.OfType<HealingItem>().FirstOrDefault(i => i.Quantity > 0);
            if (item == null) return false;

            Health = Math.Min(MaxHealth, Health + item.HealAmount);
            item.Quantity--;
            if (item.Quantity <= 0) Inventory.Remove(item);
            return true;
        }
    }
}
