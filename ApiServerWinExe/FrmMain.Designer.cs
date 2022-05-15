namespace ApiServerWinExe
{
    partial class FrmMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPower = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkPretty = new System.Windows.Forms.CheckBox();
            this.lvLog = new System.Windows.Forms.ListView();
            this.clmId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDirection = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmMethod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmResource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmBody = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnShowDb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPower
            // 
            this.btnPower.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnPower.BackColor = System.Drawing.Color.Red;
            this.btnPower.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPower.Location = new System.Drawing.Point(12, 42);
            this.btnPower.Name = "btnPower";
            this.btnPower.Size = new System.Drawing.Size(114, 47);
            this.btnPower.TabIndex = 1;
            this.btnPower.Text = "停止中";
            this.btnPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPower.UseVisualStyleBackColor = false;
            this.btnPower.CheckedChanged += new System.EventHandler(this.BtnPower_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(648, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "リクエストURLは\"http://localhost/Temporary_Listen_Addresses/\"固定となります。";
            // 
            // chkPretty
            // 
            this.chkPretty.AutoSize = true;
            this.chkPretty.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkPretty.Location = new System.Drawing.Point(412, 42);
            this.chkPretty.Name = "chkPretty";
            this.chkPretty.Size = new System.Drawing.Size(177, 26);
            this.chkPretty.TabIndex = 3;
            this.chkPretty.Text = "PrettyResponse";
            this.chkPretty.UseVisualStyleBackColor = true;
            this.chkPretty.CheckedChanged += new System.EventHandler(this.ChkPretty_CheckedChanged);
            // 
            // lvLog
            // 
            this.lvLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmId,
            this.clmDirection,
            this.clmMethod,
            this.clmResource,
            this.clmBody});
            this.lvLog.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lvLog.FullRowSelect = true;
            this.lvLog.HideSelection = false;
            this.lvLog.Location = new System.Drawing.Point(16, 104);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(853, 334);
            this.lvLog.TabIndex = 4;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.View = System.Windows.Forms.View.Details;
            this.lvLog.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LvLog_MouseDoubleClick);
            // 
            // clmId
            // 
            this.clmId.Text = "Id";
            this.clmId.Width = 47;
            // 
            // clmDirection
            // 
            this.clmDirection.Text = "方向";
            // 
            // clmMethod
            // 
            this.clmMethod.Text = "Method";
            this.clmMethod.Width = 100;
            // 
            // clmResource
            // 
            this.clmResource.Text = "Resource";
            this.clmResource.Width = 127;
            // 
            // clmBody
            // 
            this.clmBody.Text = "Body";
            this.clmBody.Width = 413;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClearLog.Location = new System.Drawing.Point(132, 42);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(114, 47);
            this.btnClearLog.TabIndex = 5;
            this.btnClearLog.Text = "ログクリア";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.BtnClearLog_Click);
            // 
            // btnShowDb
            // 
            this.btnShowDb.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnShowDb.Location = new System.Drawing.Point(252, 42);
            this.btnShowDb.Name = "btnShowDb";
            this.btnShowDb.Size = new System.Drawing.Size(154, 47);
            this.btnShowDb.TabIndex = 6;
            this.btnShowDb.Text = "ユーザDB表示";
            this.btnShowDb.UseVisualStyleBackColor = true;
            this.btnShowDb.Click += new System.EventHandler(this.BtnShowDb_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 450);
            this.Controls.Add(this.btnShowDb);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.lvLog);
            this.Controls.Add(this.chkPretty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPower);
            this.MinimumSize = new System.Drawing.Size(689, 489);
            this.Name = "frmMain";
            this.Text = "簡易Apiサーバ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox btnPower;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkPretty;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader clmId;
        private System.Windows.Forms.ColumnHeader clmDirection;
        private System.Windows.Forms.ColumnHeader clmMethod;
        private System.Windows.Forms.ColumnHeader clmBody;
        private System.Windows.Forms.ColumnHeader clmResource;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnShowDb;
    }
}

