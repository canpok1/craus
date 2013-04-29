using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Craus.Util;
using System.Diagnostics;

namespace Craus.Model
{
    /// <summary>
    /// コマンドを実行するクラスです。
    /// </summary>
    public class CommandExecuter
    {
        private ILogger logger = null;

        public CommandExecuter()
        {
            this.logger = LogUtil.GetLogger();
        }


        /// <summary>
        /// コマンドを実行します。
        /// 以下のコードで生成されるコマンドが実行対象です。
        /// path + " " + param
        /// </summary>
        /// <param name="path">実行ファイル</param>
        /// <param name="param">オプション</param>
        /// <exception cref="ArgumentNullException">pathがnullの場合</exception>
        /// <exception cref="ArgumentException">pathが空文字の場合</exception>
        public void Execute( String path, String param )
        {
            // 引数チェック
            if( path == null )
            {
                throw new ArgumentNullException( "path" );
            }
            if( path == String.Empty )
            {
                throw new ArgumentException( "pathは空文字不可" );
            }

            try
            {
                this.logger.Start();

                ProcessStartInfo psInfo = new ProcessStartInfo();
                psInfo.FileName = CommandExecuter.BuildCommand( path, param );
                psInfo.CreateNoWindow = true;   // コンソールウィンドウを開かない
                psInfo.UseShellExecute = false; // シェル機能を使用しない

                this.logger.Debug( "コマンドを実行[" + psInfo.FileName + "]" );

                Process.Start( psInfo );
            }
            // TODO [実装]例外処理
            finally
            {
                this.logger.End();
            }
        }

        /// <summary>
        /// コマンドを組み立てます。
        /// 引数で渡されたパラメータをスペース区切りで連結します。
        /// </summary>
        /// <param name="commands">コマンド</param>
        /// <returns>コマンド</returns>
        public static String BuildCommand( params String[] commands )
        {
            StringBuilder commandBuilder = new StringBuilder();

            foreach( String param in commands )
            {
                if( commandBuilder.Length != 0 )
                {
                    commandBuilder.Append( " " );
                }
                commandBuilder.Append( param );
            }

            return commandBuilder.ToString();
        }
    }
}
