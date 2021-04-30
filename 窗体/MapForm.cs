using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace 原神地图辅助器
{
    public partial class MapForm : Form
    {


        private void timer1_Tick(object sender, EventArgs e)
        {

            var parent = Unitility.GetParent(Handle);
            if (parent!= DataInfo.hDeskTop)
            {
                Console.WriteLine("######################################################");
                Console.WriteLine("重新置顶");
                Console.WriteLine("######################################################");
                Unitility.SetParent(Handle, DataInfo.hDeskTop);//循环置顶
            }
        }
        public bool isJumpOutOfTask=false;
        public MapForm()
        {
            Unitility.SetParent(Handle, DataInfo.hDeskTop);
            //graphBuffer = (new BufferedGraphicsContext()).Allocate(MapForm_Paint.CreateGraphics(), Paint.DisplayRectangle);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            Graphics g = Graphics.FromImage(DataInfo.transparentMap);
            //pictureBox1.Image = DataInfo.transparentMap;
            //Graphics g = pictureBox1.CreateGraphics();
            Task task = Task.Run(() =>
            {
                while (true)
                {
                    if (isJumpOutOfTask) break;
                    try
                    {
                        Rectangle GameRect = new Rectangle();
                        Unitility.GetWindowRect(DataInfo.mainHandle, ref GameRect);
                        //Size = new Size(GameRect.Right - GameRect.Left, GameRect.Bottom - GameRect.Top);
                        Action changeSize = () => Size = new Size(DataInfo.width, DataInfo.height);
                        Invoke(changeSize);

                        Action changeLocation = () => Location = new Point(GameRect.Left, GameRect.Top);
                        Invoke(changeLocation);

                        Console.WriteLine("屏幕分辨率为" + Size);
                        DataInfo.gameMap = DataInfo.isUseFakePicture ? DataInfo.fakeMap : Unitility.GetScreenshot(DataInfo.mainHandle);
                        int scaleSrc = 1;
                        int scaleSub = 2;
                        Bitmap imgSrc = (Bitmap)DataInfo.mainMap.GetThumbnailImage(DataInfo.mainMap.Width / scaleSrc, DataInfo.mainMap.Height / scaleSrc, null, IntPtr.Zero);
                        Bitmap imgSub = (Bitmap)DataInfo.gameMap.GetThumbnailImage(DataInfo.gameMap.Width / scaleSub, DataInfo.gameMap.Height / scaleSub, null, IntPtr.Zero);
                        var targetRect = Unitility.MatchMap(imgSrc, imgSub, true, out Image outImage);
                        imgSrc.Dispose();
                        imgSub.Dispose();
                        var activePos = DataInfo.GetAllPos.Where(pos => DataInfo.selectTags.Contains(pos.name)).ToList();
                        activePos = activePos.Where(pos => pos.x > targetRect.X).ToList();

                        g.Clear(Color.Transparent);
                        activePos.ForEach(pos =>
                        {
                            int x = (int)((pos.x - targetRect.X) * (Size.Width * 1.0f / targetRect.Width));
                            int y = (int)((pos.y - targetRect.Y) * (Size.Height * 1.0f / targetRect.Height));
                            Bitmap icon = DataInfo.iconDict[pos.name];
                            if (x - icon.Width / 2 > 0 && y - icon.Height > 0)
                            {
                                g.DrawImage(DataInfo.iconDict[pos.name], new PointF(x - icon.Width / 2, y - icon.Height));
                            }
                        });
                        Console.WriteLine("坐标绘制完成");
                        DataInfo.sampleImage.Image = DataInfo.gameMap;
                        DataInfo.pointImage.Image = DataInfo.dealMap;
                        Console.WriteLine(DataInfo.gameMap.Size);
                        if (isJumpOutOfTask) break;
                        Action refreshImage = () => pictureBox1.Image = DataInfo.transparentMap;
                        Invoke(refreshImage);
                        Timer.Show("图片更新完毕");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e.StackTrace);
                    }
                }
            });
        }
    }
}
