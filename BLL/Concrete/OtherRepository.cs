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

        public void SetConnectionStringInside(string connectionString)
        {
            string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string configFile = Path.Combine(appPath, "App.config");
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = configFile;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            config.AppSettings.Settings["connectionString"].Value = @"data source=NETSCHOOL;initial catalog=SOKO;integrated security=False;User ID=SOKOUser;Password=Admin;MultipleActiveResultSets=True;App=EntityFramework";
            config.Save();
        }

        public void SetConnectionStringOutside(string connectionString)
        {
            string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string configFile = Path.Combine(appPath, "App.config");
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = configFile;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            config.AppSettings.Settings["connectionString"].Value = @"data source=NETSCHOOL;initial catalog=SOKO;integrated security=False;User ID=SOKOUser;Password=Admin;MultipleActiveResultSets=True;App=EntityFramework";
            config.Save();
        }
    }
}
