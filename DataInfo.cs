﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 原神地图辅助器
{
    class DataInfo
    {
        public static Bitmap mainMap = (Bitmap)Image.FromFile("MainMap.jpg");
        public static Bitmap subMap = (Bitmap)Image.FromFile("sub.jpg");
        public static Bitmap gameMap;
        public static Bitmap transparentMap = (Bitmap)Image.FromFile("transparent.png");
        public static float scaleX;
        public static float scaleY;

        static List<Pos> posInfos = new List<Pos>();
        public static void LoadData()
        {
            DownLoadPosInfo("game=ys&ts=1618932203814&markTypes=87%2C88%2C89%2C105%2C106%2C107%2C108%2C175%2C&sign=5b69e10fcad70f825783527cbd6d0e1c");
            DownLoadPosInfo("game=ys&ts=1619009490581&markTypes=115%2C84%2C90%2C91%2C92%2C93%2C94%2C101%2C102%2C103%2C109%2C110%2C111%2C176%2C178%2C&sign=3c7c722f986faf9f1b8babcebd261070");
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
            var results = JsonConvert.DeserializeObject<DataModel>(response.Content);
            posInfos.AddRange(results.data.Select(info => new Pos(info.icon, float.Parse(info.point.lng), float.Parse(info.point.lat))).ToList());
            Console.WriteLine(response.Content);
            posInfos.ForEach(pos => Console.WriteLine(pos.name + ":\t" + pos.x + "," + pos.y));
        }

        public static List<Pos> GetAllPos()
        {
            //return new List<Pos>() { new Pos("可莉.png", 500, 500) };
            return posInfos;

        }
    }

    public class Pos
    {
        public string name;

        float lng;
        float lat;
        float PixelPerIng => float.Parse(File.ReadAllLines("config/bias.txt")[0]);
        float PixelPerLat => float.Parse(File.ReadAllLines("config/bias.txt")[1]);
        float IngBias => float.Parse(File.ReadAllLines("config/bias.txt")[2]);
        float LatBias => float.Parse(File.ReadAllLines("config/bias.txt")[3]);
        public int x => (int)(lng * PixelPerIng + IngBias);
        public int y => (int)(lat * PixelPerLat + LatBias);

        public Pos(string name, float lng, float lat)
        {
            this.name = name;
            this.lng = lng;
            this.lat = lat;
        }
    }

    public class DataModel
    {
        public int code { get; set; }
        public string message { get; set; }
        public Datum[] data { get; set; }
        public class Datum
        {
            public int markType { get; set; }
            public string title { get; set; }
            public string content { get; set; }
            public string imageLink { get; set; }
            public string wikiLink { get; set; }
            public string videoLink { get; set; }
            public string id { get; set; }
            public Point point { get; set; }
            public string icon { get; set; }
            public class Point
            {
                public string lng { get; set; }
                public string lat { get; set; }
            }
        }
    }





}
