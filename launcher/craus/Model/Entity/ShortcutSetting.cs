using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Craus.Model.Entity
{
    /// <summary>
    /// 全てのショートカット設定を保持するクラス
    /// </summary>
    public class ShortcutSetting
    {
        /// <summary>
        /// 設定値
        /// </summary>
        private Dictionary<int, ShortcutSettingItem> items = null;

        /// <summary>
        /// 設定値が空のインスタンスを生成します。
        /// </summary>
        public ShortcutSetting()
        {
            this.items = new Dictionary<int, ShortcutSettingItem>();
        }

        /// <summary>
        /// 同じ設定値を持つインスタンスを生成します。
        /// </summary>
        /// <param name="original">元になるインスタンス</param>
        public ShortcutSetting( ShortcutSetting original )
        {
            if( original == null )
            {
                throw new ArgumentNullException( "original" );
            }

            this.items = new Dictionary<int, ShortcutSettingItem>( original.items );
        }

        /// <summary>
        /// 設定値を追加します。
        /// ShortcutIdをキーとして追加します。
        /// 同じキーで登録済みのものがある場合は追加しません。
        /// </summary>
        /// <param name="value">追加する値</param>
        /// <returns>追加できた:true 追加できなかった:false</returns>
        public Boolean Set( ShortcutSettingItem value )
        {
            if( value == null )
            {
                throw new ArgumentNullException( "value" );
            }

            if( items.ContainsKey( value.GetShortcutId() ) )
            {
                return false;
            }

            this.items.Add( value.GetShortcutId(), value );
            return true;
        }

        /// <summary>
        /// 指定のShortcutIdを持つ設定値を取得します。
        /// 設定値が存在しない場合はnullを返します。
        /// </summary>
        /// <param name="id">ShortcutId</param>
        /// <returns>指定のShortcutIdを持つ設定値。存在しない場合はnull</returns>
        public ShortcutSettingItem GetByShortcutId( int id )
        {
            if( this.items.ContainsKey( id ) )
            {
                return this.items[id];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 指定のGroupIdを持つ設定値を取得します。
        /// 設定値が存在しない場合はnullを返します。
        /// </summary>
        /// <param name="id">GroupId</param>
        /// <returns>指定のGroupIdを持つ設定値のList。存在しない場合は空のList</returns>
        public List<ShortcutSettingItem> GetByGroupId( int id )
        {
            var list = new List<ShortcutSettingItem>();

            foreach( ShortcutSettingItem item in this.GetAll() )
            {
                if( item.GetGroupId() == id )
                {
                    list.Add( item );
                }
            }

            return list;
        }

        /// <summary>
        /// 全設定値のコピーを取得します。
        /// </summary>
        /// <returns>全設定値のコピー</returns>
        public List<ShortcutSettingItem> GetAll()
        {
            return new List<ShortcutSettingItem>( this.items.Values );
        }
    }
}
