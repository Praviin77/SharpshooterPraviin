using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpshooter_PraviinPremsankar
{
    public abstract class Weapon
    {
        public Picture picture;
        public PointF location;

        public float bulletSpeed;
        public int fireDelay;
        public float bulletStartDistance;
        public float facingAngle;
        public int timeSinceLastShot = 0;

        public int radius;
        public bool bIsOnGround = false;

        public Weapon(string filename, PointF loc)
        {
            this.picture = new Picture(filename, loc, 1, 1);
            this.location = loc;
            this.radius = picture.bitmap.Width / 2;
        }

        public void Draw(Graphics g)
        {
            picture.angle = facingAngle;

            // the image location is the player's location
            picture.location.X = location.X - GameForm.viewOffSet.X;
            picture.location.Y = location.Y - GameForm.viewOffSet.Y;

            picture.Draw(g);
        }

        public void Update(int time)
        {
            timeSinceLastShot += time;

            if (this.bIsOnGround == true)
            {
                if (this.IsTouching(GameForm.player1))
                {
                    this.bIsOnGround = false;
                    GameForm.weaponList.Remove(this);
                    GameForm.player1.currentWeapon = this;
                }
                if (GameForm.isPlayer2InGame == true && this.IsTouching(GameForm.player2))
                {
                    this.bIsOnGround = false;
                    GameForm.weaponList.Remove(this);
                    GameForm.player2.currentWeapon = this;
                }
            }
        }

        public void Fire(Soldier personFiring)
        {
            // Exit the method if not enough time has passed since last shot
            if (timeSinceLastShot < fireDelay)
            {
                return;
            }

            //Reset theshot timer
            timeSinceLastShot = 0;

            float _componentX = (float)Math.Cos(facingAngle / 180f * Math.PI);
            float _componentY = -(float)Math.Sin(facingAngle / 180f * Math.PI);

            // Create a bullet once fired with a direction (with refrence t the currnt soldier that just fired the bullet)
            Bullet bullet = CreateBullet(personFiring);

            //new Bullet("Images/bullet1.png", this,
            //new PointF(this.location.X + _componentX * bulletStartDistancce, this.location.Y + _componentY * bulletStartDistancce));
            bullet.location.X = this.location.X + _componentX * bulletStartDistance;
            bullet.location.Y = this.location.Y + _componentY * bulletStartDistance;

            // Assign magnitude (speed) to the bullets
            bullet.velocity.X = _componentX * bulletSpeed;
            bullet.velocity.Y = _componentY * bulletSpeed;

        }

        public abstract Bullet CreateBullet(Soldier personFiring);

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
    }
}
