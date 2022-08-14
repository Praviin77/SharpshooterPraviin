using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sharpshooter_PraviinPremsankar
{
    public class Bullet
    {
        public PointF location;
        public PointF velocity;
        public Picture picture;
        public float life;
        public int damage;

        private Soldier SoldierRef; // a refrence to the soldier to the soldier that fired us

        public int radius; // radius of a collision circle

        public Bullet(string image, Soldier sr, PointF loc)
        {
            this.SoldierRef = sr;

            picture = new Picture(image, loc, 4, 25);
            velocity = new PointF();
            this.location = loc;

            // get the radius through the bullet picture
            radius = picture.bitmap.Width / 2;

            // Add a bullet to the bullet list
            GameForm.bulletList.Add(this);
        }

        public virtual void Draw(Graphics g)
        {
            picture.location.X = this.location.X - GameForm.viewOffSet.X;
            picture.location.Y = this.location.Y - GameForm.viewOffSet.Y;

            picture.Draw(g);
        }

        public void Update(int time)
        {
            Move();
            picture.Update(time);

            life -= (float)time / 1000F;

            if (life <= 0)
            {
                GameForm.bulletList.Remove(this);
            }

            foreach (Wall w in GameForm.wallList)
            {
                if (this.isTouchingWall(w) == true)
                {
                    HitWall();

                    PointF _normal = w.FindNormalAtNearestPoint(this.location);
                    this.BounceFrom(_normal);
                }
            }

            // As the bullet travels, check for any enenmy that is being hit
            if (SoldierRef == GameForm.player1 || (SoldierRef == GameForm.player2 && GameForm.isPlayer2InGame == true))
            {
                for (int i = 0; i < GameForm.enemyList.Count; i++)
                {
                    if (this.IsTouching(GameForm.enemyList[i]))
                    {
                        if (GameForm.enemyList[i].health > 0)
                        {
                            //Debug.WriteLine(GameForm.enemyList[i].health);
                            GameForm.enemyList[i].TakeDamage(this.damage);
                            //Debug.WriteLine(GameForm.enemyList[i].health);
                            //this.life = 0;
                            GameForm.bulletList.Remove(this);
                            //Debug.WriteLine(this); 
                        }
                    }
                } 
            }

            // All bullets can hit player, unless player is dead
            if (this.IsTouching(GameForm.player1) && GameForm.player1.bIsKilled == false)
            {
                GameForm.player1.TakeDamage(this.damage);
                GameForm.bulletList.Remove(this);
            }

            if (GameForm.isPlayer2InGame == true)
            {
                // All bullets can hit player, unless player is dead
                if (this.IsTouching(GameForm.player2) && GameForm.player2.bIsKilled == false)
                {
                    GameForm.player2.TakeDamage(this.damage);
                    GameForm.bulletList.Remove(this);
                } 
            }
        }

        private bool IsTouching(Soldier soldier)
        {
            //Find the hypotneuse of the imaginary triangle to find the distance between two objects
            double _distance = Math.Sqrt(
                (soldier.location.X - this.location.X) * (soldier.location.X - this.location.X) +
                (soldier.location.Y - this.location.Y) * (soldier.location.Y - this.location.Y)
                );

            //If the sum of the two radii is less than the distance, then its a collsion
            return _distance < this.radius + soldier.radius;
        }

        public virtual void Move()
        {
            location.X += velocity.X;
            location.Y += velocity.Y;
        }

        public bool isTouchingWall(Wall w)
        {
            // nearestpoint on the wall to call the pointnearestto function
            PointF _nearestPoint = w.PointNearestTo(this.location);

            float _distance = (float)Math.Sqrt(
               (_nearestPoint.X - location.X) * (_nearestPoint.X - location.X) +
               (_nearestPoint.Y - location.Y) * (_nearestPoint.Y - location.Y));

            // If the distance is less than the radius
            if (_distance < this.radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void HitWall()
        {
            this.location.X -= this.velocity.X;
            this.location.Y -= this.velocity.Y;
        }

        // This method reflects along a normal vector
        public void BounceFrom(PointF normal)
        {
            // Create a pointF vector called reversed for the equation R = I - 2b
            PointF _reversed;

            // Apply the dot Product to create the "b" in the equation
            float _b = (velocity.X * normal.X + velocity.Y * normal.Y);

            // Create the 2b from the equation
            _b *= 2;

            // Create the new reflection vector
            // R = new velocity vector (outgoing)
            // I = old velocity vetor (incoming)
            // Multiply bounce factor by normal in order to turn boune factor into a vector
            _reversed = new PointF(this.velocity.X - normal.X * _b, this.velocity.Y - normal.Y * _b);

            // Set this bullet's newreflected velocity equal to the reversed vector
            this.velocity.X = _reversed.X;
            this.velocity.Y = _reversed.Y;
        }
    }
}
