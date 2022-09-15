using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 坦克大战升级版
{/// <summary>
/// 坦克的父类
/// 1.绘制的方法
/// 2.开火的方法
/// 3.是否死亡的方法
/// 4.出生的方法
/// </summary>
    public abstract class TankFather:GameObject
    {
        private Bitmap[] bitmaps = {};
        public TankFather(int x, int y,Bitmap[] bits, int speed, int life, Direction dir) : base(x, y, bits[0].Width, bits[0].Height, speed, life, dir)
        {
            this.bitmaps = bits;
            //在一开始的时候就出现闪烁
            Born();
        }

        private int bornTime = 0;
        private bool isMove = false;

        public override void Draw(Graphics g)
        {
            bornTime++;
            if (bornTime % 20 == 0)
            {
                isMove = true;
            }

            if (isMove)
            {
                switch (this.Dir)
                {
                    case Direction.Up:
                        g.DrawImage(bitmaps[0], this.X, this.Y);
                        break;
                    case Direction.Down:
                        g.DrawImage(bitmaps[1], this.X, this.Y);
                        break;
                    case Direction.Left:
                        g.DrawImage(bitmaps[2], this.X, this.Y);
                        break;
                    case Direction.Right:
                        g.DrawImage(bitmaps[3], this.X, this.Y);
                        break;
                }
            }
        }

        public abstract void Fire();
        public abstract void IsOver();
        public abstract void Born();
    }
}
