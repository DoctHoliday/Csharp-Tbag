using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using The_Game.handlers;

namespace The_Game
{
    public partial class CreateDialog : Form
    {

        public MainForm ParentWindow { get; set; }
        private FileHandler fileHandler = new FileHandler();


        public CreateDialog(MainForm parent)
        {
            InitializeComponent();
            this.ParentWindow = parent;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void CreateDialog_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Need to sanitize user input so that values are all expected
            string name = playerNameSubmission.Text;



            fileHandler.createPlayer(playerNameSubmission.Text);
            this.Close();
        }
    }
}
