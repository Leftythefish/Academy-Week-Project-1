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
            string expected = "Esine Esineet";
            string result = x.Name + " " + x.Name_Plural;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ClassConstructors_CreatingItemWeaponclassobject_willnotcrash()
        {
            Weapon x = new Weapon("Axe", "Axes", 10);
            string expected = "Axe Axes 10";
            string result = x.Name + " " + x.Name_Plural + " " + x.Damage;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ClassConstructors_CreatingItemPotionclassobject_willnotcrash()
        {
            Potion x = new Potion("Healing potion", "Healing potions", 20);
            string expected = "Healing potion Healing potions 20";
            string result = x.Name + " " + x.Name_Plural + " " + x.Healing_Amount;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ClassConstructors_CreatingCreatureMonsterclassobject_willnotcrash()
        {
            //Monster x = new Monster("Orc", 50, );
            //string expected = "Orc 50";
            //string result = x.Name + " " + x.Max_Health;
            //Assert.AreEqual(expected, result);
        }

    }
}
