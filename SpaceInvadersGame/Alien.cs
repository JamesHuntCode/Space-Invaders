using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersGame
{
    public class Alien
    {
        private int height;
        private int width;

        private double positionX;
        private double positionY;

        private double velocityX = 1.5;

        private int damageDealt = 100;
        private int health = 200;

        private bool alive = true;

        // Constructor:

        public Alien(int h, int w, double posX, double posY)
        {
            this.height = h;
            this.width = w;

            this.positionX = posX;
            this.positionY = posY;
        }

        public void setX(int x)
        {
            this.positionX = x;
        }

        public void setY(int y)
        {
            this.positionY = y;
        }

        public void setVelX(double speed)
        {
            this.velocityX = speed;
        }

        // Getter methods:

        public int getHeight()
        {
            return this.height;
        }

        public int getWidth()
        {
            return this.width;
        }

        public double getPosX()
        {
            return this.positionX;
        }

        public double getPosY()
        {
            return this.positionY;
        }

        public int getDamageDealt()
        {
            return this.damageDealt;
        }

        public int getHealth()
        {
            return this.health;
        }

        public bool getStatus()
        {
            return this.alive;
        }

        public double getVelX()
        {
            return this.velocityX;
        }

        // Behavioural methods:

        public void move()
        {
            this.positionX += this.velocityX;
            this.positionY += 0.2; 
        }

        public bool reachBottom(int bottomOfScreen)
        {
            return (this.positionY >= bottomOfScreen && alive);
        }
    }
}
