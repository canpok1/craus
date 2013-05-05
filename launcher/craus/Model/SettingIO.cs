using System;
using Craus.Util;
using Craus.Model.Entity;

namespace Craus.Model
{
    /// <summary>
    /// 設定の保存・読み込みを行うクラスです。
    /// </summary>
    public class SettingIO
    {
        private ILogger logger = null;

        public SettingIO()
        {
            this.logger = LogUtil.GetLogger();
        }

        /// <summary>
        /// 設定を読み込みます。
        /// </summary>
        /// <returns>設定値</returns>
        public SettingContainerForImmutable Load()
        {
            // TODO [実装]
            return null;
        }

        /// <summary>
        /// 設定を保存します。
        /// </summary>
        /// <param name="setting">設定値</param>
        /// <exception cref="ArgumentNullException">引数または設定値がnullの場合</exception>
        public void Save( SettingContainerForMutable setting )
        {
            if( setting == null )
            {
                throw new ArgumentNullException( "setting" );
            }
            if( setting.LauncherSetting == null )
            {
                throw new ArgumentNullException( "setting.LauncherSetting" );
            }
            if( setting.ShortcutSetting == null )
            {
                throw new ArgumentNullException( "setting.ShortcutSetting" );
            }
            if( setting.GroupSetting == null )
            {
                throw new ArgumentNullException( "setting.GroupSetting" );
            }

            // TODO [実装]
        }
    }

}
