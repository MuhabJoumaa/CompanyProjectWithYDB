using System;
using System.Windows.Forms;
using Ydb.Sdk.Auth;
using Ydb.Sdk.Services.Table;
using Ydb.Sdk;

namespace CompanyProject
{
    public partial class ExpendituresEdit : Form
    {
        private int formType;
        private int editedID;
        FormTable parent;

        public ExpendituresEdit()
        {
            InitializeComponent();
            this.formType = 0;
        }

        public ExpendituresEdit(FormTable parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.formType = 0;
            this.Text = "Добавление статьи расходов";
        }

        public ExpendituresEdit(FormTable parent, String id, String name, String descr)
        {
            InitializeComponent();
            this.parent = parent;
            this.IDtextBox.Text = id;
            this.NametextBox.Text = name;
            this.DescriptionTextBox.Text = descr;
            this.editedID = Convert.ToInt32(id);
            this.formType = 1;
            this.Text = "Редактирование статьи расходов";
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            String id = IDtextBox.Text;
            String name = NametextBox.Text;
            String descr = DescriptionTextBox.Text;
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
                    if (this.formType == 0)
                    {
                        if (descr != "")
                            yql = $"INSERT INTO expenditures (id, name, description) VALUES ({id}, '{name}', '{descr}');";
                        else
                            yql = $"INSERT INTO expenditures (id, name) VALUES ({id}, '{name}');";
                    }
                    else if (this.formType == 1)
                    {
                        if (descr != "")
                            yql = $"UPDATE expenditures SET name = '{name}', description = '{descr}' WHERE id = {editedID};";
                        else
                            yql = $"UPDATE expenditures SET name = '{name}' WHERE id = {editedID};";
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
            parent.updateTable();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
