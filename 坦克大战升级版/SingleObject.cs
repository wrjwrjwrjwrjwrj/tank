using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using 坦克大战升级版.Properties;

namespace 坦克大战升级版
{
    /// <summary>
    /// 单例类 用于绘制游戏对象
    /// </summary>
    public class SingleObject
    {
        private static readonly object _lock = new object();//锁  用于解决多线程并发，资源占用问题
        public static SingleObject _singleObject = null;
        private Random r = new Random();
        public State state = State.Running;
        private SingleObject() { }

        /// <summary>
        /// 懒汉式
        /// </summary>
        /// <returns></returns>
        public static SingleObject GetSingle()
        {
            lock (_lock)
            {
                if (_singleObject == null)
                {
                    _singleObject = new SingleObject();
                }
            }
            return _singleObject;
        }

        //单个游戏对象属性
        private Boss boss { get; set; }
        public PlayerTank playerTank { get; set; }

        //创建集合用来存储游戏对象
        private List<Wall> wallList = new List<Wall>();
        private List<Steel> steelList = new List<Steel>();
        private List<EnemyTank> enemyTanksList = new List<EnemyTank>();
        private List<PlayerBullet> myBulletList = new List<PlayerBullet>();
        private List<EnemyBullet> enemyBulletList = new List<EnemyBullet>();
        private List<Explosion> explosionList = new List<Explosion>();
        private List<TankBorn> tankBornList = new List<TankBorn>();


        /// <summary>
        /// 用来添加游戏对象
        /// </summary>
        /// <param name="go"></param>
        public void AddGameObject(GameObject go)
        {
            if (go is Wall)
            {
                wallList.Add(go as Wall);
            }
            else if (go is Steel)
            {
                steelList.Add(go as Steel);
            }
            else if (go is Boss)
            {
                boss = go as Boss;
            }
            else if (go is PlayerTank)
            {
                playerTank = go as PlayerTank;
            }
            else if (go is EnemyTank)
            {
                enemyTanksList.Add(go as EnemyTank);
            }
            else if (go is PlayerBullet)
            {
                myBulletList.Add(go as PlayerBullet);
            }
            else if (go is EnemyBullet)
            {
                enemyBulletList.Add(go as EnemyBullet);
            }
            else if (go is Explosion)
            {
                explosionList.Add(go as Explosion);
            }
            else if (go is TankBorn)
            {
                tankBornList.Add(go as TankBorn);
            }
        }


        /// <summary>
        /// 移除游戏对象
        /// </summary>
        /// <param name="go"></param>
        public void RemoveObject(GameObject go)
        {
            if (go is Wall)
            {
                wallList.Remove(go as Wall);
            }
            else if (go is Steel)
            {
                steelList.Remove(go as Steel);
            }
            else if (go is EnemyTank)
            {
                enemyTanksList.Remove(go as EnemyTank);
            }
            else if (go is PlayerBullet)
            {
                myBulletList.Remove(go as PlayerBullet);
            }
            else if (go is EnemyBullet)
            {
                enemyBulletList.Remove(go as EnemyBullet);
            }
            else if (go is Explosion)
            {
                explosionList.Remove(go as Explosion);
            }
            else if (go is TankBorn)
            {
                tankBornList.Remove(go as TankBorn);
            }
        }


        /// <summary>
        /// 用来绘制游戏对象
        /// </summary>
        /// <param name="g"></param>
        public void DrawObject(Graphics g)
        {
            if (state == State.Running)
            {
                for (int i = 0; i < wallList.Count; i++)
                {
                    wallList[i].Draw(g);
                }

                for (int i = 0; i < steelList.Count; i++)
                {
                    steelList[i].Draw(g);
                }

                boss.Draw(g);

                playerTank.Draw(g);

                for (int i = 0; i < enemyTanksList.Count; i++)
                {
                    enemyTanksList[i].Draw(g);
                }

                for (int i = 0; i < myBulletList.Count; i++)
                {
                    myBulletList[i].Draw(g);
                }

                for (int i = 0; i < enemyBulletList.Count; i++)
                {
                    enemyBulletList[i].Draw(g);
                }

                for (int i = 0; i < explosionList.Count; i++)
                {
                    explosionList[i].Draw(g);
                }

                for (int i = 0; i < tankBornList.Count; i++)
                {
                    tankBornList[i].Draw(g);
                }
            }
            else if (state == State.Gameover)
            {
                Bitmap bitmap = Resources.GameOver;
                bitmap.MakeTransparent(Color.White);
                int x = -80;
                int y = -50;
                g.DrawImage(bitmap, x, y);
            }
        }


