using GameProject.Models.Enums;

namespace GameProject.CoreGame.Saves
{
    public class SaveData
    {
        public string PlayerName { get; set; }
        public int PlayerHealth { get; set; }
        public int PlayerMaxHealth { get; set; }
        public int PlayerDamage { get; set; }
        public LocationType CurrentLocation { get; set; }
        public List<ItemSaveData> Inventory { get; set; } = new List<ItemSaveData>();
    }

    public class ItemSaveData
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool IsKey { get; set; }
        public int HealAmount { get; set; }
    }
}
