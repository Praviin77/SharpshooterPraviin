using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Sharpshooter_PraviinPremsankar
{
    public class Soldier
    {
        public Picture pic;
        public PointF location;

        public float facingAngle = 0F;
        public float turnDirection = 0F;
        public int walkDirection = 0;

        public PointF velocity;
        public float moveSpeed = 10;

        public bool bIsFiring = false;
        
        public int radius; // radius of a collision circle

        public int health;
        public bool bIsKilled = false;
        public bool bHitFlicker = false;
        public int hitFlickerCount = 0;

        public SoldierInfo soldierInfo;
        public Weapon currentWeapon;

        public Soldier(string image, PointF loc, int hp)
        {
            pic = new Picture(image, loc, 4, 60);
            this.location = loc;
            this.health = hp;
            velocity = new PointF();

            // Pick a random direction to start
            Random _random = new Random((int)DateTime.Now.Ticks);

            facingAngle = _random.Next(360);

            // get the radius through the soldier picture
            radius = pic.bitmap.Width / 2;

           soldierInfo = new SoldierInfo(this, loc, health);
        }

        public void Draw(Graphics graphics)
        {
            if (bIsKilled)
            {
                return;
            }

            if (bHitFlicker == false)
            {
                pic.angle = facingAngle;

                // the image location is the player's location
                pic.location.X = location.X - GameForm.viewOffSet.X;
                pic.location.Y = location.Y - GameForm.viewOffSet.Y;

                pic.Draw(graphics);

                currentWeapon.Draw(graphics);
            }
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            hitFlickerCount = 4;
        }

        // Virtual: allows methods to be expanded in subclasses
        public virtual void Update(int time)
        {
            if (health <= 0)
            {
                bIsKilled = true;
                radius = 0;
                //Debug.WriteLine(this + " killed");
                Explosion explosion = new Explosion(this.location);
                return;
            }

            // Ficker effect. Turns sprite on and off until counter is expired
            if (hitFlickerCount > 0)
            {
                hitFlickerCount--;
                bHitFlicker = !bHitFlicker;
            }
            else 
            {
                bHitFlicker = false;
            }

            // Rotate based on the turning direction
            facingAngle += time * turnDirection;

            // Determining forword velocity for angle being faced
            velocity.X = (float)Math.Cos(facingAngle / 180f * Math.PI) * walkDirection * moveSpeed;
            velocity.Y = -(float)Math.Sin(facingAngle / 180f * Math.PI) * walkDirection * moveSpeed;

            Move();
            if (velocity.X != 0 || velocity.Y != 0)
            {
                pic.Update(time);
            }

            if (bIsFiring == true)
            {
                currentWeapon.Fire(this);
            }

            foreach (Wall w in GameForm.wallList)
            {
                PointF _touchPoint = new PointF();

                if (this.isTouchingWall(w, ref _touchPoint))
                {
                    PushFrom(_touchPoint);
                }
            }

            this.UpdateWeapon(time);

            soldierInfo.Update(location);
        }

        public void UpdateWeapon(int time)
        {
            // Create two floats called x and y offset used to put guns in the soldiers hands
            // use sin and cos to fill x and y offset and a scalar of 32f
            float xOffset = (float)Math.Cos(facingAngle / 180f * Math.PI) * 32f;
            float yOffset = -(float)Math.Sin(facingAngle / 180f * Math.PI) * 32f;

            // Set the currentweapons x and y to the soldiers hands
            currentWeapon.location.X = this.location.X + xOffset;
            currentWeapon.location.Y = this.location.Y + yOffset;

            // Set the current weapon facing angle to this soldiers facing angle
            currentWeapon.facingAngle = this.facingAngle;

            // Update the current weapon
            currentWeapon.Update(time);
        }

        public void Move()
        {
            location.X += velocity.X;
            location.Y += velocity.Y;
        }


        /**
         * This function determines if a soldier is touching a wall.
         */
        public bool isTouchingWall(Wall wall, ref PointF touchPoint)
        {
            // We need the nearestPoint on the wall first
            // We'll need to call the function above
            PointF _nearestPoint = wall.PointNearestTo(this.location);

            // See if the nearestpoint is touching the wall using the pythagorean therom
            float _distance = (float)Math.Sqrt(
                (_nearestPoint.X - location.X) * (_nearestPoint.X - location.X) +
                (_nearestPoint.Y - location.Y) * (_nearestPoint.Y - location.Y));

            // If the distance is less than the radius
            if (_distance < this.radius)
            {
                // set the touch point to nearestpoint and return true that we found overlap
                touchPoint = _nearestPoint;
                return true;
            }
            else 
            {
                return false;
            }
        }

        /**
         * This method will push away a soldier frm the wall if touching it
         */
        public void PushFrom(PointF pointF)
        {
            // Calculate the actual distance between the pointFs
            // and this soldier's location, using pythogorean therom
            float _actualdistance = (float)Math.Sqrt(
                (pointF.X - location.X) * (pointF.X - location.X) +
                (pointF.Y - location.Y) * (pointF.Y - location.Y));

            // If the actual distance is equal to 0 (soldier is on pointF)
            if (_actualdistance == 0)
            {
                // leave the method
                return;
            }

            // disireddistance is set to the soldier's radius + 1
            float _disiredDistance = this.radius + 1;

            // proportion set as a scalar. This will be the amount to multiply against the move direction
            float _proportion = _disiredDistance / _actualdistance;

            // Initialize a new PointF vector called pushBack and set the x and y coordinate
            // to the distance between the soldier and pointF's x and y coordinates
            PointF _pushBack = new PointF(this.location.X - pointF.X, this.location.Y - pointF.Y);

            // adjust pushback's length by multiplying by the scalar proportion
            _pushBack.X *= _proportion;
            _pushBack.Y *= _proportion;

            // Move soldier away from pointF
            this.location.X = pointF.X + _pushBack.X;
            this.location.Y = pointF.Y + _pushBack.Y;
        }
    }

}
