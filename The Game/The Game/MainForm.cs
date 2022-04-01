using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Game
{
    public partial class MainForm : Form
    {

        public string tempName { get; set; }
        public Stopwatch stopwatch = new Stopwatch();

        public MainForm()
        {
            InitializeComponent();


            // for now stop watch is being initialized here, once loading is implemented moving stop watch to initliaze once loading is complete
            stopwatch.Start();
            

            this.UserInput.KeyDown += new KeyEventHandler(this.UserInput_KeyDown);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }


        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDialog createDialog = new CreateDialog(this);
            createDialog.ShowDialog();
            if (createDialog.IsDisposed)
                toolStripStatusLabel1.Text = "Player: " + tempName + ", has been created.";
        }

        private void UserInput_KeyDown(object sender, KeyEventArgs k)
        {
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:D2}:{1:D2}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);

            if (k.KeyCode == Keys.Enter)
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
    }
}
