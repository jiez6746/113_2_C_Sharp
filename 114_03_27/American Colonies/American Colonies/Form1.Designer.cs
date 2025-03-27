namespace American_Colonies
{
    partial class Form1
    {
        /// <summary>
        /// 必需的設計器變量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的資源。
        /// </summary>
        /// <param name="disposing">如果應釋放托管資源，則為 true；否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 表單設計器生成的代碼

        /// <summary>
        /// 設計器支持所需的方法 - 請勿使用代碼編輯器修改此方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.exitButton = new System.Windows.Forms.Button();
            this.promptLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.selectionListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(143, 169);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "退出";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // promptLabel
            // 
            this.promptLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.promptLabel.Location = new System.Drawing.Point(22, 6);
            this.promptLabel.Name = "promptLabel";
            this.promptLabel.Size = new System.Drawing.Size(237, 39);
            this.promptLabel.TabIndex = 6;
            this.promptLabel.Text = "以下哪一個是美國最初的13個殖民地之一？";
            this.promptLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(62, 169);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "確定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // selectionListBox
            // 
            this.selectionListBox.FormattingEnabled = true;
            this.selectionListBox.Items.AddRange(new object[] {
            "阿拉巴馬",
            "佛羅里達",
            "喬治亞",
            "印第安納",
            "內布拉斯加",
            "田納西",
            "德克薩斯"});
            this.selectionListBox.Location = new System.Drawing.Point(35, 56);
            this.selectionListBox.Name = "selectionListBox";
            this.selectionListBox.Size = new System.Drawing.Size(214, 95);
            this.selectionListBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 199);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.promptLabel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.selectionListBox);
            this.Name = "Form1";
            this.Text = "美國殖民地";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label promptLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ListBox selectionListBox;
    }
}
