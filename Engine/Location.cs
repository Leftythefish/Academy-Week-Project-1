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

        private readonly int id;
        private static int nextId = 10000;
        public int ID { get { return id; } }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Location LocationToNorth;
        public Location LocationToEast;
        public Location LocationToWest;
        public Location LocationToSouth;


        public List<Quest> LocationQuests = new List<Quest>();
        public List<Item> LocationItems = new List<Item>();
        public List<Monster> LocationMonsters = new List<Monster>();


        //Constructors
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

        public Location(string name, string description)
        {
            id = ++nextId;
            this.Name = name;
            this.Description = description;


        }

    }
}


