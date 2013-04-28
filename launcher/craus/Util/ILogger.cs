using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Craus.Util
{
    /// <summary>
    /// ログ記録機能を提供するインターフェースです。
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// メソッド開始ログ
        /// </summary>
        void Start();

        /// <summary>
        /// メソッド終了ログ
        /// </summary>
        void End();

        /// <summary>
        /// DEBUGログ
        /// </summary>
        /// <param name="msg">ログメッセージ</param>
        void Debug( String msg );

        /// <summary>
        /// INFOログ
        /// </summary>
        /// <param name="msg">ログメッセージ</param>
        void Info( String msg );

        /// <summary>
        /// WARNログ
        /// </summary>
        /// <param name="e">出力する例外</param>
        void Warn( Exception e );

        /// <summary>
        /// FATALログ
        /// </summary>
        /// <param name="e">出力する例外</param>
        void Fatal( Exception e );
    }
}
