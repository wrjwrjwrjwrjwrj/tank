using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 坦克大战升级版.Properties;

namespace 坦克大战升级版
{
    public class Boss:GameObject
    {
        private static Bitmap boss = Resources.Boss;

        public Boss(int x, int y) : base(x, y, boss.Width,boss.Height)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(boss,this.X,this.Y);
        }
    }
}
