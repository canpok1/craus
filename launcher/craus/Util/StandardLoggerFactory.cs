using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Craus.Util;

namespace Craus.Util
{
    /// <summary>
    /// コンソールに出力するロガーを生成するクラスです。
    /// </summary>
    public class StandardLoggerFactory : ILoggerFactory
    {
        /// <summary>
        /// 出力するログレベル
        /// </summary>
        private ConsoleLogger.LogLevel level;

        /// <summary>
        /// ログファクトリーを生成します。
        /// </summary>
        /// <param name="level">出力するログレベル</param>
        public StandardLoggerFactory( ConsoleLogger.LogLevel level )
        {
            this.level = level;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classType"></param>
        /// <returns></returns>
        public ILogger Create( Type classType )
        {
            return new ConsoleLogger( classType, level );
        }
    }
}
