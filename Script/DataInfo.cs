using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace 原神地图辅助器
{
    class DataInfo
    {
        public static Dictionary<string, Bitmap> iconDict = new Dictionary<string, Bitmap>();
        public static Bitmap mainMap = (Bitmap)Image.FromFile("img/MainMap.jpg");
        public static Bitmap transparentMap = (Bitmap)Image.FromFile("img/transparent.png");
        public static Bitmap fakeMap = (Bitmap)Image.FromFile("img/fake.jpg");
        public static Bitmap gameMap;
        public static Bitmap dealMap;
        public static PictureBox sampleImage;//来自游戏的采样截图
        public static PictureBox pointImage;//特征点对比截图
        public static float scaleX;
        public static float scaleY;
        static Process[] gameProcess => Process.GetProcessesByName(isUseFakePicture ? "NotePad" : "YuanShen");
        public static Process YuanshenProcess => gameProcess.Any() ? gameProcess[0] : null;
        public static IntPtr mainHandle => YuanshenProcess.MainWindowHandle;
        public static IntPtr hDeskTop = Unitility.FindWindow("Progman ", "Program   Manager ");

        public static int width = 1920;
        public static int height = 1080;
        public static bool isMapFormClose = false;
        public static bool isUseFakePicture = true;
        public static List<string> selectTags = new List<string>();
        public static List<InfoModel.Pos> GetAllPos { get; } = new List<InfoModel.Pos>();
        public static void LoadData()
        {
            DownLoadPosInfo("game=ys&ts=1618932203814&markTypes=87%2C88%2C89%2C105%2C106%2C107%2C108%2C175%2C&sign=5b69e10fcad70f825783527cbd6d0e1c");
            DownLoadPosInfo("game=ys&ts=1619009490581&markTypes=115%2C84%2C90%2C91%2C92%2C93%2C94%2C101%2C102%2C103%2C109%2C110%2C111%2C176%2C178%2C&sign=3c7c722f986faf9f1b8babcebd261070");
            DownLoadPosInfo("game=ys&ts=1619192690124&markTypes=15%2C17%2C18%2C29%2C32%2C37%2C41%2C51%2C180%2C&sign=efca01169d0c6326851ee09d19bb9432");
            DownLoadPosInfo("game=ys&ts=1619103048545&markTypes=24%2C27%2C28%2C33%2C40%2C42%2C53%2C54%2C83%2C181%2C&sign=dfd5178594302b315745b628c261d322");
            new DirectoryInfo("icon").GetFiles().ToList().ForEach(icon => { iconDict[icon.Name] = (Bitmap)Image.FromFile(icon.FullName); });
        }
        private static void DownLoadPosInfo(string cookie)
        {
            var client = new RestClient("https://tools-wiki.biligame.com/wiki/getMapData");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Origin", "https://wiki.biligame.com");
            request.AddHeader("Accept-Encoding", "gzip, deflate, br");
            request.AddHeader("Accept-Language", "zh-CN,zh;q=0.8");
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 UBrowser/6.2.4098.3 Safari/537.36";
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Referer", "https://wiki.biligame.com/ys/%E5%8E%9F%E7%A5%9E%E5%9C%B0%E5%9B%BE%E5%B7%A5%E5%85%B7_%E5%85%A8%E5%9C%B0%E6%A0%87%E4%BD%8D%E7%BD%AE%E7%82%B9");
            request.AddHeader("Connection", "keep-alive");
            request.AddParameter("application/x-www-form-urlencoded; charset=UTF-8", cookie, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var results = JsonConvert.DeserializeObject<InfoModel.DataModel>(response.Content);
            GetAllPos.AddRange(results.data.Select(info => new InfoModel.Pos(info.icon, float.Parse(info.point.lng), float.Parse(info.point.lat))));
        }
    }

}