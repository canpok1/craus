using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Craus.Util;
using System.Diagnostics;

namespace Craus.Util
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

                this.Log( "開始", methodName, LogLevel.DEBUG );
            }
        }

        public void End()
        {
            if( this.level == LogLevel.DEBUG )
            {
                // 呼び出し元のメソッド名を取得
                StackFrame callerFrame = new StackFrame( 1 );
                String methodName = callerFrame.GetMethod().Name;

                this.Log( "終了", methodName, LogLevel.DEBUG );
            }
        }

        public void Debug( String msg )
        {
            if( this.level == LogLevel.DEBUG )
            {
                // 呼び出し元のメソッド名を取得
                StackFrame callerFrame = new StackFrame( 1 );
                String methodName = callerFrame.GetMethod().Name;

                this.Log( msg, methodName, LogLevel.DEBUG );
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

                this.Log( msg, methodName, LogLevel.INFO );
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

                this.Log( e.Message, methodName, LogLevel.WARN );
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

                this.Log( e.Message, methodName, LogLevel.FATAL );
            }
        }

        /// <summary>
        /// ログを出力します。
        /// </summary>
        /// <param name="msg">出力メッセージ</param>
        private void Log( String msg, String methodName, LogLevel level )
        {
            String levelString = "";
            switch( level )
            {
                case LogLevel.DEBUG:
                    levelString = "[DEBUG]";
                    break;
                case LogLevel.INFO:
                    levelString = "[INFO ]";
                    break;
                case LogLevel.WARN:
                    levelString = "[WARN ]";
                    break;
                case LogLevel.FATAL:
                    levelString = "[FATAL]";
                    break;
            }

            System.Console.WriteLine(
                                    levelString 
                                    + this.classType.ToString() 
                                    + "." + methodName
                                    + " " + msg );
        }
    }
}
