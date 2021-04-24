using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static 原神地图辅助器.Unitility;

namespace 原神地图辅助器
{
    public partial class Form1 : Form
    {
        static bool isMapFormOpen;
        MapForm mapForm;
        public Form1()
        {
            InitializeComponent();
            DataInfo.LoadData();
            KeyBoardListenerr.GetKeyDownEvent((key) =>
            {
                if (key == "M")
                {
                    if (isMapFormOpen)
                    {
                        btn_Close_Click(null, null);
                    }
                    else
                    {
                        btn_Open_Click(null, null);
                    }
                }
                //if (key == "ESC") btn_Close_Click(null, null);
            });
            var items = DataInfo.GetAllPos.Select(icon => icon.name).Distinct().ToArray();
            checkedListBox1.Items.AddRange(items);

            //控制地图校准系数
            string[] configs = File.ReadAllLines("config/bias.txt");
            U0.Text = configs[0];
            V0.Text = configs[1];
            U1.Text = configs[2];
            V1.Text = configs[3];
        }
        private void btn_Open_Click(object sender, EventArgs e)
        {
            mapForm = new MapForm();
            mapForm.Show();
            isMapFormOpen = true;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (mapForm != null)
            {
                mapForm.Close();
                isMapFormOpen = false;
            }
        }

        private void checkedListBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void btn__Boss_Click(object sender, EventArgs e) => Enumerable.Range(0, 8).ToList().ForEach(num => checkedListBox1.SetItemChecked(num, true));
        private void btnMonster_Click(object sender, EventArgs e) => Enumerable.Range(8, 15).ToList().ForEach(num => checkedListBox1.SetItemChecked(num, true));
        private void btn_collection_Click(object sender, EventArgs e) => Enumerable.Range(22, 19).ToList().ForEach(num => checkedListBox1.SetItemChecked(num, true));
        private void btn_All_Click(object sender, EventArgs e) => Enumerable.Range(0, checkedListBox1.Items.Count).ToList().ForEach(num => checkedListBox1.SetItemChecked(num, true));
        private void btn_None_Click(object sender, EventArgs e) => Enumerable.Range(0, checkedListBox1.Items.Count).ToList().ForEach(num => checkedListBox1.SetItemChecked(num, false));
        private void btn_github_Click(object sender, EventArgs e) => Process.Start("https://github.com/red-gezi/GenshinImpact_MonsterMap");

        private void btn_rect_Click(object sender, EventArgs e)
        {
            Process process = Process.GetProcessesByName("YuanShen")[0];
            IntPtr mainHandle = process.MainWindowHandle;
            Rectangle GameRect = new Rectangle();
            GetWindowRect(mainHandle, ref GameRect);
            game_width.Text = GameRect.Width + "";
            DataInfo.width = GameRect.Width;
            game_height.Text = GameRect.Height + "";
            DataInfo.height = GameRect.Height;
        }

        private void btn_SetRect_Click(object sender, EventArgs e)
        {
            DataInfo.width = int.Parse(game_width.Text);
            DataInfo.height = int.Parse(game_height.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DataInfo.selectTags.Clear();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                DataInfo.selectTags.Add(item.ToString());
            };
            pictureSample.Image = DataInfo.gameMap;
            picturePoint.Image = DataInfo.dealMap;

        }
        private void V0_ValueChanged(object sender, EventArgs e)
        {
            File.WriteAllLines("config/bias.txt", new string[]
            {
                 U0.Text,
                ((NumericUpDown)sender).Value.ToString() ,
                U1.Text ,
                V1.Text ,
            });
        }
        private void U0_ValueChanged(object sender, EventArgs e)
        {
            File.WriteAllLines("config/bias.txt", new string[]
            {
                ((NumericUpDown)sender).Value.ToString(),
                V0.Text ,
                U1.Text ,
                V1.Text ,
            });
        }
        private void U1_ValueChanged(object sender, EventArgs e)
        {
            File.WriteAllLines("config/bias.txt", new string[]
            {
                U0.Text ,
                V0.Text ,
                ((NumericUpDown)sender).Value.ToString() ,
                V1.Text ,
            });
        }

        private void V1_ValueChanged(object sender, EventArgs e)
        {
            File.WriteAllLines("config/bias.txt", new string[]
            {
                U0.Text ,
                V0.Text ,
                U1.Text ,
                ((NumericUpDown)sender).Value.ToString() ,
            });
        }
    }
}
