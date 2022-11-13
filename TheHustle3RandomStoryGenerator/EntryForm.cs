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
        public StartAdventure StartAdventure;
        public EndAdventure EndAdventure;
        public NextScene NextScene;
        public Scene currentScene;
        public EntryForm()
        {
            InitializeComponent();
        }

        private void AdventureButton_Click(object sender, EventArgs e)
        {
            if (_onAdventure)
            {
                AdventureButton.Text = "Start Adventure";
                EndAdventure();
                SelectOptionButton.Enabled = false;
                currentScene = new Scene();
                PopulateWithScene();

            }
            else
            {
                AdventureButton.Text = "End Adventure";
                currentScene = StartAdventure();
                PopulateWithScene();
                SelectOptionButton.Enabled = true;

            }
            _onAdventure = !_onAdventure;
        }

        private void PopulateWithScene()
        {
            PromptTextBox.Text = currentScene.Prompt;
            List<string> str = new List<string>();
            str.Add(currentScene.GoodChoice);
            str.Add(currentScene.NeutralChoice);
            str.Add(currentScene.BadChoice);
            OptionsListBox.DataSource = str;
        }

        private void SelectOptionButton_Click(object sender, EventArgs e)
        {
            Alignment alignment;
            string choice;
            switch (OptionsListBox.SelectedIndex)
            {
                case 0:
                    alignment = Alignment.Good;
                    break;
                case 1:
                    alignment = Alignment.Neutral;
                    break;
                case 2:
                    alignment = Alignment.Evil;
                    break;
                default:
                    return;
            }
            currentScene = NextScene((string)(OptionsListBox.SelectedItem), alignment);
            PopulateWithScene();
        }
    }
}
