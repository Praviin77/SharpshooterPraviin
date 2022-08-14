using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sharpshooter_PraviinPremsankar
{
    public abstract class PowerUp
    {
        public Picture picture;
        public PointF location;

        public int radius;
        public bool bIsOnGround = false;
        public bool bIsAcquired = false;

        public PowerUp(string filename, PointF loc)
        {
            this.picture = new Picture(filename, loc, 1, 1);
            this.location = loc;
            this.radius = picture.bitmap.Width / 2;
        }

        public void Draw(Graphics g)
        {
            // the image location is the player's location
            picture.location.X = location.X - GameForm.viewOffSet.X;
            picture.location.Y = location.Y - GameForm.viewOffSet.Y;


            if (bIsOnGround == true)
            {
                picture.Draw(g); 
            }
            else
            {
                return;
            }
        }

        public abstract void Update(int time);
        //{
            //if (this.bIsOnGround == true)
            //{
            //    if (this.IsTouching(GameForm.player1))
            //    {
            //        this.bIsOnGround = false;
            //        GameForm.powerUpList.Remove(this);
            //    }
            //    if (GameForm.isPlayer2InGame == true && this.IsTouching(GameForm.player2))
            //    {
            //        this.bIsOnGround = false;
            //        GameForm.powerUpList.Remove(this);
            //    }
            //}
        //}

        public bool IsTouching(Soldier soldier)
        {
            //Find the hypotneuse of the imaginary triangle to find the distance between two objects
            double _distance = Math.Sqrt(
                (soldier.location.X - this.location.X) * (soldier.location.X - this.location.X) +
                (soldier.location.Y - this.location.Y) * (soldier.location.Y - this.location.Y)
                );

            //If the sum of the two radii is less than the distance, then its a collsion
            return _distance < this.radius + soldier.radius;
        }
    }
}
