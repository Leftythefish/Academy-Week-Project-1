using System;
using System.Collections.Generic;

namespace Engine
{
    public class Player : Creature
    {
        public List<Item> Inventory = new List<Item>();
        public List<Quest> QuestList = new List<Quest>();
        public int Level { get; set; }
        public int Exp { get; set; }
        public string Input { get; set; }
        private Location currentLocation;
        public Location CurrentLocation { get => currentLocation; set => currentLocation = value; }
        private Weapon equippedWeapon;
        public Weapon EquippedWeapon { get => equippedWeapon; set => equippedWeapon = value; }
        public Player() { }
        public Player(string name, int maximum_health) : base(name, maximum_health)
        {
            this.Exp = Exp;
            this.Level = Level;
        }
        public void UpdatePlayerLevel()
        {
            // player level calculator
            // check player experience
            do
            {
            if (Exp > 100)
            {
                Level += 1;
                Exp -= 100;
                Window.lines[8] = "You take a deep breath. Somehow the recent experiences seems to have made you stronger.";
                Window.line8 = "You feel like you've become stronger.";
            }
            } while (Exp > 100);
            // method to update lvl on the screen
            // if player experience is above 100, increase player level, remove 100 points from player exp            
        }
    }
}
