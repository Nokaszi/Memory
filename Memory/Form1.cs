using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class Form1 : Form, IView
    {
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            Game_Loading();
            new_game();
        }
        #region Properties
        public int How_many
        {
            get
            {
                return tableMemory.Controls.Count; 
            }
            set
            {
                How_many = tableMemory.Controls.Count;
            }
        }

        string[] _puzzle= new string[16] {
            "h", "h", "f", "f", ",", ",", "k", "k",
            "b", "b", "v", "v", "t", "t", "p", "p"
        };
        public string[] puzzle {
            get
            {
                return _puzzle.ToArray();
            }

            set
            {
                _puzzle = value;
            }
        }

        public void Game_Loading()
        {
            if (Start != null)
            {
                Start();
            }
        }
        public string firstClick
        {
            get
            {
                return FirstLabel.Text;
            }
        }
        public string secentClick
        {
            get
            {
                return SecentLabel.Text;
            }
        }
        private Label FirstLabel=null;
        private Label SecentLabel = null;
        #endregion
        #region Events
        public event Action Start;
        public event Action Check;
        public event Action Winer;
        #endregion
        private void new_game()
        {
            List<string> icons = _puzzle.ToList();
            foreach (Control control in tableMemory.Controls)
            {
                
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
            /*string[] icons = _puzzle;
            int j = 0;
            foreach (Control control in tableMemory.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    iconLabel.Text = icons[j];
                    iconLabel.ForeColor=iconLabel.BackColor;
                    j++;
                }
            }*/
        }
        private void label_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {

                if (clickedLabel.ForeColor == Color.Black)
                    return;
                if (FirstLabel == null)
                {
                    FirstLabel = clickedLabel;
                    FirstLabel.ForeColor = Color.Black;

                    return;
                }
                SecentLabel = clickedLabel;
                SecentLabel.ForeColor = Color.Black;
                if(Winer!=null)
                {
                    Winer();
                }
                timer1.Start();
                if (Check!=null)
                {
                    Check();
                }
                
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            FirstLabel.ForeColor = FirstLabel.BackColor;
            SecentLabel.ForeColor = SecentLabel.BackColor;

            FirstLabel = null;
            SecentLabel = null;
        }
        public void Couple()
        {
            timer1.Stop();
            FirstLabel = null;
            SecentLabel = null;
        }
        public void win(int ile)
        {
            ile++;
            string gratulacje = "Gratulacje, odkryłeś wszystkie w " + ile + " ruchach";
            MessageBox.Show( gratulacje, "Congratulations!");
            Close();
        }
    }
}
