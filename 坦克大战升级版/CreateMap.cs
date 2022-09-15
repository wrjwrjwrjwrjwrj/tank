using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 坦克大战升级版
{
    /// <summary>
    /// 创建地图的类
    /// </summary>
    public static class CreatelMap
    {
        /// <summary>
        /// 垂直创建砖墙
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="count"></param>
        private static void CreateWall(int x, int y, int count)
        {
            int xPosition = x * 50;
            int yPosition = y * 50;
            for (int i = yPosition; i < yPosition + count * 30; i += 15)
            {
                SingleObject.GetSingle().AddGameObject(new Wall(xPosition, i));
                SingleObject.GetSingle().AddGameObject(new Wall(xPosition + 15, i));
            }
        }

        /// <summary>
        /// 水平创建砖墙
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="count"></param>
        private static void CreateHorWall(int x, int y, int count)
        {
            int xPosition = x * 50;
            int yPosition = y * 50;
            for (int i = xPosition; i < xPosition + count * 30; i += 15)
            {
                SingleObject.GetSingle().AddGameObject(new Wall(i, yPosition));
                SingleObject.GetSingle().AddGameObject(new Wall(i, yPosition + 15));
            }
        }


        /// <summary>
        /// 垂直创建钢墙
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="count"></param>
        private static void CreateSteel(int x, int y, int count)
        {
            int xPosition = x * 50;
            int yPosition = y * 50;
            for (int i = yPosition; i < yPosition + count * 30; i += 15)
            {
                SingleObject.GetSingle().AddGameObject(new Steel(xPosition, i));
                SingleObject.GetSingle().AddGameObject(new Steel(xPosition + 15, i));
            }
        }

        /// <summary>
        /// 水平创建钢墙
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="count"></param>
        private static void CreateHorSteel(int x, int y, int count)
        {
            int xPosition = x * 50;
            int yPosition = y * 50;
            for (int i = xPosition; i < xPosition + count * 30; i += 15)
            {
                SingleObject.GetSingle().AddGameObject(new Steel(i, yPosition));
                SingleObject.GetSingle().AddGameObject(new Steel(i, yPosition + 15));
            }
        }

        /// <summary>
        /// 创建Boss
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private static void CreateBoss(int x, int y)
        {
            int xPosition = x * 50;
            int yPosition = y * 50;
            SingleObject.GetSingle().AddGameObject(new Boss(xPosition, yPosition));
        }
        /// <summary>
        /// 初始化游戏地图
        /// </summary>
        public static void InitialMap()
        {
            #region 上半部分
            CreateWall(1, 1, 5);
            CreateWall(3, 1, 5);
            CreateWall(5, 1, 4);
            CreateWall(7, 1, 3);
            CreateWall(9, 1, 4);
            CreateWall(11, 1, 5);
            CreateWall(13, 1, 5);

            CreateSteel(7, 4, 1);
            #endregion


            #region 中间部分

            CreateSteel(0, 6, 1);
            CreateWall(2, 5, 3);
            CreateHorWall(6, 6, 5);
            CreateWall(12, 5, 3);
            CreateSteel(14, 6, 1);
            #endregion


            #region 下半部分
            CreateWall(1, 9, 5);
            CreateWall(3, 9, 5);
            CreateWall(5, 9, 4);
            CreateHorWall(5, 10, 7);
            CreateSteel(7, 8, 1);
            
            CreateWall(9, 9, 4);
            CreateWall(11, 9, 5);
            CreateWall(13, 9, 5);
            #endregion

            #region Boss部分
            CreateWall(6, 12, 3);
            CreateHorWall(6, 12, 4);
            CreateWall(8, 12, 3);
            CreateBoss(7, 13);
            #endregion
        }


    }
}
