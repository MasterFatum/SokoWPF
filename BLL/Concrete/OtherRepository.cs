using System;
using System.Configuration;
using System.Windows;
using System.IO;

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
                config.ConnectionStrings.ConnectionStrings[1].ConnectionString = connectionString;
                config.ConnectionStrings.ConnectionStrings[1].Name = "Soko";
                config.ConnectionStrings.ConnectionStrings[1].ProviderName = "System.Data.SqlClient";
                config.Save(ConfigurationSaveMode.Full, true);
                ConfigurationManager.RefreshSection("connectionStrings");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
