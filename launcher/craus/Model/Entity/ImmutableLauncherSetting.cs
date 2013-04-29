using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Craus.Model.Entity
{
    /// <summary>
    /// ランチャー設定を保持する不変クラスです。
    /// </summary>
    public class ImmutableLauncherSetting
    {
        private LauncherSetting wrappedObj = null;

        /// <summary>
        /// 指定の設定を保持するインスタンスを生成します。
        /// </summary>
        /// <param name="wrappedObj">保持する設定</param>
        /// <exception cref="ArgumentNullException">引数がnullの場合</exception>
        public ImmutableLauncherSetting( LauncherSetting wrappedObj )
        {
            if( wrappedObj == null )
            {
                throw new ArgumentNullException( "wrappedObj" );
            }

            this.wrappedObj = new LauncherSetting( wrappedObj );
        }

        /// <summary>
        /// 保持している値を同じ値を持つ可変クラスに変換します。
        /// </summary>
        /// <returns>可変クラス</returns>
        public LauncherSetting ToMutable()
        {
            return new LauncherSetting( this.wrappedObj );
        }

        /// <summary>
        /// 設定値を文字列として取得します。
        /// </summary>
        /// <param name="key">設定名</param>
        /// <returns>設定値</returns>
        /// <exception cref="KeyNofFoundException">取得対象が未設定の場合</exception>
        public String GetString( LauncherSetting.Key key )
        {
            return this.wrappedObj.GetString( key );
        }

        /// <summary>
        /// 設定値を数値として取得します。
        /// </summary>
        /// <param name="key">設定名</param>
        /// <returns>設定値</returns>
        /// <exception cref="KeyNofFoundException">取得対象が未設定の場合</exception>
        /// <exception cref="FormatException">設定値が数値でない場合</exception>
        public int GetInt( LauncherSetting.Key key )
        {
            return this.wrappedObj.GetInt( key );
        }
    }
}
