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
    public class NPCHandler
    {

        private readonly string data = @"../../data/npcs.csv";

        //File.ReadAllLines(data)
        //    .Skip(1)
        //    .Select(x => NPCHandler.LoadNPCS(x))
        //    .ToList();

        public void LoadNPCS()
        {
            List<NPC> list = File.ReadAllLines(data)
                .Skip(1)
                .Select(line => ReadFromCSV(line))
                .ToList();
        }

        public NPC ReadFromCSV(string line)
        {
            string[] vs = line.Split('\u002C');
            NPC npc = null;
            npc.ID = int.Parse(vs[0]);
            npc.Name = vs[1];
            npc.HP = int.Parse(vs[2]);
            npc.Atk = int.Parse(vs[3]);
            npc.Def = int.Parse(vs[4]);
            npc.Desc = vs[5];
            return npc;
        }

        public void WhoDis(int id)
        {
            //MessageBox.Show(list.ElementAt(id).GetStats());
        }

    }
}
