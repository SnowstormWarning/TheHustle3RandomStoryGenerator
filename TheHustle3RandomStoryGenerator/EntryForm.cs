using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHustle3RandomStoryGenerator
{
    public partial class EntryForm : Form
    {
        private bool _onAdventure = false;
        public EntryForm()
        {
            InitializeComponent();
        }

        private void AdventureButton_Click(object sender, EventArgs e)
        {
            if (_onAdventure)
            {
                AdventureButton.Text = "Start Adventure";

            }
            else
            {
                AdventureButton.Text = "End Adventure";
            }
            _onAdventure = !_onAdventure;
        }
    }
}
