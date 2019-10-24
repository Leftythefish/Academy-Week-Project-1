using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Monster : Creature
    {
        public int Damage { get; set; }
        public int Exp { get; set; }
        public Item QuestItem { get; set; }
        public List<Item> MonsterLoot = new List<Item>();
        public Monster(string name, int maximum_health) : base(name, maximum_health)
        {
            this.Damage = 10;
            this.Exp = 50;
        }
        public Monster(string name, int maximum_health, Item QuestItem) : base(name, maximum_health)
        {
            this.Damage = 10;
            this.Exp = 50;
            this.QuestItem = QuestItem;
        }
        public Monster(string name, int maximum_health, Item QuestItem, int damage) : base(name, maximum_health)
        {
            this.Damage = damage;
            this.Exp = 50;
            this.QuestItem = QuestItem;
        }
        public Monster(string name, int maximum_health, Item QuestItem, int damage, int rewardExp) : base(name, maximum_health)
        {
            this.Damage = damage;
            this.Exp = rewardExp;
            this.QuestItem = QuestItem;
        }
    }
}
