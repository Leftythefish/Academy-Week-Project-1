using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Potion : Item
    {
        public int Healing_Amount { get; set; }
        //Constructors
        public Potion(string name, int healing_amount) : base(name)
        {
            this.Healing_Amount = healing_amount; //how much health the potion restores
        }
        //Methods
        public static void UsePotion(Player p, Potion potion)
        {
            // Add potion healing amount to player current health
            p.Cur_Health += potion.Healing_Amount;
            Window.UpdateHp(p);
            p.Inventory.Remove(potion);
        }
    }
}
