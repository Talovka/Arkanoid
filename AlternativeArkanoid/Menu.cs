using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AlternativeArkanoid
{
    public partial class Menu : Form
    {
        public Menu()
        {
            
            InitializeComponent();
            
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            Visible = false;
            string path = "Level1";
            using (var game = new Game1())
            {   
                 game.Disposed+= GameClosed;
                 game.Run();
            }
        }

    public void GameClosed(object sender, EventArgs e)
    {
        Visible = true;
        Cursor.Show();
    }
   
    private void button4_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {  
            ActiveForm.Hide();
            Form maps = new Maps();
            maps.ShowDialog();
        }
    }
}
