using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;

namespace Sharpshooter_PraviinPremsankar
{
    public class RapidGun : Weapon
    {
        public RapidGun(PointF location)
        : base("Images/RapidGun.png", location)
        {
            this.bulletSpeed = 25.0f;
            this.bulletStartDistance = 10.0f;
            this.fireDelay = 100;
        }
        public override Bullet CreateBullet(Soldier personFiring)
        {
            Bullet rapidBullet = new Bullet("Images/Bullet3.png", personFiring, new PointF());

            rapidBullet.life = 1f;
            rapidBullet.damage = 5;
            return rapidBullet;
        }

        public async void PlayGunShot()
        {
            await Task.Delay(900);
        }
    }
}
