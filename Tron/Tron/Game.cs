using System;
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

        Motorbike motorbike1 = new Motorbike(Direction.Down);

        Motorbike motorbike2 = new Motorbike(Direction.Up);

        
        public Game()
        {
            InitializeComponent();
        }
        private void timer_Tick(object sender, EventArgs e)
        {

            TickAction(Bike1, Color.Orange,motorbike1.Direction, motorbike1.Velocity);
            TickAction(Bike2, Color.Aqua, motorbike2.Direction, motorbike2.Velocity);

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && ((string)x.Tag == "trail" || (string)x.Tag == "border"))
                {
                    if (Bike1.Bounds.IntersectsWith(x.Bounds))
                    {
                        timer.Stop();
                        MessageBox.Show("Player 1 wins");
                        motorbike1.Score++;
                        RestarGame();
                        lblP1.Text = ": " + Convert.ToString(motorbike1.Score);
                        timer.Start();
                       
                    }

                    if (Bike2.Bounds.IntersectsWith(x.Bounds))
                    {
                        timer.Stop();
                        MessageBox.Show("Player 2 wins");
                        motorbike2.Score++;
                        RestarGame();
                        lblP2.Text = Convert.ToString(motorbike2.Score) + " :";
                        timer.Start();
                    }
                }
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

        public void TickAction(PictureBox box, Color color, Direction direction,int velocity)
        {
            switch (velocity)
            {
                case 4:
                    switch (direction)
                    {
                        case Direction.Left:
                            box.Left -= velocity;
                            SpawnTrail(box.Location.X + 21, box.Location.Y, color, 20, 4);
                            break;
                        case Direction.Right:
                            box.Left += velocity;
                            SpawnTrail(box.Location.X - 5, box.Location.Y, color, 20, 4);
                            break;
                        case Direction.Up:
                            box.Top -= velocity;
                            SpawnTrail(box.Location.X, box.Location.Y + 21, color, 4, 20);
                            break;
                        case Direction.Down:
                            box.Top += velocity;
                            SpawnTrail(box.Location.X, box.Location.Y - 5, color, 4, 20);
                            break;
                    }
                    break;
                case 8:
                    switch (direction)
                    {
                        case Direction.Left:
                            box.Left -= velocity;
                            SpawnTrail(box.Location.X + 21, box.Location.Y, color, 20, 8);
                            break;
                        case Direction.Right:
                            box.Left += velocity;
                            SpawnTrail(box.Location.X - 9, box.Location.Y, color, 20, 8);
                            break;
                        case Direction.Up:
                            box.Top -= velocity;
                            SpawnTrail(box.Location.X, box.Location.Y + 21, color, 8, 20);
                            break;
                        case Direction.Down:
                            box.Top += velocity;
                            SpawnTrail(box.Location.X, box.Location.Y - 9, color, 8, 20);
                            break;
                    }
                    break;
            }
        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    motorbike1.Velocity = 4;
                    break;
                case Keys.Space:
                    motorbike2.Velocity = 4;
                    break;

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //player1
                case Keys.Left:
                    if (motorbike1.Direction != Direction.Right && motorbike1.Velocity == 4)
                    {
                        motorbike1.Direction = Direction.Left;
                    }
                    break;
                case Keys.Right:
                    if (motorbike1.Direction != Direction.Left && motorbike1.Velocity == 4)
                    {
                        motorbike1.Direction = Direction.Right;
                    }
                    break;
                case Keys.Up:
                    if (motorbike1.Direction != Direction.Down && motorbike1.Velocity == 4)
                    {
                        motorbike1.Direction = Direction.Up;
                    }
                    break;
                case Keys.Down:
                    if (motorbike1.Direction != Direction.Up && motorbike1.Velocity == 4)
                    {
                        motorbike1.Direction = Direction.Down;
                    }
                    break;
                case Keys.Enter:
                    motorbike1.Velocity = 8;
                    break;
                //player 2
                case Keys.A:
                    if (motorbike2.Direction != Direction.Right && motorbike2.Velocity == 4)
                    {
                        motorbike2.Direction = Direction.Left;
                    }
                    break;
                case Keys.D:
                    if (motorbike2.Direction != Direction.Left && motorbike2.Velocity == 4)
                    {
                        motorbike2.Direction = Direction.Right;
                    }
                    break;
                case Keys.W:
                    if (motorbike2.Direction != Direction.Down && motorbike2.Velocity == 4)
                    {
                        motorbike2.Direction = Direction.Up;
                    }
                    break;
                case Keys.S:
                    if (motorbike2.Direction != Direction.Up && motorbike2.Velocity == 4)
                    {
                        motorbike2.Direction = Direction.Down;
                    }
                    break;
                case Keys.Space:
                    motorbike2.Velocity = 8;
                    break;
                //end
                case Keys.Escape:
                    this.Close();
                    break;
            }

        }

        public void RestarGame()
        {
            foreach (Control item in this.Controls.OfType<PictureBox>().ToList())
            {
                if ((string)item.Tag == "trail")
                    this.Controls.Remove(item);
            }

            Bike1.Location = RandomPoint(650,750);
            Bike2.Location = RandomPoint(200,220);
            motorbike1.Velocity = 4;
            motorbike2.Velocity = 4;

        }

        public Point RandomPoint(int i, int ii)
        {
            Random rand = new Random();

            int x = rand.Next(i, 800);
            int y = rand.Next(ii, 800);

            Point p = new Point(x, y);
            return p;
        }
       
       
    }
}
