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

        private int velocityX = 1;

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

        public void setVelX(int speed)
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

        public int getDamageDealth()
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

        public int getVelX()
        {
            return this.velocityX;
        }

        // Behavioural methods:

        public void move(int leftSide, int rightSide)
        {
            this.positionX += this.velocityX;

            //if (this.positionX >= rightSide || this.positionX <= leftSide)
            //{
            //    this.velocityX = -this.velocityX;
            //    this.positionY += 50;
            //}
        }

        public void shoot()
        {

        }

        public void dead()
        {
            this.alive = false;

            this.height = 0;
            this.width = 0;
        }

        public bool reachBottom(int bottomOfScreen)
        {
            return (this.positionY >= bottomOfScreen && alive);
        }
    }
}
