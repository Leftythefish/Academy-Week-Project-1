using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class World
    {
        ///<summary>
        ///--Ria-- --Jyri--
        /// All data related to the world and what is in it
        /// Static because we only have one world, which has different locations
        /// So all locations and their details go here
        ///</summary>
        ///

        //    public List<Quest> Cave3Quests = new List<Quest>();
            //public List<Item> Cave3Items = new List<Item>();
           
            //public List<Monster> Cave4Monster = new List<Monster>();
     
        public void CreateWorlds()
        {

            //public List<Quest> LocationQuests = new List<Quest>(); Luo cave1:lle yksi new quest ja lisää cave1 questlistaan
            //public List<Item> LocationItems = new List<Item>();
            //public List<Monster> LocationMonsters = new List<Monster>();

       
        Location Cave1 = new Location("Dark Cave", "The small cave you entered is very dark and moist. Walls of the cave are filled with mushrooms emitting dim green light making you able to see your nearby surroundings");
        Location Cave2 = new Location("Dark Cave2","Test description2");
        Location Cave3 = new Location("Quest","Test description3");
        Location Cave4 = new Location("Ogre Cave", "Test description4");
        Location Cave5 = new Location("AfteQuest", "Test description5");

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

            Weapon Axe = new Weapon("axe", "axes", 5);
            Cave3.LocationItems.Add(Axe);

            Item ogreReward = new Item("ogre head", "ogre heads");
            Quest OgreQuest = new Quest("Slay the Ogre", "Slay the nasty Ogre located north of cave2", 10, ogreReward);
            Cave3.LocationQuests.Add(OgreQuest);

          //  Cave3Quests.Add(OgreQuest);


            Cave4.LocationToNorth = null;
            Cave4.LocationToEast = null;
            Cave4.LocationToSouth = Cave2;
            Cave4.LocationToWest = null;

            Monster Ogre = new Monster("Ogre", 10, ogreReward);
            //Cave4Monster.Add(Ogre);
            Cave4.LocationMonsters.Add(Ogre);
         //   Monster Ogre = new Monster("Ogre", 10, ogreReward);

            Cave5.LocationToNorth = null;
            Cave5.LocationToEast = null;
            Cave5.LocationToSouth = null;
            Cave5.LocationToWest = Cave2;
        }

        }
        
    }
 
    //{
    

        //walls of the cave are filled with mushrooms emitting(vai emiting) dim green light.
        //Cave1.DEscription =  "The small cave you entered is very dark and moist."<
        //Cave1.LocationToNorth = 
            //this.LocationToNorth = locationToNorth; mitä on tämän paikan pohjoispuolella
            //this.LocationToEast = locationToEast; mitä on tämän paikan itäpuolella
            //this.LocationToSouth = locationToSouth;
            //this.LocationToWest = locationToWest;

             //public List<Quest> LocationQuests = new List<Quest>(); Luo cave1:lle yksi new quest ja lisää cave1 questlistaan
            //public List<Item> LocationItems = new List<Item>();
            //public List<Monster> LocationMonsters = new List<Monster>();
       
//}
        
