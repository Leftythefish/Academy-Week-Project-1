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
                    p.M_Direction = Player.MovementDirection.North;
                    MoveToLocation(p, p.CurrentLocation.LocationToNorth);
                    break;
                case "go south":
                case "s":
                    p.M_Direction = Player.MovementDirection.South;
                    MoveToLocation(p, p.CurrentLocation.LocationToSouth);
                    break;
                case "go east":
                case "e":
                    p.M_Direction = Player.MovementDirection.East;
                    MoveToLocation(p, p.CurrentLocation.LocationToEast);
                    break;
                case "go west":
                case "w":
                    p.M_Direction = Player.MovementDirection.West;
                    MoveToLocation(p, p.CurrentLocation.LocationToWest);
                    break;
                case "look around":
                case "search":
                    p.Act = Player.Action.LookAround;
                    DoPlayerAction(p);
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

        private static void DoPlayerAction(Player p)
        {
            if (p.Act == Player.Action.LookAround)
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
                        Window.InsertGameTextToScreenArray();
                        counter += 1;
                    }
                }
                else
                {
                    Window.lines[1] = "You found nothing.";
                    Window.InsertGameTextToScreenArray();
                }

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
            Window.line1 = "You have entered " + loc.Name;
            Window.line2 = loc.Description;
            Window.InsertGameTextToScreen();

            //check if the location has a quest to offer
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
                                Window.line1 = lquest.CompletionMessage;
                                foreach (var item in lquest.Reward_Items) // Currently works only if one reward
                                {
                                    p.Inventory.Add(item);
                                    Window.line3 = "Added " + item.Name + " to inventory.";
                                    Window.InsertGameTextToScreen();
                                }
                                p.Exp += lquest.RewardXP;
                                // update player level
                                p.UpdatePlayerLevel();
                            }
                            else
                            {
                                //display message that player doesn't have required items to complete quest?
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
                        Window.line1 = lquest.Description;
                        Window.InsertGameTextToScreen();
                    }
                }
            }
            //check if the location has a monster to fight
            if (loc.LocationMonsters != null) //here there be monsters
            {
                foreach (var mon in loc.LocationMonsters) //fight all monsters in turn, maybe random generate this to pick one?
                {
                    //displaymessage
                    //fightmonster'
                    FightMonster(p, mon);
                }
            }
            else
            {
                // Do nothing and end the loop
            }

        }
        private static void FightMonster(Player p, Monster mon)
        {
            int php = p.Cur_Health;
            int mhp = mon.Cur_Health;
            var p_weapon = p.EquippedWeapon;
            if (p_weapon == null)
            {
                // DO SOMETHING NO WEAPON
                Window.CreateGameOverScreen();
            }
            do
            {
                switch (p.Input)
                {
                    case "attack":
                    case "a":
                        Window.EmptyGameTextFromScreen();
                        Window.EmptyStringData();
                        Window.line1 = "You attack the " + mon.Name + " with your " +p_weapon.Name + " doing " + p_weapon.Damage + " damage.";
                        Window.InsertGameTextToScreen();
                        mhp -= p_weapon.Damage;
                        break;
                    case "hit":
                    case "h":
                        Window.EmptyGameTextFromScreen();
                        Window.EmptyStringData();
                        Window.line1 = "You hit the " + mon.Name + " with your " + p_weapon.Name + " doing " + p_weapon.Damage + " damage.";
                        Window.InsertGameTextToScreen();
                        mhp -= p_weapon.Damage;
                        break;
                    case "slash":
                        Window.EmptyGameTextFromScreen();
                        Window.EmptyStringData();
                        Window.line1 = "You slash the " + mon.Name + " with your " + p_weapon.Name + " doing " + p_weapon.Damage + " damage.";
                        Window.InsertGameTextToScreen();
                        mhp -= p_weapon.Damage;
                        break;
                    default:
                        Window.EmptyGameTextFromScreen();
                        Window.EmptyStringData();
                        Window.line1 = "You were too slow. Next round try one of the following commands: 'slash', 'attack' or 'hit'";
                        Window.InsertGameTextToScreen();
                        break;
                }   // player hits monster
                    //monster hits player
                Window.EmptyGameTextFromScreen();
                Window.EmptyStringData();
                Window.line1 = "The " + mon.Name + " hits you, doing " + mon.Damage + " damage.";
                Window.InsertGameTextToScreen();
                php -= mon.Damage;
                Window.UpdateHp(p);
            }
            while (php > 0 || mhp > 0);
            // check who died
            if (php <= 0)
            {
                Window.CreateGameOverScreen();
            }
            else
            {
                Console.WriteLine($"You killed the mean {mon.Name}. Yippee!");
                Console.WriteLine($"You collect the {mon.RewardItem}.");
                //player.Inventory.Add(mon.RewardItem);
            }
        }

    }
}
//public static void PlayerInputHelp() //case help or case h
//{
//    Console.WriteLine("Help menu. Type what you want to do and press enter:");
//    Console.WriteLine("Movement:");
//    Console.WriteLine("\"go north\" or \"n\" = Move to north");
//    Console.WriteLine("\"go east\" or \"e\" = Move to east");
//    Console.WriteLine("\"go south\" or \"s\" = Move to south");
//    Console.WriteLine("\"go west\" or \"w\" = Move to west");
//    Console.WriteLine("Actions:");
//    Console.WriteLine("\"look around\" or \"search\" = Take a closer look at your surroundings");
//    Console.WriteLine("\"help\" or \"h\" = Open Help menu");
//}
