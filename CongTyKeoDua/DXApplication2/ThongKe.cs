using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DashboardCommon;

namespace DXApplication2
{
    public partial class ThongKe : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public ThongKe()
        {
            InitializeComponent();
            loadDatasource();
        }
        public void loadDatasource()
        {

            #region #OLAPDataSource




            OlapConnectionParameters olapParams = new OlapConnectionParameters();
            olapParams.ConnectionString = @"provider=MSOLAP;
                                    data source=.;
                                  initial catalog=SSAS;
                                  cube name=QLKEODUA;";
            DashboardOlapDataSource olapDataSource = new DashboardOlapDataSource(olapParams);

            dashboardDesigner1.Dashboard.DataSources.Add(olapDataSource);

            #endregion #OLAPDataSource
        }
    }
}