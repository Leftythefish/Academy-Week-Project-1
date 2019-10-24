using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Item
    {
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

        public string Description { get; set; }

        //Constructors
        public Item(string name, string name_plural)
        {
            id = ++nextId;
            this.Name = name;
            this.Name_Plural = name_plural;
        }
        public Item(string name)
        {
            id = ++nextId;
            this.Name = name;
            this.Name_Plural = name_plural;
        }
    }
}
