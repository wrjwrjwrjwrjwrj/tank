using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 坦克大战升级版
{
    //方向
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public enum State
    {
        Running,
        Gameover
    }
    /// <summary>
    /// 游戏对象的父类
    /// 有着游戏对象共有的属性和方法
    /// 因为要碰撞检测，所以每个对象都要有x、y坐标和宽高
    /// 1.编写一个单例类，用于绘制所有的游戏对象，并且解决多线程并发的问题
    /// 2.画图
    /// 3.绘制玩家坦克
    /// 4.绘制敌人坦克
    /// 5.通过键盘让玩家坦克移动
    /// 6.让AI控制敌人坦克移动
    /// 7.写玩家坦克和敌人坦克的碰撞检测效果
    /// 8.让玩家发射子弹
    /// 9.让敌人发射子弹
    /// 10.子弹和墙的碰撞检测
    /// 11.玩家子弹和敌人的碰撞检测
    /// 12.玩家子弹和敌人子弹的碰撞检测
    /// 13.发生爆炸的效果
    /// 14.判断敌人子弹和玩家的碰撞检测
    /// 在判断时注意break的使用，否则索引会越界
    /// 15.添加坦克出生时的效果
    /// 16.添加音乐
    /// 17.让玩家死亡时回到初始位置
    /// 18.添加子弹和boss的碰撞检测
    /// 19.添加游戏结束的图片
    /// </summary>
    public abstract class GameObject
    {
        #region 游戏对象的共有属性
        //X坐标
        public int X
        {
            get;
            set;
        }

        //Y坐标
        public int Y
        {
            get;
            set;
        }

        //宽度
        public int Width
        {
            get;
            set;
        }

        //高度
        public int Height
        {
            get;
            set;
        }

        //速度
        public int Speed
        {
            get;
            set;
        }

        //生命值
        public int Life
        {
            get;
            set;
        }

        public Direction Dir
        {
            get;
            set;
        }
        #endregion

        /// <summary>
        /// 初始化游戏对象
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="speed"></param>
        /// <param name="life"></param>
        /// <param name="dir"></param>
        public GameObject(int x, int y, int width, int height, int speed, int life, Direction dir)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Speed = speed;
            this.Life = life;
            this.Dir = dir;
        }

        /// <summary>
        /// 给地图用的
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public GameObject(int x, int y, int width, int height) : this(x, y, width, height, 0, 0, Direction.Up)
        {

        }

        //用来绘图
        public abstract void Draw(Graphics g);

        /// <summary>
        /// 用来移动的方法
        /// </summary>
        public virtual void Move()
        {
            switch (this.Dir)
            {
                case Direction.Up:
                    this.Y -= this.Speed;
                    break;
                case Direction.Down:
                    this.Y += this.Speed;
                    break;
                case Direction.Left:
                    this.X -= this.Speed;
                    break;
                case Direction.Right:
                    this.X += this.Speed;
                    break;
            }
            //移动完成后，需要判断游戏对象是否出界
            if (this.X <= 0)
            {
                this.X = 0;
            }
            if (this.X >= 710)
            {
                this.X = 710;
            }
            if (this.Y <= 0)
            {
                this.Y = 0;
            }
            if (this.Y >= 650)
            {
                this.Y = 650;
            }
        }

        /// <summary>
        /// 用于碰撞检测
        /// </summary>
        /// <returns></returns>
        public Rectangle GetRectangle()
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }
    }
}
