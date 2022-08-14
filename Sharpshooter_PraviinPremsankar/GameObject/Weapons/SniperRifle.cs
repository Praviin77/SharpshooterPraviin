using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sharpshooter_PraviinPremsankar
{
    public class SniperRifle : Weapon
    {
        public SniperRifle(PointF location)
        : base("Images/SniperRifle.png", location)
        {
            this.bulletSpeed = 20.0f;
            this.bulletStartDistance = 30.0f;
            this.fireDelay = 400;
        }
        public override Bullet CreateBullet(Soldier personFiring)
        {
            Bullet sniperBullet = new Bullet("Images/SniperBullet.png", personFiring, new PointF());
            sniperBullet.life = 10f;
            sniperBullet.damage = 15;
            return sniperBullet;
        }
    }
}
