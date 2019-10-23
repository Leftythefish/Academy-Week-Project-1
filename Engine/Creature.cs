using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Creature
    {
        ///<summary>
        ///--Ria--
        /// This is base class for player and monsters so all properties here will be inherited by them
        /// Current health
        /// Maximum health
        /// etc
        ///</summary>
        ///
        private string name;

        public string Name
        {
            get { return name; }
            set
            { name = value; }
        }

        private int cur_health;

        public int Cur_Health
        {
            get { return cur_health; }
            set { cur_health = value; }
        }

        private int max_health;
        public int Max_Health
        {
            get { return max_health; }
            set { max_health = value; }
        }

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
