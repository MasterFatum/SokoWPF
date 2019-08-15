using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.IO;
using System.Xml;

namespace BLL.Concrete
{
    public class OtherRepository
    {
        public void SettingDataGrid(System.Windows.Controls.DataGrid dataGrid)
        {
            dataGrid.Columns[0].Visibility = Visibility.Hidden;
            dataGrid.Columns[1].Visibility = Visibility.Hidden;
        }

        public void SetConnectionString(string connectionString)
        {
            try
            {

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings.Remove("Soko");
                config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("Soko", connectionString, "System.Data.SqlClient"));
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
                config.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
