using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 坦克大战升级版.Properties;

namespace 坦克大战升级版
{
    public class PlayerBullet:BulletFather
    {
        private static Bitmap MyBullet = Resources.Bullet;
        public PlayerBullet(TankFather tf, int speed, int power) : base(tf, speed, power, MyBullet)
        { }
    }
}
