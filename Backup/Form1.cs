using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace Sheep
{
    public partial class Form1 : Form
    {
        int flipper, screenW, screenH, sheepX, sheepSpeed;
        Image Sheep1, Sheep2, Sheep3;
        public Form1()
        {
            InitializeComponent();
            Sheep1 = Image.FromFile(@"Sheeps\weird_sheep1.gif");
            Sheep2 = Image.FromFile(@"Sheeps\weird_sheep2.gif");
            Sheep3 = Image.FromFile(@"Sheeps\weird_sheep3.gif");
            flipper = 1;
            screenW = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            screenH = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            sheepX = screenW;
            sheepSpeed = 2;




        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(screenW, (screenH - this.Height) - 22);
            BoxSheep.Image = Sheep1;
            tmrSheeper.Start();
            tmrMoveit.Start();
        }

        private void tmrSheeper_Tick(object sender, EventArgs e)
        {
            switch(flipper)
            {
                case 1:
                    BoxSheep.Image = Sheep1;
                    flipper++;
                    break;
                case 2:
                    BoxSheep.Image = Sheep2;
                    flipper++;
                    break;
                case 3:
                    BoxSheep.Image = Sheep3;
                    flipper = 1;
                    break;

            }

        }

        private void tmrMoveit_Tick(object sender, EventArgs e)
        {
            if (sheepX >= this.Width*-1)
            {
                this.Location = new Point(sheepX, (screenH - this.Height)-22);
                sheepX -= sheepSpeed;
            }
            else
                sheepX = screenW;

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();
            this.Close();
        }



        private void fastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sheepSpeed = 3;
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sheepSpeed = 2;
        }

        private void slowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sheepSpeed = 1;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }




    }
}