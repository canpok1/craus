using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Craus.Model.Entity
{
    /// <summary>
    /// 全てのグループ設定を保持するクラス
    /// </summary>
    public class GroupSetting
    {
        /// <summary>
        /// 設定値
        /// </summary>
        private Dictionary<int, GroupSettingItem> items = null;

        /// <summary>
        /// 設定値が空のインスタンスを生成します。
        /// </summary>
        public GroupSetting()
        {
            this.items = new Dictionary<int, GroupSettingItem>();
        }

        /// <summary>
        /// 同じ設定値を持つインスタンスを生成します。
        /// </summary>
        /// <param name="original">元になるインスタンス</param>
        public GroupSetting( GroupSetting original )
        {
            if( original == null )
            {
                throw new ArgumentNullException( "original" );
            }

            this.items = new Dictionary<int, GroupSettingItem>( original.items );
        }

        /// <summary>
        /// 設定値を追加します。
        /// GroupIdをキーとして追加します。
        /// 同じキーで登録済みのものがある場合は追加しません。
        /// </summary>
        /// <param name="value">追加する値</param>
        /// <returns>追加できた:true 追加できなかった:false</returns>
        public Boolean Set( GroupSettingItem value )
        {
            if( value == null )
            {
                throw new ArgumentNullException( "value" );
            }

            if( items.ContainsKey( value.GetGroupId() ) )
            {
                return false;
            }

            this.items.Add( value.GetGroupId(), value );
            return true;
        }

        /// <summary>
        /// 指定のGroupIdを持つ設定値を取得します。
        /// 設定値が存在しない場合はnullを返します。
        /// </summary>
        /// <param name="id">GroupId</param>
        /// <returns>指定のGroupIdを持つ設定値。存在しない場合はnull</returns>
        public GroupSettingItem Get( int id )
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
        /// 全設定値のコピーを取得します。
        /// </summary>
        /// <returns>全設定値のコピー</returns>
        public List<GroupSettingItem> GetAll()
        {
            return new List<GroupSettingItem>( this.items.Values );
        }
    }
}