        public void IsCollided()
        {
            #region 判断玩家是否和墙发生碰撞
            //for (int i = 0; i < wallList.Count; i++)
            //{
            //    switch (playerTank.Dir)
            //    {
            //        case Direction.Up:
            //            if (wallList[i].GetRectangle().IntersectsWith(playerTank.GetRectangle()))
            //            {
            //                playerTank.Y += playerTank.Speed;
            //            }
            //            break;
            //        case Direction.Down:
            //            if (wallList[i].GetRectangle().IntersectsWith(playerTank.GetRectangle()))
            //            {
            //                playerTank.Y -= playerTank.Speed;

            //            }
            //            break;
            //        case Direction.Left:
            //            if (wallList[i].GetRectangle().IntersectsWith(playerTank.GetRectangle()))
            //            {
            //                playerTank.X += playerTank.Speed;
            //            }
            //            break;
            //        case Direction.Right:
            //            if (wallList[i].GetRectangle().IntersectsWith(playerTank.GetRectangle()))
            //            {
            //                playerTank.X -= playerTank.Speed;
            //            }
            //            break;
            //    }
            //}
            PlayerIsCollidedWall(new List<GameObject>(wallList));
            #endregion

            #region 判断玩家是否和钢墙发生碰撞
            //for (int i = 0; i < steelList.Count; i++)
            //{
            //    switch (playerTank.Dir)
            //    {
            //        case Direction.Up:
            //            if (steelList[i].GetRectangle().IntersectsWith(playerTank.GetRectangle()))
            //            {
            //                playerTank.Y += playerTank.Speed;
            //            }
            //            break;
            //        case Direction.Down:
            //            if (steelList[i].GetRectangle().IntersectsWith(playerTank.GetRectangle()))
            //            {
            //                playerTank.Y -= playerTank.Speed;

            //            }
            //            break;
            //        case Direction.Left:
            //            if (steelList[i].GetRectangle().IntersectsWith(playerTank.GetRectangle()))
            //            {
            //                playerTank.X += playerTank.Speed;
            //            }
            //            break;
            //        case Direction.Right:
            //            if (steelList[i].GetRectangle().IntersectsWith(playerTank.GetRectangle()))
            //            {
            //                playerTank.X -= playerTank.Speed;
            //            }
            //            break;
            //    }
            //}
            PlayerIsCollidedWall(new List<GameObject>(steelList));
            #endregion

            #region 判断敌人坦克和墙体是否发生碰撞

            //for (int i = 0; i < wallList.Count; i++)
            //{
            //    for (int j = 0; j < enemyTanksList.Count; j++)
            //    {
            //        if (wallList[i].GetRectangle().IntersectsWith(enemyTanksList[j].GetRectangle()))
            //        {
            //            switch (enemyTanksList[j].Dir)
            //            {
            //                case Direction.Up:
            //                    enemyTanksList[j].Y += enemyTanksList[j].Speed;
            //                    if (r.Next(0, 100) < 10)
            //                    {
            //                        switch (r.Next(0, 3))
            //                        {
            //                            case 0:
            //                                enemyTanksList[j].Dir = Direction.Down;
            //                                break;
            //                            case 1:
            //                                enemyTanksList[j].Dir = Direction.Left;
            //                                break;
            //                            case 2:
            //                                enemyTanksList[j].Dir = Direction.Right;
            //                                break;
            //                        }
            //                    }

            //                    break;
            //                case Direction.Down:
            //                    enemyTanksList[j].Y -= enemyTanksList[j].Speed;
            //                    if (r.Next(0, 100) < 10)
            //                    {
            //                        switch (r.Next(0, 3))
            //                        {
            //                            case 0:
            //                                enemyTanksList[j].Dir = Direction.Up;
            //                                break;
            //                            case 1:
            //                                enemyTanksList[j].Dir = Direction.Left;
            //                                break;
            //                            case 2:
            //                                enemyTanksList[j].Dir = Direction.Right;
            //                                break;
            //                        }
            //                    }

            //                    break;
            //                case Direction.Left:
            //                    enemyTanksList[j].X += enemyTanksList[j].Speed;
            //                    if (r.Next(0, 100) < 10)
            //                    {
            //                        switch (r.Next(0, 3))
            //                        {
            //                            case 0:
            //                                enemyTanksList[j].Dir = Direction.Down;
            //                                break;
            //                            case 1:
            //                                enemyTanksList[j].Dir = Direction.Up;
            //                                break;
            //                            case 2:
            //                                enemyTanksList[j].Dir = Direction.Right;
            //                                break;
            //                        }
            //                    }

            //                    break;
            //                case Direction.Right:
            //                    enemyTanksList[j].X -= enemyTanksList[j].Speed;
            //                    if (r.Next(0, 100) < 10)
            //                    {
            //                        switch (r.Next(0, 3))
            //                        {
            //                            case 0:
            //                                enemyTanksList[j].Dir = Direction.Down;
            //                                break;
            //                            case 1:
            //                                enemyTanksList[j].Dir = Direction.Left;
            //                                break;
            //                            case 2:
            //                                enemyTanksList[j].Dir = Direction.Up;
            //                                break;
            //                        }
            //                    }

            //                    break;
            //            }
            //            break;
            //        }
            //    }
            //}
            EnemyIsCollidedWall(new List<GameObject>(wallList));
            #endregion

            #region 判断敌人是否和钢墙发生碰撞
            //for (int i = 0; i < steelList.Count; i++)
            //{
            //    for (int j = 0; j < enemyTanksList.Count; j++)
            //    {
            //        if (steelList[i].GetRectangle().IntersectsWith(enemyTanksList[j].GetRectangle()))
            //        {
            //            switch (enemyTanksList[j].Dir)
            //            {
            //                case Direction.Up:
            //                    enemyTanksList[j].Y += enemyTanksList[j].Speed;
            //                    if (r.Next(0, 100) < 10)
            //                    {
            //                        switch (r.Next(0, 3))
            //                        {
            //                            case 0:
            //                                enemyTanksList[j].Dir = Direction.Down;
            //                                break;
            //                            case 1:
            //                                enemyTanksList[j].Dir = Direction.Left;
            //                                break;
            //                            case 2:
            //                                enemyTanksList[j].Dir = Direction.Right;
            //                                break;
            //                        }
            //                    }

            //                    break;
            //                case Direction.Down:
            //                    enemyTanksList[j].Y -= enemyTanksList[j].Speed;
            //                    if (r.Next(0, 100) < 10)
            //                    {
            //                        switch (r.Next(0, 3))
            //                        {
            //                            case 0:
            //                                enemyTanksList[j].Dir = Direction.Up;
            //                                break;
            //                            case 1:
            //                                enemyTanksList[j].Dir = Direction.Left;
            //                                break;
            //                            case 2:
            //                                enemyTanksList[j].Dir = Direction.Right;
            //                                break;
            //                        }
            //                    }

            //                    break;
            //                case Direction.Left:
            //                    enemyTanksList[j].X += enemyTanksList[j].Speed;
            //                    if (r.Next(0, 100) < 10)
            //                    {
            //                        switch (r.Next(0, 3))
            //                        {
            //                            case 0:
            //                                enemyTanksList[j].Dir = Direction.Down;
            //                                break;
            //                            case 1:
            //                                enemyTanksList[j].Dir = Direction.Up;
            //                                break;
            //                            case 2:
            //                                enemyTanksList[j].Dir = Direction.Right;
            //                                break;
            //                        }
            //                    }

            //                    break;
            //                case Direction.Right:
            //                    enemyTanksList[j].X -= enemyTanksList[j].Speed;
            //                    if (r.Next(0, 100) < 10)
            //                    {
            //                        switch (r.Next(0, 3))
            //                        {
            //                            case 0:
            //                                enemyTanksList[j].Dir = Direction.Down;
            //                                break;
            //                            case 1:
            //                                enemyTanksList[j].Dir = Direction.Left;
            //                                break;
            //                            case 2:
            //                                enemyTanksList[j].Dir = Direction.Up;
            //                                break;
            //                        }
            //                    }

            //                    break;
            //            }
            //            break;
            //        }
            //    }
            //}
            EnemyIsCollidedWall(new List<GameObject>(steelList));
            #endregion

            #region 判断玩家子弹和墙是否发生碰撞

            for (int i = 0; i < wallList.Count; i++)
            {
                for (int j = 0; j < myBulletList.Count; j++)
                {
                    if (wallList[i].GetRectangle().IntersectsWith(myBulletList[j].GetRectangle()))
                    {
                        //发生爆炸
                        SingleObject.GetSingle().AddGameObject(new Explosion(wallList[i].X, wallList[i].Y));
                        //墙被消灭
                        wallList.Remove(wallList[i]);
                        //子弹被销毁
                        myBulletList.Remove(myBulletList[j]);
                        //播放音乐
                        GameSoundPlay.BlastPlay();
                        break;
                    }
                }
            }
            #endregion

            #region 判断玩家子弹和钢墙是否发生碰撞
            for (int i = 0; i < steelList.Count; i++)
            {
                for (int j = 0; j < myBulletList.Count; j++)
                {
                    if (steelList[i].GetRectangle().IntersectsWith(myBulletList[j].GetRectangle()))
                    {
                        //发生爆炸
                        SingleObject.GetSingle().AddGameObject(new Explosion(steelList[i].X, steelList[i].Y));
                        //子弹被销毁
                        myBulletList.Remove(myBulletList[j]);
                        //播放音乐
                        GameSoundPlay.HitPlay();
                        break;
                    }
                }
            }
            #endregion

            #region 判断敌人子弹和墙是否发生碰撞
            for (int i = 0; i < wallList.Count; i++)
            {
                for (int j = 0; j < enemyBulletList.Count; j++)
                {
                    if (wallList[i].GetRectangle().IntersectsWith(enemyBulletList[j].GetRectangle()))
                    {
                        //发生爆炸
                        SingleObject.GetSingle().AddGameObject(new Explosion(wallList[i].X, wallList[i].Y));
                        //墙被消灭
                        wallList.Remove(wallList[i]);
                        //子弹被销毁
                        enemyBulletList.Remove(enemyBulletList[j]);
                        //播放音乐
                        GameSoundPlay.BlastPlay();
                        break;
                    }
                }
            }
            #endregion

            #region 判断敌人子弹和钢墙是否发生碰撞
            for (int i = 0; i < steelList.Count; i++)
            {
                for (int j = 0; j < enemyBulletList.Count; j++)
                {
                    if (steelList[i].GetRectangle().IntersectsWith(enemyBulletList[j].GetRectangle()))
                    {
                        //发生爆炸
                        SingleObject.GetSingle().AddGameObject(new Explosion(steelList[i].X, steelList[i].Y));
                        //子弹被销毁
                        enemyBulletList.Remove(enemyBulletList[j]);
                        //播放音乐
                        GameSoundPlay.HitPlay();
                        break;
                    }
                }
            }
            #endregion

            #region 判断玩家子弹是否打中敌人

            for (int i = 0; i < myBulletList.Count; i++)
            {
                for (int j = 0; j < enemyTanksList.Count; j++)
                {
                    if (myBulletList[i].GetRectangle().IntersectsWith(enemyTanksList[j].GetRectangle()))
                    {
                        //表示玩家的子弹打在了敌人的身上
                        //敌人应该减少生命值
                        enemyTanksList[j].Life -= myBulletList[i].Power;
                        enemyTanksList[j].IsOver();
                        //当玩家子弹击中敌人坦克的时候  应该将玩家坦克子弹移除
                        myBulletList.Remove(myBulletList[i]);
                        break;
                    }
                }
            }
            #endregion

            #region 判断玩家子弹和敌人子弹是否发生碰撞
            for (int i = 0; i < myBulletList.Count; i++)
            {
                for (int j = 0; j < enemyBulletList.Count; j++)
                {
                    if (myBulletList[i].GetRectangle().IntersectsWith(enemyBulletList[j].GetRectangle()))
                    {
                        //发生爆炸
                        SingleObject.GetSingle().AddGameObject(new Explosion(myBulletList[i].X,myBulletList[i].Y));
                        //敌人坦克销毁
                        enemyBulletList.Remove(enemyBulletList[j]);
                        //玩家子弹销毁
                        myBulletList.Remove(myBulletList[i]);
                        //播放音乐
                        GameSoundPlay.HitPlay();
                        break;
                    }
                }
            }
            #endregion

            #region 判断敌人是否打中玩家
            for (int i = 0; i < enemyBulletList.Count; i++)
            {
                if (enemyBulletList[i].GetRectangle().IntersectsWith(playerTank.GetRectangle()))
                {
                    playerTank.Life -= enemyBulletList[i].Power;
                    playerTank.IsOver();
                    enemyBulletList.Remove(enemyBulletList[i]);
                    break;
                }
            }
            #endregion

            #region 判断玩家子弹是否和boss发生碰撞
            //for (int i = 0; i < myBulletList.Count; i++)
            //{
            //    if (myBulletList[i].GetRectangle().IntersectsWith(boss.GetRectangle()))
            //    {
            //        state = State.Gameover;
            //    }
            //}
            BulletIsCollidedBoss(new List<GameObject>(myBulletList));
            #endregion

            #region 判断敌人子弹是否和boss发生碰撞
            //for (int i = 0; i < enemyBulletList.Count; i++)
            //{
            //    if (enemyBulletList[i].GetRectangle().IntersectsWith(boss.GetRectangle()))
            //    {
            //        state = State.Gameover;
            //    }
            //}
            BulletIsCollidedBoss(new List<GameObject>(enemyBulletList));

            #endregion
        }

