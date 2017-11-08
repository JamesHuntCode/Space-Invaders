using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersGame
{
    public class Canon
    {
        private int height;
        private int width;

        private int positionX;
        private int positionY;

        private int damageDealt = 100;
        private int health = 100;

        // Constructor:

        public Canon(int h, int w, int posX, int posY)
        {
            this.height = h;
            this.width = w;

            this.positionX = posX;
            this.positionY = posY;
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

        public int getHealth()
        {
            return this.health;
        }

        // Behavioural methods:

        public void move(int direction, int leftSide, int rightSide)
        {
            if (direction == 1) // Move left
            {
                this.positionX -= 20;

                if (this.positionX  + this.width < leftSide) // Player has moved too far left
                {
                    this.positionX += 20;
                }
            }
            else if (direction == 2) // Move right
            {
                this.positionX += 15;

                if (this.positionX + this.width > rightSide) // Player has moved too far right
                {
                    this.positionX -= 15;
                }
            }
        }

        public void dead()
        {
            
        }
    }
}
