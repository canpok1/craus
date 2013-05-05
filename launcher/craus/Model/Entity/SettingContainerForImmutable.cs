namespace Craus.Model.Entity
{
    /// <summary>
    /// �S�Ă̐ݒ��ێ�����N���X
    /// </summary>
    public class SettingContainerForImmutable
    {
        /// <summary>
        /// �����`���[�ݒ�
        /// </summary>
        public ImmutableLauncherSetting LauncherSetting{ set; get; }

        /// <summary>
        /// �V���[�g�J�b�g�ݒ�
        /// </summary>
        public ImmutableShortcutSetting ShortcutSetting { set; get; }

        /// <summary>
        /// �O���[�v�ݒ�
        /// </summary>
        public ImmutableGroupSetting GroupSetting { set; get; }

        /// <summary>
        /// �ێ����Ă���ݒ�l���ςɕϊ����܂��B
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