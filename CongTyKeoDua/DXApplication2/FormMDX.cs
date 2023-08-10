using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AnalysisServices.AdomdClient;
using DevExpress.XtraPrinting;
using DevExpress.Export;
using DGVPrinterHelper;

namespace DXApplication2
{
    public partial class FormMDX : Form
    {
        AdomdConnection conn = new AdomdConnection("Provider=MSOLAP;Data Source=localhost;Initial Catalog=SSAS");
        DataTable dtb = new DataTable();
        public FormMDX()
        {
            InitializeComponent();
        }

        class select
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Grid_Load();
        }

        public void Grid_Load()
        {
            dtb.Columns.Clear();
            dtb.Rows.Clear();
            try
            {
                conn.Open();
                string mdx = cbo_MDX.SelectedValue.ToString();               
                AdomdDataAdapter a = new AdomdDataAdapter(mdx, conn);
                //DataTable dtb = new DataTable();
                a.Fill(dtb);               
                grid_MDX.DataSource = dtb;
                //MessageBox.Show("Thành công");
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void FormMDX_Load(object sender, EventArgs e)
        {
            //List<select> sl = new List<select>();
            //sl.Add(new select() { Text = "Doanh thu của các chi nhánh qua các năm", Value = "select non empty{[Measures].[DOANHTHU]} on columns,non empty {crossjoin([NHANVIEN].[TENCN].[TENCN],[THOIGIAN].[NAM].[NAM])} on rows from [QLKEODUA]" });
            //sl.Add(new select() { Text = "Doanh thu của các Khu vực qua các năm", Value = "select non empty{[Measures].[DOANHTHU]} on columns,non empty {crossjoin([TINH].[TENKV].[TENKV],[THOIGIAN].[NAM].[NAM])} on rows from [QLKEODUA]" });
            //sl.Add(new select() { Text = "4 sản phẩm cho doanh thu cao nhất", Value = "select {[Measures].[DOANHTHU]} on columns,HEAD(ORDER([SANPHAM].[TENSP].[TENSP],[Measures].[DOANHTHU],DESC),4) on rows from [QLKEODUA];" });
            //sl.Add(new select() { Text = "Số lượng sản phẩm được mua qua từng tỉnh", Value = "select [Measures].[SOLUONG] on columns,[TINH].[TENKVC].[TENKVC] on rows from [QLKEODUA];" });
            //sl.Add(new select() { Text = "Doanh thu sản phẩm theo từng loại sản phẩm ", Value = "select [Measures].[DOANHTHU] on columns,crossjoin([SANPHAM].[TENLOAISP].[TENLOAISP],[SANPHAM].[TENSP].[TENSP]) on rows from [QLKEODUA];" });
            //sl.Add(new select() { Text = "Doanh thu của từng nhân viên theo chi nhánh ", Value = "select [Measures].[DOANHTHU] on columns,crossjoin([NHANVIEN].[TENNV].[TENNV],[NHANVIEN].[TENCN].[TENCN]) on rows from [QLKEODUA]" });
            //sl.Add(new select() { Text = "Top 10 nhà phân phối có doanh thu sản phẩm cao nhất ", Value = "select [Measures].[DOANHTHU] on columns,topcount(crossjoin([NHAPP].[TENNPP].[TENNPP],[SANPHAM].[TENSP].[TENSP]),10,[Measures].[DOANHTHU]) on rows from [QLKEODUA]" });
            //sl.Add(new select() { Text = "Số lượng sản phẩm được bán theo nghề nhiệp độ tuổi khánh hàng ", Value = "select [Measures].[SOLUONG] on columns,non empty (crossjoin([KHACHHANG].[NGHENGHIEP].[NGHENGHIEP],[KHACHHANG].[TUOI].[TUOI],[SANPHAM].[TENSP].[TENSP])) on rows  from [QLKEODUA]" });
            //sl.Add(new select() { Text = "Sản phẩm có số lượng bán lớn hơn 2000 và nhỏ hơn 4000 ", Value = "select filter([SANPHAM].[TENSP].[TENSP],[Measures].[SOLUONG] > 2000 and [Measures].[SOLUONG] < 4000) on rows,non empty{[THOIGIAN].[NAM].[NAM]} on columns from [QLKEODUA]" });
            //sl.Add(new select() { Text = "Chi phi vận chuyển của từng sản phẩm theo trọng lượng ", Value = "select [Measures].[CHIPHIVC] on columns,non empty{crossjoin([SANPHAM].[TENSP].[TENSP],[SANPHAM].[TRONGLUONG].[TRONGLUONG])} on rows from [QLKEODUA]" });
            //cbo_MDX.DataSource = sl;
            //cbo_MDX.DisplayMember = "Text";
            //cbo_MDX.ValueMember = "Value";
        }

        public void MDX_Load()
        {
           
        }

        private void ExportExcel(string filename)
        {
            //try
            //{
            //    if (gridView1.FocusedRowHandle < 0)
            //    {

            //    }
            //    else
            //    {
            //        var dialog = new SaveFileDialog();
            //        dialog.Title = @"Export file excel";
            //        dialog.FileName = filename;
            //        dialog.Filter = @"Microsoft Exel|*.xlsx";

            //        if (dialog.ShowDialog() == DialogResult.OK)
            //        {
            //            gridView1.ColumnPanelRowHeight = 40;
            //            gridView1.OptionsPrint.AutoWidth = AutoSize;
            //            gridView1.OptionsPrint.ShowPrintExportProgress = true;
            //            gridView1.OptionsPrint.AllowCancelPrintExport = true;
            //            XlsxExportOptions options = new XlsxExportOptions();
            //            options.TextExportMode = TextExportMode.Text;
            //            options.ExportMode = XlsxExportMode.SingleFile;
            //            options.SheetName = @"sheet1";

            //            ExportSettings.DefaultExportType = ExportType.Default;
            //            gridView1.ExportToXlsx(dialog.FileName, options);

            //        }
            //    }
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //return false;
          
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (grid_MDX.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelapp = new Microsoft.Office.Interop.Excel.Application();
                xcelapp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < grid_MDX.Columns.Count + 1; i++)
                {
                    xcelapp.Cells[1, i] = grid_MDX.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < grid_MDX.Rows.Count; i++)
                {
                    for (int j = 0; j < grid_MDX.Columns.Count; j++)
                    {
                        xcelapp.Cells[i + 2, j + 1] = grid_MDX.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelapp.Columns.AutoFit();
                xcelapp.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox1.SelectedIndex == 0)
            //{
            //    MDX_Load();
            //}
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //conn.Open();
            //string mdx = cbo_MDX.SelectedValue.ToString();
            //AdomdDataAdapter a = new AdomdDataAdapter(mdx, conn);
            //DataTable dt = new DataTable();
            //a.Fill(dt);
            //grid_MDX.DataSource = dt;
            //MessageBox.Show("Thành công");
            //conn.Close();
            //DataView dv = new DataView(dt);
            //if (comboBox1.SelectedItem.ToString() == "ALL")
            //{
            //    grid_MDX.DataSource = dt;
            //}
            //else
            //{
            //    dv.RowFilter = string.Format("[TINH].[TENKV].[TENKV].[MEMBER_CAPTION] = '%0%' ", comboBox1.SelectedItem.ToString());
            //    grid_MDX.DataSource = dv;
            //}     
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = "Báo Cáo";
            print.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("MM/dd/yyyy"));
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Báo Cáo";
            print.FooterSpacing = 15;
            print.PrintDataGridView(grid_MDX);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            List<select> sl = new List<select>();
            sl.Add(new select() { Text = "Chi phí của từng sản phẩm", Value = "select [Measures].[CHIPHIVC] on columns, non empty{ crossjoin([SANPHAM].[TENSP].[TENSP],[THOIGIAN].[NAM].[NAM])} on rows from[QLKEODUA]" });
            sl.Add(new select() { Text = "Chi phí vận chuyển ở từng chi nhánh ", Value = "select {[Measures].[CHIPHIVC]} on columns, NON EMPTY(crossjoin([NHANVIEN].[TENCN].[TENCN],[THOIGIAN].[THANG].[THANG])) on rows from[QLKEODUA] " });
            sl.Add(new select() { Text = "Chi phí vận chuyển ở từng khu vực theo năm ", Value = "select non empty{[Measures].[DOANHTHU]} on columns,non empty { crossjoin([TINH].[TENKV].[TENKV],[THOIGIAN].[NAM].[NAM])} on rows from[QLKEODUA] " });
            sl.Add(new select() { Text = "TOP 3 Chi phí vận chuyển cao nhất theo tháng ", Value = "select [Measures].[CHIPHIVC] on columns,topcount([THOIGIAN].[Hierarchy].[THANG],3,[Measures].[DOANHTHU]) on rows from [QLKEODUA] " });
            sl.Add(new select() { Text = "Chi phí vận chuyển ở TPHCM qua từng năm ", Value = "select {[Measures].[CHIPHIVC]} on columns,crossjoin ([TINH].[TENKV].&[HCM],[THOIGIAN].[NAM].[NAM]) on rows from [QLKEODUA];" });
            sl.Add(new select() { Text = "Chi phí vận chuyển ở từng tháng ", Value = "select {[Measures].[CHIPHIVC]} on columns,crossjoin ([TINH].[TENKV].&[HCM],[THOIGIAN].[THANG].[THANG]) on rows from [QLKEODUA] " });
            sl.Add(new select() { Text = "Doanh thu, Số lượng và chi phí của từng Chi nhánh", Value = "select {[Measures].[SOLUONG],[Measures].[CHIPHIVC],[Measures].[DOANHTHU]} on columns, ORDER ([NHANVIEN].[TENCN].[TENCN],[Measures].[DOANHTHU],DESC) on rows from [QLKEODUA]" });
            cbo_MDX.DataSource = sl;
            cbo_MDX.DisplayMember = "Text";
            cbo_MDX.ValueMember = "Value";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            List<select> sl = new List<select>();
            sl.Add(new select() { Text = "Số lượng sản phẩm được bán", Value = "select [Measures].[SOLUONG] on columns,[SANPHAM].[TENSP].[TENSP] on rows from[QLKEODUA]" });
            sl.Add(new select() { Text = "Số lượng sản phẩm được bán trong tháng 1 năm 2017", Value = "select {[Measures].[SOLUONG]} on columns,NON EMPTY( crossjoin ([SANPHAM].[TENSP].[TENSP],[THOIGIAN].[THANG].&[Tháng 1],[THOIGIAN].[NAM].&[2017] ) ) on rows from[QLKEODUA]" });
            sl.Add(new select() { Text = "Số lượng sản phẩm được bán trong tháng 2 năm 2017", Value = "select {[Measures].[SOLUONG]} on columns,NON EMPTY( crossjoin ([SANPHAM].[TENSP].[TENSP],[THOIGIAN].[THANG].&[Tháng 2],[THOIGIAN].[NAM].&[2017] ) ) on rows from[QLKEODUA]" });
            sl.Add(new select() { Text = "Số lượng sản phẩm được bán trong tháng 3 năm 2017", Value = "select {[Measures].[SOLUONG]} on columns,NON EMPTY( crossjoin ([SANPHAM].[TENSP].[TENSP],[THOIGIAN].[THANG].&[Tháng 3],[THOIGIAN].[NAM].&[2017] ) ) on rows from[QLKEODUA]" });
            sl.Add(new select() { Text = "Số lượng sản phẩm được bán trong tháng 4 năm 2017", Value = "select {[Measures].[SOLUONG]} on columns,NON EMPTY( crossjoin ([SANPHAM].[TENSP].[TENSP],[THOIGIAN].[THANG].&[Tháng 4],[THOIGIAN].[NAM].&[2017] ) ) on rows from[QLKEODUA]" });
            sl.Add(new select() { Text = "Số lượng sản phẩm được bán trong tháng 5 năm 2017", Value = "select {[Measures].[SOLUONG]} on columns,NON EMPTY( crossjoin ([SANPHAM].[TENSP].[TENSP],[THOIGIAN].[THANG].&[Tháng 5],[THOIGIAN].[NAM].&[2017] ) ) on rows from[QLKEODUA]" });
            sl.Add(new select() { Text = "Số lượng sản phẩm được bán trong tháng 6 năm 2017", Value = "select {[Measures].[SOLUONG]} on columns,NON EMPTY( crossjoin ([SANPHAM].[TENSP].[TENSP],[THOIGIAN].[THANG].&[Tháng 6],[THOIGIAN].[NAM].&[2017] ) ) on rows from[QLKEODUA]" });
            sl.Add(new select() { Text = "Số lượng sản phẩm được bán trong tháng 7 năm 2017", Value = "select {[Measures].[SOLUONG]} on columns,NON EMPTY( crossjoin ([SANPHAM].[TENSP].[TENSP],[THOIGIAN].[THANG].&[Tháng 7],[THOIGIAN].[NAM].&[2017] ) ) on rows from[QLKEODUA]" });
            sl.Add(new select() { Text = "Số lượng sản phẩm được bán trong tháng 8 năm 2017", Value = "select {[Measures].[SOLUONG]} on columns,NON EMPTY( crossjoin ([SANPHAM].[TENSP].[TENSP],[THOIGIAN].[THANG].&[Tháng 8],[THOIGIAN].[NAM].&[2017] ) ) on rows from[QLKEODUA]" });
            sl.Add(new select() { Text = "Số lượng sản phẩm được bán trong tháng 9 năm 2017", Value = "select {[Measures].[SOLUONG]} on columns,NON EMPTY( crossjoin ([SANPHAM].[TENSP].[TENSP],[THOIGIAN].[THANG].&[Tháng 9],[THOIGIAN].[NAM].&[2017] ) ) on rows from[QLKEODUA]" });
            sl.Add(new select() { Text = "Doanh thu, Số lượng và Chi phí của từng Chi nhánh", Value = "select {[Measures].[SOLUONG],[Measures].[CHIPHIVC],[Measures].[DOANHTHU]} on columns, ORDER ([NHANVIEN].[TENCN].[TENCN],[Measures].[DOANHTHU],DESC) on rows from [QLKEODUA]" });
            cbo_MDX.DataSource = sl;
            cbo_MDX.DisplayMember = "Text";
            cbo_MDX.ValueMember = "Value";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            List<select> sl = new List<select>();
            sl.Add(new select() { Text = "Doanh thu của các chi nhánh qua các năm", Value = "select non empty{[Measures].[DOANHTHU]} on columns,non empty {crossjoin([NHANVIEN].[TENCN].[TENCN],[THOIGIAN].[NAM].[NAM])} on rows from [QLKEODUA]" });
            sl.Add(new select() { Text = "Doanh thu của các Khu vực qua các năm", Value = "select non empty{[Measures].[DOANHTHU]} on columns,non empty {crossjoin([TINH].[TENKV].[TENKV],[THOIGIAN].[NAM].[NAM])} on rows from [QLKEODUA]" });
            sl.Add(new select() { Text = "Doanh thu 3 tháng cao nhất", Value = "select [Measures].[DOANHTHU] on columns,topcount([THOIGIAN].[THANG].[THANG],3,[Measures].[DOANHTHU]) on rows from[QLKEODUA]" });
            sl.Add(new select() { Text = "Doanh thu, Số lượng và Chi phí của từng Chi nhánh", Value = "select {[Measures].[SOLUONG],[Measures].[CHIPHIVC],[Measures].[DOANHTHU]} on columns, ORDER ([NHANVIEN].[TENCN].[TENCN],[Measures].[DOANHTHU],DESC) on rows from [QLKEODUA]" });
            sl.Add(new select() { Text = "Cho biết doanh thu của  HCM trong năm", Value = "select {[Measures].[DOANHTHU]} on columns,non empty (crossjoin ([TINH].[TENKV].&[HCM],[TINH].[TENKVC].[TENKVC],[THOIGIAN].[NAM].[NAM])) on rows from [QLKEODUA]" });
            sl.Add(new select() { Text = "Cho biết 4 sản phẩm có doanh thu cao nhất và được sắp xếp theo thứ tự", Value = "select {[Measures].[DOANHTHU]} on columns,HEAD(ORDER([SANPHAM].[TENSP].[TENSP],[Measures].[DOANHTHU],DESC),4) on rows from [QLKEODUA]" });
            sl.Add(new select() { Text = "Doanh thu theo tháng và năm", Value = "select {[Measures].[DOANHTHU]} on columns,crossjoin ([THOIGIAN].[THANG].[THANG],[THOIGIAN].[NAM].[NAM]) on rows from [QLKEODUA]" });
            sl.Add(new select() { Text = "Cho biết doanh thu từng chi nhánh theo tháng", Value = "select {[Measures].[DOANHTHU]} on columns, NON EMPTY(crossjoin ([NHANVIEN].[TENCN].[TENCN],[THOIGIAN].[THANG].[THANG])) on rows from [QLKEODUA];" });
            cbo_MDX.DataSource = sl;
            cbo_MDX.DisplayMember = "Text";
            cbo_MDX.ValueMember = "Value";
        }
    }
} 
