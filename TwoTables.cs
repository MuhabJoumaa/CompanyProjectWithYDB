using System;
using System.Data;
using System.Windows.Forms;
using Ydb.Sdk.Auth;
using Ydb.Sdk.Services.Table;
using Ydb.Sdk;
using Ydb.Sdk.Value;

namespace CompanyProject
{
    public partial class TwoTables : Form
    {
        private int formType;
        private DataSet ds_header;
        private DataTable dt_header;
        private DataSet ds_footer;
        private DataTable dt_footer;
        private string sql_header;
        private string sql_footer;
        private readonly static String[] types = { "Затраты", "План на год" };
        private readonly static String[] sqls_header = {"SELECT Eh.id, Eh.year, Eh.money, dp.name FROM expenses_header as Eh JOIN departments dp ON dp.id = Eh.departaments_id; SELECT * FROM expenditures; SELECT * FROM departments",
            "SELECT Eh.id, Eh.year, Eh.money, dp.name FROM plan_header as Eh JOIN departments dp ON dp.id = Eh.departaments_id; SELECT * FROM expenditures; SELECT * FROM departments"};
        
        public TwoTables()
        {
            InitializeComponent();
            if (this.HeaderTable.Rows.Count > 0)
            {
                this.HeaderTable.Rows[0].Selected = true;
            }
        }

        public TwoTables(int formType)
        {
            InitializeComponent();
            if (this.HeaderTable.Rows.Count > 0)
            {
                this.HeaderTable.Rows[0].Selected = true;
            }
            this.formType = formType;
            this.Text = types[this.formType];
            this.sql_header = sqls_header[this.formType];
            this.updateTableHeader();
        }

        public async void updateTableHeader()
        {
            try
            {
                ds_header = new DataSet();
                dt_header = new DataTable();
                DriverConfig config;
                Driver driver = null;
                ResultSet resultSet = null;
                string[] yqlQueries = this.sql_header.Split(';');
                ds_header.Reset();
                foreach (string yqlQuery in yqlQueries)
                {
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
                            return await session.ExecuteDataQuery(
                                query: yqlQuery,
                                txControl: TxControl.BeginSerializableRW().Commit()
                            );
                        });
                        response.Status.EnsureSuccess();
                        var queryResponse = (ExecuteDataQueryResponse)response;
                        resultSet = queryResponse.Result.ResultSets[0];
                        ds_header.Tables.Add(resultSet.ToDataTable());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                dt_header = ds_header.Tables[0];
                dt_header.Columns["Eh.id"].ColumnName = "id";
                dt_header.Columns["Eh.year"].ColumnName = "Год";
                dt_header.Columns["Eh.money"].ColumnName = "Сумма";
                dt_header.Columns["dp.name"].ColumnName = "Отдел";
                this.HeaderTable.DataSource = dt_header;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public async void updateTableFooter()
        {
            try
            {
                int selected_count = HeaderTable.SelectedRows.Count;
                if (selected_count >= 1)
                {
                    int ind = HeaderTable.SelectedRows[0].Index;
                    String id = HeaderTable.Rows[ind].Cells[0].Value.ToString();
                    ds_footer = new DataSet();
                    dt_footer = new DataTable();
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
                            if (this.formType == 0)
                                this.sql_footer = $"SELECT Eh.id, Eh.money, ex.name, Eh.header_id FROM expenses as Eh JOIN expenditures ex ON ex.id = Eh.expenditures_id WHERE header_id = {id};";
                            else if (this.formType == 1)
                                this.sql_footer = $"SELECT Eh.id, Eh.money, ex.name, Eh.header_id FROM plan as Eh JOIN expenditures ex ON ex.id = Eh.expenditures_id WHERE header_id = {id};";
                            return await session.ExecuteDataQuery(
                                query: this.sql_footer,
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
                    dt_footer.Reset();
                    ds_footer = resultSet.ToDataSet();
                    dt_footer = ds_footer.Tables[0];
                    dt_footer.Columns["Eh.id"].ColumnName = "id";
                    dt_footer.Columns["Eh.money"].ColumnName = "Сумма";
                    dt_footer.Columns["ex.name"].ColumnName = "Наименование статьи затрат";
                    dt_footer.Columns["Eh.header_id"].ColumnMapping = MappingType.Hidden;
                    infoTable.DataSource = dt_footer;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void HeaderTable_SelectionChanged(object sender, EventArgs e)
        {
            this.updateTableFooter();
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = null;
                int selected_count = HeaderTable.SelectedRows.Count;
                if (selected_count >= 1)
                {
                    int ind = HeaderTable.SelectedRows[0].Index;
                    String id = HeaderTable.Rows[ind].Cells[0].Value.ToString();
                    String date = HeaderTable.Rows[ind].Cells[1].Value.ToString();
                    String money = HeaderTable.Rows[ind].Cells[2].Value.ToString();
                    String departaments = HeaderTable.Rows[ind].Cells[3].Value.ToString();
                    form = new HeaderEdit(this, id, money, date, departaments, this.ds_header, this.formType);
                    form.ShowDialog();
                }
                else { MessageBox.Show("Выберите строку для изменения"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HeaderEdit form = new HeaderEdit(this, this.formType, this.ds_header);
            form.ShowDialog();
        }

        private void добавитьЗатратыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int selected_count = HeaderTable.SelectedRows.Count;
                if (selected_count >= 1)
                {
                    int ind = HeaderTable.SelectedRows[0].Index;
                    String header_id = HeaderTable.Rows[ind].Cells[0].Value.ToString();
                    ExpensesEdit form = new ExpensesEdit(this, header_id, this.ds_header, this.formType);
                    form.ShowDialog();
                }
                else { MessageBox.Show("Выберите строку в заголовке для добавления "); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void редактироватьЗатратыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int selected_count = infoTable.SelectedRows.Count;
                if (selected_count >= 1)
                {
                    int ind = infoTable.SelectedRows[0].Index;
                    int indHead = HeaderTable.SelectedRows[0].Index;
                    String id = infoTable.Rows[ind].Cells[0].Value.ToString();
                    String money = infoTable.Rows[ind].Cells[1].Value.ToString();
                    String expenditures = infoTable.Rows[ind].Cells[2].Value.ToString();
                    String header_id = HeaderTable.Rows[indHead].Cells[0].Value.ToString();
                    ExpensesEdit form = new ExpensesEdit(this, id, header_id, money, expenditures, this.ds_header, this.formType);
                    form.ShowDialog();
                }
                else { MessageBox.Show("Выберите строку для изменения"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int selected_count = HeaderTable.SelectedRows.Count;
                if (selected_count >= 1)
                {
                    int ind = HeaderTable.SelectedRows[0].Index;
                    String id = HeaderTable.Rows[ind].Cells[0].Value.ToString();
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
                                yql = $"DELETE FROM expenses_header WHERE id = {id}";
                            if (this.formType == 1)
                                yql = $"DELETE FROM plan_header WHERE id = {id}";
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
                    this.updateTableHeader();
                }
                else { MessageBox.Show("Выберите строку в заголовке для удаления "); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void удалитьЗатратыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int selected_count = infoTable.SelectedRows.Count;
                if (selected_count >= 1)
                {
                    int ind = infoTable.SelectedRows[0].Index;
                    String id = infoTable.Rows[ind].Cells[0].Value.ToString();
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
                                yql = $"DELETE FROM expenses WHERE id = {id}";
                            if (this.formType == 1)
                                yql = $"DELETE FROM plan WHERE id = {id}";
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
                    this.updateTableFooter();
                }
                else { MessageBox.Show("Выберите строку в затратах для удаления "); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
