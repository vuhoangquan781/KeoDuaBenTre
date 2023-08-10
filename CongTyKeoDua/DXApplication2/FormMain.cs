using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using System.Windows.Forms;
using DXApplication2.DAO;

namespace DXApplication2
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private FormLOGIN fLg;
        private string tdn;
        public FormMain()
        {
            InitializeComponent();
        }
        public FormMain(FormLOGIN _flg, string _tdn)
        {
            InitializeComponent();
            tdn = _tdn;
            fLg = _flg;
            DataProvider _dt = new DataProvider();
            DataTable dt = _dt.GetData("select * from ACCOUNT where ACCOUNT.TenDangNhap = '" + tdn + "'");
            string gt = dt.Rows[0]["Quyen"].ToString();
            if (gt == "0")
            {
                ribbonPage1.Visible = true;
            }
            else
            {
                barButtonItem1.Enabled = false;
                barButtonItem9.Enabled = false;
                barButtonItem11.Enabled = false;
            }
        }


        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormBackupAndRestore frm=new FormBackupAndRestore();
            this.Hide();
            frm.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormNapTuExcel frm = new FormNapTuExcel();
            frm.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormNapTuSQL frm = new FormNapTuSQL();
            frm.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormNapTuAccess frm = new FormNapTuAccess();
            frm.ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormMDX frm = new FormMDX();
            frm.ShowDialog();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThongKe frm = new ThongKe();
            frm.ShowDialog();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("https://app.powerbi.com/view?r=eyJrIjoiNDc5OTgyOTYtOTRmZS00ZjNlLWJkYmItZWFjOTM3ZDMxYmNlIiwidCI6ImU5Njg5MDk2LWMyNDgtNGZjMC04NmQ2LTcyNWU1YTBiNjQ3MiJ9");
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Anh frm = new Anh();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl1.Controls.Add(frm);

        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //panelControl1.Controls.Clear();
            //FrmDoiMK frm = new FrmDoiMK(tdn);
            //frm.Dock = System.Windows.Forms.DockStyle.Fill;
            //panelControl1.Controls.Add(frm);
            FormDoiMK frm = new FormDoiMK(tdn);
            frm.ShowDialog();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.Controls.Clear();

            FrmCapTaiKhoan frm = new FrmCapTaiKhoan();           
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl1.Controls.Add(frm);
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormLOGIN fm = new FormLOGIN();
            this.Hide();
            fm.ShowDialog();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeViewDataMiningHierarchy fm = new TreeViewDataMiningHierarchy();
            fm.ShowDialog();
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormReport fm = new FormReport();
            fm.ShowDialog();
        }
    }
}
