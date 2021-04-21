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
using static 原神地图辅助器.DataInfo;
using static 原神地图辅助器.Unitility;
namespace 原神地图辅助器
{
    public partial class MapForm : Form
    {
        public MapForm()
        {
            InitializeComponent();
            SetProcessDPIAware();
        }

        static Process process = Process.GetProcessesByName("YuanShen")[0];
        IntPtr mainHandle = process.MainWindowHandle;
        IntPtr hDeskTop = FindWindow("Progman ", "Program   Manager ");

        private void timer1_Tick(object sender, EventArgs e)
        {
            Rectangle GameRect = new Rectangle();
            GetWindowRect(mainHandle, ref GameRect);
            Size = new Size(GameRect.Right - GameRect.Left, GameRect.Bottom - GameRect.Top);
            this.Location = new Point(GameRect.Left, GameRect.Top);
            Console.WriteLine(Size);
            gameMap = GetScreenshot(mainHandle);
            pictureBox1.Image = gameMap;
            int scale1 = 1;
            int scale2 = 2;
            Bitmap imgSrc = (Bitmap)mainMap.GetThumbnailImage(mainMap.Width / scale1, mainMap.Height / scale1, null, IntPtr.Zero);
            Bitmap imgSub = (Bitmap)gameMap.GetThumbnailImage(gameMap.Width / scale2, gameMap.Height / scale2, null, IntPtr.Zero);
            var targetRect = MatchPicBySift(imgSrc, imgSub);

            var activePos = DataInfo.GetAllPos().Where(pos => pos.x > targetRect.X).ToList();


            Graphics g = Graphics.FromImage(transparentMap);
            g.Clear(Color.Transparent);
            activePos.ForEach(pos =>
            {

                int x = (int)((pos.x - targetRect.X) * (Size.Width * 1.0f / targetRect.Width));
                int y = (int)((pos.y - targetRect.Y) * (Size.Height * 1.0f / targetRect.Height));

                Bitmap icon = (Bitmap)Image.FromFile("icon/" + pos.name);

                if (x - icon.Width / 2 > 0 && y - icon.Height > 0)
                {
                    g.DrawImage(Image.FromFile("icon/" + pos.name), new PointF(x - icon.Width / 2, y - icon.Height));
                }
            });

            //if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
            pictureBox1.Image = transparentMap;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            SetParent(this.Handle, hDeskTop);
        }
    }
}
