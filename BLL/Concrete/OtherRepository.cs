﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BLL.Concrete
{
    public class OtherRepository
    {
        public void SettingDataGrid(System.Windows.Controls.DataGrid dataGrid)
        {
            dataGrid.Columns[0].Visibility = Visibility.Hidden;
            dataGrid.Columns[1].Visibility = Visibility.Hidden;
        }
    }
}