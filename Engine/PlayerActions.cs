using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{

    public class PlayerActions
    {
        ///<summary>
        ///--Ria
        ///Engine methods for input, movement, fighting etc
        ///</summary>

        public static void ReadInput(Player p) //deal with movement input, decide location to go to
        {
            switch (p.Input)
            {
                case "help":
                case "h":
                    PlayerInputHelp();
                    break;
                case "go north":
                case "north":
                case "n":
                    MoveToLocation(p, p.CurrentLocation.LocationToNorth);
                    break;
                case "go south":
                case "south":
                case "s":
                    MoveToLocation(p, p.CurrentLocation.LocationToSouth);
                    break;
                case "go east":
                case "east":
                case "e":
                    MoveToLocation(p, p.CurrentLocation.LocationToEast);
                    break;
                case "go west":
                case "west":
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
                case "b":
                case "bag":
                    InventoryManagement(p);
                    break;
                case "a":
                case "attack":
                    Window.EmptyGameTextFromScreen();
                    Window.EmptyStringData();
                    Window.line1 = "You swing around you aimlessly. Nothing happens.";
                    Window.line6 = "((hint: there's nothing to fight here, type HELP for command info))";
                    Window.InsertGameTextToScreen();
                    break;
                default:
                    Window.EmptyGameTextFromScreen();
                    Window.EmptyStringData();
                    Window.line1 = "You can hear the wind rustling as you stare emptily ahead and wonder what your place in the world is.";
                    Window.line2 = "Were you about to do something?";
                    Window.line6 = "((hint: given input was not appropriate, type HELP for command info))";
                    Window.InsertGameTextToScreen();
                    break;
            }
        }
        public static void Search(Player p)
        {
            //show detailed description
            //give player hidden items
            Window.EmptyGameTextFromScreen();
            Window.EmptyStringData();
            int counter = 2;
            Window.lines[0] = "You search around for anything that looks like it has any value...";
            Window.lines[1] = "You found:";

            if (p.CurrentLocation.LocationItems.Count > 0)
            {
                foreach (var item in p.CurrentLocation.LocationItems)
                {
                    Window.lines[counter] = item.Name;
                    counter += 1;
                    p.Inventory.Add(item);
                }
                p.CurrentLocation.LocationItems.Clear();
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
                if (newLocation.Key == null)
                {
                    p.CurrentLocation = newLocation;
                    EnterNewLocation(p);
                }
                else
                {
                    string keyname = newLocation.Key.Name;
                    bool playerhaskey = PlayerHasItemNoRemove(p, keyname);
                    if (playerhaskey == true) // player has the key
                    {
                        // add description of using the key
                        Window.EmptyGameTextFromScreen();
                        Window.EmptyStringData();
                        Window.line1 = "You have the " + keyname + ". " + newLocation.Key.EntranceDescription;
                        Window.line3 = "Press any key to enter.";
                        Window.InsertGameTextToScreen();
                        Console.ReadKey();
                        if (newLocation.Name.ToLower() == "long stairway.")
                        {
                            p.CurrentLocation = newLocation;
                            EnterFinalLocation(p);
                        }
                        else
                        {
                            p.CurrentLocation = newLocation;
                            EnterNewLocation(p);
                        }
                    }
                    else //player no has the key
                    {
                        Window.EmptyGameTextFromScreen();
                        Window.EmptyStringData();
                        Window.line1 = newLocation.NoEntranceDescription;
                        Window.InsertGameTextToScreen();
                    }
                }
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
            int counter = 1;
            Window.lines[0] = "You walk into the " + loc.Name;
            foreach (var desc in loc.Info)
            {
                Window.lines[counter] = desc;
                counter += 1;
            }
            //check if the location has a monster to fight
            if (loc.LocationMonsters.Count > 0) //here there be monsters
            {
                var mon = loc.LocationMonsters[loc.LocationMonsters.Count - 1];
                Window.lines[counter] = "You quickly realize you are not alone. An evil looking " + mon.Name + " rushes at you! Prepare to fight!";
                Window.InsertGameTextToScreenArray();
                FightMonster(p, mon);
                p.CurrentLocation.LocationMonsters.Remove(mon);
            }
            else
            {
                Window.InsertGameTextToScreenArray();
            }
        }
        public static void EnterFinalLocation(Player p)
        {
            var loc = p.CurrentLocation;
            //Display location name and description
            Window.EmptyGameTextFromScreen();
            Window.EmptyStringData();
            int counter = 1;
            Window.lines[0] = "You walk into the " + loc.Name;
            foreach (var desc in loc.Info)
            {
                Window.lines[counter] = desc;
                counter += 1;
            }
            Window.lines[counter] = "Press any key to walk out";
            Window.InsertGameTextToScreenArray();
            Console.ReadKey();
            Window.CreateGameFinishedScreen(p);
        }
        public static void FightMonster(Player p, Monster mon)
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
                            int damage = p.EquippedWeapon.Damage + (p.Level * 5);
                            Window.EmptyGameTextFromScreen();
                            Window.EmptyStringData();
                            bool hit = HitCalculator();
                            if (hit == true)
                            {
                                Window.line1 = "You hit the " + mon.Name + " with your " + p_weapon.Name + " doing " + damage + " damage.";
                                Window.InsertGameTextToScreen();
                                mon.Cur_Health -= damage;
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
                            Window.line1 = "You were too slow. Next round try to attack by typing the command ATTACK or A.";
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
                    Window.lines[0] = "You have managed to kill the " + mon.Name + ".";
                    Window.lines[1] = "You loot the corpse and find:";
                    if (mon.QuestItem != null) //--Jyri, Ria--
                    {
                        Window.lines[2] = mon.QuestItem.Name;
                        p.Inventory.Add(mon.QuestItem);
                        int counter = 3;
                        foreach (var item in mon.MonsterLoot)
                        {
                            Window.lines[counter] = item.Name;
                            p.Inventory.Add(item);
                            counter += 1;
                        }
                    }
                    else
                    {
                        Window.lines[2] = "Absolutely nothing.";
                    }
                    p.Exp += mon.Exp;
                    p.UpdatePlayerLevel();
                    Window.UpdateExp(p);
                    Window.UpdateLvl(p);
                    Window.InsertGameTextToScreenArray();
                    return;
                }
            } while (p.Cur_Health > 0); // player is alive
            //player health below 0
            Window.CreateGameOverScreen();
        }
        public static void TalkToQuestGiver(Player p)
        {
            var loc = p.CurrentLocation;
            //check if the there is a quest to offer
            if (loc.LocationQuests.Count > 0) // location has a quest
            {
                foreach (var lquest in loc.LocationQuests)
                {
                    //does the player already have the quest?
                    if (p.QuestList.Contains(lquest)) //player has the quest
                    {
                        if (lquest.QuestCompleted == true) //player has the quest and it is completed
                        {
                            Window.EmptyGameTextFromScreen();
                            Window.EmptyStringData();
                            Window.line1 = "There really is nothing else to say. You stare at each other in awkward silence. Maybe you should leave..";
                            Window.InsertGameTextToScreen();
                        }
                        else //player has quest and it is not marked as complete
                        {
                            bool playerhasitem = PlayerHasItem(p, lquest.CompletionRequirement.Name);

                            if (playerhasitem == true) //does player inventory contain the required completion item?
                            {
                                CompleteQuest(p, lquest);
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
                        Window.line1 = "If you want to find your way out of here, you need to help me first.";
                        Window.line2 = lquest.Description;

                        bool playerhasitem = PlayerHasItem(p, lquest.CompletionRequirement.Name);
                        if (playerhasitem == true)
                        {
                            Window.line3 = "...";
                            Window.line4 = "...";
                            Window.line5 = "...";
                            Window.line7 = "Wait, what do you mean you already did it?";
                            Window.line9 = "Press any key to show them the proof.";
                            Window.InsertGameTextToScreen();
                            Console.ReadKey();
                            CompleteQuest(p, lquest);
                        }
                        else
                        {
                            Window.InsertGameTextToScreen();

                        }
                    }
                }
            }
            else // no quest
            {
                Window.EmptyGameTextFromScreen();
                Window.EmptyStringData();
                Window.line1 = "There's nobody to talk to. ";
                Window.InsertGameTextToScreen();
            }

        }
        public static void CompleteQuest(Player p, Quest lquest)
        {
            //set quest completion status as complete and remove quest inventory item
            lquest.QuestCompleted = true;
            //display completion message and give rewards
            Window.EmptyGameTextFromScreen();
            Window.EmptyStringData();
            int counter = 1;
            Window.lines[0] = lquest.CompletionMessage;
            foreach (var item in lquest.Reward_Items)
            {
                p.Inventory.Add(item);
                Window.lines[counter] = "Added " + item.Name + " to inventory.";
                Window.lines[counter + 1] = item.Description;
                counter += 1;
            }
            p.Exp += lquest.RewardXP;
            // update player level
            p.UpdatePlayerLevel();
            
            Window.UpdateExp(p);
            Window.UpdateLvl(p);
            Window.InsertGameTextToScreenArray();
            // p.Inventory.Remove(lquest.CompletionRequirement);
        }
        public static void PlayerInputHelp() //--Jesse
        {
            Window.EmptyGameTextFromScreen();
            Window.EmptyStringData();
            Window.line1 = "Type what you want to do and press ENTER:";
            Window.line2 = "";
            Window.line3 = "GO NORTH or N to move north";
            Window.line4 = "GO EAST or E to move east";
            Window.line5 = "GO SOUTH or S to move south";
            Window.line6 = "GO WEST or W to move west";
            Window.line7 = "LOOK AROUND or SEARCH to take a closer look at your surroundings";
            Window.line8 = "ATTACK or A to attack";
            Window.line9 = "TALK to talk";
            Window.line10 = "OPEN BAG, BAG or b to manage inventory";
            Window.line11 = "HELP or H to open Help Menu";
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
            Window.lines[counter] = "To use an item from inventory, type the item name and press enter. Type EXIT to close inventory.";
            Window.lines[counter + 1] = "Using a weapon will equip the chosen weapon. Using a potion will consume the potion.";

            Window.InsertGameTextToScreenArray();

            p.Input = Console.ReadLine().ToLower();
            if (!string.IsNullOrEmpty(p.Input))
            {
                if (p.Input == "exit")
                {
                    Window.EmptyGameTextFromScreen();
                    Window.EmptyStringData();
                    Window.line1 = "You are standing in the " + p.CurrentLocation.Name;
                    Window.InsertGameTextToScreen();
                    return;
                }
                else
                {
                    try
                    {

                        var selection = p.Inventory.Where(it => it.Name.ToLower().Contains(p.Input)).First();

                        if (selection is Weapon)
                        {
                            p.EquippedWeapon = (Weapon)selection;
                            Window.EmptyGameTextFromScreen();
                            Window.EmptyStringData();
                            Window.line1 = "You have equipped the " + p.EquippedWeapon.Name;
                            Window.InsertGameTextToScreen();
                        }
                        else if (selection is Potion)
                        {
                            p.Cur_Health += ((Potion)selection).Healing_Amount;
                            Window.UpdateHp(p);
                            Window.EmptyGameTextFromScreen();
                            Window.EmptyStringData();
                            Window.line1 = "You drink the potion, instantly feeling a lot better.";
                            Window.InsertGameTextToScreen();
                            p.Inventory.Remove(selection);
                        }
                        else
                        {
                            Window.EmptyGameTextFromScreen();
                            Window.EmptyStringData();
                            Window.line1 = "That is not the type of item you could actually use.";
                            Window.InsertGameTextToScreen();
                        }
                    }
                    catch (Exception)
                    {
                        Window.EmptyGameTextFromScreen();
                        Window.EmptyStringData();
                        Window.line1 = "You tumble around clumsily.";
                        Window.InsertGameTextToScreen();
                    }
                }
            }
            else
            {
                Window.EmptyGameTextFromScreen();
                Window.EmptyStringData();
                Window.line1 = "You are standing in the " + p.CurrentLocation.Name;
                Window.InsertGameTextToScreen();
            }
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
        public static bool PlayerHasItem(Player p, string itemname)
        {
            bool playerhasitem = false;
            foreach (var item in p.Inventory)
            {
                if (item.Name == itemname)
                {
                    playerhasitem = true;
                    p.Inventory.Remove(item);
                    break;
                }
            }
            return playerhasitem;
        }
        public static bool PlayerHasItemNoRemove(Player p, string itemname)
        {
            bool playerhasitem = false;
            foreach (var item in p.Inventory)
            {
                if (item.Name == itemname)
                {
                    playerhasitem = true;
                    break;
                }
            }
            return playerhasitem;
        }
    }
}
