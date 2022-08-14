using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpshooter_PraviinPremsankar
{
    public class Wall
    {
        public int left;
        public int top;
        public int width;
        public int height;

        Bitmap image;

        public Wall(String color, int l, int t, int w, int h)
        {
            image = new Bitmap("Images/" + color + "box.png");

            this.left = l;
            this.top = t;
            this.width = w;
            this.height = h;

            GameForm.wallList.Add(this);
        }

        public void Draw(Graphics g)
        {
            g.Transform = new Matrix();
            g.DrawImage(image, new Rectangle(
                left - GameForm.viewOffSet.X, 
                top - GameForm.viewOffSet.Y, 
                width, 
                height));
        }


        /**
         * This function returns a point on a wall closer to our player
         */
        public PointF PointNearestTo(PointF pointF)
        {
            //Initalize a new PointF called nearestPoint
            PointF _nearestPoint = new PointF();

            // check if the left edge of this wall is to the right of th pointF
            // If it is, then the nearestpoint's x coordinate must be the left edge of this wall
            if (this.left > pointF.X)
            {
                _nearestPoint.X = this.left;
            }
            // Else if the right edge of the wall is to the left of the pointF
            // then the nearestpoint's x coordinate must be to the right edge of the wall
            else if (this.left + this.width < pointF.X)
            {
                _nearestPoint.X = this.left + this.width;
            }
            // Else if it's not to the left or to the right
            // Then it must be inside the wall, so we'll set the nearestpoint's X equal to pointF's coordinate
            else
            {
                _nearestPoint.X = pointF.X;
            }

            if (this.top > pointF.Y)
            {
                _nearestPoint.Y = this.top;
            }
            else if (this.top + this.height < pointF.Y)
            {
                _nearestPoint.Y = this.top + this.height;
            }
            else
            {
                _nearestPoint.Y = pointF.Y;
            }
            return _nearestPoint;
        }

        /**
         * For reflection, we need to find the normal at the nearest point on the box
         * This is the line from the narest point to the given point, only with the 
         * length adjusted to 1 (normalized to avoid the bullet's speed change) 
         */

        public PointF FindNormalAtNearestPoint(PointF p)
        {
            // Create a pointF called nearest point and set it
            // equal to the point of this wall nearest to p
            PointF _nearestPoint = this.PointNearestTo(p);

            // Create another pointF vector called normal and set its direction
            // pointing from nearestpoint to p
            PointF _normal = new PointF();
            _normal.X = p.X - _nearestPoint.X;
            _normal.Y = p.Y - _nearestPoint.Y;

            // Now that we have the normal vector, make sure its length is set to 1 (normalize)
            // If the length of the normal is zero, we can't resize it, so just return the normal and leave
            if (_normal.X == 0 && _normal.Y == 0)
            {
                return _normal;
            }

            // Create a float called factor and set it to the inverse of normal's length (pythogorean theorm)
            float _factor = 1f / (float)Math.Sqrt((_normal.X * _normal.X) + (_normal.Y * _normal.Y));

            // Multiplying the normal by the factor gives normal length of 1
            _normal.X *= _factor;
            _normal.Y *= _factor;

            return _normal;

        }
    }
}
