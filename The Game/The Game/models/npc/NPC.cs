using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Game.models.npc
{
    public class NPC
    {

        private int id;
        private string name;
        private int hp;
        private int atk;
        private int def;
        private String desc;

        public NPC(int id, string name, int hp, int atk, int def, string desc)
        {
            ID = id;
            Name = name;
            HP = hp;
            Atk = atk;
            Def = def;
            Desc = desc;
        }

        public NPC(string line)
        {
            var split = line.Split('\u002C');
            ID = int.Parse(split[0]);
            Name = split[1];
            HP = int.Parse(split[2]);
            Atk = int.Parse(split[3]);
            Def = int.Parse(split[4]);
            Desc = split[5];
        }

        public int ID { get { return id; } set { id = value; } }

        public string Name { get { return name; } set { name = value; } }

        public int HP { get { return hp; } set { hp = value; } }

        public int Atk { get { return atk; } set { atk = value; } }

        public int Def { get { return def; } set { def = value; } }

        public String Desc { get { return desc; } set { desc = value; } }

        public string GetStats()
        {
            return String.Format("ID: {0}, Name: {1}, HP: {2}, Atk: {3}, Def: {4}, Desc: {5}", ID, Name, Atk, Def, Desc);
        }

    }
}
