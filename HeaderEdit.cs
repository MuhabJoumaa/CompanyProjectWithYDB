using System;
using System.Data;
using System.Windows.Forms;
using Ydb.Sdk.Auth;
using Ydb.Sdk.Services.Table;
using Ydb.Sdk;

namespace CompanyProject
{
    public partial class HeaderEdit : Form
    {
        private int formType;
        private int editedID;
        private int formSituation;
        TwoTables parent;

        public HeaderEdit()
        {
            InitializeComponent();
        }

        public HeaderEdit(TwoTables parent, int formSituation, DataSet ds)
        {
            InitializeComponent();
            this.parent = parent;
            this.DepartamentComboBox.DataSource = ds.Tables[2];
            this.DepartamentComboBox.DisplayMember = "Name";
            this.formType = 0;
            this.formSituation = formSituation;
            this.Text = "Добавление заголовка";
        }

        public HeaderEdit(TwoTables parent, String id, String money, String date, String departaments_id, DataSet ds, int formSituation)
        {
            InitializeComponent();
            this.parent = parent;
            this.IDtextBox.Text = id;
            this.MoneyTextBox.Text = money;
            this.YearTextBox.Text = date;
            this.DepartamentComboBox.DataSource = ds.Tables[2];
            this.DepartamentComboBox.DisplayMember = "Name";
            this.DepartamentComboBox.SelectedItem = departaments_id;
            this.formType = 1;
            this.formSituation = formSituation;
            this.Text = "Редактирование заголовка";
            this.editedID = Convert.ToInt32(id);
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                String money = MoneyTextBox.Text;
                String date = YearTextBox.Text;
                DataRowView drv = drv = (DataRowView)DepartamentComboBox.SelectedItem;
                String deps_id = drv["id"].ToString();
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
                                yql = $"INSERT INTO expenses_header (id, money, year, departaments_id) VALUES ({id}, {money}, {date}, {deps_id});";
                            }
                            else if (this.formType == 1)
                                yql = $"UPDATE expenses_header SET money = {money}, year = {date}, departaments_id = {deps_id} WHERE id = {editedID};";
                        }
                        else if (this.formSituation == 1)
                        {
                            if (this.formType == 0)
                            {
                                String id = IDtextBox.Text;
                                yql = $"INSERT INTO plan_header (id, money, year, departaments_id) VALUES ({id}, {money}, {date}, {deps_id});";
                            }
                            else if (this.formType == 1)
                                yql = $"UPDATE plan_header SET money = {money}, year = {date}, departaments_id = {deps_id} WHERE id = {editedID};";
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
                parent.updateTableHeader();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void MoneyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != '.')
            {
                e.Handled = true;
            }
        }

        private void YearTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
