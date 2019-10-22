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


        public static void ReadInput(Player player) //deal with movement input, decide location to go to
        {

            switch (player.Input)
            {
                case "go north":
                case "n":
                    player.M_Direction = Player.MovementDirection.North;
                    MoveToLocation(player, player.CurrentLocation.LocationToNorth);
                    break;
                case "go south":
                case "s":
                    player.M_Direction = Player.MovementDirection.South;
                    MoveToLocation(player, player.CurrentLocation.LocationToSouth);
                    break;
                case "go east":
                case "e":
                    player.M_Direction = Player.MovementDirection.East;
                    MoveToLocation(player, player.CurrentLocation.LocationToEast);
                    break;
                case "go west":
                case "w":
                    player.M_Direction = Player.MovementDirection.West;
                    MoveToLocation(player, player.CurrentLocation.LocationToWest);
                    break;
                default:
                    Console.WriteLine("You can hear the wind rustling as you stare emptily ahead and wonder what your place in the world is. Were you about to do something? ((hint: given input was not appropriate))");
                    break;
            }

        }
        public static void MoveToLocation(Player player, Location newLocation)
        {
            if (newLocation != null)
            {
                player.CurrentLocation = player.CurrentLocation.LocationToNorth;
                EnterNewLocation(player);
            }
            else
            {
                Console.WriteLine("You cannot go that way."); //generate additional answers here? maybe location based?
                //and go back to asking for input
            }
        }

        public static void EnterNewLocation(Player player)
        {
            var loc = player.CurrentLocation;
            //Display location name and description
            Console.WriteLine($"You have entered {loc.Name}");
            Console.WriteLine(loc.Description);

            //check if the location has a quest to offer
            if (loc.LocationQuests != null) // location has a quest
            {
                foreach (var lquest in loc.LocationQuests)
                {
                    //does the player already have the quest?
                    if (player.QuestList.Contains(lquest)) //player has the quest
                    {
                        if (lquest.QuestCompleted == true) //player has the quest and it is completed
                        {
                            // do nothing
                        }
                        else //player has quest and it is not marked as complete
                        {
                            if (player.Inventory.Contains(lquest.CompletionRequirement)) //does player inventory contain the required completion item?
                            {
                                //set quest completion status as complete and remove quest inventory item
                                lquest.QuestCompleted = true;
                                player.Inventory.Remove(lquest.CompletionRequirement);
                                //display completion message and give rewards
                                Console.WriteLine(lquest.CompletionMessage);
                                foreach (var item in lquest.Reward_Items)
                                {
                                    player.Inventory.Add(item);
                                    Console.WriteLine($"Added {item.Name} to inventory");
                                }
                                player.Exp = player.Exp + lquest.RewardXP;
                                player.UpdatePlayerLevel();
                                // update player level?
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
                        player.QuestList.Add(lquest);
                        //Display message
                        Console.WriteLine(lquest.Description);
                    }
                }

            }

            //check if the location has a monster to fight
            if (loc.LocationMonsters != null) //here there be monsters
            {
                foreach (var mon in loc.LocationMonsters) //fight all monsters in turn, maybe random generate this to pick one?
                {
                    //displaymessage
                    //fightmonster
                }
            }
            else
            {
                // Do nothing and end the loop
            }

        }

    }
}
