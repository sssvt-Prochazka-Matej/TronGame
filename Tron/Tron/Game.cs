﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tron
{
    public partial class Game : Form
    {

        bool right1, left1, up1;
        bool down1 = true;

        bool right2, left2, down2;
        bool up2 = true;

        int velocity = 4;    

        public Game()
        {
            InitializeComponent();
        }


        private void timer_Tick(object sender, EventArgs e)
        {

            TickAction(Bike1, Color.Orange,left1,right1,up1,down1);
            TickAction(Bike2, Color.Aqua, left2, right2, up2, down2);

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && ((string)x.Tag == "trail" || (string)x.Tag == "border"))
                {
                    if (Bike1.Bounds.IntersectsWith(x.Bounds))
                    {
                        timer.Stop();
                        MessageBox.Show("Player 1 wins");
                        this.Close();

                    }
                    if (Bike2.Bounds.IntersectsWith(x.Bounds))
                    {
                        timer.Stop();
                        MessageBox.Show("Player 2 wins");
                        this.Close();
                    }
                }
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //player1
                case Keys.Left:
                    if (!right1)
                    {
                        left1 = true;
                        right1 = false;
                        up1 = false;
                        down1 = false;
                    }
                    break;
                case Keys.Right:
                    if (!left1)
                    {
                        left1 = false;
                        right1 = true;
                        up1 = false;
                        down1 = false;
                    }
                    break;
                case Keys.Up:
                    if (!down1)
                    {
                        left1 = false;
                        right1 = false;
                        up1 = true;
                        down1 = false;
                    }
                    break;
                case Keys.Down:
                    if (!up1)
                    {
                        left1 = false;
                        right1 = false;
                        up1 = false;
                        down1 = true;
                    }
                    break;
                //player 2
                case Keys.A:
                    if (!right2)
                    {
                        left2 = true;
                        right2 = false;
                        up2 = false;
                        down2 = false;
                    }
                    break;
                case Keys.D:
                    if (!left2)
                    {
                        left2 = false;
                        right2 = true;
                        up2 = false;
                        down2 = false;
                    }
                    break;
                case Keys.W:
                    if (!down2)
                    {
                        left2 = false;
                        right2 = false;
                        up2 = true;
                        down2 = false;
                    }
                    break;
                case Keys.S:
                    if (!up2)
                    {
                        left2 = false;
                        right2 = false;
                        up2 = false;
                        down2 = true;
                    }
                    break;

            }

        }

        public void SpawnTrail(int x, int y, Color color, int height, int width)
        {
            PictureBox newTrail = new PictureBox();
            newTrail.Height = height;
            newTrail.Width = width;
            newTrail.BackColor = color;
            newTrail.Tag = "trail";

            Point p = new Point(x, y);

            newTrail.Location = p;

            this.Controls.Add(newTrail);
        }

        public void TickAction(PictureBox box, Color color, bool left, bool right, bool up, bool down)
        {
            if (left)
            {
                box.Left -= velocity;
                SpawnTrail(box.Location.X + 21, box.Location.Y, color, 20, 4);
            }
            if (right)
            {
                box.Left += velocity;
                SpawnTrail(box.Location.X - 5, box.Location.Y, color, 20, 4);
            }
            if (up)
            {
                box.Top -= velocity;
                SpawnTrail(box.Location.X, box.Location.Y + 21, color, 4, 20);
            }
            if (down)
            {
                box.Top += velocity;
                SpawnTrail(box.Location.X, box.Location.Y - 5, color, 4, 20);
            }

        }

        /*
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    left = false;
                    break;
                case Keys.Right:
                    right = false;
                    break;
                case Keys.Up:
                    up = false;
                    break;
                case Keys.Down:
                    down = false;
                    break;
            }
        }*/
    }
}