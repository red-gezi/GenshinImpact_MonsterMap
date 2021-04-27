using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static 原神地图辅助器.DataInfo;
//using static 原神地图辅助器.Unitility;
namespace 原神地图辅助器
{
    public partial class MapForm : Form
    {
        static Process process = Process.GetProcessesByName("YuanShen").FirstOrDefault();
        IntPtr mainHandle = process.MainWindowHandle;
        IntPtr hDeskTop = Unitility.FindWindow("Progman ", "Program   Manager ");

        public MapForm()
        {
            InitializeComponent();
            Graphics g = Graphics.FromImage(transparentMap);

            Task task = Task.Run(() =>
            {
                while (true)
                {
                    if (isClose) break;
                    try
                    {
                        Rectangle GameRect = new Rectangle();
                        Unitility.GetWindowRect(mainHandle, ref GameRect);
                        //Size = new Size(GameRect.Right - GameRect.Left, GameRect.Bottom - GameRect.Top);

                        Action changeSize = () => Size = new Size(DataInfo.width, DataInfo.height);
                        Invoke(changeSize);

                        Action changeLocation = () => Location = new Point(GameRect.Left, GameRect.Top);
                        Invoke(changeLocation);

                        Console.WriteLine(Size);
                        gameMap = Unitility.GetScreenshot(mainHandle);
                        //gameMap.Save("sample.png");
                        int scale1 = 1;
                        int scale2 = 2;
                        Bitmap imgSrc = (Bitmap)mainMap.GetThumbnailImage(mainMap.Width / scale1, mainMap.Height / scale1, null, IntPtr.Zero);
                        Bitmap imgSub = (Bitmap)gameMap.GetThumbnailImage(gameMap.Width / scale2, gameMap.Height / scale2, null, IntPtr.Zero);
                        var targetRect = Unitility.MatchPicBySurf(imgSrc, imgSub);
                        imgSrc.Dispose();
                        imgSub.Dispose();
                        //var targetRect = Unitility.MatchPicBySift(imgSrc, imgSub);
                        var activePos = DataInfo.GetAllPos
                          .Where(pos => DataInfo.selectTags.Contains(pos.name)).ToList();
                        activePos = activePos.Where(pos => pos.x > targetRect.X).ToList();

                        g.Clear(Color.Transparent);
                        activePos.ForEach(pos =>
                        {
                            int x = (int)((pos.x - targetRect.X) * (Size.Width * 1.0f / targetRect.Width));
                            int y = (int)((pos.y - targetRect.Y) * (Size.Height * 1.0f / targetRect.Height));
                            Bitmap icon = (Bitmap)Image.FromFile("icon/" + pos.name);
                            if (x - icon.Width / 2 > 0 && y - icon.Height > 0)
                            {
                                g.DrawImage(icon, new PointF(x - icon.Width / 2, y - icon.Height));
                            }
                            icon.Dispose();
                        });
                        Console.WriteLine("坐标绘制完成");
                        DataInfo.sampleImage.Image = gameMap;
                        DataInfo.pointImage.Image = dealMap;
                        Action refreshImage = () => pictureBox1.Image = transparentMap;
                        Invoke(refreshImage);
                        Timer.Show("图片更新完毕");
                        //transparentMap.Save("test.png");
                        Console.WriteLine("更新图片");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e.StackTrace);
                    }
                }

            });
            // task.Wait();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    Rectangle GameRect = new Rectangle();
            //    Unitility.GetWindowRect(mainHandle, ref GameRect);
            //    //Size = new Size(GameRect.Right - GameRect.Left, GameRect.Bottom - GameRect.Top);
            //    Size = new Size(DataInfo.width, DataInfo.height);
            //    this.Location = new Point(GameRect.Left, GameRect.Top);
            //    Console.WriteLine(Size);
            //    gameMap = Unitility.GetScreenshot(mainHandle);
            //    //gameMap.Save("sample.png");
            //    int scale1 = 1;
            //    int scale2 = 5;
            //    Bitmap imgSrc = (Bitmap)mainMap.GetThumbnailImage(mainMap.Width / scale1, mainMap.Height / scale1, null, IntPtr.Zero);
            //    Bitmap imgSub = (Bitmap)gameMap.GetThumbnailImage(gameMap.Width / scale2, gameMap.Height / scale2, null, IntPtr.Zero);
            //    //var targetRect = Unitility.MatchPicBySurf(imgSrc, imgSub);
            //    var targetRect = Unitility.MatchPicBySift(imgSrc, imgSub);
            //    var activePos = DataInfo.GetAllPos
            //        .Where(pos => DataInfo.selectTags.Contains(pos.name)).ToList();
            //    activePos = activePos.Where(pos => pos.x > targetRect.X).ToList();

            //    Graphics g = Graphics.FromImage(transparentMap);
            //    g.Clear(Color.Transparent);
            //    activePos.ForEach(pos =>
            //    {
            //        int x = (int)((pos.x - targetRect.X) * (Size.Width * 1.0f / targetRect.Width));
            //        int y = (int)((pos.y - targetRect.Y) * (Size.Height * 1.0f / targetRect.Height));
            //        Bitmap icon = (Bitmap)Image.FromFile("icon/" + pos.name);
            //        if (x - icon.Width / 2 > 0 && y - icon.Height > 0)
            //        {
            //            g.DrawImage(Image.FromFile("icon/" + pos.name), new PointF(x - icon.Width / 2, y - icon.Height));
            //        }
            //    });
            //    pictureBox1.Image = transparentMap;
            //}
            //catch (Exception)
            //{

            //}

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Unitility.SetParent(this.Handle, hDeskTop);
        }
    }
}
