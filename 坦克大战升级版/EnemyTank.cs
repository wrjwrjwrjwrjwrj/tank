using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 坦克大战升级版.Properties;

namespace 坦克大战升级版
{
    public class EnemyTank:TankFather
    {
        private static Bitmap[] enemy1 =
        {
            Resources.GrayUp,
            Resources.GrayDown,
            Resources.GrayLeft,
            Resources.GrayRight
        };

        private static Bitmap[] enemy2 =
        {
            Resources.GreenUp,
            Resources.GreenDown,
            Resources.GreenLeft,
            Resources.GreenRight
        };

        private static Bitmap[] enemy3 =
        {
            Resources.YellowUp,
            Resources.YellowDown,
            Resources.YellowLeft,
            Resources.YellowRight
        };

        public int EnemyType { get; set; }

        private int bornTime  = 0;
        private Random r = new Random();
        private int changeSpeed = 0;
        private int changeTime = 60;
        private bool IsMove { get; set; }
        private bool isStop = false;
        private int stopTime = 0;
        private static int _speed = 0;//设置坦克的速度
        private static int _life = 0;//设置坦克的生命
        public EnemyTank(int x, int y,int type, Direction dir) : base(x, y, enemy1,SetSpeed(type),SetLife(type),dir)
        {
            this.EnemyType = type;
        }

        /// <summary>
        /// 敌人开火
        /// </summary>
        public override void Fire()
        {
            if (r.Next(0, 100) < 3)
            {
                SingleObject.GetSingle().AddGameObject(new EnemyBullet(this, 8, 1));
            }
        }

        /// <summary>
        /// 判断是否死亡
        /// </summary>
        public override void IsOver()
        {
            if (this.Life <= 0)
            {
                //出现爆炸的图片
                SingleObject.GetSingle().AddGameObject(new Explosion(this.X,this.Y));
                //被击毁了就删掉
                SingleObject.GetSingle().RemoveObject(this);
                //播放音乐
                GameSoundPlay.BlastPlay();
            }
            else
            {
                GameSoundPlay.HitPlay();
            }
        }

        /// <summary>
        /// 坦克出生的方法
        /// </summary>
        public override void Born()
        {
           SingleObject.GetSingle().AddGameObject(new TankBorn(this.X,this.Y));
        }

        /// <summary>
        /// 设置敌人坦克速度
        /// </summary>
        /// <param name="type"></param>
        public static int SetSpeed(int type)
        {
            switch (type)
            {
                case 0:
                    _speed = 5;
                    break;
                case 1:
                    _speed = 6;
                    break;
                case 2:
                    _speed = 7;
                    break;
            }

            return _speed;
        }

        /// <summary>
        /// 设置敌人坦克生命
        /// </summary>
        /// <param name="type"></param>
        public static int SetLife(int type)
        {
            switch (type)
            {
                case 0:
                    _life = 1;
                    break;
                case 1:
                    _life = 2;
                    break;
                case 2:
                    _life = 3;
                    break;
            }

            return _life;
        }

        /// <summary>
        /// 绘制的方法
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            bornTime++;
            
            if (bornTime % 20 == 0)
            {
                this.IsMove = true;
            }

            if (this.IsMove)
            {
                if (!isStop)
                {
                    Move();
                }
                else
                {
                    stopTime++;
                    if (stopTime % 20 == 0)
                    {
                        isStop = true;
                    }
                }
                
            }
            switch (EnemyType)
            {
                case 0:
                    switch (this.Dir)//方向要和所提供的图片方向一致
                    {
                        case Direction.Up:
                            g.DrawImage(enemy1[0], this.X, this.Y);
                            break;
                        case Direction.Down:
                            g.DrawImage(enemy1[1], this.X, this.Y);
                            break;
                        case Direction.Left:
                            g.DrawImage(enemy1[2], this.X, this.Y);
                            break;
                        case Direction.Right:
                            g.DrawImage(enemy1[3], this.X, this.Y);
                            break;
                    }
                    break;
                case 1:
                    switch (this.Dir)//方向要和所提供的图片方向一致
                    {
                        case Direction.Up:
                            g.DrawImage(enemy2[0], this.X, this.Y);
                            break;
                        case Direction.Down:
                            g.DrawImage(enemy2[1], this.X, this.Y);
                            break;
                        case Direction.Left:
                            g.DrawImage(enemy2[2], this.X, this.Y);
                            break;
                        case Direction.Right:
                            g.DrawImage(enemy2[3], this.X, this.Y);
                            break;
                    }
                    break;
                case 2:
                    switch (this.Dir)//方向要和所提供的图片方向一致
                    {
                        case Direction.Up:
                            g.DrawImage(enemy3[0], this.X, this.Y);
                            break;
                        case Direction.Down:
                            g.DrawImage(enemy3[1], this.X, this.Y);
                            break;
                        case Direction.Left:
                            g.DrawImage(enemy3[2], this.X, this.Y);
                            break;
                        case Direction.Right:
                            g.DrawImage(enemy3[3], this.X, this.Y);
                            break;
                    }
                    break;
            }
        }

        /// <summary>
        /// 移动的方法
        /// </summary>
        public override void Move()
        {
            base.Move();
            //给一个很小的概率来产生随机数
            if (r.Next(0, 100) < 5)//概率为1/20产生下面的随机数
            {
                //如果随机数产生过快，方向的改变也会很快
                switch (r.Next(0, 4))
                {
                    case 0:
                        this.Dir = Direction.Up;
                        break;
                    case 1:
                        this.Dir = Direction.Down;
                        break;
                    case 2:
                        this.Dir = Direction.Left;
                        break;
                    case 3:
                        this.Dir = Direction.Right;
                        break;
                }
            }
            Fire();
        }
    }
}
