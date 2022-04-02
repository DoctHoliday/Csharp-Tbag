using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;
using The_Game.handlers;
using The_Game.models.npc;
using The_Game.models.player;

namespace The_Game
{
    public partial class MainForm : Form
    {

        private FileHandler fileHandler = new FileHandler();
        public Stopwatch stopwatch = new Stopwatch();
        public string tempName { get; set; }
        public Player player = new Player("dummy", 0, 0 ,0, 0);

        public MainForm()
        {
            InitializeComponent();
            NPCHandler.LoadNPCS();
            this.UserInput.KeyDown += new KeyEventHandler(this.UserInput_KeyDown);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            stopwatch.Start();
        }

        private void UserInput_KeyDown(object sender, KeyEventArgs k)
        {
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:D2}:{1:D2}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);

            if (k.KeyCode == Keys.Enter && UserInput.Text != "")
            {
                MainConsole.AppendText("[" + elapsedTime + "] " + UserInput.Text.ToString() + "\n");
                UserInput.Text = "";
                k.Handled = true;
                k.SuppressKeyPress = true;
            }
        }

        private void userInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void mainConsole_TextChanged(object sender, EventArgs e)
        {
            MainConsole.SelectionStart = MainConsole.Text.Length;
            MainConsole.ScrollToCaret();
        }

        #region ToolStrip
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDialog createDialog = new CreateDialog(this);
            createDialog.ShowDialog();
            if (createDialog.IsDisposed)
                toolStripStatusLabel1.Text = "Player: " + tempName + ", has been created.";
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"../../data/saves/";
                openFileDialog.Filter = "JSON Files (*.json)|*.json";
                openFileDialog.FilterIndex = 0;
                openFileDialog.Title = "Load Character";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    player = JsonConvert.DeserializeObject<Player>(File.ReadAllText(filePath));  
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileHandler.SavePlayer(player);
            MessageBox.Show(player.Name + " has been saved!");
            NPCHandler.WhoDis(0);
        }
        #endregion
    }
}
