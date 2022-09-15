using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace 坦克大战升级版
{
    public class BulletFather:GameObject
    {
        private Bitmap Bullet { get; set; }

        public int Power { get; set; }//子弹的威力
        public BulletFather(TankFather tf,int speed,int power,Bitmap bit)
            : base(tf.X + tf.Width / 2 - 12, tf.Y + tf.Height / 2 - 10,bit.Width,bit.Height,speed,0,tf.Dir)
        {
            this.Bullet = bit;
            this.Power = power;
            this.Bullet.MakeTransparent(Color.Black);
        }

        public override void Draw(Graphics g)
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
                SingleObject.GetSingle().RemoveObject(this);
            }
            if (this.X >= 710)
            {
                SingleObject.GetSingle().RemoveObject(this);
            }
            if (this.Y <= 0)
            {
                SingleObject.GetSingle().RemoveObject(this);
            }
            if (this.Y >= 710)
            {
                SingleObject.GetSingle().RemoveObject(this);
            }
            g.DrawImage(Bullet,this.X,this.Y);
        }
    }
}
