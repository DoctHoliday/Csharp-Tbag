using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using The_Game.player;

namespace The_Game.handlers
{
    public class FileHandler
    {
        private readonly string savedir = @"../../data/saves/";
        
        public void createPlayer(String name)
        {
            Player player = new Player(name, 10, 10, 5, 10);
            JObject json = JObject.Parse(JsonConvert.SerializeObject(player));
            File.WriteAllText(Path.GetFullPath(Path.Combine(savedir, name + ".json")), json.ToString());
        }
    }
}
