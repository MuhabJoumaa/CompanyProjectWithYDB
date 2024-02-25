using System;
using System.Data;
using System.Windows.Forms;
using Ydb.Sdk.Value;

namespace CompanyProject
{
    internal static class Program
    {
        public static readonly string endpoint = "grpcs://ydb.serverless.yandexcloud.net:2135",
            database = "/ru-central1/b1gr17ja2gu5ntlmqlt2/etnhapkn2crippdo1jh0",
            token = "t1.9euelZrLlpfPzYqVzc2ay8yPz42Tmu3rnpWak5KSjMvMnJiaxo_OnsbPkJ3l8_c1LBNR-e9ONHld_t3z93VaEFH57040eV3-zef1656VmpXKyZmSxsmSyJ6JkZ7Hl82S7_zF656VmpXKyZmSxsmSyJ6JkZ7Hl82S.rayQzRuGzrEiMJvmaxusPxzsd_m3V5NHwMLSyLAv2lJ462unvrwysQlDZmnqOchFmGSoBj1ciUdkbFDwlTzpCA";

        public static DataTable ToDataTable(this ResultSet resultSet)
        {
            var dataTable = new DataTable();
            foreach (var column in resultSet.Columns)
            {
                dataTable.Columns.Add(column.Name);
            }
            foreach (var row in resultSet.Rows)
            {
                var dataRow = dataTable.NewRow();
                for (int i = 0; i < resultSet.Columns.Count; i++)
                {
                    var columnName = resultSet.Columns[i].Name;
                    var columnValue = row[columnName];
                    if (columnName.Contains("id"))
                    {
                        dataRow[i] = ((ulong)columnValue);
                    }
                    else if (columnName.Contains("money"))
                    {
                        dataRow[i] = ((float)columnValue);
                    }
                    else if (columnName.Contains("year"))
                    {
                        dataRow[i] = ((short)columnValue);
                    }
                    else
                    {
                        try
                        {
                            dataRow[i] = ((string)columnValue);
                        }
                        catch (Exception)
                        {
                            dataRow[i] = ((float)columnValue);
                        }
                    }
                }
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

        public static DataSet ToDataSet(this ResultSet resultSet)
        {
            var dataSet = new DataSet();
            var dataTable = new DataTable();
            foreach (var column in resultSet.Columns)
            {
                dataTable.Columns.Add(column.Name);
            }
            foreach (var row in resultSet.Rows)
            {
                var dataRow = dataTable.NewRow();
                for (int i = 0; i < resultSet.Columns.Count; i++)
                {
                    var columnName = resultSet.Columns[i].Name;
                    var columnValue = row[columnName];
                    if (columnName.Contains("id"))
                    {
                        dataRow[i] = ((ulong)columnValue);
                    }
                    else if (columnName.Contains("money"))
                    {
                        dataRow[i] = ((float)columnValue);
                    }
                    else if (columnName.Contains("year"))
                    {
                        dataRow[i] = ((short)columnValue);
                    }
                    else
                    {
                        try
                        {
                            dataRow[i] = ((string)columnValue);
                        }
                        catch (Exception)
                        {
                            dataRow[i] = ((float)columnValue);
                        }
                    }
                }
                dataTable.Rows.Add(dataRow);
            }
            dataSet.Tables.Add(dataTable);
            return dataSet;
        }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
