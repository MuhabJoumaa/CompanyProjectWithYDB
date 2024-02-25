namespace CompanyProject
{
    partial class DepartamentsEdit
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
            label1 = new System.Windows.Forms.Label();
            IDtextBox = new System.Windows.Forms.TextBox();
            NametextBox = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            saveButton = new System.Windows.Forms.Button();
            exitButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(204, 38);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(17, 15);
            label1.TabIndex = 0;
            label1.Text = "id";
            // 
            // IDtextBox
            // 
            IDtextBox.Location = new System.Drawing.Point(106, 57);
            IDtextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            IDtextBox.Name = "IDtextBox";
            IDtextBox.Size = new System.Drawing.Size(209, 23);
            IDtextBox.TabIndex = 1;
            // 
            // NametextBox
            // 
            NametextBox.Location = new System.Drawing.Point(106, 134);
            NametextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NametextBox.Name = "NametextBox";
            NametextBox.Size = new System.Drawing.Size(209, 23);
            NametextBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(144, 115);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(130, 15);
            label2.TabIndex = 2;
            label2.Text = "Наименование отдела";
            // 
            // saveButton
            // 
            saveButton.Location = new System.Drawing.Point(106, 187);
            saveButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            saveButton.Name = "saveButton";
            saveButton.Size = new System.Drawing.Size(210, 27);
            saveButton.TabIndex = 4;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // exitButton
            // 
            exitButton.Location = new System.Drawing.Point(106, 220);
            exitButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            exitButton.Name = "exitButton";
            exitButton.Size = new System.Drawing.Size(210, 27);
            exitButton.TabIndex = 5;
            exitButton.Text = "Выйти";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // DepartamentsEdit
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(435, 314);
            Controls.Add(exitButton);
            Controls.Add(saveButton);
            Controls.Add(NametextBox);
            Controls.Add(label2);
            Controls.Add(IDtextBox);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "DepartamentsEdit";
            Text = "DepartamentsEdit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IDtextBox;
        private System.Windows.Forms.TextBox NametextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button exitButton;
    }
}