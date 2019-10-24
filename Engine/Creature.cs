using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Creature
    {
        public string Name { get; set; }
        public int Cur_Health { get; set; }
        public int Max_Health { get; set; }
        public Creature(string name, int maximum_health)
        {
            this.Name = name;
            this.Max_Health = maximum_health;
            this.Cur_Health = maximum_health;
        }
        public Creature()
        {

        }
    }
}
