using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using 坦克大战升级版.Properties;

namespace 坦克大战升级版
{
    public class GameSoundPlay
    {
        private static SoundPlayer startPlay = new SoundPlayer();
        private static SoundPlayer firePlay = new SoundPlayer();
        private static SoundPlayer hitPlay = new SoundPlayer();
        private static SoundPlayer blastPlay = new SoundPlayer();
        private static SoundPlayer addPlay = new SoundPlayer();
        private static SoundPlayer gameOverPlay = new SoundPlayer();

        /// <summary>
        /// 初始化音乐
        /// </summary>
        public static void Initial()
        {
            startPlay.Stream = Resources.start;
            firePlay.Stream = Resources.fire;
            blastPlay.Stream = Resources.blast;
            addPlay.Stream = Resources.add;
            hitPlay.Stream = Resources.hit;
            gameOverPlay.Stream = Resources.game_over;
        }

        /// <summary>
        /// 开始音乐
        /// </summary>
        public static void PlayStart()
        {
            if (SingleObject.GetSingle().state == State.Running)
            {
                startPlay.Play();
            }
        }

        /// <summary>
        /// 开火音乐
        /// </summary>
        public static void FirePlay()
        {
            if (SingleObject.GetSingle().state == State.Running)
            {
                firePlay.Play();
            }
        }

        /// <summary>
        /// 击中音乐
        /// </summary>
        public static void HitPlay()
        {
            if (SingleObject.GetSingle().state == State.Running)
            {
                hitPlay.Play();
            }
        }

        /// <summary>
        /// 添加敌人音乐
        /// </summary>
        public static void AddPlay()
        {
            if (SingleObject.GetSingle().state == State.Running)
            {
                addPlay.Play();
            }
        }

        /// <summary>
        /// 爆炸音乐
        /// </summary>
        public static void BlastPlay()
        {
            if (SingleObject.GetSingle().state == State.Running)
            {
                blastPlay.Play();
            }
        }

        /// <summary>
        /// 游戏结束音乐
        /// </summary>
        public static void OverPlay()
        {
            if (SingleObject.GetSingle().state == State.Gameover)
            {
                gameOverPlay.Play();
            }
        }
    }
}
