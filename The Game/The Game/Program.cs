using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using The_Game.player;

namespace The_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());

            Player player = new Player("Name", 10, 10, 10);
            Console.WriteLine(player.GetStats());
            Console.ReadKey();
        }
    }
}
