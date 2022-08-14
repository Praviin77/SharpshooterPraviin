using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sharpshooter_PraviinPremsankar
{
    public class SuperBallLauncher : Weapon
    {
        public SuperBallLauncher(PointF location)
        : base("Images/SuperBallLauncher.png", location)
        {
            this.bulletSpeed = 10.0f;
            this.bulletStartDistance = 40.0f;
            this.fireDelay = 2000;
        }
        public override Bullet CreateBullet(Soldier personFiring)
        {
            Bullet ball = new Bullet("Images/SuperBall.png", personFiring, new PointF());
            ball.life = 2f;
            ball.damage = 25;
            return ball;
        }
    }
}
