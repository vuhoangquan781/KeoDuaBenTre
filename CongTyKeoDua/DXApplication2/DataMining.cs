﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clusterViewer1.LoadViewerData(null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TreeViewDataMiningHierarchy trv = new TreeViewDataMiningHierarchy();
            this.Hide();
            trv.ShowDialog();
        }
    }
}
