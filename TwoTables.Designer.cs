namespace CompanyProject
{
    partial class TwoTables
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьЗатратыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьЗатратыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьЗатратыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HeaderTable = new System.Windows.Forms.DataGridView();
            this.infoTable = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoTable)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripMenuItem,
            this.UpdateToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.добавитьЗатратыToolStripMenuItem,
            this.редактироватьЗатратыToolStripMenuItem,
            this.удалитьЗатратыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(796, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // AddToolStripMenuItem
            // 
            this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            this.AddToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.AddToolStripMenuItem.Text = "Добавить заголовок";
            this.AddToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
            // 
            // UpdateToolStripMenuItem
            // 
            this.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem";
            this.UpdateToolStripMenuItem.Size = new System.Drawing.Size(158, 20);
            this.UpdateToolStripMenuItem.Text = "Редактировать заголовок";
            this.UpdateToolStripMenuItem.Click += new System.EventHandler(this.UpdateToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.DeleteToolStripMenuItem.Text = "Удалить заголовок";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // добавитьЗатратыToolStripMenuItem
            // 
            this.добавитьЗатратыToolStripMenuItem.Name = "добавитьЗатратыToolStripMenuItem";
            this.добавитьЗатратыToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.добавитьЗатратыToolStripMenuItem.Text = "Добавить затраты";
            this.добавитьЗатратыToolStripMenuItem.Click += new System.EventHandler(this.добавитьЗатратыToolStripMenuItem_Click);
            // 
            // редактироватьЗатратыToolStripMenuItem
            // 
            this.редактироватьЗатратыToolStripMenuItem.Name = "редактироватьЗатратыToolStripMenuItem";
            this.редактироватьЗатратыToolStripMenuItem.Size = new System.Drawing.Size(145, 20);
            this.редактироватьЗатратыToolStripMenuItem.Text = "Редактировать затраты";
            this.редактироватьЗатратыToolStripMenuItem.Click += new System.EventHandler(this.редактироватьЗатратыToolStripMenuItem_Click);
            // 
            // удалитьЗатратыToolStripMenuItem
            // 
            this.удалитьЗатратыToolStripMenuItem.Name = "удалитьЗатратыToolStripMenuItem";
            this.удалитьЗатратыToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.удалитьЗатратыToolStripMenuItem.Text = "Удалить затраты";
            this.удалитьЗатратыToolStripMenuItem.Click += new System.EventHandler(this.удалитьЗатратыToolStripMenuItem_Click);
            // 
            // HeaderTable
            //
            this.HeaderTable.AllowUserToAddRows = false;
            this.HeaderTable.AllowUserToDeleteRows = false;
            this.HeaderTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.HeaderTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HeaderTable.Location = new System.Drawing.Point(12, 27);
            this.HeaderTable.Name = "HeaderTable";
            this.HeaderTable.ReadOnly = true;
            this.HeaderTable.Size = new System.Drawing.Size(780, 206);
            this.HeaderTable.TabIndex = 3;
            this.HeaderTable.SelectionChanged += new System.EventHandler(this.HeaderTable_SelectionChanged);
            // 
            // infoTable
            // 
            this.infoTable.AllowUserToAddRows = false;
            this.infoTable.AllowUserToDeleteRows = false;
            this.infoTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.infoTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.infoTable.Location = new System.Drawing.Point(12, 239);
            this.infoTable.Name = "infoTable";
            this.infoTable.ReadOnly = true;
            this.infoTable.Size = new System.Drawing.Size(780, 206);
            this.infoTable.TabIndex = 4;
            // 
            // TwoTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 453);
            this.Controls.Add(this.infoTable);
            this.Controls.Add(this.HeaderTable);
            this.Controls.Add(this.menuStrip1);
            this.Name = "TwoTables";
            this.Text = "TwoTables";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.DataGridView HeaderTable;
        private System.Windows.Forms.DataGridView infoTable;
        private System.Windows.Forms.ToolStripMenuItem добавитьЗатратыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьЗатратыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьЗатратыToolStripMenuItem;
    }
}