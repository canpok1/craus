namespace Craus.Model.Entity
{
    /// <summary>
    /// �S�Ă̐ݒ��ێ�����N���X
    /// </summary>
    public class SettingContainerForMutable
    {
        /// <summary>
        /// �����`���[�ݒ�
        /// </summary>
        public LauncherSetting LauncherSetting{ set; get; }

        /// <summary>
        /// �V���[�g�J�b�g�ݒ�
        /// </summary>
        public ShortcutSetting ShortcutSetting { set; get; }

        /// <summary>
        /// �O���[�v�ݒ�
        /// </summary>
        public GroupSetting GroupSetting { set; get; }
    }
}