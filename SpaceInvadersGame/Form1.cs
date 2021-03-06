﻿using System;
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

        private Graphics spaceInvanders; // Set up graphics

        private Canon playerIcon; // Initialize player

        private List<List<Alien>> Aliens = new List<List<Alien>>(); // Array list of the different waves of aliens

        private List<Shelter> Shelters = new List<Shelter>(); // Array list of shelters for the player to hide behind

        private List<Bullet> Bullets = new List<Bullet>(); // Dynamic array list of bullets 

        private List<AlienRay> AlienRays = new List<AlienRay>(); // Dynamic list of alien rays

        private void Form1_Load(object sender, EventArgs e)
        {
            playerIcon = new Canon(25, 15, (this.picCanvas.Width / 2), (this.picCanvas.Height - 25));

            // Create multiple array lists that represent the waves of aliens that come towards the player:

            int offsetX = 0; // Set offset value

            List<Alien> row1 = new List<Alien>();

            for (int i = 0; i < 8; i++)
            {
                row1.Add(new Alien(25, 50, offsetX, 0));
                offsetX += 70;
            }

            Aliens.Add(row1);

            offsetX = 0; // Reset offset value

            List<Alien> row2 = new List<Alien>();

            for (int i = 0; i < 8; i++)
            {
                row2.Add(new Alien(25, 50, offsetX, 50));
                offsetX += 70;
            }

            Aliens.Add(row2);

            offsetX = 0;  // Reset offset value

            List<Alien> row3 = new List<Alien>();

            for (int i = 0; i < 8; i++)
            {
                row3.Add(new Alien(25, 50, offsetX, 100));
                offsetX += 70;
            }

            Aliens.Add(row3);

            offsetX = 0;  // Reset offset value

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
            this.draw();

            shootPlayer(Aliens[3], 200);

            if (Aliens[3].Count == 0)
            {
                shootPlayer(Aliens[2], 150);
            }

            if (Aliens[2].Count == 0 && Aliens[3].Count == 0)
            {
                shootPlayer(Aliens[1], 100);
            }

            if (Aliens[1].Count == 0 && Aliens[2].Count == 0 && Aliens[3].Count == 0)
            {
                shootPlayer(Aliens[0], 50);
            }
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

                // Program alien behaviour for when they hit a wall:

                keepFormation(Aliens[0]);

                // Check to see if the aliens have touched the shelters:

                touchShelter(Aliens[0]);

                // Check to see if aliens have reached the bottom of the sreen:

                reachBottom(Aliens[0]);
            }

            for (int i = 0; i < Aliens[1].Count; i++)
            {
                spaceInvanders.FillRectangle(alienBrush, Convert.ToSingle(Aliens[1][i].getPosX()), Convert.ToSingle(Aliens[1][i].getPosY()), Aliens[1][i].getWidth(), Aliens[1][i].getHeight());

                // Enable behaviours:

                Aliens[1][i].move();

                // Program alien behaviour for when they hit a wall:

                keepFormation(Aliens[1]);

                // Check to see if the aliens have touched the shelters:

                touchShelter(Aliens[1]);

                // Check to see if aliens have reached the bottom of the sreen:

                reachBottom(Aliens[1]);
            }

            for (int i = 0; i < Aliens[2].Count; i++)
            {
                spaceInvanders.FillRectangle(alienBrush, Convert.ToSingle(Aliens[2][i].getPosX()), Convert.ToSingle(Aliens[2][i].getPosY()), Aliens[2][i].getWidth(), Aliens[2][i].getHeight());

                // Enable behaviours:

                Aliens[2][i].move();

                // Program alien behaviour for when they hit a wall:

                keepFormation(Aliens[2]);

                // Check to see if the aliens have touched the shelters:

                touchShelter(Aliens[2]);

                // Check to see if aliens have reached the bottom of the sreen:

                reachBottom(Aliens[2]);
            }

            for (int i = 0; i < Aliens[3].Count; i++)
            {
                spaceInvanders.FillRectangle(alienBrush, Convert.ToSingle(Aliens[3][i].getPosX()), Convert.ToSingle(Aliens[3][i].getPosY()), Aliens[3][i].getWidth(), Aliens[3][i].getHeight());

                // Enable behaviours:

                Aliens[3][i].move();

                // Program alien behaviour for when they hit a wall:

                keepFormation(Aliens[3]);


                // Check to see if the aliens have touched the shelters:

                touchShelter(Aliens[3]);

                // Check to see if aliens have reached the bottom of the sreen:

                reachBottom(Aliens[3]);
            }

            // Draw shelters:

            SolidBrush shelterBrush = new SolidBrush(Color.White);

            for (int i = 0; i < Shelters.Count; i++)
            {
                spaceInvanders.FillRectangle(shelterBrush, Shelters[i].getPosX(), Shelters[i].getPosY(), Shelters[i].getHeight(), Shelters[i].getWidth());

                // Check shelter status:

                if (Shelters[i].getHealth() <= 0)
                {
                    Shelters[i].destroyed();

                    Shelters.Remove(Shelters[i]);
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

                if (Bullets[i].getPosY() < -10) // Bullet has gone off the top of the screen
                {
                    Bullets[i].notActive();
                }

                // Check to see if a bullet has hit an alien:

                for (int j = 0; j < Aliens.Count; j++)
                {
                    for (int k = 0; k < Aliens[j].Count; k++)
                    {
                        if ((Aliens[j][k].getPosY() >= Bullets[i].getPosY()) && ((-50 <= Aliens[j][k].getPosX() - Bullets[i].getPosX()) && (0 >= Aliens[j][k].getPosX() - Bullets[i].getPosX())) && (Bullets[i].getStatus()))
                        {
                            Aliens[j].Remove(Aliens[j][k]); // Remove alien

                            Bullets[i].notActive(); // Remove bullet
                        }
                    }
                }

                // Check to see if the user shot a shelter:

                for (int j = 0; j < Shelters.Count; j++)
                {
                    if ((Shelters[j].getPosY() >= Bullets[i].getPosY()) && ((-100 <= Shelters[j].getPosX() - Bullets[i].getPosX()) && (0 >= Shelters[j].getPosX() - Bullets[i].getPosX())) && Bullets[i].getStatus())
                    {
                        Shelters[j].setHealth(Shelters[j].getHealth() - this.playerIcon.getDamageDealt()); // Lower the shelter's health

                        Bullets[i].notActive(); // Remove bullet
                    }
                }
            }

            // Draw alien rays:

            SolidBrush rayBrush = new SolidBrush(Color.Green);

            for (int i = 0; i < AlienRays.Count; i++)
            {
                // Draw alien rays:

                spaceInvanders.FillRectangle(rayBrush, AlienRays[i].getPosX(), AlienRays[i].getPosY(), AlienRays[i].getWidth(), AlienRays[i].getHeight());

                // Enable alien ray behaviours:

                AlienRays[i].move();

                if (AlienRays[i].getPosY() >= this.picCanvas.Height) // Alien ray has gone off the top of the screen
                {
                    AlienRays[i].notActive();
                }

                // Check to see if the alien hit the player:

                if ((AlienRays[i].getPosY() >= this.playerIcon.getPosY()) && ((0 <= AlienRays[i].getPosX() - this.playerIcon.getPosX()) && (15 >= AlienRays[i].getPosX() - this.playerIcon.getPosX())) && AlienRays[i].getStatus())
                {
                    AlienRays[i].notActive(); // Remove alien ray

                    // Restart the game:

                    Application.Restart();
                    Environment.Exit(0);
                }

                // Check to see if the alien shot any of the shelters:

                for (int j = 0; j < Shelters.Count; j++)
                {
                    if ((AlienRays[i].getPosY() >= Shelters[j].getPosY()) && ((-100 <= Shelters[j].getPosX() - AlienRays[i].getPosX()) && (0 >= Shelters[j].getPosX() - AlienRays[i].getPosX())) && AlienRays[i].getStatus())
                    {
                        Shelters[j].setHealth(Shelters[j].getHealth() - AlienRays[i].getDamageDealt()); // Lower the shelter's health

                        AlienRays[i].notActive(); // Remove alien ray
                    }
                }

            }
        }

        // Method used to control the alien formation when one side has touched a wall:

        private void keepFormation(List<Alien> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].getPosX() >= (this.picCanvas.Width - list[i].getWidth())) // Aliens have hit the right side wall
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        list[j].setVelX(-1.5);
                    }
                }
                else if (list[i].getPosX() <= 0) // Aliens have hit the left side wall
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        list[j].setVelX(1.5);
                    }
                }
            }
        }

        // Method used to allow the aliens to shoot at the player:

        private void shootPlayer(List<Alien> list, int chance)
        {
            Random rnd = new Random();

            for (int i = 0; i < list.Count; i++)
            {
                if (rnd.Next(0, chance) == 10)
                {
                    AlienRays.Add(new AlienRay(20, 3, (Convert.ToInt32(list[i].getPosX()) + (list[i].getWidth() / 2)), Convert.ToInt32(list[i].getPosY()), list[i].getDamageDealt()));
                }
            }
        }

        // Method used to remove shelters if touched by the aliens:

        private void touchShelter(List<Alien> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < Shelters.Count; j++)
                {
                    if ((list[i].getPosY() >= (Shelters[j].getPosY() - 25)) && ((-100 <= list[i].getPosX() - Shelters[j].getPosX()) && (100 >= list[i].getPosX() - Shelters[j].getPosX())))
                    {
                        Shelters[j].destroyed();
                    }
                }
            }
        }

        // Method used to check if any aliens have touched the bottom of the screen:

        private void reachBottom(List<Alien> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].reachBottom(this.picCanvas.Height - 25))
                {
                    // Restart the game:
                    Application.Restart();
                    Environment.Exit(0);
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
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Space) // Fire weapon
            {
                Bullets.Add(new Bullet(20, 3, this.playerIcon.getPosX() + 5, this.playerIcon.getPosY(), this.playerIcon.getDamageDealt()));
            }
        }
    }
}
