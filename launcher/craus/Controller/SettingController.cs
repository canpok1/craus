using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Craus.Util;
using Craus.Model.Entity;
using Craus.Model;

namespace Craus.Controller
{
    /// <summary>
    /// 設定系の操作クラス
    /// </summary>
    public class SettingController
    {
        private ILogger logger = null;

        private SettingIO io = null;

        /// <summary>
        /// 初期設定
        /// </summary>
        /// <param name="io">設定操作クラス</param>
        public SettingController( SettingIO io )
        {
            if( io == null )
            {
                throw new ArgumentNullException( "io" );
            }

            this.logger = LogUtil.GetLogger();
            this.io = io;
        }

        /// <summary>
        /// 設定を保存します。
        /// </summary>
        /// <param name="setting">設定値</param>
        /// <exception cref="ArgumentNullException">引数がnull</exception>
        public void Save( SettingContainerForMutable setting )
        {
            if( setting == null )
            {
                throw new ArgumentNullException( "setting" );
            }

            if( this.io.Save( setting ) )
            {
                // TODO [実装]設定の保存に成功
            }
            else
            {
                // TODO [実装]設定の保存に失敗
            }

        }

        /// <summary>
        /// 設定保存をキャンセルします。
        /// </summary>
        public void Cancel()
        {
            // TODO [実装]
        }
    }
}
