using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sharpshooter_PraviinPremsankar
{
    public class Commander : EnemySoldier
    {
        public Commander(PointF loc)
            : base("Images/Enemy3.png", loc, 70)
        {
            GameForm.enemyList.Add(this);

            moveSpeed = 5;
            walkDirection = 1;

            // Set currentWeapon to a new instance of enemyPistol and provide a location
            this.currentWeapon = new SuperBallLauncher(this.location);
        }
    }
}
