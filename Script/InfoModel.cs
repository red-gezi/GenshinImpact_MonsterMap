using System.IO;

namespace 原神地图辅助器
{
    class InfoModel
    {
        public struct RECT
        {
            public int Left;                             //最左坐标
            public int Top;                             //最上坐标
            public int Right;                           //最右坐标
            public int Bottom;                        //最下坐标
        }
        public class Pos
        {
            public string name;

            float lng;
            float lat;
            float PixelPerIng => float.Parse(File.ReadAllLines("config/bias.txt")[0]) * 0.1f;
            float PixelPerLat => float.Parse(File.ReadAllLines("config/bias.txt")[1]) * 0.1f;
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
        
}
