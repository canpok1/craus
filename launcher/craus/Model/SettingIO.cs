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
        /// 読み込みに失敗した場合はnullを返します。
        /// </summary>
        /// <returns>設定値</returns>
        public SettingContainerForImmutable Load()
        {
            try
            {
                this.logger.Start();

                // TODO [実装]

                var container = new SettingContainerForImmutable();
                container.LauncherSetting = this.loadLauncherSetting();
                container.ShortcutSetting = this.loadShortcutSetting();
                container.GroupSetting = this.loadGroupSetting();

                return container;
            }
            catch( Exception e )
            {
                this.logger.Warn( e );

                return null;
            }
            finally
            {
                this.logger.End();
            }
        }

        /// <summary>
        /// ランチャー設定を読み込みます。
        /// </summary>
        /// <returns>ランチャー設定</returns>
        private ImmutableLauncherSetting loadLauncherSetting()
        {
            try
            {
                this.logger.Start();

                var setting = new LauncherSetting();

                foreach( LauncherSetting.Key key in Enum.GetValues( typeof( LauncherSetting.Key ) ) )
                {
                    string keyString = Enum.GetName( typeof( LauncherSetting.Key ), key );
                    setting.Set( key, Craus.Properties.Settings.Default[keyString] as string );

                    this.logger.Debug( "key[" + keyString + "] value[" + setting.GetString( key ) + "]" );
                }

                return new ImmutableLauncherSetting( setting );
            }
            finally
            {
                this.logger.End();
            }
        }

        /// <summary>
        /// ショートカット設定を読み込みます。
        /// </summary>
        /// <returns>ショートカット設定</returns>
        private ImmutableShortcutSetting loadShortcutSetting()
        {
            try
            {
                this.logger.Start();

                var setting = new ShortcutSetting();

                // TODO [実装]

                return new ImmutableShortcutSetting( setting );
            }
            finally
            {
                this.logger.End();
            }
        }

        /// <summary>
        /// グループ設定を読み込みます。
        /// </summary>
        /// <returns>グループ設定</returns>
        private ImmutableGroupSetting loadGroupSetting()
        {
            try
            {
                this.logger.Start();

                var setting = new GroupSetting();

                // TODO [実装]

                return new ImmutableGroupSetting( setting );
            }
            finally
            {
                this.logger.End();
            }
        }

        /// <summary>
        /// 設定を保存します。
        /// </summary>
        /// <param name="setting">設定値</param>
        /// <returns>true:保存成功 false:保存失敗</returns>
        /// <exception cref="ArgumentNullException">引数または設定値がnullの場合</exception>
        public Boolean Save( SettingContainerForMutable setting )
        {
            if( setting == null )
            {
                throw new ArgumentNullException( "setting" );
            }

            try
            {
                // TODO [実装]
                this.logger.Start();

                this.saveLauncherSetting( setting.LauncherSetting );
                this.saveShortcutAndGroup( setting.ShortcutSetting, setting.GroupSetting );

                return true;
            }
            catch( Exception e )
            {
                this.logger.Warn( e );
                return false;
            }
            finally
            {
                this.logger.End();
            }
        }

        /// <summary>
        /// ランチャー設定を保存します。
        /// </summary>
        /// <param name="setting">ランチャー設定</param>
        /// <exception cref="ArgumentNullException">引数がnullの場合</exception>
        private void saveLauncherSetting( LauncherSetting setting )
        {
            if( setting == null )
            {
                throw new ArgumentNullException( "setting" );
            }

            try
            {
                this.logger.Start();

                // TODO [実装]
                foreach( LauncherSetting.Key key in Enum.GetValues( typeof( LauncherSetting.Key ) ) )
                {
                    string keyString = Enum.GetName( typeof( LauncherSetting.Key ), key );
                    Craus.Properties.Settings.Default[keyString] = setting.GetString( key );
                }
            }
            finally
            {
                this.logger.End();
            }
        }

        /// <summary>
        /// ショートカットとグループの設定を保存します。
        /// </summary>
        /// <param name="shortcut">ショートカット設定</param>
        /// <param name="group">グループ設定</param>
        /// <exception cref="ArgumentNullException">引数がnullの場合</exception>
        private void saveShortcutAndGroup( ShortcutSetting shortcut, GroupSetting group )
        {
            if( shortcut == null )
            {
                throw new ArgumentNullException( "shortcut" );
            }
            if( group == null )
            {
                throw new ArgumentNullException( "group" );
            }

            try
            {
                this.logger.Start();

                // TODO [実装]
            }
            finally
            {
                this.logger.End();
            }
        }
    }

}
