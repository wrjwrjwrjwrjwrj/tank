using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 坦克大战升级版.Properties;

namespace 坦克大战升级版
{
    public class EnemyBullet:BulletFather
    {
        private static Bitmap Enemy = Resources.Bullet;
        public EnemyBullet(TankFather tf, int speed, int power) : base(tf, speed, power, Enemy)
        {
        }
    }
}
