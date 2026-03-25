namespace GameProject.Models.Items.Base
{
    public class BaseItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool IsKey = false;

        public BaseItem(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
