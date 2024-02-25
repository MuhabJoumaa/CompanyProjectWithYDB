namespace CompanyProject
{
    partial class ExpendituresEdit
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
            exitButton = new System.Windows.Forms.Button();
            saveButton = new System.Windows.Forms.Button();
            NametextBox = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            IDtextBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            DescriptionTextBox = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // exitButton
            // 
            exitButton.Location = new System.Drawing.Point(110, 255);
            exitButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            exitButton.Name = "exitButton";
            exitButton.Size = new System.Drawing.Size(210, 27);
            exitButton.TabIndex = 11;
            exitButton.Text = "Выйти";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new System.Drawing.Point(110, 222);
            saveButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            saveButton.Name = "saveButton";
            saveButton.Size = new System.Drawing.Size(210, 27);
            saveButton.TabIndex = 10;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // NametextBox
            // 
            NametextBox.Location = new System.Drawing.Point(4, 106);
            NametextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NametextBox.Name = "NametextBox";
            NametextBox.Size = new System.Drawing.Size(460, 23);
            NametextBox.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(121, 88);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(182, 15);
            label2.TabIndex = 8;
            label2.Text = "Наименование статьи расходов";
            // 
            // IDtextBox
            // 
            IDtextBox.Location = new System.Drawing.Point(110, 29);
            IDtextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            IDtextBox.Name = "IDtextBox";
            IDtextBox.Size = new System.Drawing.Size(209, 23);
            IDtextBox.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(208, 10);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(17, 15);
            label1.TabIndex = 6;
            label1.Text = "id";
            // 
            // DescriptionTextBox
            // 
            DescriptionTextBox.Location = new System.Drawing.Point(4, 170);
            DescriptionTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            DescriptionTextBox.Name = "DescriptionTextBox";
            DescriptionTextBox.Size = new System.Drawing.Size(460, 23);
            DescriptionTextBox.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(121, 151);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(154, 15);
            label3.TabIndex = 12;
            label3.Text = "Описание статьи расходов";
            // 
            // ExpendituresEdit
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(478, 338);
            Controls.Add(DescriptionTextBox);
            Controls.Add(label3);
            Controls.Add(exitButton);
            Controls.Add(saveButton);
            Controls.Add(NametextBox);
            Controls.Add(label2);
            Controls.Add(IDtextBox);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ExpendituresEdit";
            Text = "ExpendituresEdit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox NametextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IDtextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label label3;
    }
}