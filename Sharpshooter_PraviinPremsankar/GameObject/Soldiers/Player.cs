using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpshooter_PraviinPremsankar
{
    public class Player : Soldier
    {
        public string playerName;

        public string P1Name = "Player1";
        public string P2Name = "Player2";
        public string P1Num = "P1";
        public string P2Num = "P2";

        public Player(PointF loc) 
            : base ("Images/Player.png", loc, 100)
        {
            this.currentWeapon = new RapidGun(this.location);
            this.playerName = P1Name;
            this.playerName = P2Name;
        }

        public void Player1KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                turnDirection = .5F;
            }

            if (e.KeyCode == Keys.Right)
            {
                turnDirection = -.5F;
            }

            if (e.KeyCode == Keys.Up)
            {
                walkDirection = 1;
            }

            if (e.KeyCode == Keys.Down)
            {
                walkDirection = -1;
            }

            if (e.KeyCode == Keys.Enter)
            {
                bIsFiring = true;
            }
            if (e.KeyCode == Keys.P)
            {
                Level.bIsLevelWon = true;

                //Level.levelNum++;
                //Debug.WriteLine("are you running twice?");
                //Level.CreateLevel();
            }
        }

        public void Player1KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                turnDirection = 0F;
            }

            if (e.KeyCode == Keys.Right)
            {
                turnDirection = 0F;
            }

            if (e.KeyCode == Keys.Up)
            {
                walkDirection = 0;
            }

            if (e.KeyCode == Keys.Down)
            {
                walkDirection = 0;
            }

            if (e.KeyCode == Keys.Enter)
            {
                bIsFiring = false;
            }
        }

        public void Player2KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                turnDirection = .5F;
            }

            if (e.KeyCode == Keys.D)
            {
                turnDirection = -.5F;
            }

            if (e.KeyCode == Keys.W)
            {
                walkDirection = 1;
            }

            if (e.KeyCode == Keys.S)
            {
                walkDirection = -1;
            }

            if (e.KeyCode == Keys.Space)
            {
                bIsFiring = true;
            }
        }

        public void Player2KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                turnDirection = 0F;
            }

            if (e.KeyCode == Keys.D)
            {
                turnDirection = 0F;
            }

            if (e.KeyCode == Keys.W)
            {
                walkDirection = 0;
            }

            if (e.KeyCode == Keys.S)
            {
                walkDirection = 0;
            }

            if (e.KeyCode == Keys.Space)
            {
                bIsFiring = false;
            }
        }

    }
}
