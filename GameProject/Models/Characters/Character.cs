using GameProject.Models.Items.Base;

namespace GameProject.Models.Characters
{
    public class Character
    {

        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Damage { get; set; }
        public bool IsAlive => Health > 0;

        public Character(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            MaxHealth = health;
            Damage = damage;
        }

        public void TakeDamage(int amount)
        {
            Health = Math.Max(0, Health - amount);
        }
    }
}
