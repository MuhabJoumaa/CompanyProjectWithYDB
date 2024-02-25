namespace CompanyProject
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.departaments_button = new System.Windows.Forms.Button();
            this.expenditures_button = new System.Windows.Forms.Button();
            this.expenses_button = new System.Windows.Forms.Button();
            this.report_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.planButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // departaments_button
            // 
            this.departaments_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.departaments_button.Location = new System.Drawing.Point(193, 12);
            this.departaments_button.Name = "departaments_button";
            this.departaments_button.Size = new System.Drawing.Size(170, 72);
            this.departaments_button.TabIndex = 0;
            this.departaments_button.Text = "Отделы";
            this.departaments_button.UseVisualStyleBackColor = true;
            this.departaments_button.Click += new System.EventHandler(this.departaments_button_Click);
            // 
            // expenditures_button
            // 
            this.expenditures_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expenditures_button.Location = new System.Drawing.Point(193, 90);
            this.expenditures_button.Name = "expenditures_button";
            this.expenditures_button.Size = new System.Drawing.Size(170, 72);
            this.expenditures_button.TabIndex = 1;
            this.expenditures_button.Text = "Статьи затрат";
            this.expenditures_button.UseVisualStyleBackColor = true;
            this.expenditures_button.Click += new System.EventHandler(this.expenditures_button_Click);
            // 
            // expenses_button
            // 
            this.expenses_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expenses_button.Location = new System.Drawing.Point(193, 246);
            this.expenses_button.Name = "expenses_button";
            this.expenses_button.Size = new System.Drawing.Size(170, 72);
            this.expenses_button.TabIndex = 2;
            this.expenses_button.Text = "Учет расходов";
            this.expenses_button.UseVisualStyleBackColor = true;
            this.expenses_button.Click += new System.EventHandler(this.expenses_button_Click);
            // 
            // report_button
            // 
            this.report_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.report_button.Location = new System.Drawing.Point(193, 324);
            this.report_button.Name = "report_button";
            this.report_button.Size = new System.Drawing.Size(170, 72);
            this.report_button.TabIndex = 3;
            this.report_button.Text = "Формирование отчета";
            this.report_button.UseVisualStyleBackColor = true;
            this.report_button.Click += new System.EventHandler(this.report_button_Click);
            // 
            // exit_button
            // 
            this.exit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit_button.Location = new System.Drawing.Point(193, 402);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(170, 72);
            this.exit_button.TabIndex = 4;
            this.exit_button.Text = "Выход";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // planButton
            // 
            this.planButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.planButton.Location = new System.Drawing.Point(193, 168);
            this.planButton.Name = "planButton";
            this.planButton.Size = new System.Drawing.Size(170, 72);
            this.planButton.TabIndex = 5;
            this.planButton.Text = "План расходов";
            this.planButton.UseVisualStyleBackColor = true;
            this.planButton.Click += new System.EventHandler(this.planButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 485);
            this.Controls.Add(this.planButton);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.report_button);
            this.Controls.Add(this.expenses_button);
            this.Controls.Add(this.expenditures_button);
            this.Controls.Add(this.departaments_button);
            this.Name = "Form1";
            this.Text = "Выбор таблицы";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button departaments_button;
        private System.Windows.Forms.Button expenditures_button;
        private System.Windows.Forms.Button expenses_button;
        private System.Windows.Forms.Button report_button;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Button planButton;
    }
}

