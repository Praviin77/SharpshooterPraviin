using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sharpshooter_PraviinPremsankar
{
	public class Picture
	{
		public Bitmap bitmap;   // Images
		public PointF location; // Center point of picture
		public float angle = 0F;
		public PointF anchorPointoffset;
		public int currentFrame = 0;
		public int frameCount;
		public int timePerFrame; // number of ticks per frame
		public int animationCounter = 0; // Keep track of how much time has elasped since last frame

		public Picture(string fileName, PointF loc, int frames, int flipTime)
		{
			this.frameCount = frames;
			this.timePerFrame = flipTime;

			// Create bitmap object
			bitmap = new Bitmap(fileName);

			this.location = loc;

			//set the anchor point of the srite to the centr
			anchorPointoffset = new PointF(bitmap.Width / 2F, bitmap.Height / frameCount / 2F);
		}

		public void Draw(Graphics g)
		{
			// So that our pictures are centered, treat location as the middle
			// and find the top left corner
			Point _drawLocation = new Point((int)(location.X - anchorPointoffset.X), (int)(location.Y - anchorPointoffset.Y));

			// mathematical matrix(spreadsheet) for transfrm values (x, y for move/rotate/scale)
			Matrix matrix = new Matrix();

			// Rotate by the given angle and around the center location of the picture
			matrix.RotateAt(-angle, location);

			// Set the drawing transform to this rotation matrix
			g.Transform = matrix;
			
			g.DrawImage(
				bitmap,									// Image
				new Rectangle(
					_drawLocation.X, 
					_drawLocation.Y, 
					bitmap.Width, 
					bitmap.Height / this.frameCount),	// destination rectangle
				new Rectangle(
					0,
					this.currentFrame * bitmap.Height / this.frameCount, 
					bitmap.Width,
					bitmap.Height / this.frameCount),						// Source rectangle
				GraphicsUnit.Pixel						// pixel units
				);
		}

		public void Update(int time)
        {
			// Add amount of time that has passed to animation counter
			animationCounter += time;

			// if enought time has passed (time per frame)
			if (animationCounter >= this.timePerFrame)
            {
				// Then advance to the next frame 
                currentFrame++;

                if (currentFrame >= frameCount)
                {
                    currentFrame = 0;
                }

				//restart the animation
				animationCounter = 0;
            }
        }
	}
}
