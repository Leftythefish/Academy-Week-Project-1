using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class World
    {
        public List<Location> WorldList = new List<Location>();

        public Location WorldLocation { get; set; }

        public World() { }

        //    public List<Quest> Cave3Quests = new List<Quest>();
        //public List<Item> Cave3Items = new List<Item>();

        //public List<Monster> Cave4Monster = new List<Monster>();

        public void CreateWorlds()
        {

            Location Cave1 = new Location("Dark Cave", "The small cave you entered is very dark and moist. Walls of the cave are filled with mushrooms emitting dim green light making you able to see your nearby surroundings");
            Location Cave2 = new Location("Dark Cave Tunnels", "You came to a room which splits into multiple tunnels. There is a large door with omnious carvings about hellish monsters blocking the way to east. From the north tunnel comes loud growling noises. The pathway to west tunnel seems to be used a lot");
            Location Cave3 = new Location("Pleasant Cave Room", "There is a bonfire in the middle of the room creating warmth and light around it. Small humanoid creature sits infront of the bonfire. He tells you to go slay nearby Ogre");
            Location Cave4 = new Location("Ogre Cave", "Unpleasant smell welcomes you as you enter the room. The floor is filled with bones and rusty weapons. You see a big and bulky creature in the room");
            Location Cave5 = new Location("Dungeon Entrance", "Torches on the wall lights up the room. You see some cages hanging from the cave roof housing the remains of their last prisoners");
            //"You came to a room which splits into multiple tunnels. There is a large door blocking the way to . The pathway to west tunnel seems to be used a lot"
            Weapon Axe = new Weapon("axe", "axes", 5);
            Potion HealPot = new Potion("healing potion", "healing potions", 20);

            Item ogreReward = new Item("ogre head", "ogre heads");

            Cave1.LocationToNorth = Cave2;
            Cave1.LocationToEast = null;
            Cave1.LocationToSouth = null;
            Cave1.LocationToWest = null;

            Cave2.LocationToNorth = Cave4;
            Cave2.LocationToEast = Cave5;
            Cave2.LocationToSouth = Cave1;
            Cave2.LocationToWest = Cave3;

            Cave3.LocationToNorth = null;
            Cave3.LocationToEast = Cave2;
            Cave3.LocationToSouth = null;
            Cave3.LocationToWest = null;

            Cave3.LocationItems.Add(HealPot);
            Cave3.LocationItems.Add(Axe);

            Quest OgreQuest = new Quest("Slay the Ogre", "Slay the nasty Ogre located north of Dark Cave Tunnels", 100, ogreReward);
            Cave3.LocationQuests.Add(OgreQuest);

            Cave4.LocationToNorth = null;
            Cave4.LocationToEast = null;
            Cave4.LocationToSouth = Cave2;
            Cave4.LocationToWest = null;

            Monster Ogre = new Monster("Ogre", 10, ogreReward);

            Cave4.LocationMonsters.Add(Ogre);

            Cave5.LocationToNorth = null;
            Cave5.LocationToEast = null;
            Cave5.LocationToSouth = null;
            Cave5.LocationToWest = Cave2;

            WorldList.Add(Cave1);
            WorldList.Add(Cave2);
            WorldList.Add(Cave3);
            WorldList.Add(Cave4);
            WorldList.Add(Cave5);


        }

    }

}