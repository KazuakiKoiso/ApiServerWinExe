namespace ApiServerWinExe
{
    partial class FrmLogDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblId = new System.Windows.Forms.Label();
            this.lblDirection = new System.Windows.Forms.Label();
            this.lblTimestamp = new System.Windows.Forms.Label();
            this.lblResource = new System.Windows.Forms.Label();
            this.lblMethod = new System.Windows.Forms.Label();
            this.lvHeader = new System.Windows.Forms.ListView();
            this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblId.Location = new System.Drawing.Point(12, 9);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(81, 22);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ログId：1";
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDirection.Location = new System.Drawing.Point(12, 43);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(109, 22);
            this.lblDirection.TabIndex = 3;
            this.lblDirection.Text = "方向：受信";
            // 
            // lblTimestamp
            // 
            this.lblTimestamp.AutoSize = true;
            this.lblTimestamp.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTimestamp.Location = new System.Drawing.Point(145, 9);
            this.lblTimestamp.Name = "lblTimestamp";
            this.lblTimestamp.Size = new System.Drawing.Size(175, 22);
            this.lblTimestamp.TabIndex = 1;
            this.lblTimestamp.Text = "日時：2022/02/22";
            // 
            // lblResource
            // 
            this.lblResource.AutoSize = true;
            this.lblResource.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblResource.Location = new System.Drawing.Point(362, 43);
            this.lblResource.Name = "lblResource";
            this.lblResource.Size = new System.Drawing.Size(173, 22);
            this.lblResource.TabIndex = 2;
            this.lblResource.Text = "対象リソース：User";
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMethod.Location = new System.Drawing.Point(145, 43);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(211, 22);
            this.lblMethod.TabIndex = 4;
            this.lblMethod.Text = "HTTPメソッド：DELETE";
            // 
            // lvHeader
            // 
            this.lvHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvHeader.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmValue});
            this.lvHeader.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lvHeader.FullRowSelect = true;
            this.lvHeader.HideSelection = false;
            this.lvHeader.Location = new System.Drawing.Point(16, 148);
            this.lvHeader.Name = "lvHeader";
            this.lvHeader.Size = new System.Drawing.Size(613, 137);
            this.lvHeader.TabIndex = 5;
            this.lvHeader.UseCompatibleStateImageBehavior = false;
            this.lvHeader.View = System.Windows.Forms.View.Details;
            // 
            // clmName
            // 
            this.clmName.Tag = "Name";
            this.clmName.Text = "Name";
            this.clmName.Width = 249;
            // 
            // clmValue
            // 
            this.clmValue.Tag = "Value";
            this.clmValue.Text = "Value";
            this.clmValue.Width = 233;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "HTTPヘッダ";
            // 
            // txtBody
            // 
            this.txtBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBody.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtBody.Location = new System.Drawing.Point(16, 314);
            this.txtBody.MaxLength = 65535;
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ReadOnly = true;
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBody.Size = new System.Drawing.Size(613, 261);
            this.txtBody.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(12, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "ボディ";
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblIp.Location = new System.Drawing.Point(12, 78);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(140, 22);
            this.lblIp.TabIndex = 7;
            this.lblIp.Text = "IP：192.168.0.0";
            // 
            // frmLogDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 587);
            this.Controls.Add(this.lblIp);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.lvHeader);
            this.Controls.Add(this.lblMethod);
            this.Controls.Add(this.lblResource);
            this.Controls.Add(this.lblTimestamp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.lblId);
            this.MinimumSize = new System.Drawing.Size(659, 546);
            this.Name = "FrmLogDetail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ログ詳細";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.Label lblTimestamp;
        private System.Windows.Forms.Label lblResource;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.ListView lvHeader;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.ColumnHeader clmValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblIp;
    }
}