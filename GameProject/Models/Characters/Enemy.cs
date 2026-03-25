namespace GameProject.Models.Characters
{
    public class Enemy : Character
    {
        public int DropXP { get; set; }
        public Enemy(string name, int health, int damage, int dropXP) : base(name, health, damage)
        {
            DropXP = dropXP;
        }
    }
}
