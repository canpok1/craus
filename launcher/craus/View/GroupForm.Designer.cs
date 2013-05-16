namespace Craus.View
{
    partial class GroupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MessageArea = new System.Windows.Forms.Label();
            this.GroupView = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // MessageArea
            // 
            this.MessageArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageArea.AutoSize = true;
            this.MessageArea.Location = new System.Drawing.Point(12, 178);
            this.MessageArea.Name = "MessageArea";
            this.MessageArea.Size = new System.Drawing.Size(58, 12);
            this.MessageArea.TabIndex = 0;
            this.MessageArea.Text = "Escで終了";
            // 
            // GroupView
            // 
            this.GroupView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupView.Location = new System.Drawing.Point(14, 13);
            this.GroupView.Multiline = true;
            this.GroupView.Name = "GroupView";
            this.GroupView.Size = new System.Drawing.Size(244, 151);
            this.GroupView.TabIndex = 1;
            this.GroupView.Text = "Group";
            // 
            // GroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 199);
            this.Controls.Add(this.GroupView);
            this.Controls.Add(this.MessageArea);
            this.Name = "GroupForm";
            this.Text = "GroupForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GroupForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GroupForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MessageArea;
        private System.Windows.Forms.TextBox GroupView;
    }
}