namespace 原神地图辅助器
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_None = new System.Windows.Forms.Button();
            this.btn_All = new System.Windows.Forms.Button();
            this.btn__Boss = new System.Windows.Forms.Button();
            this.btn_collection = new System.Windows.Forms.Button();
            this.btnMonster = new System.Windows.Forms.Button();
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cb_AutoLoadScreen = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.V1 = new System.Windows.Forms.NumericUpDown();
            this.U1 = new System.Windows.Forms.NumericUpDown();
            this.V0 = new System.Windows.Forms.NumericUpDown();
            this.U0 = new System.Windows.Forms.NumericUpDown();
            this.btn_SetRect = new System.Windows.Forms.Button();
            this.game_height = new System.Windows.Forms.TextBox();
            this.game_width = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pictureSample = new System.Windows.Forms.PictureBox();
            this.picturePoint = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_github = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_update = new System.Windows.Forms.Button();
            this.cb_ShowLine = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.V1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.U1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.V0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.U0)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSample)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePoint)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.checkedListBox1);
            this.splitContainer1.Size = new System.Drawing.Size(398, 613);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(398, 250);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_update);
            this.tabPage1.Controls.Add(this.btn_None);
            this.tabPage1.Controls.Add(this.btn_All);
            this.tabPage1.Controls.Add(this.btn__Boss);
            this.tabPage1.Controls.Add(this.btn_collection);
            this.tabPage1.Controls.Add(this.btnMonster);
            this.tabPage1.Controls.Add(this.btn_Open);
            this.tabPage1.Controls.Add(this.btn_Close);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(390, 221);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "筛选";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_None
            // 
            this.btn_None.Location = new System.Drawing.Point(111, 186);
            this.btn_None.Name = "btn_None";
            this.btn_None.Size = new System.Drawing.Size(109, 23);
            this.btn_None.TabIndex = 10;
            this.btn_None.Text = "取消全选";
            this.btn_None.UseVisualStyleBackColor = true;
            this.btn_None.Click += new System.EventHandler(this.btn_None_Click);
            // 
            // btn_All
            // 
            this.btn_All.Location = new System.Drawing.Point(20, 186);
            this.btn_All.Name = "btn_All";
            this.btn_All.Size = new System.Drawing.Size(75, 23);
            this.btn_All.TabIndex = 9;
            this.btn_All.Text = "全选";
            this.btn_All.UseVisualStyleBackColor = true;
            this.btn_All.Click += new System.EventHandler(this.btn_All_Click);
            // 
            // btn__Boss
            // 
            this.btn__Boss.Location = new System.Drawing.Point(20, 109);
            this.btn__Boss.Name = "btn__Boss";
            this.btn__Boss.Size = new System.Drawing.Size(120, 23);
            this.btn__Boss.TabIndex = 8;
            this.btn__Boss.Text = "Boss(锚点)";
            this.btn__Boss.UseVisualStyleBackColor = true;
            this.btn__Boss.Click += new System.EventHandler(this.btn__Boss_Click);
            // 
            // btn_collection
            // 
            this.btn_collection.Location = new System.Drawing.Point(111, 147);
            this.btn_collection.Name = "btn_collection";
            this.btn_collection.Size = new System.Drawing.Size(75, 23);
            this.btn_collection.TabIndex = 7;
            this.btn_collection.Text = "采集物";
            this.btn_collection.UseVisualStyleBackColor = true;
            this.btn_collection.Click += new System.EventHandler(this.btn_collection_Click);
            // 
            // btnMonster
            // 
            this.btnMonster.Location = new System.Drawing.Point(20, 147);
            this.btnMonster.Name = "btnMonster";
            this.btnMonster.Size = new System.Drawing.Size(75, 23);
            this.btnMonster.TabIndex = 6;
            this.btnMonster.Text = "精英怪";
            this.btnMonster.UseVisualStyleBackColor = true;
            this.btnMonster.Click += new System.EventHandler(this.btnMonster_Click);
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(20, 17);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(85, 64);
            this.btn_Open.TabIndex = 4;
            this.btn_Open.Text = "Open";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(111, 17);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(90, 64);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cb_ShowLine);
            this.tabPage2.Controls.Add(this.cb_AutoLoadScreen);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.V1);
            this.tabPage2.Controls.Add(this.U1);
            this.tabPage2.Controls.Add(this.V0);
            this.tabPage2.Controls.Add(this.U0);
            this.tabPage2.Controls.Add(this.btn_SetRect);
            this.tabPage2.Controls.Add(this.game_height);
            this.tabPage2.Controls.Add(this.game_width);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(390, 221);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "校准";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cb_AutoLoadScreen
            // 
            this.cb_AutoLoadScreen.AutoSize = true;
            this.cb_AutoLoadScreen.Checked = true;
            this.cb_AutoLoadScreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_AutoLoadScreen.Location = new System.Drawing.Point(233, 78);
            this.cb_AutoLoadScreen.Name = "cb_AutoLoadScreen";
            this.cb_AutoLoadScreen.Size = new System.Drawing.Size(134, 19);
            this.cb_AutoLoadScreen.TabIndex = 13;
            this.cb_AutoLoadScreen.Text = "自动读取分辨率";
            this.cb_AutoLoadScreen.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "偏移";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "缩放";
            // 
            // V1
            // 
            this.V1.Location = new System.Drawing.Point(119, 118);
            this.V1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.V1.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.V1.Name = "V1";
            this.V1.Size = new System.Drawing.Size(61, 25);
            this.V1.TabIndex = 10;
            this.V1.ValueChanged += new System.EventHandler(this.ValueChange);
            // 
            // U1
            // 
            this.U1.Location = new System.Drawing.Point(27, 118);
            this.U1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.U1.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.U1.Name = "U1";
            this.U1.Size = new System.Drawing.Size(61, 25);
            this.U1.TabIndex = 9;
            this.U1.ValueChanged += new System.EventHandler(this.ValueChange);
            // 
            // V0
            // 
            this.V0.Location = new System.Drawing.Point(119, 50);
            this.V0.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.V0.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.V0.Name = "V0";
            this.V0.Size = new System.Drawing.Size(61, 25);
            this.V0.TabIndex = 8;
            this.V0.ValueChanged += new System.EventHandler(this.ValueChange);
            // 
            // U0
            // 
            this.U0.Location = new System.Drawing.Point(27, 50);
            this.U0.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.U0.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.U0.Name = "U0";
            this.U0.Size = new System.Drawing.Size(61, 25);
            this.U0.TabIndex = 7;
            this.U0.ValueChanged += new System.EventHandler(this.ValueChange);
            // 
            // btn_SetRect
            // 
            this.btn_SetRect.Location = new System.Drawing.Point(233, 118);
            this.btn_SetRect.Name = "btn_SetRect";
            this.btn_SetRect.Size = new System.Drawing.Size(114, 34);
            this.btn_SetRect.TabIndex = 7;
            this.btn_SetRect.Text = "手动提交分辨率";
            this.btn_SetRect.UseVisualStyleBackColor = true;
            this.btn_SetRect.Click += new System.EventHandler(this.btn_SetRect_Click);
            // 
            // game_height
            // 
            this.game_height.Location = new System.Drawing.Point(294, 33);
            this.game_height.Name = "game_height";
            this.game_height.Size = new System.Drawing.Size(57, 25);
            this.game_height.TabIndex = 5;
            this.game_height.Text = "1080";
            // 
            // game_width
            // 
            this.game_width.Location = new System.Drawing.Point(233, 33);
            this.game_width.Name = "game_width";
            this.game_width.Size = new System.Drawing.Size(55, 25);
            this.game_width.TabIndex = 4;
            this.game_width.Text = "1920";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer2);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(390, 221);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "采集测试";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pictureSample);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.picturePoint);
            this.splitContainer2.Size = new System.Drawing.Size(390, 221);
            this.splitContainer2.SplitterDistance = 130;
            this.splitContainer2.TabIndex = 0;
            // 
            // pictureSample
            // 
            this.pictureSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureSample.Location = new System.Drawing.Point(0, 0);
            this.pictureSample.Name = "pictureSample";
            this.pictureSample.Size = new System.Drawing.Size(130, 221);
            this.pictureSample.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureSample.TabIndex = 0;
            this.pictureSample.TabStop = false;
            // 
            // picturePoint
            // 
            this.picturePoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picturePoint.Location = new System.Drawing.Point(0, 0);
            this.picturePoint.Name = "picturePoint";
            this.picturePoint.Size = new System.Drawing.Size(256, 221);
            this.picturePoint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturePoint.TabIndex = 1;
            this.picturePoint.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.pictureBox1);
            this.tabPage4.Controls.Add(this.btn_github);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(390, 221);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "更新";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(223, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 53);
            this.button1.TabIndex = 3;
            this.button1.Text = "访问原神Bwiki地图";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "请我吃雪糕";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btn_github
            // 
            this.btn_github.Location = new System.Drawing.Point(223, 23);
            this.btn_github.Name = "btn_github";
            this.btn_github.Size = new System.Drawing.Size(164, 53);
            this.btn_github.TabIndex = 0;
            this.btn_github.Text = "访问项目开源页面";
            this.btn_github.UseVisualStyleBackColor = true;
            this.btn_github.Click += new System.EventHandler(this.btn_github_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(398, 359);
            this.checkedListBox1.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(261, 17);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(90, 115);
            this.btn_update.TabIndex = 11;
            this.btn_update.Text = "联网更新新坐标数据";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // cb_ShowLine
            // 
            this.cb_ShowLine.AutoSize = true;
            this.cb_ShowLine.Checked = true;
            this.cb_ShowLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ShowLine.Location = new System.Drawing.Point(27, 169);
            this.cb_ShowLine.Name = "cb_ShowLine";
            this.cb_ShowLine.Size = new System.Drawing.Size(104, 19);
            this.cb_ShowLine.TabIndex = 14;
            this.cb_ShowLine.Text = "显示经纬线";
            this.cb_ShowLine.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 613);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "原神雷达滤镜v1.0";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.V1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.U1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.V0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.U0)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureSample)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePoint)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_collection;
        private System.Windows.Forms.Button btnMonster;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_None;
        private System.Windows.Forms.Button btn_All;
        private System.Windows.Forms.Button btn__Boss;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_github;
        private System.Windows.Forms.TextBox game_height;
        private System.Windows.Forms.TextBox game_width;
        private System.Windows.Forms.Button btn_SetRect;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox pictureSample;
        private System.Windows.Forms.PictureBox picturePoint;
        private System.Windows.Forms.NumericUpDown U0;
        private System.Windows.Forms.NumericUpDown V1;
        private System.Windows.Forms.NumericUpDown U1;
        private System.Windows.Forms.NumericUpDown V0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb_AutoLoadScreen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.CheckBox cb_ShowLine;
    }
}

