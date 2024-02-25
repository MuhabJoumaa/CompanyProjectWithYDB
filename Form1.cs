using System;
using System.Windows.Forms;

namespace CompanyProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void expenditures_button_Click(object sender, EventArgs e)
        {
            FormTable formTable = new FormTable(1);
            formTable.Show();
        }

        private void expenses_button_Click(object sender, EventArgs e)
        {
            TwoTables form = new TwoTables(0);
            form.Show();
        }

        private void departaments_button_Click(object sender, EventArgs e)
        {
            FormTable formTable = new FormTable(0);
            formTable.Show();
        }

        private void report_button_Click(object sender, EventArgs e)
        {
            GetParamsForm form = new GetParamsForm();   
            form.Show();    
        }

        private void planButton_Click(object sender, EventArgs e)
        {
            TwoTables form = new TwoTables(1);
            form.Show();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
