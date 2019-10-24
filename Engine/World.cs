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
            Location Cave6 = new Location("Start of Dungeon");
            Location Cave7 = new Location("Magic Prison");
            Location Cave8 = new Location("Painted Room");
            Location Cave9 = new Location("Breakroom from life");

            Location Cave10 = new Location("");
            Location Cave11 = new Location("Room of Dark Magic");
            Location Cave12 = new Location("Long stairway");
            #endregion

            #region Items
            Weapon Axe = new Weapon("Axe", "Axes", 15);
            Weapon ShortSword = new Weapon("Short sword", "Short Swords", 25);
            Potion HealPot = new Potion("Healing potion", "Healing potions", 50);
            Item OgreQuestCompleteRequirement = new Item("Bloody Ogre head", "Bloody Ogre heads");
            Item SorcererQuestCompleteRequirement = new Item("Sorcerer's wand", "Sorcerer's wands");
            #endregion

            #region Quests
            Quest OgreQuest = new Quest("Slay the Ogre", "Slay the nasty Ogre located north of the Dark Cave Tunnels", 100, OgreQuestCompleteRequirement)
            {
                CompletionMessage = "You return the " + OgreQuestCompleteRequirement.Name + "to the man. The monster has been slain!"
            };

            Quest SorcererQuest = new Quest("Kill the sorcerer", "Kill the sorcerer located somewhere in the dungeon and bring back its wand to me", 150, SorcererQuestCompleteRequirement)
            {
                CompletionMessage = "You give the" + SorcererQuestCompleteRequirement.Name + "to the old man. He thanks you for setting him free of his curse and turns to fine dust"
            };
            #endregion

            #region Monsters
            Monster Ogre = new Monster("Ogre", 100, OgreQuestCompleteRequirement)
            {
                Damage = 10

            };
            Ogre.MonsterLoot.Add(HealPot);

            Monster SkeletonWarrior = new Monster("Skeleton Warrior", 75)
            {
                Damage = 12
            };

            Monster Zombie = new Monster("Zombie", 125, HealPot)
            {
                Damage = 20

            };

            Monster Sorcerer = new Monster("Dark Sorcerer", 250, SorcererQuestCompleteRequirement)
            {
                Damage = 40
            };

            #endregion

            #region LocationSpecifics

            //You can not go from Cave 2 to 5 before you have slain the Ogre, OgreQuest must be done
            //
            Cave1.LocationToNorth = Cave2;
            Cave1.LocationToEast = null;
            Cave1.LocationToSouth = null;
            Cave1.LocationToWest = null;
            Cave1.Info.Add(Cave1.Description = "The small cave you entered is very dark and moist.");
            Cave1.Info.Add(Cave1.Description2 = "The walls of the cave are filled with mushrooms emitting a dim green light.");
            Cave1.Info.Add(Cave1.Description3 = "The light from the mushrooms allows you to vaguely see your nearby surroundings");

            Cave2.LocationToNorth = Cave4;
            Cave2.LocationToEast = Cave5;
            Cave2.LocationToSouth = Cave1;
            Cave2.LocationToWest = Cave3;
            Cave2.Info.Add(Cave2.Description = "You are in a room which splits into multiple tunnels.");
            Cave2.Info.Add(Cave2.Description2 = "To the east, there is a large door with ominous carvings about hellish monsters.");
            Cave2.Info.Add(Cave2.Description3 = "From the north tunnel you can hear some distant growling noises.");
            Cave2.Info.Add(Cave2.Description4 = "The pathway to the west tunnel is clean and seems to be used a lot.");
            Cave2.Info.Add(Cave2.Description5 = "To the south lies a dark, quiet passage.");

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
            // Cave4.Info.Add(Cave4.Description3 = "You see a big and bulky creature in the room. It lunges at you in rage! Time to fight!");
            Cave4.LocationMonsters.Add(Ogre);

            Cave5.LocationToNorth = null;
            Cave5.LocationToEast = Cave6;
            Cave5.LocationToSouth = null;
            Cave5.LocationToWest = Cave2;
            Cave5.Info.Add(Cave5.Description = "Torches on the wall light up the room.");
            Cave5.Info.Add(Cave5.Description2 = "You see some cages hanging from the cave roof housing the remains of their last prisoners");
            Cave5.Info.Add(Cave5.Description3 = "On the east end of the room are stairs which seem to lead somewhere up.");
            Cave5.Info.Add(Cave5.Description4 = "To the west there is a large door with ominous carvings about hellish monsters");

            Cave6.LocationToNorth = Cave7;
            Cave6.LocationToEast = null;
            Cave6.LocationToSouth = null;
            Cave6.LocationToWest = Cave5;
            Cave6.Info.Add(Cave6.Description = "The temperature seems higher on this level of the cave than what it was before.");
            Cave6.Info.Add(Cave6.Description2 = "The walls of this room are warm to your touch.");
            Cave6.Info.Add(Cave6.Description3 = "You see a pathway leading to north and stairs going further down to the cave on the west side of the room");
            Cave6.Info.Add(Cave6.Description4 = "There is a pile of bones on the ground");
            //Cave6.Info.Add(Cave6.Description5 = "On the ground a pile of bones starts to merge to a creature of somesort.");
            //Cave6.Info.Add(Cave6.Description6= "Skeleton warrior picks up a rusty sword from the ground and starts to move towards you!");
            Cave6.LocationMonsters.Add(SkeletonWarrior);

            Cave7.LocationToNorth = Cave8;
            Cave7.LocationToEast = null;
            Cave7.LocationToSouth = Cave6;
            Cave7.LocationToWest = null;
            Cave7.Info.Add(Cave7.Description = "You see an old man chained on the ground in the middle of this room.");
            Cave7.Info.Add(Cave7.Description2 = "The room is filled with dark symbols which seem to suck nearby light into them.");
            Cave7.Info.Add(Cave7.Description3 = "In one of its corners is a weapon rack.");
            Cave7.Info.Add(Cave7.Description4 = "There are ways leading south and north.");
            Cave7.LocationItems.Add(ShortSword);
            Cave7.LocationQuests.Add(SorcererQuest);
            Cave7.LocationItems.Add(HealPot);

            Cave8.LocationToNorth = Cave10;
            Cave8.LocationToEast = Cave9;
            Cave8.LocationToSouth = Cave7;
            Cave8.LocationToWest = null;
            Cave8.Info.Add(Cave8.Description = "The walls are covered with paintings of Devils and tormented humans.");
            Cave8.Info.Add(Cave8.Description2 = "The painter seems to have loved the color red.");
            Cave8.Info.Add(Cave8.Description3 = "The east wall has a broken door leading somewhere. There is also a door leading north.");
            Cave8.Info.Add(Cave8.Description4 = "The way south seems darker than it should be.");

            Cave9.LocationToNorth = null;
            Cave9.LocationToEast = null;
            Cave9.LocationToSouth = null;
            Cave9.LocationToWest = Cave8;
            Cave9.Info.Add(Cave9.Description = "You see an stone sarcophagus in the room.");
            Cave9.Info.Add(Cave9.Description2 = "The smell of rotting flesh is overwhelming.");
            //Cave9.Info.Add(Cave9.Description3 = "You hear a sad sounding moan and see a corpse getting outh of the sarcophagus");
            //Cave9.Info.Add(Cave9.Description4 = "It shambles towards you reaching out its hands in front of it");
            Cave9.LocationMonsters.Add(Zombie);


            Cave10.LocationToNorth = null;
            Cave10.LocationToEast = null;
            Cave10.LocationToSouth = Cave10;
            Cave10.LocationToWest = Cave11;
            Cave10.Info.Add(Cave10.Description = "Room filled with mist and misfortune");

            Cave11.LocationToNorth = null;
            Cave11.LocationToEast = Cave10;
            Cave11.LocationToSouth = null;
            Cave11.LocationToWest = Cave12;
            Cave11.Info.Add(Cave11.Description = "Sorcerer");
            Cave11.LocationMonsters.Add(Sorcerer);


            Cave12.LocationToNorth = null;
            Cave12.LocationToEast = null;
            Cave12.LocationToSouth = null;
            Cave12.LocationToWest = null;
            Cave12.Info.Add(Cave12.Description = "Stairway to get out of the cave");

            #endregion


            #region AddToWorld
            WorldList.Add(Cave1);
            WorldList.Add(Cave2);
            WorldList.Add(Cave3);
            WorldList.Add(Cave4);
            WorldList.Add(Cave5);
            WorldList.Add(Cave6);
            WorldList.Add(Cave7);
            WorldList.Add(Cave8);
            WorldList.Add(Cave9);
            WorldList.Add(Cave10);
            WorldList.Add(Cave11);
            //WorldList.Add(Cave8);
            #endregion







        }

    }

}