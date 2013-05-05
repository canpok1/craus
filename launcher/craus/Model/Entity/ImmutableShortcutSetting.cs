using System;
using System.Collections.Generic;
using System.Text;

namespace Craus.Model.Entity
{
    /// <summary>
    /// グループ設定を保持する不変クラスです。
    /// </summary>
    public class ImmutableShortcutSetting
    {
        /// <summary>
        /// グループ設定
        /// </summary>
        private ShortcutSetting wrappedObj = null;

        /// <summary>
        /// 同じ値を持つインスタンスを生成します。
        /// </summary>
        /// <param name="wrappedObj">元になるグループ設定</param>
        public ImmutableShortcutSetting( ShortcutSetting wrappedObj )
        {
            if( wrappedObj == null )
            {
                throw new ArgumentNullException( "wrappedObj" );
            }

            this.wrappedObj = new ShortcutSetting( wrappedObj );
        }

        /// <summary>
        /// 同じ値を持つ可変なインスタンスに変換します。
        /// </summary>
        /// <returns>可変インスタンス</returns>
        public ShortcutSetting ToMutable()
        {
            return new ShortcutSetting( this.wrappedObj );
        }

        /// <summary>
        /// ショートカットIDを指定して設定値を取得します。
        /// </summary>
        /// <param name="id">ショートカットID</param>
        /// <returns>設定値</returns>
        public ShortcutSettingItem GetByShortcutId( int id )
        {
            return this.wrappedObj.GetByShortcutId( id );
        }

        /// <summary>
        /// グループIDを指定して設定値を取得します。
        /// </summary>
        /// <param name="id">グループID</param>
        /// <returns>設定値</returns>
        public List<ShortcutSettingItem> GetByGroupId( int id )
        {
            return this.wrappedObj.GetByGroupId( id );
        }

        /// <summary>
        /// 全ての設定値を取得します。
        /// </summary>
        /// <returns>全ての設定値</returns>
        public List<ShortcutSettingItem> GetAll()
        {
            return this.wrappedObj.GetAll();
        }
    }
}
