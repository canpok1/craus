using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Craus.Util;
using Craus.Model;
using Craus.View;

namespace Craus
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            LogUtil.SetFactory( new StandardLoggerFactory( ConsoleLogger.LogLevel.DEBUG ) );

            ILogger logger = LogUtil.GetLogger();

            logger.Start();
            logger.Debug( "DEBUGレベルは出力対象" );
            logger.Info( "INFOレベルは出力対象" );
            logger.Warn( new Exception( "WARNレベルは出力対象" ) );
            logger.Fatal( new Exception( "FATALレベルは出力対象" ) );

            CommandExecuter executer = new CommandExecuter();
            executer.Execute( "calc", "" );

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new GroupForm() );

            logger.End();

        }
    }
}
