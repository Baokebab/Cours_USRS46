using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeuxDeLaVie_WindowsForms
{
    public partial class Form1 : Form
    {
        private Game game;
        Timer MyTimer = new Timer();
        int n;
        bool isPaused = false;
        public Form1()
        {
            n = 200; //A modif dans Game aussi si besoin 
            InitializeComponent(n);
            game = new Game(n);
            pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
            
            button2.Click += new EventHandler(button2_Click);
            button3.Click += new EventHandler(button3_Click);
            button2.Enabled = false;
            MyTimer.Interval = (20);
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
        }
        private void MyTimer_Tick(object sender, EventArgs e)
        {
            game.grid.UpdateGrid();
            if (game.grid.hasChanged)
            {
                Refresh();
            }
            else
            {
                MyTimer.Stop();
                MessageBox.Show("Le jeu de la vie restera dans un état constant.","Fin du jeu");
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            game.Paint(e.Graphics);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex < 6)
            {
                game = new Game(comboBox1.SelectedIndex);
            }
            else
            {
                game = new Game(n);                
            }
            button2.Enabled = false;
            button3.Text = "Start";
            pictureBox1.Invalidate();
            MyTimer.Stop();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (isPaused) { MyTimer.Start(); isPaused = false; button2.Text = "Pause"; }
            else { MyTimer.Stop(); isPaused = true; button2.Text = "Play"; }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            game.Reset();
            MyTimer.Start();
            button2.Enabled = true;
            button3.Text = "Reset";
            button2.Text = "Pause";
            isPaused = false;


        }
    }
}
