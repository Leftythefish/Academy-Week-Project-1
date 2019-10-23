using Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectEngine
{
    [TestClass]
    public class UnitTestClassObjects
    {
        ///<summary>
        ///--Ria--
        /// Unit tests for class object creation
        ///</summary>


        [TestMethod]
        public void ClassConstructors_CreatingItemclassobject_willnotcrash()
        {
            Item x = new Item("Esine", "Esineet");
        }

        [TestMethod]
        public void ClassConstructors_CreatingItemWeaponclassobject_willnotcrash()
        {
            Weapon x = new Weapon("Axe", "Axes", 10);
        }

        [TestMethod]
        public void ClassConstructors_CreatingItemPotionclassobject_willnotcrash()
        {
            Potion x = new Potion("Healing potion", "Healing potions", 20);
        }

    }
}
