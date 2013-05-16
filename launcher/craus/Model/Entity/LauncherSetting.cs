using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Craus.Model.Entity
{
    /// <summary>
    /// 設定値を保持するクラスです。
    /// </summary>
    public class LauncherSetting
    {
        /// <summary>
        /// 設定値の種別
        /// </summary>
        public enum Key
        {
            WINDOW_WIDTH,
            WINDOW_HEIGHT,
            SHORTCUT_CONF_FILE,
        }

        /// <summary>
        /// 設定値
        /// </summary>
        private Dictionary<Key, String> param = null;

        /// <summary>
        /// 何も登録されていない設定を生成します。
        /// </summary>
        public LauncherSetting()
        {
            this.param = new Dictionary<Key, string>();
        }

        /// <summary>
        /// 同じ設定値を持つインスタンスを生成します。
        /// </summary>
        /// <param name="original">元になる設定</param>
        /// <exception cref="ArgumentNullException">引数がnullの場合</exception>
        public LauncherSetting( LauncherSetting original )
        {
            if( original == null )
            {
                throw new ArgumentNullException( "original" );
            }

            this.param = new Dictionary<Key, string>( original.param );
        }

        /// <summary>
        /// 設定値を追加します。
        /// 追加済みの設定は上書きされます。
        /// </summary>
        /// <param name="key">設定名</param>
        /// <param name="value">値</param>
        /// <exception cref="ArgumentNullException">引数がnullの場合</exception>
        public void Set( Key key, String value )
        {
            if( value == null )
            {
                throw new ArgumentNullException( "value" );
            }

            if( this.param.ContainsKey( key ) )
            {
                this.param.Remove( key );
            }

            this.param.Add( key, value );
        }


        /// <summary>
        /// 設定値を追加します。
        /// 追加済みの設定は上書きされます。
        /// </summary>
        /// <param name="key">設定名</param>
        /// <param name="value">値</param>
        /// <exception cref="ArgumentNullException">引数がnullの場合</exception>
        public void Set( Key key, int value )
        {
            this.Set( key, value.ToString() );
        }

        /// <summary>
        /// 設定値を文字列として取得します。
        /// </summary>
        /// <param name="key">設定名</param>
        /// <returns>設定値</returns>
        /// <exception cref="KeyNofFoundException">取得対象が未設定の場合</exception>
        public String GetString( Key key )
        {
            if( this.param.ContainsKey( key ) )
            {
                return this.param[key];
            }
            else
            {
                throw new KeyNotFoundException( 
                    "[" + key + "]は未設定です。" );
            }
        }

        /// <summary>
        /// 設定値を数値として取得します。
        /// </summary>
        /// <param name="key">設定名</param>
        /// <returns>設定値</returns>
        /// <exception cref="KeyNofFoundException">取得対象が未設定の場合</exception>
        /// <exception cref="FormatException">設定値が数値でない場合</exception>
        public int GetInt( Key key )
        {
            String value = this.GetString( key );

            try
            {
                return int.Parse( value );
            }
            catch( Exception e )
            {
                throw new FormatException(
                    "[" + key + "]は非数値[" + value + "]",
                    e );
            }
        }
    }
}
