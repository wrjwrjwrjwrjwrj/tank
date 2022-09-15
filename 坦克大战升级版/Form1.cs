using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 坦克大战升级版.Properties;

namespace 坦克大战升级版
{
    public partial class Form1 : Form
    {
        private Random r = new Random();
        private static Point[] points = new Point[3];
        private static int enemyCount = 0;
        private static int enemyBornSpeed = 30;
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            InitialGame();
        }

        /// <summary>
        /// 初始化游戏
        /// </summary>
        public void InitialGame()
        {
            //画地图
            CreatelMap.InitialMap();
            //绘制玩家坦克
            SingleObject.GetSingle().AddGameObject(new PlayerTank(270,650,5,2,Direction.Up));
            //初始化敌人坐标
            EnemyBornPoint();


        }

        /// <summary>
        /// 敌人出生的位置
        /// </summary>
        private void EnemyBornPoint()
        {
            points[0].X = 0; points[0].Y = 0;
            points[1].X = 7 * 50; points[1].Y = 0;
            points[2].X = 14 *50; points[1].Y = 0;
        }

        /// <summary>
        /// 创建敌人坦克
        /// </summary>
        public void CreateEnemy()
        {
            enemyCount++;
            if (enemyCount < enemyBornSpeed)//60帧创建一个敌人
            {
                return;
            }

            int index = r.Next(0, 3);
            Point position = points[index];
            SingleObject.GetSingle().AddGameObject(new EnemyTank(position.X,position.Y,r.Next(0,3),Direction.Down));
            GameSoundPlay.AddPlay();
            enemyCount = 0;
        }

         

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
            //创造敌人
            CreateEnemy();
            //碰撞检测的方法
            SingleObject.GetSingle().IsCollided();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SingleObject.GetSingle().DrawObject(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GameSoundPlay.Initial();//必须要初始化音乐
            GameSoundPlay.PlayStart();
            //减少屏幕的闪烁
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer|
                          ControlStyles.ResizeRedraw|ControlStyles.AllPaintingInWmPaint, true);
                          
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            SingleObject.GetSingle().playerTank.KeyDown(e);
        }
    }
}
