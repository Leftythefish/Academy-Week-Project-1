using System;
using System.Collections.Generic;

namespace Engine
{
    public class Player : Creature
    {
        ///<summary>
        ///--Ria--
        /// All data related to the player
        /// --- Current health inherited from Creature
        /// --- Maximum health inherited from Creature
        /// Experience **
        /// Level **
        /// Items in inventory <List>
        /// Quests in progress <List>
        ///</summary>
        
        private int level; //Player level

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        private int exp; //Player Experience

        public int Exp
        {
            get { return exp; }
            set { exp = value; }
        }

        public List<Item> Inventory = new List<Item>();
        public List<Quest> QuestList = new List<Quest>();


        public Player(string name, int maximum_health) : base(name, maximum_health)
        {
            this.Exp = exp;
            this.Level = level;
        }
    }
}
