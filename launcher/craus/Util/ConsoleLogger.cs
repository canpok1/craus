using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Craus.Util;
using System.Diagnostics;

namespace craus.Util
{
    /// <summary>
    /// コンソールに出力するロガーです。
    /// </summary>
    class ConsoleLogger : ILogger
    {
        public enum LogLevel
        {
            DEBUG,
            INFO,
            WARN,
            FATAL
        };

        /// <summary>
        /// 出力対象クラス
        /// </summary>
        private Type classType;

        /// <summary>
        /// 出力するログレベル
        /// </summary>
        private LogLevel level;

        /// <summary>
        /// 指定クラス用のロガーを生成します。
        /// </summary>
        /// <param name="classType">クラス種別</param>
        /// <param name="level">出力するログレベル</param>
        public ConsoleLogger( Type classType, LogLevel level )
        {
            if( classType == null )
            {
                throw new ArgumentNullException( "classType" );
            }

            this.classType = classType;
            this.level = level;
        }

        public void Start()
        {
            if( this.level == LogLevel.DEBUG )
            {
                // 呼び出し元のメソッド名を取得
                StackFrame callerFrame = new StackFrame( 1 );
                String methodName = callerFrame.GetMethod().Name;

                this.Log( methodName + " 開始" );
            }
        }

        public void End()
        {
            if( this.level == LogLevel.DEBUG )
            {
                // 呼び出し元のメソッド名を取得
                StackFrame callerFrame = new StackFrame( 1 );
                String methodName = callerFrame.GetMethod().Name;

                this.Log( methodName + " 終了" );
            }
        }

        public void Debug( String msg )
        {
            if( this.level == LogLevel.DEBUG )
            {
                // 呼び出し元のメソッド名を取得
                StackFrame callerFrame = new StackFrame( 1 );
                String methodName = callerFrame.GetMethod().Name;

                this.Log( methodName + " " + msg );
            }
        }

        public void Info( String msg )
        {
            if( this.level == LogLevel.DEBUG
                || this.level == LogLevel.INFO )
            {
                // 呼び出し元のメソッド名を取得
                StackFrame callerFrame = new StackFrame( 1 );
                String methodName = callerFrame.GetMethod().Name;

                this.Log( methodName + " " + msg );
            }
        }

        public void Warn( Exception e )
        {
            if( this.level == LogLevel.DEBUG
                || this.level == LogLevel.INFO
                || this.level == LogLevel.WARN )
            {
                // 呼び出し元のメソッド名を取得
                StackFrame callerFrame = new StackFrame( 1 );
                String methodName = callerFrame.GetMethod().Name;

                this.Log( methodName + " " + e.Message );
            }
        }

        public void Fatal( Exception e )
        {
            if( this.level == LogLevel.DEBUG
                || this.level == LogLevel.INFO
                || this.level == LogLevel.WARN
                || this.level == LogLevel.FATAL )
            {
                // 呼び出し元のメソッド名を取得
                StackFrame callerFrame = new StackFrame( 1 );
                String methodName = callerFrame.GetMethod().Name;

                this.Log( methodName + " " + e.Message );
            }
        }

        /// <summary>
        /// ログを出力します。
        /// </summary>
        /// <param name="msg">出力メッセージ</param>
        private void Log( String msg )
        {
            switch( this.level )
            {
                case LogLevel.DEBUG:
                    System.Console.WriteLine( "[DEBUG]" + msg );
                    break;
                case LogLevel.INFO:
                    System.Console.WriteLine( "[INFO ]" + msg );
                    break;
                case LogLevel.WARN:
                    System.Console.WriteLine( "[WARN ]" + msg );
                    break;
                case LogLevel.FATAL:
                    System.Console.WriteLine( "[FATAL]" + msg );
                    break;
            }
        }
    }
}
