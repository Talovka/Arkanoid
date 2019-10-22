using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlternativeArkanoid
{
    public partial class Maps : Form
    {
        public Maps()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button10_Click(object sender, EventArgs e)
        {
            Visible = false;
            string path = "Level1";
            using (var game = new Game1())
            {
                game.Disposed += GameClosed;
                game.Run();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
            string path = "Level2";
            using (var game = new Game1())
            {
                game.Disposed += GameClosed;
                game.Run();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Visible = false;
            string path = "Level3";
            using (var game = new Game1())
            {
                game.Disposed += GameClosed;
                game.Run();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Visible = false;
            string path = "Level4";
            using (var game = new Game1())
            {
                game.Disposed += GameClosed;
                game.Run();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Visible = false;
            string path = "Level5";
            using (var game = new Game1())
            {
                game.Disposed += GameClosed;
                game.Run();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Visible = false;
            string path = "Level6";
            using (var game = new Game1())
            {
                game.Disposed += GameClosed;
                game.Run();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Visible = false;
            string path = "Level7";
            using (var game = new Game1())
            {
                game.Disposed += GameClosed;
                game.Run();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Visible = false;
            string path = "Level8";
            using (var game = new Game1())
            {
                game.Disposed += GameClosed;
                game.Run();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Visible = false;
            string path = "Level9";
            using (var game = new Game1())
            {
                game.Disposed += GameClosed;
                game.Run();
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            Form menu = new Menu();
            menu.ShowDialog();
        }

        public void GameClosed(object sender, EventArgs e)
        {
            Visible = true;
            Cursor.Show();
        }
    }
}
