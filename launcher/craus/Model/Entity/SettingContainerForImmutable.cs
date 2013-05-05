namespace Craus.Model.Entity
{
    /// <summary>
    /// 全ての設定を保持するクラス
    /// </summary>
    public class SettingContainerForImmutable
    {
        /// <summary>
        /// ランチャー設定
        /// </summary>
        public ImmutableLauncherSetting LauncherSetting{ set; get; }

        /// <summary>
        /// ショートカット設定
        /// </summary>
        public ImmutableShortcutSetting ShortcutSetting { set; get; }

        /// <summary>
        /// グループ設定
        /// </summary>
        public ImmutableGroupSetting GroupSetting { set; get; }

        /// <summary>
        /// 保持している設定値を可変に変換します。
        /// </summary>
        public SettingContainerForMutable ToMutable()
        {
            var mutable = new SettingContainerForMutable();
            mutable.LauncherSetting = LauncherSetting.ToMutable();
            mutable.ShortcutSetting = ShortcutSetting.ToMutable();
            mutable.GroupSetting = GroupSetting.ToMutable();

            return mutable;
        }
    }
}