using System;
using System.Data;
using System.Windows.Forms;
using Ydb.Sdk.Auth;
using Ydb.Sdk.Services.Table;
using Ydb.Sdk;
using Ydb.Sdk.Value;

namespace CompanyProject
{
    public partial class GetParamsForm : Form
    {
        DataSet ds;
        DataTable dt;

        public GetParamsForm()
        {
            InitializeComponent();
            this.getExpenditures();
        }

        private async void getExpenditures()
        {
            this.ds = new DataSet();
            this.dt = new DataTable();
            DriverConfig config;
            Driver driver = null;
            ResultSet resultSet = null;
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
                    string yql = "SELECT * FROM expenditures";
                    return await session.ExecuteDataQuery(
                        query: yql,
                        txControl: TxControl.BeginSerializableRW().Commit()
                    );
                });
                response.Status.EnsureSuccess();
                var queryResponse = (ExecuteDataQueryResponse)response;
                resultSet = queryResponse.Result.ResultSets[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.ds.Reset();
            this.ds = resultSet.ToDataSet();
            this.dt = ds.Tables[0];
            this.DepsCheckedListBox.DataSource = this.ds.Tables[0];
            this.DepsCheckedListBox.DisplayMember = "Name";
            this.DepsCheckedListBox.ValueMember = "id";
        }

        private async void reportButton_Click(object sender, EventArgs e)
        {
            try
            {
                String date = textBox1.Text;
                String deps = "";
                foreach (object item in DepsCheckedListBox.CheckedItems)
                {
                    DataRowView drv = (DataRowView)item;
                    String deps_id = drv["id"].ToString();
                    deps += deps_id + ", ";
                }
                deps = deps.Substring(0, deps.Length - 2);
                DataSet ds1 = new DataSet();
                DataTable dt1 = new DataTable();
                DriverConfig config;
                Driver driver = null;
                ResultSet resultSet = null;
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
                        String yql = $"SELECT dp.name, ex.name, sum(exps.money) FROM expenses_header eh JOIN expenses exps ON exps.header_id = eh.id JOIN expenditures ex ON ex.id = exps.expenditures_id JOIN departments dp ON dp.id = eh.departaments_id WHERE eh.year = {date} AND ex.id IN({deps}) GROUP BY dp.name, ex.name";
                        return await session.ExecuteDataQuery(
                            query: yql,
                            txControl: TxControl.BeginSerializableRW().Commit()
                        );
                    });
                    response.Status.EnsureSuccess();
                    var queryResponse = (ExecuteDataQueryResponse)response;
                    resultSet = queryResponse.Result.ResultSets[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ds1.Reset();
                ds1 = resultSet.ToDataSet();
                dt1 = ds1.Tables[0];
                FormTable form = new FormTable(2, ds1);
                form.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void endButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != '.')
            {
                e.Handled = true;
            }
        }
    }
}
