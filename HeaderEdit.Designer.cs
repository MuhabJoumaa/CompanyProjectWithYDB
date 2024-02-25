namespace CompanyProject
{
    partial class HeaderEdit
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
            IDtextBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            YearTextBox = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            MoneyTextBox = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            DepartamentComboBox = new System.Windows.Forms.ComboBox();
            exitButton = new System.Windows.Forms.Button();
            saveButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // IDtextBox
            // 
            IDtextBox.Location = new System.Drawing.Point(118, 29);
            IDtextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            IDtextBox.Name = "IDtextBox";
            IDtextBox.Size = new System.Drawing.Size(209, 23);
            IDtextBox.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(204, 10);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(17, 15);
            label1.TabIndex = 16;
            label1.Text = "id";
            // 
            // YearTextBox
            // 
            YearTextBox.Location = new System.Drawing.Point(118, 93);
            YearTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            YearTextBox.Name = "YearTextBox";
            YearTextBox.Size = new System.Drawing.Size(209, 23);
            YearTextBox.TabIndex = 19;
            YearTextBox.KeyPress += YearTextBox_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(204, 75);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(26, 15);
            label2.TabIndex = 18;
            label2.Text = "Год";
            // 
            // MoneyTextBox
            // 
            MoneyTextBox.Location = new System.Drawing.Point(118, 155);
            MoneyTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MoneyTextBox.Name = "MoneyTextBox";
            MoneyTextBox.Size = new System.Drawing.Size(209, 23);
            MoneyTextBox.TabIndex = 21;
            MoneyTextBox.Text = "0";
            MoneyTextBox.KeyPress += MoneyTextBox_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(201, 136);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(45, 15);
            label3.TabIndex = 20;
            label3.Text = "Сумма";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(204, 201);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(40, 15);
            label6.TabIndex = 30;
            label6.Text = "Отдел";
            // 
            // DepartamentComboBox
            // 
            DepartamentComboBox.FormattingEnabled = true;
            DepartamentComboBox.Location = new System.Drawing.Point(31, 219);
            DepartamentComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            DepartamentComboBox.Name = "DepartamentComboBox";
            DepartamentComboBox.Size = new System.Drawing.Size(398, 23);
            DepartamentComboBox.TabIndex = 29;
            // 
            // exitButton
            // 
            exitButton.Location = new System.Drawing.Point(118, 301);
            exitButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            exitButton.Name = "exitButton";
            exitButton.Size = new System.Drawing.Size(210, 27);
            exitButton.TabIndex = 32;
            exitButton.Text = "Выйти";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new System.Drawing.Point(118, 268);
            saveButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            saveButton.Name = "saveButton";
            saveButton.Size = new System.Drawing.Size(210, 27);
            saveButton.TabIndex = 31;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // HeaderEdit
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(441, 340);
            Controls.Add(exitButton);
            Controls.Add(saveButton);
            Controls.Add(label6);
            Controls.Add(DepartamentComboBox);
            Controls.Add(MoneyTextBox);
            Controls.Add(label3);
            Controls.Add(YearTextBox);
            Controls.Add(label2);
            Controls.Add(IDtextBox);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "HeaderEdit";
            Text = "HeaderEdit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox IDtextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox YearTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MoneyTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox DepartamentComboBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button saveButton;
    }
}