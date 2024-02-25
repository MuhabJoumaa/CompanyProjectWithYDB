using System;
using System.Data;
using System.Windows.Forms;
using Ydb.Sdk.Auth;
using Ydb.Sdk.Services.Table;
using Ydb.Sdk;
using System.IO;
using OfficeOpenXml;
using System.Globalization;
using System.Text;
using CsvHelper;

namespace CompanyProject
{

    public partial class FormTable : Form
    {
        private int formType;
        private DataSet ds;
        private DataTable dt;
        private string sql;
        private readonly static String[] types = { "Отделы", "Статьи затрат",  "Отчеты по расходам" };
        private readonly static String[] sqls = {"SELECT * FROM departments",
            "SELECT * FROM expenditures"};

        public FormTable()
        {
            InitializeComponent();
        }

        public FormTable(int formType)
        {
            InitializeComponent();
            this.formType = formType;
            this.Text = types[formType];
            this.sql = sqls[formType];
            this.SaveToolStripMenuItem.Visible=false;
            this.updateTable();
        }

        public FormTable(int formType, DataSet ds)
        {
            InitializeComponent();
            this.formType = formType;
            this.AddToolStripMenuItem.Visible = false;
            this.UpdateToolStripMenuItem.Visible = false;
            this.DeleteToolStripMenuItem.Visible = false;
            this.dt = ds.Tables[0];
            dt.Columns["dp.name"].ColumnName = "Наименование отдела";
            dt.Columns["ex.name"].ColumnName = "Наименование статьи расходов";
            dt.Columns["column2"].ColumnName = "Потраченная сумма";
            this.Text = types[formType];
            dataGridView1.DataSource = dt;
            this.ds = ds;
        }

        public async void updateTable()
        {
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
                    return await session.ExecuteDataQuery(
                        query: this.sql,
                        txControl: TxControl.BeginSerializableRW().Commit()
                    );
                });
                response.Status.EnsureSuccess();
                var queryResponse = (ExecuteDataQueryResponse)response;
                var resultSet = queryResponse.Result.ResultSets[0];
                dataGridView1.DataSource = resultSet.ToDataTable();
                if (formType == 0)
                    dataGridView1.Columns["name"].HeaderText = "Наименование отдела";
                else if (formType == 1)
                {
                    dataGridView1.Columns["name"].HeaderText = "Наименование статьи расходов";
                    dataGridView1.Columns["description"].HeaderText = "Описание статьи расходов";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = null;
            if (this.formType == 0)
                form = new DepartamentsEdit(this);
            else if (this.formType == 1)
                form = new ExpendituresEdit(this);
            form.ShowDialog();
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = null;
                int selected_count = dataGridView1.SelectedRows.Count;
                if (selected_count >= 1)
                {
                    int ind = dataGridView1.SelectedRows[0].Index;
                    String id, name;
                    if (this.formType == 0)
                    {
                        id = dataGridView1.Rows[ind].Cells[0].Value.ToString();
                        name = dataGridView1.Rows[ind].Cells[1].Value.ToString();
                        form = new DepartamentsEdit(this, id, name);
                    }
                    else if (this.formType == 1)
                    {
                        id = dataGridView1.Rows[ind].Cells[1].Value.ToString();
                        name = dataGridView1.Rows[ind].Cells[2].Value.ToString();
                        String descr = dataGridView1.Rows[ind].Cells[0].Value.ToString();
                        form = new ExpendituresEdit(this, id, name, descr);
                    }
                    form.ShowDialog();
                }
                else { MessageBox.Show("Выберите строку для изменения"); }
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int selected_count = dataGridView1.SelectedRows.Count;
                if (selected_count >= 1)
                {
                    int ind = dataGridView1.SelectedRows[0].Index;
                    String id;
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
                                id = dataGridView1.Rows[ind].Cells[0].Value.ToString();
                                yql = $"DELETE FROM departments WHERE id = {id};";
                            }
                            if (this.formType == 1)
                            {
                                id = dataGridView1.Rows[ind].Cells[1].Value.ToString();
                                yql = $"DELETE FROM expenditures WHERE id = {id};";
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
                    this.updateTable();
                }
                else { MessageBox.Show("Выберите строку для удаления"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        using (var excelPackage = new ExcelPackage())
                        {
                            foreach (DataTable table in ds.Tables)
                            {
                                var excelWorksheet = excelPackage.Workbook.Worksheets.Add(table.TableName);
                                for (int i = 0; i < table.Columns.Count; i++)
                                {
                                    excelWorksheet.Cells[1, i + 1].Value = table.Columns[i].ColumnName;
                                }
                                for (int j = 0; j < table.Rows.Count; j++)
                                {
                                    for (int k = 0; k < table.Columns.Count; k++)
                                    {
                                        excelWorksheet.Cells[j + 2, k + 1].Value = table.Rows[j].ItemArray[k].ToString();
                                    }
                                }
                            }
                            File.WriteAllBytes(saveFileDialog.FileName, excelPackage.GetAsByteArray());
                        }
                    }
                }
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "CSV File (*.csv)|*.csv";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (var writer = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            foreach (DataTable table in ds.Tables)
                            {
                                csv.WriteComment(table.TableName);
                                csv.NextRecord();
                                for (int i = 0; i < table.Columns.Count; i++)
                                {
                                    csv.WriteField(table.Columns[i].ColumnName);
                                }
                                csv.NextRecord();
                                for (int j = 0; j < table.Rows.Count; j++)
                                {
                                    for (int k = 0; k < table.Columns.Count; k++)
                                    {
                                        csv.WriteField(table.Rows[j].ItemArray[k].ToString());
                                    }
                                    csv.NextRecord();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void FormTable_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
        }
    }
}
