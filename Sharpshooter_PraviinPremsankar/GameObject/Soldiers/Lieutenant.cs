using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sharpshooter_PraviinPremsankar
{
    public class Lieutenant : EnemySoldier
    {
        public Lieutenant(PointF loc)
            : base("Images/Enemy2.png", loc, 70)
        {
            GameForm.enemyList.Add(this);

            enemyName = "Lieutenant";

            moveSpeed = 3;
            walkDirection = 1;

            // Set currentWeapon to a new instance of enemyPistol and provide a location
            this.currentWeapon = new RapidGun(this.location);
        }
    }
}
