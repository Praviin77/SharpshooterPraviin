using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sharpshooter_PraviinPremsankar
{
    public class EnemyPistol : Weapon
    {
        public EnemyPistol (PointF location)
        : base("Images/Pistol.png", location)
        {
            this.bulletSpeed = 15.0f;
            this.bulletStartDistance = 10.0f;
            this.fireDelay = 600;
        }

        public override Bullet CreateBullet(Soldier personFiring)
        {
            Bullet pistol = new Bullet("Images/Bullet2.png", personFiring, new PointF());
            pistol.life = 1f;
            pistol.damage = 10;
            return pistol;
        }
    }
}
