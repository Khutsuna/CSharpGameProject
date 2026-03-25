using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Models.Items.Base
{
    public class HealingItem : BaseItem
    {
        public int HealAmount { get; set; }

        public HealingItem(string name, int quantity, int HealAmount) : base(name, quantity)
        {
            HealAmount = HealAmount;
        }
    }
}
