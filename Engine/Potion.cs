using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Potion : Item
    {
        ///<summary>
        ///--Ria--
        /// All data related to potions
        /// --- ID inherited from item
        /// --- Name inherited from item (+name plural)
        /// Start with healing potion, more if time
        /// Healing amount
        ///</summary>
        ///
        private int healing_amount;

        public int Healing_Amount
        {
            get { return healing_amount; }
            set { healing_amount = value; }
        }

        //Constructors

        public Potion(string name, string name_plural, int healing_amount) : base(name, name_plural)
        {
            this.Healing_Amount = healing_amount; //how much health the potion restores
        }

        //Methods
        public static void UsePotion(Potion potion)
        {
        // Add potion healing amount to player current health
        // Update player health indicator screen
        // Remove potion from player inventory
        // Update player inventory indicators?
        }
    }
}
