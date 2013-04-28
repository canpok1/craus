using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using craus.Util;
using Craus.Util;

namespace craus
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ILoggerFactory factory = new StandardLoggerFactory( ConsoleLogger.LogLevel.DEBUG );
            ILogger logger = factory.Create( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );

            logger.Start();
            logger.Debug( "デバッグ" );
            logger.Info( "インフォ" );
            logger.Warn( new Exception( "警告" ) );
            logger.Fatal( new Exception( "致命的" ) );

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            logger.End();

        }
    }
}
