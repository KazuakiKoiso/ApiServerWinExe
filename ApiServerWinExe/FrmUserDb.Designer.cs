namespace ApiServerWinExe
{
    partial class FrmUserDb
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
            this.lvDb = new System.Windows.Forms.ListView();
            this.clmId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmMail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvDb
            // 
            this.lvDb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDb.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmId,
            this.clmName,
            this.clmMail});
            this.lvDb.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lvDb.FullRowSelect = true;
            this.lvDb.HideSelection = false;
            this.lvDb.Location = new System.Drawing.Point(12, 12);
            this.lvDb.Name = "lvDb";
            this.lvDb.Size = new System.Drawing.Size(613, 281);
            this.lvDb.TabIndex = 0;
            this.lvDb.UseCompatibleStateImageBehavior = false;
            this.lvDb.View = System.Windows.Forms.View.Details;
            // 
            // clmId
            // 
            this.clmId.Tag = "Id";
            this.clmId.Text = "Id";
            // 
            // clmName
            // 
            this.clmName.Tag = "Name";
            this.clmName.Text = "Name";
            this.clmName.Width = 97;
            // 
            // clmMail
            // 
            this.clmMail.Tag = "Mail";
            this.clmMail.Text = "Mail";
            this.clmMail.Width = 216;
            // 
            // FrmUserDb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 309);
            this.Controls.Add(this.lvDb);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmUserDb";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ユーザDB";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUserDb_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvDb;
        private System.Windows.Forms.ColumnHeader clmId;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.ColumnHeader clmMail;
    }
}