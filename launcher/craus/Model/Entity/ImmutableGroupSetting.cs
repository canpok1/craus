using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Craus.Model.Entity
{
    /// <summary>
    /// グループ設定を保持する不変クラスです。
    /// </summary>
    public class ImmutableGroupSetting
    {
        /// <summary>
        /// グループ設定
        /// </summary>
        private GroupSetting wrappedObj = null;

        /// <summary>
        /// 同じ値を持つインスタンスを生成します。
        /// </summary>
        /// <param name="wrappedObj">元になるグループ設定</param>
        public ImmutableGroupSetting( GroupSetting wrappedObj )
        {
            if( wrappedObj == null )
            {
                throw new ArgumentNullException( "wrappedObj" );
            }

            this.wrappedObj = new GroupSetting( wrappedObj );
        }

        /// <summary>
        /// 同じ値を持つ可変なインスタンスに変換します。
        /// </summary>
        /// <returns>可変インスタンス</returns>
        public GroupSetting ToMutable()
        {
            return new GroupSetting( this.wrappedObj );
        }

        /// <summary>
        /// グループIDを指定して設定値を取得します。
        /// </summary>
        /// <param name="id">グループID</param>
        /// <returns>設定値</returns>
        public GroupSettingItem Get( int id )
        {
            return this.wrappedObj.Get( id );
        }

        /// <summary>
        /// 全ての設定値を取得します。
        /// </summary>
        /// <returns>全ての設定値</returns>
        public List<GroupSettingItem> GetAll()
        {
            return this.wrappedObj.GetAll();
        }
    }
}
