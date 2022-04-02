using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using The_Game.models.npc;

namespace The_Game.handlers
{
    public static class NPCHandler
    {

        private static readonly string data = @"../../data/npcs.csv";
        public static List<NPC> npcList = new List<NPC>();

        public static void LoadNPCS()
        {
            var lines = File.ReadAllLines(data)
                .Skip(1);
            foreach (string npc in lines)
            {
                var info = npc.Split('\u002C');
                npcList.Add(item: new NPC()
                {
                    ID = int.Parse(info[0]),
                    Name = info[1],
                    HP = int.Parse(info[2]),
                    Atk = int.Parse(info[3]),
                    Def = int.Parse(info[4]),
                    Desc = info[5]
                });

            }
        }

        public static void WhoDis(int id)
        {
            MessageBox.Show(npcList.ElementAt(id).GetStats());
        }

    }
}
