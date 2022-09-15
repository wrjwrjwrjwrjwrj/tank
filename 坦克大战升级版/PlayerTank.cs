using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 坦克大战升级版.Properties;

namespace 坦克大战升级版
{
    public class PlayerTank:TankFather
    {
        private static Bitmap[] MyTank =
        {
            Resources.MyTankUp,
            Resources.MyTankDown,
            Resources.MyTankLeft,
            Resources.MyTankRight
        };

        //初始位置和生命
        private int xOrigin { get; set; }
        private int yOrigin { get; set; }
        private int lifeOrigin { get; set; }
        
        public PlayerTank(int x, int y, int speed, int life, Direction dir) 
            : base(x, y, MyTank,speed, life, dir)
        {
            this.xOrigin = x;
            this.yOrigin = y;
            this.lifeOrigin = life;
        }

        /// <summary>
        /// 开火的方法
        /// </summary>
        public override void Fire()
        {
            SingleObject.GetSingle().AddGameObject(new PlayerBullet(this,10,1));
        }

        public override void IsOver()
        {
           //发生爆炸效果
           SingleObject.GetSingle().AddGameObject(new Explosion(this.X,this.Y));
           if (this.Life <= 0)
           {
               this.X = xOrigin;
               this.Y = yOrigin;
               this.Life = this.lifeOrigin;
                Born();
                GameSoundPlay.BlastPlay();
           }
           else
           {
               GameSoundPlay.HitPlay();
           }
        }

        public override void Born()
        {
            SingleObject.GetSingle().AddGameObject(new TankBorn(this.X,this.Y));
        }


        public void KeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    this.Dir = Direction.Up;
                    base.Move();
                    break;
                case Keys.Down:
                    this.Dir = Direction.Down;
                    base.Move();
                    break;
                case Keys.Left:
                    this.Dir = Direction.Left;
                    base.Move();
                    break;
                case Keys.Right:
                    this.Dir = Direction.Right;
                    base.Move();
                    break;
                case Keys.Space:
                    Fire();
                    break;
            }
        }
    }
}