        /// <summary>
        /// 判断玩家是否与墙体发生碰撞
        /// </summary>
        /// <param name="goList"></param>
        public void PlayerIsCollidedWall(List<GameObject> goList)
        {
            for (int i = 0; i < goList.Count; i++)
            {
                switch (playerTank.Dir)
                {
                    case Direction.Up:
                        if (goList[i].GetRectangle().IntersectsWith(playerTank.GetRectangle()))
                        {
                            playerTank.Y += playerTank.Speed;
                        }
                        break;
                    case Direction.Down:
                        if (goList[i].GetRectangle().IntersectsWith(playerTank.GetRectangle()))
                        {
                            playerTank.Y -= playerTank.Speed;

                        }
                        break;
                    case Direction.Left:
                        if (goList[i].GetRectangle().IntersectsWith(playerTank.GetRectangle()))
                        {
                            playerTank.X += playerTank.Speed;
                        }
                        break;
                    case Direction.Right:
                        if (goList[i].GetRectangle().IntersectsWith(playerTank.GetRectangle()))
                        {
                            playerTank.X -= playerTank.Speed;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// 判断敌人是否与墙体发生碰撞
        /// </summary>
        /// <param name="goList"></param>
        public void EnemyIsCollidedWall(List<GameObject> goList)
        {
            for (int i = 0; i < goList.Count; i++)
            {
                for (int j = 0; j < enemyTanksList.Count; j++)
                {
                    if (goList[i].GetRectangle().IntersectsWith(enemyTanksList[j].GetRectangle()))
                    {
                        switch (enemyTanksList[j].Dir)
                        {
                            case Direction.Up:
                                enemyTanksList[j].Y += enemyTanksList[j].Speed;
                                if (r.Next(0, 100) < 10)
                                {
                                    switch (r.Next(0, 3))
                                    {
                                        case 0:
                                            enemyTanksList[j].Dir = Direction.Down;
                                            break;
                                        case 1:
                                            enemyTanksList[j].Dir = Direction.Left;
                                            break;
                                        case 2:
                                            enemyTanksList[j].Dir = Direction.Right;
                                            break;
                                    }
                                }

                                break;
                            case Direction.Down:
                                enemyTanksList[j].Y -= enemyTanksList[j].Speed;
                                if (r.Next(0, 100) < 10)
                                {
                                    switch (r.Next(0, 3))
                                    {
                                        case 0:
                                            enemyTanksList[j].Dir = Direction.Up;
                                            break;
                                        case 1:
                                            enemyTanksList[j].Dir = Direction.Left;
                                            break;
                                        case 2:
                                            enemyTanksList[j].Dir = Direction.Right;
                                            break;
                                    }
                                }

                                break;
                            case Direction.Left:
                                enemyTanksList[j].X += enemyTanksList[j].Speed;
                                if (r.Next(0, 100) < 10)
                                {
                                    switch (r.Next(0, 3))
                                    {
                                        case 0:
                                            enemyTanksList[j].Dir = Direction.Down;
                                            break;
                                        case 1:
                                            enemyTanksList[j].Dir = Direction.Up;
                                            break;
                                        case 2:
                                            enemyTanksList[j].Dir = Direction.Right;
                                            break;
                                    }
                                }

                                break;
                            case Direction.Right:
                                enemyTanksList[j].X -= enemyTanksList[j].Speed;
                                if (r.Next(0, 100) < 10)
                                {
                                    switch (r.Next(0, 3))
                                    {
                                        case 0:
                                            enemyTanksList[j].Dir = Direction.Down;
                                            break;
                                        case 1:
                                            enemyTanksList[j].Dir = Direction.Left;
                                            break;
                                        case 2:
                                            enemyTanksList[j].Dir = Direction.Up;
                                            break;
                                    }
                                }

                                break;
                        }
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 判断子弹是否与Boss发生碰撞
        /// </summary>
        /// <param name="goList"></param>
        public void BulletIsCollidedBoss(List<GameObject> goList)
        {
            for (int i = 0; i < goList.Count; i++)
            {
                if (goList[i].GetRectangle().IntersectsWith(boss.GetRectangle()))
                {
                    state = State.Gameover;
                }
            }
        }
    }
}


