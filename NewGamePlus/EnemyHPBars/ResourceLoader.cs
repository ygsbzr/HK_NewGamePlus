using System.IO;
using UnityEngine;

namespace EnemyHPBar
{
	internal class ResourceLoader : MonoBehaviour
    {
        public static byte[] GetBackgroundImage()
            => File.ReadAllBytes(EnemyHPBar.DATA_DIR + "/" + EnemyHPBar.HPBAR_BG);

        public static byte[] GetForegroundImage()
            => File.ReadAllBytes(EnemyHPBar.DATA_DIR + "/" + EnemyHPBar.HPBAR_FG);

        public static byte[] GetMiddlegroundImage()
            => File.ReadAllBytes(EnemyHPBar.DATA_DIR + "/" + EnemyHPBar.HPBAR_MG);

        public static byte[] GetOutlineImage()
            => File.ReadAllBytes(EnemyHPBar.DATA_DIR + "/" + EnemyHPBar.HPBAR_OL);

        public static byte[] GetBossBackgroundImage()
            => File.ReadAllBytes(EnemyHPBar.DATA_DIR + "/" + EnemyHPBar.HPBAR_BOSSBG);

        public static byte[] GetBossForegroundImage()
            => File.ReadAllBytes(EnemyHPBar.DATA_DIR + "/" + EnemyHPBar.HPBAR_BOSSFG);

        public static byte[] GetBossOutlineImage()
            => File.ReadAllBytes(EnemyHPBar.DATA_DIR + "/" + EnemyHPBar.HPBAR_BOSSOL);
    }
}