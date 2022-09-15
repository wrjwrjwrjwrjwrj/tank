using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 坦克大战升级版.Properties;

namespace 坦克大战升级版
{
    public class TankBorn:GameObject
    {
        private static Bitmap[] Born =
        {
            Resources.Star1,
            Resources.Star2,
            Resources.Star3
        };

        private int time = 0;
        public TankBorn(int x, int y) : base(x, y, Born[0].Width,Born[0].Height)
        {
            for (int i = 0; i < Born.Length; i++)
            {
                Born[i].MakeTransparent(Color.Black);
            }
        }

        /// <summary>
        /// 让这几张图片快速的闪过从而制造出闪烁的效果
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            time++;
            for (int i = 0; i < Born.Length; i++)
            {
                switch (time%10)
                {
                    case 1:g.DrawImage(Born[0],this.X,this.Y);
                        break;
                    case 2:g.DrawImage(Born[1],this.X,this.Y);
                        break;
                    case 3:g.DrawImage(Born[2],this.X,this.Y);
                        break;
                }
            }

            if (time % 20 == 0)//让闪烁的图片停留一会
            {
                SingleObject.GetSingle().RemoveObject(this);
            }
        }
    }
}
