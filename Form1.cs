using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Media;
namespace Walker
{
    public partial class Form1 : Form
    {
        // Declare Sound Object
        private SoundPlayer _soundPlayer;
        int flipper, screenW, screenH, walkerX, walkerSpeed;
        Image Walker1, Walker2, Walker3;
        public Form1()
        {
            InitializeComponent();
            Walker1 = Image.FromFile(@"Walkers\MOONWALK.gif");
            Walker2 = Image.FromFile(@"Walkers\MOONWALK.gif");
            Walker3 = Image.FromFile(@"Walkers\MOONWALK.gif");
            flipper = 1;
            screenW = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            screenH = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            walkerX = screenW;
            walkerSpeed = 2;

            _soundPlayer = new SoundPlayer("C:/Users/arvin/OneDrive/Desktop/Walker/BJean.wav");
            //Play Snow - Red Hot Chilli Peppers
            _soundPlayer.Play();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(screenW, (screenH - this.Height) - 22);
            BoxWalker.Image = Walker1;
            tmrWalker.Start();
            tmrMoveit.Start();
        }

        private void tmrWalker_Tick(object sender, EventArgs e)
        {
            switch(flipper)
            {
                case 1:
                    BoxWalker.Image = Walker1;
                    flipper++;
                    break;
                case 2:
                    BoxWalker.Image = Walker2;
                    flipper++;
                    break;
                case 3:
                    BoxWalker.Image = Walker3;
                    flipper = 1;
                    break;

            }

        }

        private void tmrMoveit_Tick(object sender, EventArgs e)
        {
            if (walkerX >= this.Width*-1)
            {
                this.Location = new Point(walkerX, (screenH - this.Height)-22);
                walkerX -= walkerSpeed;
            }
            else
                walkerX = screenW;

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
            walkerSpeed = 3;
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            walkerSpeed = 2;
        }

        private void slowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            walkerSpeed = 1;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }




    }
}