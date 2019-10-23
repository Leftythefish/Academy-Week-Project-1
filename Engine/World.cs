using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class World
    {
        ///<summary>
        ///--Jyri
        ///--Ria
        ///World Creation
        ///</summary>

        public List<Location> WorldList = new List<Location>();
        public Location WorldLocation { get; set; }
        public World() { }

        public void CreateWorlds()
        {
            #region Location
            Location Cave1 = new Location("Dark Cave");
            Location Cave2 = new Location("Dark Cave Tunnels");
            Location Cave3 = new Location("Pleasant Cave Room");
            Location Cave4 = new Location("Ogre Cave");
            Location Cave5 = new Location("Dungeon Entrance");
            #endregion

            #region Items
            Weapon Axe = new Weapon("Axe", "Axes", 5);
            Potion HealPot = new Potion("healing potion", "healing potions", 20);
            Item OgreQuestCompleteRequirement = new Item("Bloody Ogre head", "Bloody Ogre heads");
            #endregion

            #region Quests
            Quest OgreQuest = new Quest("Slay the Ogre", "Slay the nasty Ogre located north of the Dark Cave Tunnels", 100, OgreQuestCompleteRequirement);
            OgreQuest.CompletionMessage = "You return the " + OgreQuestCompleteRequirement.Name + "to the man. The monster has been slain!";
            #endregion

            #region Monsters
            Monster Ogre = new Monster("Ogre", 10, OgreQuestCompleteRequirement);
            Ogre.Damage = 10;
            Ogre.MonsterLoot.Add(HealPot);
            #endregion

            #region LocationSpecifics
            Cave1.LocationToNorth = Cave2;
            Cave1.LocationToEast = null;
            Cave1.LocationToSouth = null;
            Cave1.LocationToWest = null;
            Cave1.Description = "The small cave you entered is very dark and moist.";
            Cave1.Description2 = "Walls of the cave are filled with mushrooms emitting a dim green light.";
            Cave1.Description3 = "The light from the mushrooms allows you to vaguely see your nearby surroundings";

            Cave2.LocationToNorth = Cave4;
            Cave2.LocationToEast = Cave5;
            Cave2.LocationToSouth = Cave1;
            Cave2.LocationToWest = Cave3;
            Cave2.Info.Add(Cave2.Description = "You are in a room which splits into multiple tunnels.");
            Cave2.Info.Add(Cave2.Description2 = "To the east, there is a large door with ominous carvings about hellish monsters.");
            Cave2.Info.Add(Cave2.Description3 = "From the north tunnel you can hear some distant growling noises.");
            Cave2.Info.Add(Cave2.Description4 = "The pathway to the west tunnel is clean and seems to be used a lot.");
            Cave2.Info.Add(Cave2.Description4 = "To the south lies a dark, quiet passage.");

            Cave3.LocationToNorth = null;
            Cave3.LocationToEast = Cave2;
            Cave3.LocationToSouth = null;
            Cave3.LocationToWest = null;
            Cave3.Info.Add(Cave3.Description = "There is a bonfire in the middle of the room creating warmth and light around it.");
            Cave3.Info.Add(Cave3.Description2 = "A small humanoid creature sits in front of the bonfire.");

            Cave3.LocationItems.Add(HealPot);
            Cave3.LocationItems.Add(Axe);
            Cave3.LocationQuests.Add(OgreQuest);
           
            Cave4.LocationToNorth = null;
            Cave4.LocationToEast = null;
            Cave4.LocationToSouth = Cave2;
            Cave4.LocationToWest = null;
            Cave4.Info.Add(Cave4.Description = "An unpleasant smell welcomes you as you enter the room.");
            Cave4.Info.Add(Cave4.Description2 = "The floor is filled with bones and rusty weapons.");
            Cave4.Info.Add(Cave4.Description3 = "You see a big and bulky creature in the room. It lunges at you in rage! Time to fight!");
            Cave4.LocationMonsters.Add(Ogre);

            Cave5.LocationToNorth = null;
            Cave5.LocationToEast = null;
            Cave5.LocationToSouth = null;
            Cave5.LocationToWest = Cave2;
            Cave5.Description = "Torches on the wall light up the room. You see some cages hanging from the cave roof housing the remains of their last prisoners";
            #endregion


            #region AddToWorld
            WorldList.Add(Cave1);
            WorldList.Add(Cave2);
            WorldList.Add(Cave3);
            WorldList.Add(Cave4);
            WorldList.Add(Cave5);
            #endregion







        }

    }

}