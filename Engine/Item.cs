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
        public string Name { get; set; }
        public string Description { get; set; }
        public string EntranceDescription { get; set; }
        //Constructors
        public Item(string name)
        {
            id = ++nextId;
            this.Name = name;
        }
    }
}
