using System;
using System.Windows.Forms;
using Ydb.Sdk.Auth;
using Ydb.Sdk.Services.Table;
using Ydb.Sdk;

namespace CompanyProject
{
    public partial class DepartamentsEdit : Form
    {
        private int formType;
        private int editedID;
        FormTable parent;

        public DepartamentsEdit()
        {
            InitializeComponent();
            this.formType = 0;
        }

        public DepartamentsEdit(FormTable parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.formType = 0;
            this.Text = "Добавление отдела";
        }

        public DepartamentsEdit(FormTable parent, String id, String name)
        {
            InitializeComponent();
            this.parent = parent;
            this.IDtextBox.Text = id;
            this.NametextBox.Text = name;
            this.editedID = Convert.ToInt32(id);
            this.formType = 1;
            this.Text = "Редактирование отдела";
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                String id = IDtextBox.Text;
                String name = NametextBox.Text;
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
                            yql = $"INSERT INTO departments (id, name) VALUES ({id}, '{name}');";
                        else if (this.formType == 1)
                            yql = $"UPDATE departments SET name = '{name}' WHERE id = {editedID};";
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
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
