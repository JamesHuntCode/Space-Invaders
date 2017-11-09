using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersGame
{
    public class Shelter
    {
        private int height;
        private int width;

        private int positionX;
        private int positionY;

        private int health = 500;

        private bool active = true;

        // Constructor:

        public Shelter(int h, int w, int posX, int posY)
        {
            this.height = h;
            this.width = w;

            this.positionX = posX;
            this.positionY = posY;
        }

        public void setHealth(int amount)
        {
            this.health = amount;
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

        public int getPosX()
        {
            return this.positionX;
        }

        public int getPosY()
        {
            return this.positionY;
        }

        public int getHealth()
        {
            return this.health;
        }

        public bool getStatus()
        {
            return this.active;
        }

        // Behavioural methods:

        public void destroyed()
        {
            this.active = false;

            this.height = 0;
            this.width = 0;
        }
    }
}
