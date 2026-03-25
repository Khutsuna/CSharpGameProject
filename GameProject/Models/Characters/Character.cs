using GameProject.Models.Items.Base;

namespace GameProject.Models.Characters
{
    public class Character
    {

        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        public Character(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
    }
}
