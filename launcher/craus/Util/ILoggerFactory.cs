using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Craus.Util;

namespace Craus.Util
{
    /// <summary>
    /// ロガー生成機能を提供するインターフェースです。
    /// </summary>
    interface ILoggerFactory
    {
        /// <summary>
        /// ロガーを生成します。
        /// </summary>
        /// <param name="classType">ロガーを使用するクラス</param>
        /// <returns>ロガー</returns>
        ILogger Create( Type classType );
    }
}
