using System;
using System.Data;
using System.Windows.Forms;
using Ydb.Sdk.Auth;
using Ydb.Sdk.Services.Table;
using Ydb.Sdk;

namespace CompanyProject
{
    public partial class ExpensesEdit : Form
    {
        private int formType;
        private int editedID;
        private int formSituation;
        TwoTables parent;

        public ExpensesEdit()
        {
            InitializeComponent();
            this.formType = 0;
        }

        public ExpensesEdit(TwoTables parent, String header_id, DataSet ds, int formSituation)
        {
            InitializeComponent();
            this.parent = parent;
            this.headerTextBox.Text = header_id;    
            this.expendituresComboBox.DataSource = ds.Tables[1];
            this.expendituresComboBox.DisplayMember = "Name";
            this.formType = 0;
            this.Text = "Добавление затраты";
            this.formSituation = formSituation;
        }

        public ExpensesEdit(TwoTables parent, String id, String header_id, String money, String expenditures_id, DataSet ds,int formSituation)
        {
            InitializeComponent();
            this.parent = parent;
            this.IDtextBox.Text = id;
            this.headerTextBox.Text = header_id;
            this.MoneyTextBox.Text = money;
            this.expendituresComboBox.DataSource = ds.Tables[1];
            this.expendituresComboBox.DisplayMember = "Name";
            this.expendituresComboBox.ValueMember = "id";
            this.expendituresComboBox.SelectedItem = expenditures_id;
            this.editedID = Convert.ToInt32(id);
            this.formType = 1;
            this.Text = "Редактирование затраты";
            this.formSituation = formSituation;
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                String header_id = headerTextBox.Text;
                String money = MoneyTextBox.Text;
                DataRowView drv = (DataRowView)expendituresComboBox.SelectedItem;
                String expend_id = drv["id"].ToString();
                String yql = "";
                DriverConfig config;
                Driver driver = null;
                try
                {
                    config = new DriverConfig(
                        endpoint: Program.endpoint,
                        database: Program.database,
                        credentials: new TokenProvider(Program.token)
                    );
                    driver = await Driver.CreateInitialized(config);
                    var tableClient = new TableClient(driver, new TableClientConfig());
                    var response = await tableClient.SessionExec(async session =>
                    {
                        if (this.formSituation == 0)
                        {
                            if (this.formType == 0)
                            {
                                String id = IDtextBox.Text;
                                yql = $"INSERT INTO expenses (id, money, expenditures_id, header_id) VALUES ({id}, {money}, {expend_id}, {header_id});";
                            }
                            else if (this.formType == 1)
                                yql = $"UPDATE expenses SET money = {money}, expenditures_id = {expend_id}, header_id = {header_id} WHERE id = {editedID};";
                        }
                        else if (this.formSituation == 1)
                        {
                            if (this.formType == 0)
                            {
                                String id = IDtextBox.Text;
                                yql = $"INSERT INTO plan (id, money, expenditures_id, header_id) VALUES ({id}, {money}, {expend_id}, {header_id});";
                            }
                            else if (this.formType == 1)
                                yql = $"UPDATE plan SET money = {money}, expenditures_id = {expend_id}, header_id = {header_id} WHERE id = {editedID};";
                        }
                        return await session.ExecuteDataQuery(
                            query: yql,
                            txControl: TxControl.BeginSerializableRW().Commit()
                        );
                    });
                    response.Status.EnsureSuccess();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                parent.updateTableFooter();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void MoneyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != '.') 
            {
                e.Handled = true;
            }
        }
    }
}
