namespace Craus.Model.Entity
{
    /// <summary>
    /// 全ての設定を保持するクラス
    /// </summary>
    public class SettingContainerForMutable
    {
        /// <summary>
        /// ランチャー設定
        /// </summary>
        public LauncherSetting LauncherSetting{ set; get; }

        /// <summary>
        /// ショートカット設定
        /// </summary>
        public ShortcutSetting ShortcutSetting { set; get; }

        /// <summary>
        /// グループ設定
        /// </summary>
        public GroupSetting GroupSetting { set; get; }
    }
}