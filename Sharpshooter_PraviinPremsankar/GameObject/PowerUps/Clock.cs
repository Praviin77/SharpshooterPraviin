using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sharpshooter_PraviinPremsankar
{
    public class Clock : PowerUp
    {
        public float counter = 10000;

        public Clock(PointF location)
        : base("Images/Clock2.png", location)
        {
            GameForm.powerUpList.Add(this);
        }

        public void ApplyEffect(int time)
        {
            counter -= (float)time;

            if (counter <= 0)
            {
                counter = 10000;
                bIsAcquired = false;

                for (int i = 0; i < GameForm.enemyList.Count; i++)
                {
                    GameForm.enemyList[i].moveSpeed *= 2;
                }
            }
        }

        public void SlowDown()
        {
            for (int i = 0; i < GameForm.enemyList.Count; i++)
            {
                GameForm.enemyList[i].moveSpeed /= 2;
                //System.Diagnostics.Debug.WriteLine(GameForm.enemyList[i].moveSpeed);
            }
        }

        public override void Update(int time)
        {
            if (this.bIsOnGround == true)
            {
                if (this.IsTouching(GameForm.player1) || (GameForm.isPlayer2InGame == true && this.IsTouching(GameForm.player2)))
                {
                    bIsAcquired = true;
                    this.bIsOnGround = false;
                    GameForm.powerUpList.Remove(this);
                    
                }

                
            }

            if (this.bIsAcquired == true)
            {
                ApplyEffect(time);
                SlowDown();
                bIsAcquired = false;
            }
        }
    }
}
