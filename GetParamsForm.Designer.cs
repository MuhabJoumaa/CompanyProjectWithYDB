namespace CompanyProject
{
    partial class GetParamsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.reportButton = new System.Windows.Forms.Button();
            this.DepsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.endButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Год";
            // 
            // reportButton
            // 
            this.reportButton.Location = new System.Drawing.Point(50, 176);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(200, 23);
            this.reportButton.TabIndex = 4;
            this.reportButton.Text = "Отчет";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // DepsCheckedListBox
            // 
            this.DepsCheckedListBox.FormattingEnabled = true;
            this.DepsCheckedListBox.Location = new System.Drawing.Point(307, 29);
            this.DepsCheckedListBox.Name = "DepsCheckedListBox";
            this.DepsCheckedListBox.Size = new System.Drawing.Size(312, 199);
            this.DepsCheckedListBox.TabIndex = 5;
            // 
            // endButton
            // 
            this.endButton.Location = new System.Drawing.Point(50, 205);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(200, 23);
            this.endButton.TabIndex = 6;
            this.endButton.Text = "Выход";
            this.endButton.UseVisualStyleBackColor = true;
            this.endButton.Click += new System.EventHandler(this.endButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Статьи затрат";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(103, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // GetParamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 256);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.endButton);
            this.Controls.Add(this.DepsCheckedListBox);
            this.Controls.Add(this.reportButton);
            this.Controls.Add(this.label1);
            this.Name = "GetParamsForm";
            this.Text = "Определите временной интервал и требуемые подразделения";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button reportButton;
        private System.Windows.Forms.CheckedListBox DepsCheckedListBox;
        private System.Windows.Forms.Button endButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
    }
}