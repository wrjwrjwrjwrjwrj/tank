using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 坦克大战升级版.Properties;

namespace 坦克大战升级版
{
    public class Explosion:GameObject
    {
        private static Bitmap[] exp =
        {
            Resources.EXP1,
            Resources.EXP2,
            Resources.EXP3,
            Resources.EXP4,
            Resources.EXP5
        };
        public Explosion(int x, int y) : base(x, y,exp[0].Width,exp[0].Height )
        {
            for (int i = 0; i < exp.Length; i++)
            {
                exp[i].MakeTransparent(Color.Black);
            }
        }

        public override void Draw(Graphics g)
        {
            for (int i = 0; i < 50; i++)//通过一个循环来产生爆炸的效果
            {
                for (int j = 0; j < exp.Length; j++)
                {
                     g.DrawImage(exp[j],this.X,this.Y);
                }
            }
            SingleObject.GetSingle().RemoveObject(this);//爆炸完后立刻销毁
        }
    }
}
