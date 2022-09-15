using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 坦克大战升级版.Properties;

namespace 坦克大战升级版
{
    public class Steel:GameObject
    {
        private static Bitmap bit = Resources.steel;
        public Steel(int x, int y) : base(x, y, bit.Width, bit.Height)
        {

        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(bit, this.X, this.Y);
        }
    }
}
