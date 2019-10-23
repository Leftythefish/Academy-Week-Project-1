using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Item
    {
        ///<summary>
        ///--Ria--
        /// This is base class for potions and weapons so all properties here will be inherited by them
        /// ID
        /// Name (+name plural)
        /// etc.
        ///</summary>
        ///

        // Properties 

        private readonly int id;
        private static int nextId = 10000;
        public int ID { get { return id; } }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string name_plural;
        public string Name_Plural
        {
            get { return name_plural; }
            set { name_plural = value; }
        }

        //Constructors
        public Item(string name, string name_plural)
        {
            id = ++nextId;
            this.Name = name;
            this.Name_Plural = name_plural;
        }
    }
}
