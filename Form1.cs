using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using static 原神地图辅助器.Unitility;

namespace 原神地图辅助器
{
    public partial class Form1 : Form
    {
        MapForm mapForm;
        public Form1()
        {
            InitializeComponent();
            DataInfo.LoadData();
            var items = DataInfo.GetAllPos().Select(icon => icon.name).Distinct().ToArray();
            checkedListBox1.Items.AddRange(items);
        }
        private void btn_Open_Click(object sender, EventArgs e)
        {
            mapForm = new MapForm();
            mapForm.Show();
        }

        private void btn_Close_Click(object sender, EventArgs e) => mapForm.Close();
    }
}
