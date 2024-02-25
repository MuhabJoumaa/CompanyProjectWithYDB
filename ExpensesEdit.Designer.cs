namespace CompanyProject
{
    partial class ExpensesEdit
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
            MoneyTextBox = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            exitButton = new System.Windows.Forms.Button();
            saveButton = new System.Windows.Forms.Button();
            IDtextBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            expendituresComboBox = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            headerTextBox = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // MoneyTextBox
            // 
            MoneyTextBox.Location = new System.Drawing.Point(136, 143);
            MoneyTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MoneyTextBox.Name = "MoneyTextBox";
            MoneyTextBox.Size = new System.Drawing.Size(209, 23);
            MoneyTextBox.TabIndex = 21;
            MoneyTextBox.KeyPress += MoneyTextBox_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(166, 125);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(113, 15);
            label3.TabIndex = 20;
            label3.Text = "Потрачено средств";
            // 
            // exitButton
            // 
            exitButton.Location = new System.Drawing.Point(131, 269);
            exitButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            exitButton.Name = "exitButton";
            exitButton.Size = new System.Drawing.Size(210, 27);
            exitButton.TabIndex = 19;
            exitButton.Text = "Выйти";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new System.Drawing.Point(131, 235);
            saveButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            saveButton.Name = "saveButton";
            saveButton.Size = new System.Drawing.Size(210, 27);
            saveButton.TabIndex = 18;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // IDtextBox
            // 
            IDtextBox.Location = new System.Drawing.Point(136, 36);
            IDtextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            IDtextBox.Name = "IDtextBox";
            IDtextBox.Size = new System.Drawing.Size(209, 23);
            IDtextBox.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(234, 17);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(17, 15);
            label1.TabIndex = 14;
            label1.Text = "id";
            // 
            // expendituresComboBox
            // 
            expendituresComboBox.FormattingEnabled = true;
            expendituresComboBox.Location = new System.Drawing.Point(29, 204);
            expendituresComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            expendituresComboBox.Name = "expendituresComboBox";
            expendituresComboBox.Size = new System.Drawing.Size(460, 23);
            expendituresComboBox.TabIndex = 25;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(196, 186);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(80, 15);
            label5.TabIndex = 26;
            label5.Text = "Статья затрат";
            // 
            // headerTextBox
            // 
            headerTextBox.Enabled = false;
            headerTextBox.Location = new System.Drawing.Point(135, 81);
            headerTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            headerTextBox.Name = "headerTextBox";
            headerTextBox.Size = new System.Drawing.Size(209, 23);
            headerTextBox.TabIndex = 28;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(205, 62);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(75, 15);
            label2.TabIndex = 27;
            label2.Text = "id заголовка";
            // 
            // ExpensesEdit
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(509, 312);
            Controls.Add(headerTextBox);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(expendituresComboBox);
            Controls.Add(MoneyTextBox);
            Controls.Add(label3);
            Controls.Add(exitButton);
            Controls.Add(saveButton);
            Controls.Add(IDtextBox);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ExpensesEdit";
            Text = "ExpensesEdit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox MoneyTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox IDtextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox expendituresComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox headerTextBox;
        private System.Windows.Forms.Label label2;
    }
}