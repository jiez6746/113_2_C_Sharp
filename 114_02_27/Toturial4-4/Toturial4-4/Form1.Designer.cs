namespace Toturial4_4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            distancetextbox = new TextBox();
            gastextBox = new TextBox();
            averagelabel = new Label();
            calculatebutton = new Button();
            exitbutton = new Button();
            loglistBox = new ListBox();
            button = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label1.Location = new Point(502, 210);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(159, 26);
            label1.TabIndex = 0;
            label1.Text = "輸入行駛里程數";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label2.Location = new Point(502, 300);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(159, 26);
            label2.TabIndex = 1;
            label2.Text = "消耗油量公升數";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label3.Location = new Point(506, 385);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(138, 26);
            label3.TabIndex = 2;
            label3.Text = "您的平均油耗";
            // 
            // distancetextbox
            // 
            distancetextbox.Location = new Point(811, 215);
            distancetextbox.Margin = new Padding(5);
            distancetextbox.Name = "distancetextbox";
            distancetextbox.Size = new Size(385, 34);
            distancetextbox.TabIndex = 3;
            // 
            // gastextBox
            // 
            gastextBox.Location = new Point(811, 300);
            gastextBox.Margin = new Padding(5);
            gastextBox.Name = "gastextBox";
            gastextBox.Size = new Size(385, 34);
            gastextBox.TabIndex = 4;
            // 
            // averagelabel
            // 
            averagelabel.BorderStyle = BorderStyle.Fixed3D;
            averagelabel.Location = new Point(811, 385);
            averagelabel.Name = "averagelabel";
            averagelabel.Size = new Size(262, 62);
            averagelabel.TabIndex = 5;
            averagelabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // calculatebutton
            // 
            calculatebutton.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            calculatebutton.Location = new Point(659, 530);
            calculatebutton.Name = "calculatebutton";
            calculatebutton.Size = new Size(183, 88);
            calculatebutton.TabIndex = 6;
            calculatebutton.Text = "計算";
            calculatebutton.UseVisualStyleBackColor = true;
            calculatebutton.Click += calculatebutton_Click;
            // 
            // exitbutton
            // 
            exitbutton.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            exitbutton.Location = new Point(1013, 530);
            exitbutton.Name = "exitbutton";
            exitbutton.Size = new Size(183, 88);
            exitbutton.TabIndex = 7;
            exitbutton.Text = "離開";
            exitbutton.UseVisualStyleBackColor = true;
            exitbutton.Click += exitbutton_Click;
            // 
            // loglistBox
            // 
            loglistBox.FormattingEnabled = true;
            loglistBox.ItemHeight = 26;
            loglistBox.Location = new Point(24, 210);
            loglistBox.Name = "loglistBox";
            loglistBox.Size = new Size(459, 342);
            loglistBox.TabIndex = 8;
            // 
            // button
            // 
            button.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            button.Location = new Point(141, 606);
            button.Name = "button";
            button.Size = new Size(183, 88);
            button.TabIndex = 9;
            button.Text = "總平均油耗";
            button.UseVisualStyleBackColor = true;
            button.Click += button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 780);
            Controls.Add(button);
            Controls.Add(loglistBox);
            Controls.Add(exitbutton);
            Controls.Add(calculatebutton);
            Controls.Add(averagelabel);
            Controls.Add(gastextBox);
            Controls.Add(distancetextbox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 136);
            Margin = new Padding(5);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox distancetextbox;
        private TextBox gastextBox;
        private Label averagelabel;
        private Button calculatebutton;
        private Button exitbutton;
        private ListBox loglistBox;
        private Button button;
    }
}
