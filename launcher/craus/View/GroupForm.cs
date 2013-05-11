using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Craus.Util;
using Craus.Model.Entity;
using Craus.Controller;

namespace Craus.View
{
    public partial class GroupForm : Form
    {
        private ILogger logger = null;

        private List<GroupSettingItem> groups = null;

        /// <summary>
        /// フォームを生成します。
        /// </summary>
        /// <param name="setting">各種設定</param>
        /// <param name="controller">グループ用コントローラー</param>
        /// <exception cref="ArgumentNullException">引数がnullの場合</exception>
        public GroupForm( SettingContainerForImmutable setting, GroupController controller )
        {
            if( setting == null )
            {
                throw new ArgumentNullException( "setting" );
            }
            if( setting.GroupSetting == null )
            {
                throw new ArgumentNullException( "setting.GroupSetting" );
            }
            if( controller == null )
            {
                throw new ArgumentNullException( "controller" );
            }

            InitializeComponent();

            this.logger = LogUtil.GetLogger();
            this.groups = setting.GroupSetting.GetAll();

            // TODO [実装]各種イベントを実装
        }
    }
}
