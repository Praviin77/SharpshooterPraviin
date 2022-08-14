using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Sharpshooter_PraviinPremsankar
{

    public class Sergeant : EnemySoldier
    {
        public Sergeant(PointF loc) 
            : base("Images/Enemy1.png", loc, 30)
        {
            GameForm.enemyList.Add(this);

            moveSpeed = 2;
            walkDirection = 1;

            // Set currentWeapon to a new instance of enemyPistol and provide a location
            this.currentWeapon = new EnemyPistol(this.location);
        }
    }
}
