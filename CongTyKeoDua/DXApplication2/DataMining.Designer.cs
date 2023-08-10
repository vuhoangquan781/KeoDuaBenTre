namespace DXApplication2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clusterViewer1 = new Microsoft.AnalysisServices.Viewers.ClusterViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clusterViewer1
            // 
            this.clusterViewer1.ActivePage = 13;
            this.clusterViewer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.clusterViewer1.ConnectionString = "Provider=MSOLAP.5;Integrated Security=SSPI;Persist Security Info=False;Initial Ca" +
    "talog=DataMining;Data Source=localhost;Update Isolation Level=2";
            this.clusterViewer1.DbConnection = null;
            this.clusterViewer1.DesignSurfaceBackground = System.Drawing.SystemColors.Control;
            this.clusterViewer1.DesignSurfaceForeground = System.Drawing.SystemColors.ControlText;
            this.clusterViewer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.clusterViewer1.Location = new System.Drawing.Point(12, 41);
            this.clusterViewer1.MiningModelName = "KHACHHANG";
            this.clusterViewer1.ModelAllowDrillThrough = false;
            this.clusterViewer1.Name = "clusterViewer1";
            this.clusterViewer1.Size = new System.Drawing.Size(842, 544);
            this.clusterViewer1.StrNameClusterSelected1 = "";
            this.clusterViewer1.StrNameClusterSelected2 = "";
            this.clusterViewer1.SupportStructureColumn = false;
            this.clusterViewer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(779, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "TreeView";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 599);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.clusterViewer1);
            this.Name = "Form1";
            this.Text = "Khai phá dữ liệu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.AnalysisServices.Viewers.ClusterViewer clusterViewer1;
        private System.Windows.Forms.Button button1;



    }
}