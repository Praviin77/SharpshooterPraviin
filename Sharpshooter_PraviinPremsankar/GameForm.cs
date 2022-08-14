using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace Sharpshooter_PraviinPremsankar
{
    public partial class GameForm : Form
    {
        public static Player player1, player2;
        public static List<Soldier> enemyList;
        public static List<Bullet> bulletList;
        public static List<Wall> wallList;
        public static List<Explosion> explosionList;
        public static List<Weapon> weaponList;
        public static List<PowerUp> powerUpList;
        public static List<SoldierInfo> soldierInfoList;

        Graphics windowsGraphics;
        Graphics onScreenGraphics;
        Bitmap screen;

        public static bool mainMenu = false;
        public static bool isPlayer2InGame = false;
        public static bool isBossInGame = false;

        public static Point viewOffSet;

        public Picture gameOverScreen;
        public Picture victoryScreen;

        public Soldier soldierRef;

        public GameForm()
        {
            InitializeComponent();

            windowsGraphics = this.CreateGraphics();
            screen = new Bitmap(this.Width, this.Height);
            onScreenGraphics = Graphics.FromImage(screen);

            // Set our DrawGame() method to be calledwhen the window repaints
            this.Paint += new PaintEventHandler(DrawGame);

            //Init();
        }

        public void Init()
        {
            SetSounds();

            Level.levelNum = 1;
            Level.CreateLevel();

            gameOverScreen = new Picture("Images/GameOver.png", new PointF(this.Width / 2, this.Height / 3), 1, 1);
            victoryScreen = new Picture("Images/Victory.png", new PointF(this.Width / 2, this.Height / 3), 1, 1);

            // Set input on player
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(player1.Player1KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(player1.Player1KeyUp);
            // player 2
            if (isPlayer2InGame == true)
            {
                this.KeyDown += new System.Windows.Forms.KeyEventHandler(player2.Player2KeyDown);
                this.KeyUp += new System.Windows.Forms.KeyEventHandler(player2.Player2KeyUp);
            }

            
        }

        public void DrawGame(Object sender, PaintEventArgs e)
        {
            if (GameTimer.Enabled == false)
            {
                return;
            }

            onScreenGraphics.Clear(Color.Black);

            player1.Draw(onScreenGraphics);

            if (isPlayer2InGame == true)
            {
                player2.Draw(onScreenGraphics);
            }

            // foreach uses a reference
            //foreach (Soldier es in enemyList)
            //{
            //    es.Draw(onScreenGraphics);
            //}

            foreach (EnemySoldier es in enemyList)
            {
                es.Draw(onScreenGraphics);
            }

            foreach (Bullet b in bulletList)
            {
                b.Draw(onScreenGraphics);
            }

            foreach (Wall w in wallList)
            {
                w.Draw(onScreenGraphics);
            }

            foreach (Explosion exp in explosionList)
            {
                exp.Draw(onScreenGraphics);
            }

            foreach (Weapon wp in weaponList)
            {
                wp.Draw(onScreenGraphics);
            }

            foreach (PowerUp p in powerUpList)
            {
                p.Draw(onScreenGraphics);
            }

            foreach (SoldierInfo si in soldierInfoList)
            {
                si.Draw(onScreenGraphics, si.soldierRef);
            }


            if (isPlayer2InGame == true)
            {
                if (player1.bIsKilled == true && player2.bIsKilled == true)
                {
                    gameOverScreen.Draw(onScreenGraphics);
                }
            }
            else
            {
                if (player1.bIsKilled == true)
                {
                    gameOverScreen.Draw(onScreenGraphics);
                }
            }

            if (enemyList.Count == 0 && Level.levelNum > 2)
            {
                victoryScreen.Draw(onScreenGraphics);               
            }

            // Finally, draw the buffer
            windowsGraphics.DrawImage(screen, new Point(0, 0));
        }



        private void GameTimer_Tick(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Level: " + Level.levelNum);
            System.Diagnostics.Debug.WriteLine("Enemies: " + enemyList.Count);

            player1.Update(GameTimer.Interval);
            if (isPlayer2InGame == true)
            {
                player2.Update(GameTimer.Interval);
            }

            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].Update(GameTimer.Interval);
            }

            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].Update(GameTimer.Interval);
            }

            for (int i = 0; i < explosionList.Count; i++)
            {
                explosionList[i].Update(GameTimer.Interval);
            }

            for (int i = 0; i < weaponList.Count; i++)
            {
                weaponList[i].Update(GameTimer.Interval);
            }
            for (int i = 0; i < powerUpList.Count; i++)
            {
                powerUpList[i].Update(GameTimer.Interval);
            }

            // Set offSetView to be equal to the top left corner of the camera
            // Our player is in the center of the camera
            if (isPlayer2InGame == true)
            {
                if (player1.bIsKilled == true)
                {
                    viewOffSet.X = (int)player2.location.X - this.Width / 2;
                    viewOffSet.Y = (int)player2.location.Y - this.Height / 2;
                }
                else
                {
                    viewOffSet.X = (int)player1.location.X - this.Width / 2;
                    viewOffSet.Y = (int)player1.location.Y - this.Height / 2;
                }          
            }
            else
            {
                viewOffSet.X = (int)player1.location.X - this.Width / 2;
                viewOffSet.Y = (int)player1.location.Y - this.Height / 2;
            }

            if (enemyList.Count == 0)
            {
                if (isBossInGame == false)
                {
                    Boss boss = new Boss(new PointF(700, 700));
                    //GameForm.enemyList.Add(boss);
                    isBossInGame = true;
                }
                else
                {
                    Level.bIsLevelWon = true;

                    if (Level.levelNum <= 3)
                    {
                        Level.bIsLevelWon = false;                        
                        Level.levelNum++;
                        Level.CreateLevel();

                        // Set input on player
                        this.KeyDown += new System.Windows.Forms.KeyEventHandler(player1.Player1KeyDown);
                        this.KeyUp += new System.Windows.Forms.KeyEventHandler(player1.Player1KeyUp);
                        // player 2
                        if (isPlayer2InGame == true)
                        {
                            this.KeyDown += new System.Windows.Forms.KeyEventHandler(player2.Player2KeyDown);
                            this.KeyUp += new System.Windows.Forms.KeyEventHandler(player2.Player2KeyUp);
                        }
                    }
                }      
            }


            // This is a trigger event, which needs PaintEventArgs 
            // to describe what should happe during its execution
            // WindowsGraphics is the object we draw with
            // and we draw a rectanglethesame size of the screen (THIS GameForm)
            OnPaint(new PaintEventArgs(windowsGraphics, new Rectangle(0, 0, this.Width, this.Height)));
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void PlayLabel_Click(object sender, EventArgs e)
        {
            mainMenu = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameTimer.Enabled = !GameTimer.Enabled;
            Pause.Visible = !Pause.Visible;
        }

        private void onePlayer_Click(object sender, EventArgs e)
        {
            isPlayer2InGame = false;
            GameTimer.Enabled = true;
            onePlayer.Hide();
            twoPlayer.Hide();
            TitlePic.Hide();
            Init();
        }

        private void twoPlayer_Click(object sender, EventArgs e)
        {
            isPlayer2InGame = true;
            GameTimer.Enabled = true;
            onePlayer.Hide();
            twoPlayer.Hide();
            TitlePic.Hide();
            Init();

        }

        //private void DrawPlayer2Text(Graphics g, Player player)
        //{
        //    int BarWidth = player.health;

        //    Rectangle RedBarRect = new Rectangle(20, 70, 120, 10);
        //    g.FillRectangle(RedBrush, RedBarRect);

        //    Rectangle GreenBarRect = new Rectangle(20, 70, BarWidth, 10);
        //    g.FillRectangle(GreenBrush, GreenBarRect);

        //    PointF NamePos = new PointF(20, 60);
        //    g.DrawString(player.playerName, font, WhiteTextBrush, NamePos);

        //    PointF NumPos = new PointF(player.location.X - 20, player.location.Y - 50);
        //    g.DrawString(P1Num, font, RedTextBrush, NumPos);
        //}

        //private void DrawEnemyText(Graphics g, EnemySoldier enemySoldier)
        //{
        //    int BarWidth = enemySoldier.health;

        //    Rectangle RedBarRect = new Rectangle(20, 40, 120, 10);
        //    g.FillRectangle(RedBrush, RedBarRect);

        //    Rectangle GreenBarRect = new Rectangle(20, 40, BarWidth, 10);
        //    g.FillRectangle(GreenBrush, GreenBarRect);

        //    PointF NamePos = new PointF(20, 30);
        //    g.DrawString(enemySoldier.enemyName, font, WhiteTextBrush, NamePos);

        //    PointF NumPos = new PointF(enemySoldier.location.X - 20, enemySoldier.location.Y - 50);
        //    g.DrawString(P1Num, font, RedTextBrush, NumPos);
        //}

        private void SetSounds()
        {
            
        }
    }
}
