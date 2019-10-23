using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Location
    {
        ///<summary>
        ///--Ria--
        /// All data related to locations
        /// ID
        /// Name 
        /// Description
        /// Items available
        /// Quests available
        /// Position : Location to North
        /// Position : Location to East
        /// Position : Location to South
        /// Position : Location to West
        /// Monsters living here
        /// Event starters
        ///</summary>

        public List<Quest> LocationQuests = new List<Quest>();
        public List<Item> LocationItems = new List<Item>();
        public List<Monster> LocationMonsters = new List<Monster>();

        private readonly int id;
        private static int nextId = 10000;
        public int ID { get { return id; } }
        public string Name { get; set; }
        public string Description { get; set; }
        public Location LocationToNorth;
        public Location LocationToEast;
        public Location LocationToWest;
        public Location LocationToSouth;
     //   public string QuestCompletedDescription; //get settinä?
        //Constructors
        public Location(string name, string description)
        {
            id = ++nextId;
            this.Name = name;
            this.Description = description;
        }
        public Location(string name, string description, Location locationToNorth, Location locationToEast, Location locationToWest, Location locationToSouth)
        {
            id = ++nextId;
            this.Name = name;
            this.Description = description;
            this.LocationToNorth = locationToNorth;
            this.LocationToEast = locationToEast;
            this.LocationToSouth = locationToSouth;
            this.LocationToWest = locationToWest;
        }
    }
}


