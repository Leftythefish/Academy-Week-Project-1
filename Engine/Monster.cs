using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Monster : Creature
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

        private int damage;

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        private int exp;

        public int Exp
        {
            get { return exp; }
            set { exp = value; }
        }
        public Item RewardItem { get; set; }

        public Monster(string name, int maximum_health, Item rewardItem) : base(name, maximum_health)
        {
            this.Damage = damage;
            this.Exp = exp;
          this.RewardItem = rewardItem;
        }
    }
}
