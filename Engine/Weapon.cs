using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Weapon : Item
    {
        ///<summary>
        ///--Ria--
        /// All data related to weapons
        /// --- ID inherited from item
        /// --- Name inherited from item (+name plural)
        /// Damage
        ///</summary>

        //Properties
        private int damage; //Damage is an integer, per hit.
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        //Constructors
        public Weapon(string name, int damage) : base(name)
        {
            this.Damage = damage;
        }
    }
}
