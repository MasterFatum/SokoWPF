﻿using System;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;

namespace BLL.Concrete
{
    public class OtherRepository
    {
        public void SettingDataGridUsers(DataGrid dataGrid)
        {
            dataGrid.Columns[0].Visibility = Visibility.Hidden;
            dataGrid.Columns[1].Visibility = Visibility.Hidden;
            dataGrid.Columns[4].Visibility = Visibility.Hidden;
            dataGrid.Columns[8].Visibility = Visibility.Hidden;
            dataGrid.Columns[10].Visibility = Visibility.Hidden;

            dataGrid.Columns[2].Header = "Категория";
            dataGrid.Columns[3].Header = "Название";
            dataGrid.Columns[5].Header = "Баллы";
            dataGrid.Columns[6].Header = "Оценивающий";
            dataGrid.Columns[7].Header = "Дата создания";
            dataGrid.Columns[9].Header = "Дата редактирования";

        }

        public void SettingDataGridAdmins(DataGrid dataGrid)
        {
            dataGrid.Columns[0].Visibility = Visibility.Hidden;
            dataGrid.Columns[5].Visibility = Visibility.Hidden;
            dataGrid.Columns[7].Visibility = Visibility.Hidden;

            dataGrid.Columns[1].Header = "Фамилия";
            dataGrid.Columns[2].Header = "Имя";
            dataGrid.Columns[3].Header = "Отчество";
            dataGrid.Columns[4].Header = "Должность";
            dataGrid.Columns[6].Header = "Email";
            dataGrid.Columns[8].Header = "Дата регистрации";

        }

        public void SettingDataGridSummaryStatement(DataGrid dataGrid)
        {
            dataGrid.Columns[0].Visibility = Visibility.Hidden;
            dataGrid.Columns[1].Visibility = Visibility.Hidden;

            dataGrid.Columns[2].Header = "Категория";
            dataGrid.Columns[3].Visibility = Visibility.Hidden;
            dataGrid.Columns[4].Visibility = Visibility.Hidden; 
            dataGrid.Columns[5].Header = "Оценка";
            dataGrid.Columns[6].Visibility = Visibility.Hidden;
            dataGrid.Columns[7].Visibility = Visibility.Hidden;
            dataGrid.Columns[8].Visibility = Visibility.Hidden;
            dataGrid.Columns[9].Visibility = Visibility.Hidden;
            dataGrid.Columns[10].Visibility = Visibility.Hidden;

        }

        public void SetConnectionString(string connectionString)
        {
            try
            {

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings.Remove("Soko");
                config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("Soko", connectionString, "System.Data.SqlClient"));
                config.Save(ConfigurationSaveMode.Modified);
                config.Save();
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
