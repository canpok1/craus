using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Craus.Util;

namespace Craus.Controller
{
    /// <summary>
    /// グループ系の操作クラス
    /// </summary>
    public class GroupController
    {
        private ILogger logger = null;

        /// <summary>
        /// 初期設定
        /// </summary>
        public GroupController()
        {
            this.logger = LogUtil.GetLogger();
        }

        /// <summary>
        /// 指定グループのショートカットを表示します。
        /// </summary>
        public void ViewShortcutList()
        {
            try
            {
                this.logger.Start();

                // TODO [実装]
            }
            finally
            {
                this.logger.End();
            }
        }

        /// <summary>
        /// グループの表示を終了します。
        /// </summary>
        public void ExitGroupView()
        {
            try
            {
                this.logger.Start();

                // TODO [実装]
            }
            finally
            {
                this.logger.End();
            }
        }
    }
}
