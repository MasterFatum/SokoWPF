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
                //string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                //string configFile = Path.Combine(appPath, "Authorization.config");
                //ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                //configFileMap.ExeConfigFilename = configFile;
                //Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

                //var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                ////connectionStringsSection.ConnectionStrings["TeacherSystem.Authorization.Properties.Settings.Setting"].ConnectionString = connectionString;
                //connectionStringsSection.ConnectionStrings[0].ConnectionString = connectionString;
                //config.Save();
                //ConfigurationManager.RefreshSection("connectionStrings");
                //config.Save();

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings.Remove("Soko");
                config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("Soko", connectionString));
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
