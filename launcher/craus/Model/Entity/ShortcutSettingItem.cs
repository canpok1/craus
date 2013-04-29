using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Craus.Model.Entity
{
    /// <summary>
    /// ショートカット毎の設定
    /// </summary>
    public class ShortcutSettingItem
    {
        /// <summary>
        /// 設定値
        /// </summary>
        private Param param = null;

        /// <summary>
        /// ショートカット毎の設定を生成します。
        /// </summary>
        /// <param name="param">設定値</param>
        /// <exception cref="ArgumentNullException">引数がnullの場合</exception>
        public ShortcutSettingItem( Param param )
        {
            if( param == null )
            {
                throw new ArgumentNullException( "param" );
            }

            if( !this.checkArgShortcutId( param.ShortcutId ) )
            {
                throw new ArgumentException( "param.ShortcutIdが不正" );
            }

            if( !this.checkArgPath( param.Path ) )
            {
                throw new ArgumentException( "param.Pathが不正" );
            }

            if( !this.checkArgOption( param.Option ) )
            {
                throw new ArgumentException( "param.Optionが不正" );
            }

            if( !this.checkArgGroupId( param.GroupId ) )
            {
                throw new ArgumentException( "param.GroupIdが不正" );
            }

            this.param = new Param( param );
        }

        /// <summary>
        /// ショートカットIDが適切かの確認
        /// </summary>
        /// <param name="arg">ショートカットID</param>
        /// <returns>適切:true 不適切:false</returns>
        private Boolean checkArgShortcutId( int arg )
        {
            if( arg < 0 )
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// パスが適切かの確認
        /// </summary>
        /// <param name="arg">パス</param>
        /// <returns>適切:true 不適切:false</returns>
        private Boolean checkArgPath( String arg )
        {
            if( String.IsNullOrEmpty( arg ) )
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// オプションが適切かの確認
        /// </summary>
        /// <param name="arg">オプション</param>
        /// <returns>適切:true 不適切:false</returns>
        private Boolean checkArgOption( String arg )
        {
            if( arg == null )
            {
                return false;
            }

            return true;
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
        /// ショートカットIDを取得
        /// </summary>
        /// <returns>ショートカットID</returns>
        public int GetShortcutId()
        {
            return this.param.ShortcutId;
        }

        /// <summary>
        /// パスを取得
        /// </summary>
        /// <returns>パス</returns>
        public String GetPath()
        {
            return this.param.Path;
        }

        /// <summary>
        /// オプションを取得
        /// </summary>
        /// <returns>オプション</returns>
        public String GetOption()
        {
            return this.param.Option;
        }

        /// <summary>
        /// ショートカットが属するグループIDを取得
        /// </summary>
        /// <returns>グループID</returns>
        public int GetGroupId()
        {
            return this.param.GroupId;
        }

        /// <summary>
        /// ショートカット用の設定値
        /// </summary>
        public class Param
        {
            /// <summary>ショートカットのID</summary>
            public int ShortcutId { set; get; }

            /// <summary>ショートカットのパス</summary>
            public String Path { set; get; }

            /// <summary>ショートカットのオプション</summary>
            public String Option { set; get; }

            /// <summary>ショートカットのグループのID</summary>
            public int GroupId { set; get; }

            /// <summary>
            /// 無効な値を格納したパラメータを作成します。
            /// </summary>
            public Param()
            {
                this.ShortcutId = -1;
                this.Path = null;
                this.Option = null;
                this.GroupId = -1;
            }

            /// <summary>
            /// 同じ値を格納したパラメータを作成します。
            /// </summary>
            /// <param name="original">元になるパラメータ</param>
            public Param( Param original )
            {
                if( original == null )
                {
                    throw new ArgumentNullException( "param" );
                }

                this.ShortcutId = original.ShortcutId;
                this.Path = original.Path;
                this.Option = original.Option;
                this.GroupId = original.GroupId;
            }


        }
    }
}
