using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{

    public class PlayerActions
    {

        //Player input
        //move to --> try to move to location, update player location
        //look around, search --> show description of possible event triggers
        // search EVENT TRIGGER --> give item, spawn monster, do nothing
        // fighting --> hit, use potion, run away

        public static void ReadInput(Player p) //deal with movement input, decide location to go to
        {
            switch (p.Input)
            {
                case "go north":
                case "n":
                    MoveToLocation(p, p.CurrentLocation.LocationToNorth);
                    break;
                case "go south":
                case "s":
                    MoveToLocation(p, p.CurrentLocation.LocationToSouth);
                    break;
                case "go east":
                case "e":
                    MoveToLocation(p, p.CurrentLocation.LocationToEast);
                    break;
                case "go west":
                case "w":
                    MoveToLocation(p, p.CurrentLocation.LocationToWest);
                    break;
                case "look around":
                case "search":
                    Search(p);
                    break;
                case "talk":
                case "ask":
                    TalkToQuestGiver(p);
                    break;
                case "open bag":
                case "i":
                case "bag":
                    InventoryManagement(p);
                    break;
                default:
                    Window.EmptyGameTextFromScreen();
                    Window.EmptyStringData();
                    Window.line1 = "You can hear the wind rustling as you stare emptily ahead and wonder what your place in the world is.";
                    Window.line2 = "Were you about to do something?";
                    Window.line6 = "((hint: given input was not appropriate))";
                    Window.InsertGameTextToScreen();
                    break;
            }
        }
        private static void Search(Player p)
        {
            //show detailed description
            //give player hidden items
            Window.EmptyGameTextFromScreen();
            Window.EmptyStringData();
            int counter = 2;
            Window.lines[0] = "You search around for anything that looks like it has any value..";
            Window.lines[1] = "You found:";

            if (p.CurrentLocation.LocationItems.Count > 0)
            {
                foreach (var item in p.CurrentLocation.LocationItems)
                {
                    Window.lines[counter] = item.Name;
                    counter += 1;
                }
                    Window.InsertGameTextToScreenArray();
            }
            else
            {
                Window.lines[1] = "You found nothing.";
                Window.InsertGameTextToScreenArray();
            }
        }
        public static void MoveToLocation(Player p, Location newLocation)
        {
            if (newLocation != null)
            {
                p.CurrentLocation = newLocation;
                EnterNewLocation(p);
            }
            else
            {
                Window.EmptyGameTextFromScreen();
                Window.EmptyStringData();
                Window.line1 = "You cannot go that way."; //generate additional answers here? maybe location based?
                Window.InsertGameTextToScreen();
                //and go back to asking for input
            }
        }
        public static void EnterNewLocation(Player p)
        {
            var loc = p.CurrentLocation;
            //Display location name and description
            Window.EmptyGameTextFromScreen();
            Window.EmptyStringData();
            int counter = 0;
            Window.line1 = "You walk into the " + loc.Name;
            foreach (var desc in loc.Info)
            {
                Window.lines[counter] = desc;
                counter += 1;
            }
            Window.InsertGameTextToScreenArray();
            //check if the location has a monster to fight
            if (loc.LocationMonsters.Count > 0) //here there be monsters
            {
                var mon = loc.LocationMonsters[loc.LocationMonsters.Count-1];
                FightMonster(p, mon);
                p.CurrentLocation.LocationMonsters.Remove(mon);

                //foreach (var mon in loc.LocationMonsters) //fight all monsters in turn, maybe random generate this to pick one?
                //{
                //    //displaymessage
                //    //fightmonster'

                //}
            }
        }
        private static void FightMonster(Player p, Monster mon)
        {//--Ria, Jesse

            var p_weapon = p.EquippedWeapon;
            do
            {
                Window.InsertGameTextToScreen();

                if (mon.Cur_Health > 0)
                {

                    p.Input = Console.ReadLine().ToLower();
                    switch (p.Input)
                    { //create damage variables to change 
                        case "attack":
                        case "a":
                        case "hit":
                        case "h":
                        case "slash":
                            Window.EmptyGameTextFromScreen();
                            Window.EmptyStringData();
                            bool hit = HitCalculator();
                            if (hit == true)
                            {
                            Window.line1 = "You hit the " + mon.Name + " with your " + p_weapon.Name + " doing " + p.EquippedWeapon.Damage + " damage.";
                            Window.InsertGameTextToScreen();
                            mon.Cur_Health -= p.EquippedWeapon.Damage;
                            }
                            else
                            {
                                Window.line1 = "You attempt to hit the " + mon.Name + " with your " + p_weapon.Name + ", but it evades your attack.";
                                Window.InsertGameTextToScreen();
                            }
                            break;
                        default:
                            Window.EmptyGameTextFromScreen();
                            Window.EmptyStringData();
                            Window.line1 = "You were too slow. Next round try one of the following commands: 'slash', 'attack' or 'hit'";
                            Window.InsertGameTextToScreen();
                            break;
                    }
                    Window.line2 = "The " + mon.Name + " hits you, doing " + mon.Damage + " damage.";
                    Window.line3 = "The monster health is at: " + mon.Cur_Health + "/" + mon.Max_Health;
                    Window.InsertGameTextToScreen();
                    p.Cur_Health -= mon.Damage;
                    Window.UpdateHp(p);
                }
                else //monster health below 0
                {
                    Window.EmptyGameTextFromScreen();
                    Window.EmptyStringData();
                    Window.lines[0] = "You have managed to kill the " +mon.Name + ".";
                    Window.lines[1] = "You loot the corpse and find:";
                    Window.lines[2] = mon.QuestItem.Name;
                    int counter = 3;
                    foreach (var item in mon.MonsterLoot)
                    {
                        Window.lines[counter] = item.Name;
                        p.Inventory.Add(item);
                        counter += 1;
                    }
                    Window.InsertGameTextToScreenArray();
                    return;
                }
            } while (p.Cur_Health > 0); // player is alive
            //player health below 0
            Window.CreateGameOverScreen();
        }
        private static void TalkToQuestGiver(Player p)
        {
            var loc = p.CurrentLocation;
            //check if the there is a quest to offer
            if (loc.LocationQuests != null) // location has a quest
            {
                foreach (var lquest in loc.LocationQuests)
                {
                    //does the player already have the quest?
                    if (p.QuestList.Contains(lquest)) //player has the quest
                    {
                        if (lquest.QuestCompleted == true) //player has the quest and it is completed
                        {
                            // do nothing
                        }
                        else //player has quest and it is not marked as complete
                        {
                            if (p.Inventory.Contains(lquest.CompletionRequirement)) //does player inventory contain the required completion item?
                            {
                                //set quest completion status as complete and remove quest inventory item
                                lquest.QuestCompleted = true;
                                p.Inventory.Remove(lquest.CompletionRequirement);
                                //display completion message and give rewards
                                Window.EmptyGameTextFromScreen();
                                Window.EmptyStringData();
                                int counter = 1;
                                Window.lines[0] = lquest.CompletionMessage;
                                foreach (var item in lquest.Reward_Items)
                                {
                                    p.Inventory.Add(item);
                                    Window.lines[counter] = "Added " + item.Name + " to inventory.";
                                    Window.InsertGameTextToScreenArray();
                                }
                                p.Exp += lquest.RewardXP;
                                // update player level
                                p.UpdatePlayerLevel();
                            }
                            else
                            {
                                Window.EmptyGameTextFromScreen();
                                Window.EmptyStringData();
                                Window.line1 = "You don't have the required proof to finish the quest.";
                                Window.InsertGameTextToScreen();
                            }
                        }
                    }
                    else //player does not have the quest
                    {
                        //give the player the quest
                        p.QuestList.Add(lquest);
                        //Display message
                        Window.EmptyGameTextFromScreen();
                        Window.EmptyStringData();
                        Window.line1 = "You are given a quest: ";
                        Window.line2 = lquest.Description;
                        Window.InsertGameTextToScreen();
                    }
                }
            }

        }
        public static void PlayerInputHelp() //case help or case h
        {
            Window.EmptyGameTextFromScreen();
            Window.EmptyStringData();
            Window.line1 = "Help menu. Type what you want to do and press enter:";
            Window.line2 = "Movement:";
            Window.line3 = "'go north' or 'n' to move north";
            Window.line4 = "'go east' or 'e' to move east";
            Window.line5 = "'go south' or 's' to move south";
            Window.line6 = "'go west' or 'w' to move west";
            Window.line7 = "Actions:";
            Window.line8 = "'look around' or 'search' to take a closer look at your surroundings";
            Window.line9 = "'help' or 'h' to open Help Menu";
            Window.InsertGameTextToScreen();
        }

        public static void InventoryManagement(Player p) 
        {
            Window.EmptyGameTextFromScreen();
            Window.EmptyStringData();
            Window.lines[0] = "You have the following items in your inventory";
            int counter = 1;
            foreach (var item in p.Inventory)
            {
                Window.lines[counter] = item.Name;                
                counter += 1;
            }
            Window.InsertGameTextToScreenArray();
            // add functino for showing multiple items counter
            // add function for choosing item by name
            // add method for using potion
            // add method for equipping weapon
            // add method for dropping item
        }

        public static bool HitCalculator() 
        {            
            int variable = RandomNumber();
            bool hit;
            if (variable < 70)
            {
                hit = true;
            }
            else
            {
                hit = false;
            }
            return hit;
        }
        public static int RandomNumber()
        {
            Random rnd = new Random();
            int rndnumber = rnd.Next(1, 100);
            return rndnumber;
        }
    }
}
