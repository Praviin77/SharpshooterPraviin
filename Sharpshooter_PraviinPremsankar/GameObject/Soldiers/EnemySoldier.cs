using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sharpshooter_PraviinPremsankar
{
    public class EnemySoldier : Soldier
    {
        int directionChangeCount = 0;
        int nextDirectionChange = 0;
        
        public string enemyName;

        public EnemySoldier(string image, PointF loc, int hp)
            : base(image, loc, hp)
        {
            //GameForm.enemyList.Add(this);
            bIsFiring = true;

            // Use a random range between 500 and 2000 before turning
            Random _random = new Random((int)loc.X);
            nextDirectionChange = _random.Next(500) + 2000;
        }

        public override void Update(int time)
        {
            if (this.health <= 0)
            {
                GameForm.enemyList.Remove(this);
            }

            // Inherit update method definition from soldier superclass
            base.Update(time);

            directionChangeCount += time;

            if (directionChangeCount >= nextDirectionChange)
            {
                Random _random = new Random();
                facingAngle = _random.Next(360);

                directionChangeCount = 0;
                nextDirectionChange = _random.Next(500) + 2000;
            }
        }
    }
}
