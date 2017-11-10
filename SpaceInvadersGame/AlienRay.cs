using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersGame
{
    class AlienRay
    {
        private int height;
        private int width;

        private int positionX;
        private int positionY;

        private int damageDealt;

        private bool active = true;

        // Constructor:

        public AlienRay(int h, int w, int posX, int posY, int damage)
        {
            this.height = h;
            this.width = w;

            this.positionX = posX;
            this.positionY = posY;

            this.damageDealt = damage;
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

        public int getDamageDealt()
        {
            return this.damageDealt;
        }

        public bool getStatus()
        {
            return this.active;
        }

        // Behavioural methods:

        public void move()
        {
            this.positionY += 5;
        }

        public void notActive()
        {
            this.active = false;

            this.height = 0;
            this.width = 0;
        }
    }
}
