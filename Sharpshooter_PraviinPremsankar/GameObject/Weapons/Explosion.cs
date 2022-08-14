using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpshooter_PraviinPremsankar
{
    public class Explosion
    {
        public PointF location;
        public Picture picture;
        public int life = 240;

        public Explosion(PointF loc)
        {
            picture = new Picture("Images/Explode.png", loc, 6, 40);
            this.location = loc;

            GameForm.explosionList.Add(this);
        }

        public virtual void Draw(Graphics graphics)
        {
            picture.location.X = this.location.X - GameForm.viewOffSet.X;
            picture.location.Y = this.location.Y - GameForm.viewOffSet.Y;

            picture.Draw(graphics);
        }

        public void Update(int time)
        {
            life -= time;

            if (life <= 0)
            {
                GameForm.explosionList.Remove(this);
                return;
            }
            picture.Update(time);
        }
    }
}
