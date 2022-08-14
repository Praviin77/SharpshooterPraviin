using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Sharpshooter_PraviinPremsankar
{
    public class Level
    {
        // Grid that contains of array of slots to be used fr your map
        public static int[,] mapItem = new int[30, 30];
        public static int blockSize = 50;
        public static Picture picture;
        public static int levelNum;
        public static bool bIsLevelWon = false;

        public static void InitalizeLists()
        {
            //All lists should be initalized here
            GameForm.enemyList = new List<Soldier>();
            GameForm.bulletList = new List<Bullet>();
            GameForm.wallList = new List<Wall>();
            GameForm.explosionList = new List<Explosion>();
            GameForm.weaponList = new List<Weapon>();
            GameForm.powerUpList = new List<PowerUp>();
            GameForm.soldierInfoList = new List<SoldierInfo>();
        }

        //public static void CreateBorder(int topLeftCrn, int bottmRightCrn, int width, int height)
        //{
            // The four walls of our arena
            //Wall topBorder = new Wall("Green", topLeftCrn - 80, bottmRightCrn - 80, width + 80, 80);
            //Wall leftBorder = new Wall("Green", topLeftCrn - 80, bottmRightCrn, 80, height + 80);
            //Wall bottomBorder = new Wall("Green", topLeftCrn, bottmRightCrn + height, width + 80, 80);
            //Wall rightBorder = new Wall("Green", topLeftCrn + width, bottmRightCrn - 80, 80, width + 80);
        //}

        //public static void CreateInnerWalls()
        //{
        //    Wall wall1 = new Wall("Blue", 150, 250, 300, 30);
        //    Wall wall2 = new Wall("Orange", 550, 150, 30, 350);
        //}

        //public static void CreateEnemies()
        //{
        //    // Place some soldiers
        //    EnemySoldier enemy1 = new EnemySoldier(new PointF(650F, 100F));
        //    EnemySoldier enemy2 = new EnemySoldier(new PointF(200F, 400F));
        //    EnemySoldier enemy3 = new EnemySoldier(new PointF(-100F, -200F));
        //    EnemySoldier enemy4 = new EnemySoldier(new PointF(-50F, -400F));
        //}

        //public static void CreateWeapons()
        //{
            
        //}

        public static void CreateLevel()
        {
            // Create player in game
            //GameForm.player1 = new Player(new PointF(500F, 400F));

            InitalizeLists();
            //CreateBorder(-800, -800, 1600, 1600); // start from center
            //CreateInnerWalls();
            //CreateEnemies();
            //CreateWeapons();


            if (levelNum == 1 || levelNum == 2)
            {
                string[] _lines = File.ReadAllLines(System.Windows.Forms.Application.StartupPath + "/levels/level" + levelNum + ".txt");

                for (int h = 0; h < mapItem.GetLength(0); h++)
                {
                    for (int v = 0; v < mapItem.GetLength(1); v++)
                    {
                        // use IDs from the text file and convert into readible lines
                        mapItem[h, v] = _lines[v][h];
                        AssignMapItems(h, v);
                    }
                }
            }

           
        }

        public static void AssignMapItems(int x, int y)
        {
            if(mapItem[x, y] == '0')
            {
                return;
            }

            if (mapItem[x, y] == 'G')
            {
                Wall borderWall = new Wall("Green", x * blockSize, y * blockSize, blockSize, blockSize);
                GameForm.wallList.Add(borderWall);
            }

            if (mapItem[x, y] == 'B')
            {
                Wall blueWall = new Wall("Blue", x * blockSize, y * blockSize, blockSize, blockSize);
                GameForm.wallList.Add(blueWall);
            }

            if (mapItem[x, y] == 'O')
            {
                Wall orangeWall = new Wall("Orange", x * blockSize, y * blockSize, blockSize, blockSize);
                GameForm.wallList.Add(orangeWall);
            }

            if (mapItem[x, y] == '1')
            {
                GameForm.player1 = new Player(new PointF(
                    x * blockSize + 25, 
                    y * blockSize + 25));
            }

            if (mapItem[x, y] == '2')
            {
                if (GameForm.isPlayer2InGame == true)
                {
                    GameForm.player2 = new Player(new PointF(
                        x * blockSize + 25,
                        y * blockSize + 25));
                }
                else
                {
                    return;
                }
            }

            if (mapItem[x, y] == 'q')
            {
                Sergeant sergeant = new Sergeant(new PointF(
                    x * blockSize + 25,
                    y * blockSize + 25));
                //GameForm.enemyList.Add(sergeant);
            }

            if (mapItem[x, y] == 'w')
            {
                Lieutenant lieutenant = new Lieutenant(new PointF(
                    x * blockSize + 25,
                    y * blockSize + 25));
                //GameForm.enemyList.Add(lieutenant);
               
                
            }

            if (mapItem[x, y] == 'C')
            {
                Commander commander = new Commander(new PointF(
                    x * blockSize + 25,
                    y * blockSize + 25));
                //GameForm.enemyList.Add(commander);
            }

            if (mapItem[x, y] == 'R')
            {
                RapidGun rg = new RapidGun(new PointF(
                    x * blockSize + 25,
                    y * blockSize + 25));
                rg.bIsOnGround = true;
                GameForm.weaponList.Add(rg);
            }

            if (mapItem[x, y] == 'S')
            {
                SniperRifle sr1 = new SniperRifle(new PointF(
                    x * blockSize + 25,
                    y * blockSize + 25));
                sr1.bIsOnGround = true;
                GameForm.weaponList.Add(sr1);
            }

            if (mapItem[x, y] == 'L')
            {
                SuperBallLauncher sbl1 = new SuperBallLauncher(new PointF(
                    x * blockSize + 25,
                    y * blockSize + 25));
                sbl1.bIsOnGround = true;
                GameForm.weaponList.Add(sbl1);
            }

            if (mapItem[x, y] == 'T')
            {
                Clock c1 = new Clock(new PointF(
                    x * blockSize + 25,
                    y * blockSize + 25));
                c1.bIsOnGround = true;
                GameForm.powerUpList.Add(c1);
            }
        }
    }
}
