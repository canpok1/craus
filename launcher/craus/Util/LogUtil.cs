using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Craus.Util
{
    /// <summary>
    /// ログ関係の処理を行うクラスです。
    /// </summary>
    public static class LogUtil
    {
        /// <summary>
        /// ロガーファクトリー
        /// </summary>
        private static ILoggerFactory factory
            = new StandardLoggerFactory( ConsoleLogger.LogLevel.DEBUG );

        public static ILogger GetLogger()
        {
            StackFrame callerFrame = new StackFrame( 1 );
            Type type = callerFrame.GetMethod().ReflectedType;

            return factory.Create( type );
        }

        public static void SetFactory( ILoggerFactory factory )
        {
            if( factory == null )
            {
                throw new ArgumentNullException( "factory" );
            }

            LogUtil.factory = factory;
        }
    }
}
