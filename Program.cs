using System;
using System.Data;
using System.Management.Automation;
using System.Windows.Forms;
using Ydb.Sdk.Value;

namespace CompanyProject
{
    internal static class Program
    {
        public static readonly string endpoint = "grpcs://ydb.serverless.yandexcloud.net:2135",
            database = "/ru-central1/b1gr17ja2gu5ntlmqlt2/etnhapkn2crippdo1jh0",
            token = GetToken("$yandexPassportOauthToken = \"y0_AgAAAABbuA-FAATuwQAAAAD7kCXsAAC2_hK-kipLAZOC9mQf0S9oyOFZmg\"\r\n$Body = @{ yandexPassportOauthToken = \"$yandexPassportOauthToken\" } | ConvertTo-Json -Compress\r\nInvoke-RestMethod -Method 'POST' -Uri 'https://iam.api.cloud.yandex.net/iam/v1/tokens' -Body $Body -ContentType 'Application/json' | Select-Object -ExpandProperty iamToken");

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

        private static string GetToken(string script)
        {
            using (PowerShell ps = PowerShell.Create())
            {
                ps.AddScript(script);
                var output = ps.Invoke();
                if (ps.HadErrors)
                {
                    string errorMessage = string.Join(Environment.NewLine, ps.Streams.Error);
                    return $"PowerShell Error: {errorMessage}";
                }
                else
                {
                    string result = string.Join(Environment.NewLine, output);
                    return result;
                }
            }
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
