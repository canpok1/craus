using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Craus.Util;
using Craus.Model;
using Craus.View;
using Craus.Controller;

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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( createStartForm() );

            logger.End();
        }

        /// <summary>
        /// 最初に表示するフォームを生成します。
        /// </summary>
        /// <returns>フォーム</returns>
        private static Form createStartForm()
        {
            var io = new SettingIO();
            var setting = io.Load();

            var controller = new GroupController();

            return new GroupForm( setting, controller );
        }
    }
}
