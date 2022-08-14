using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sharpshooter_PraviinPremsankar
{
    public class Boss : EnemySoldier
    {
        public SolidBrush RedBrush = new SolidBrush(Color.Red);
        public SolidBrush GreenBrush = new SolidBrush(Color.Green);

        public Brush WhiteTextBrush = new SolidBrush(Color.White);
        public Brush RedTextBrush = new SolidBrush(Color.Red);
        public Brush BlueTextBrush = new SolidBrush(Color.Blue);

        public Font font = new Font("Courier New", 20);

        public string SoldierName;
        public Soldier soldierRef;

        public Boss(PointF loc)
            : base("Images/Boss2.png", loc, 300)
        {
            GameForm.enemyList.Add(this);

            moveSpeed = 10;
            walkDirection = 1;

            // Set currentWeapon to a new instance of enemyPistol and provide a location
            this.currentWeapon = new SuperBallLauncher(this.location);
        }
        public void Draw(Graphics g, Soldier soldierRef)
        {
            if (soldierRef.bIsKilled)
            {
                return;
            }

            int BarWidth = soldierRef.health;

            Rectangle RedBarRect = new Rectangle((int)soldierRef.location.X - GameForm.viewOffSet.X - 60, (int)soldierRef.location.Y - GameForm.viewOffSet.Y - 50, 120, 10);
            g.FillRectangle(RedBrush, RedBarRect);

            Rectangle GreenBarRect = new Rectangle((int)soldierRef.location.X - GameForm.viewOffSet.X - 60, (int)soldierRef.location.Y - GameForm.viewOffSet.Y - 50, BarWidth, 10);
            g.FillRectangle(GreenBrush, GreenBarRect);

            PointF NamePos = new PointF(soldierRef.location.X, soldierRef.location.Y);
            g.DrawString(this.SoldierName, font, WhiteTextBrush, NamePos);

            PointF NumPos = new PointF(soldierRef.location.X - 20, soldierRef.location.Y - 50);
            g.DrawString(SoldierName, font, RedTextBrush, NumPos);
        }
        public void Update(PointF location)
        {
            this.location.X = location.X;
            this.location.Y = location.Y;
        }

    }
}
