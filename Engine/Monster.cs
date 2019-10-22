using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    class Monster : Creature
    {
        ///<summary>
        ///--Ria--
        ///--Jyri--
        /// All data related to monsters
        /// ID
        /// Name (+name plural)
        /// --- Current health inherited from Creature
        /// --- Maximum health inherited from Creature
        /// Damage **
        /// Reward XP **
        /// Reward items **
        ///</summary>

        private int Damage;

        public int damage
        {
            get { return damage; }
            set { damage = value; }
        }

        private int Exp;

        public int exp
        {
            get { return exp; }
            set { exp = value; }
        }

        private int Items;

        public int items
        {
            get { return items; }
            set { items = value; }
        }


        public Monster(string name, int maximum_health) : base(name, maximum_health)
        {
            this.Damage = damage;
            this.Exp = exp;
            this.Items = items;
        }
    }
}
