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

        private Location currentLocation;
        public Location CurrentLocation { get => currentLocation; set => currentLocation = value; }

        private Weapon equippedWeapon;
        public Weapon EquippedWeapon { get => equippedWeapon; set => equippedWeapon = value; }

        public List<Item> Inventory = new List<Item>();
        public List<Quest> QuestList = new List<Quest>();


        public string Input;
        public enum MovementDirection
        {
            North,
            East,
            South,
            West,
        }

        public MovementDirection M_Direction;

        public Action Act;
        public enum Action
        {
            LookAround,
            Fight,

        }

        public Player(string name, int maximum_health) : base(name, maximum_health)
        {
            this.Exp = exp;
            this.Level = level;
        }

        public Player()
        { }

        internal void UpdatePlayerLevel()
        {
            // player level calculator
            // check player experience
            if (this.Exp > 100)
            {
                this.Level = this.Level++;
                this.Exp -= 100;
                Console.WriteLine("Yay, you gained a level!");
            }
            // if player experience is above 100, increase player level, remove 100 points from player exp            
        }
    }
}
