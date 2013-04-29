using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Craus.Model.Entity
{
    /// <summary>
    /// グループ毎の設定
    /// </summary>
    public class GroupSettingItem
    {
        /// <summary>
        /// 設定値
        /// </summary>
        private Param param;

        /// <summary>
        /// 指定の設定値を持つグループ設定を生成します。
        /// </summary>
        /// <param name="param">設定値</param>
        public GroupSettingItem( Param param )
        {
            if( param == null )
            {
                throw new ArgumentNullException( "param" );
            }

            if( !this.checkArgGroupId( param.GroupId ) )
            {
                throw new ArgumentException( "param.GroupIdが不正" );
            }
            if( !this.checkArgGroupName( param.GroupName ) )
            {
                throw new ArgumentException( "param.GroupName" );
            }

            this.param = new Param( param );
        }

        /// <summary>
        /// グループIDが適切かの確認
        /// </summary>
        /// <param name="arg">グループID</param>
        /// <returns>適切:true 不適切:false</returns>
        private Boolean checkArgGroupId( int arg )
        {
            if( arg < 0 )
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// グループ名が適切かの確認
        /// </summary>
        /// <param name="arg">グループ名</param>
        /// <returns>適切:true 不適切:false</returns>
        private Boolean checkArgGroupName( String arg )
        {
            if( String.IsNullOrEmpty( arg ) )
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// グループIDの取得
        /// </summary>
        /// <returns>グループID</returns>
        public int GetGroupId()
        {
            return this.param.GroupId;
        }

        /// <summary>
        /// グループ名の取得
        /// </summary>
        /// <returns>グループ名</returns>
        public String GetGroupName()
        {
            return this.param.GroupName;
        }

        /// <summary>
        /// グループ設定の設定値
        /// </summary>
        public class Param
        {
            /// <summary>グループID</summary>
            public int GroupId { set; get; }

            /// <summary>グループ名</summary>
            public String GroupName { set; get; }

            /// <summary>
            /// 無効な値を格納したグループ設定を生成します。
            /// </summary>
            public Param()
            {
                this.GroupId = -1;
                this.GroupName = null;
            }

            /// <summary>
            /// 同じ値を格納したグループ設定を生成します。
            /// </summary>
            /// <param name="original">元になるグループ設定</param>
            public Param( Param original )
            {
                if( original == null )
                {
                    throw new ArgumentNullException( "original" );
                }

                this.GroupId = original.GroupId;
                this.GroupName = original.GroupName;
            }
        }
    }
}
