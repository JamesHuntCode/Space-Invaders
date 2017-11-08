using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvadersGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.KeyDown += this.Form1_KeyDown;
        }

        Graphics spaceInvanders; // Set up graphics

        Canon playerIcon; // Initialize player

        List<List<Alien>> Aliens = new List<List<Alien>>(); // Array list of the different waves of aliens

        List<Shelter> Shelters = new List<Shelter>(); // Array list of shelters for the player to hide behind

        List<Bullet> Bullets = new List<Bullet>(); // Dynamic array list of bullets 

        private void Form1_Load(object sender, EventArgs e)
        {
            playerIcon = new Canon(25, 15, (this.picCanvas.Width / 2), (this.picCanvas.Height - 25));

            // Create multiple array lists that represent the waves of aliens that come towards the player:

            int offsetX = 180; // Set offset value

            List<Alien> row1 = new List<Alien>();

            for (int i = 0; i < 8; i++)
            {
                row1.Add(new Alien(25, 50, offsetX, 0));
                offsetX += 70;
            }

            Aliens.Add(row1);

            offsetX = 180; // Reset offset value

            List<Alien> row2 = new List<Alien>();

            for (int i = 0; i < 8; i++)
            {
                row2.Add(new Alien(25, 50, offsetX, 50));
                offsetX += 70;
            }

            Aliens.Add(row2);

            offsetX = 180;  // Reset offset value

            List<Alien> row3 = new List<Alien>();

            for (int i = 0; i < 8; i++)
            {
                row3.Add(new Alien(25, 50, offsetX, 100));
                offsetX += 70;
            }

            Aliens.Add(row3);

            offsetX = 180;  // Reset offset value

            List<Alien> row4 = new List<Alien>();

            for (int i = 0; i < 8; i++)
            {
                row4.Add(new Alien(25, 50, offsetX, 150));
                offsetX += 70;
            }

            Aliens.Add(row4);

            // Set up the different shelters:

            int shelterOffsetX = this.picCanvas.Width / 9;

            for (int i = 0; i < 4; i++)
            {
                Shelters.Add(new Shelter(100, 25, shelterOffsetX, this.picCanvas.Height - 100));
                shelterOffsetX += 200;
            }

            // Set up timer to control game:

            Timer timer = new Timer();

            timer.Interval = 10;

            timer.Tick += new EventHandler(timer_Tick);

            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            draw();
        }

        private void draw()
        {
            // Set up canvas:

            spaceInvanders = this.picCanvas.CreateGraphics();

            spaceInvanders.Clear(Color.Black);

            // Draw player icon (canon):

            SolidBrush playerBrush = new SolidBrush(Color.White);

            spaceInvanders.FillRectangle(playerBrush, this.playerIcon.getPosX(), this.playerIcon.getPosY(), this.playerIcon.getWidth(), this.playerIcon.getHeight());

            // Draw aliens in rectangular formation:

            SolidBrush alienBrush = new SolidBrush(Color.Green);

            for (int i = 0; i < Aliens[0].Count; i++)
            {
                spaceInvanders.FillRectangle(alienBrush, Convert.ToSingle(Aliens[0][i].getPosX()), Convert.ToSingle(Aliens[0][i].getPosY()), Aliens[0][i].getWidth(), Aliens[0][i].getHeight());

                // Enable behaviours:

                Aliens[0][i].move();

                if (Aliens[0][i].reachBottom(this.picCanvas.Height))
                {

                }
            }

            for (int i = 0; i < Aliens[1].Count; i++)
            {
                spaceInvanders.FillRectangle(alienBrush, Convert.ToSingle(Aliens[1][i].getPosX()), Convert.ToSingle(Aliens[1][i].getPosY()), Aliens[1][i].getWidth(), Aliens[1][i].getHeight());

                // Enable behaviours:

                Aliens[1][i].move();

                if (Aliens[1][i].reachBottom(this.picCanvas.Height))
                {

                }
            }

            for (int i = 0; i < Aliens[2].Count; i++)
            {
                spaceInvanders.FillRectangle(alienBrush, Convert.ToSingle(Aliens[2][i].getPosX()), Convert.ToSingle(Aliens[2][i].getPosY()), Aliens[2][i].getWidth(), Aliens[2][i].getHeight());

                // Enable behaviours:

                Aliens[2][i].move();

                if (Aliens[2][i].reachBottom(this.picCanvas.Height))
                {

                }
            }

            for (int i = 0; i < Aliens[3].Count; i++)
            {
                spaceInvanders.FillRectangle(alienBrush, Convert.ToSingle(Aliens[3][i].getPosX()), Convert.ToSingle(Aliens[3][i].getPosY()), Aliens[3][i].getWidth(), Aliens[3][i].getHeight());

                // Enable behaviours:

                Aliens[3][i].move();

                if (Aliens[3][i].reachBottom(this.picCanvas.Height))
                {

                }
            }

            // Draw shelters:

            SolidBrush shelterBrush = new SolidBrush(Color.White);

            for (int i = 0; i < Shelters.Count; i++)
            {
                spaceInvanders.FillRectangle(shelterBrush, Shelters[i].getPosX(), Shelters[i].getPosY(), Shelters[i].getHeight(), Shelters[i].getWidth());

                // Check shelter status:

                if (Shelters[i].getHealth() <= 0)
                {

                }
            }

            // Draw bullets:

            SolidBrush bulletBrush = new SolidBrush(Color.White);

            for (int i = 0; i < Bullets.Count; i++)
            {
                // Draw bullets:

                spaceInvanders.FillRectangle(bulletBrush, Bullets[i].getPosX(), Bullets[i].getPosY(), Bullets[i].getWidth(), Bullets[i].getHeight());

                // Enable bullet behaviours:

                Bullets[i].move();

                if (Bullets[i].getPosY() < 0)
                {
                    Bullets.Remove(Bullets[i]);
                }
            }
        }

        // Method used to handle the movement of the canon:
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) // Move left
            {
                this.playerIcon.move(1, 0, this.picCanvas.Width);
            }
            else if (e.KeyCode == Keys.Right) // Move right
            {
                this.playerIcon.move(2, 0, this.picCanvas.Width);
            }
            else if (e.KeyCode == Keys.Up) // Fire weapon
            {
                Bullets.Add(new Bullet(20, 3, this.playerIcon.getPosX() + 5, this.playerIcon.getPosY(), this.playerIcon.getDamageDealt()));
            }
        }
    }
}
