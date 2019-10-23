using Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProjectEngine
{
    [TestClass]
    public class UnitTestPlayerMovement
    {
        ///<summary>
        ///--Ria--
        /// Unit tests for player movement methods
        ///</summary>


        [TestMethod]
        public void SimplePlayerMovement_UpdatesPlayerPosition_NoErrors()
        {
            Player player1 = new Player("defaultname", 100);
            Location room2 = new Location("room2", "white room full of light");
            Location room1 = new Location("Room one", "A dark, blank room.", room2, null, null, null);
            room2.LocationToSouth = room1;
            player1.CurrentLocation = room1;
            player1.Input = "go north";
            PlayerActions.ReadInput(player1);

        }


    }
}
