using Newtonsoft.Json;
using System;
using System.IO;

namespace 原神地图辅助器
{
    public class InfoModel
    {
        public struct RECT
        {
            public int Left;                             //最左坐标
            public int Top;                             //最上坐标
            public int Right;                           //最右坐标
            public int Bottom;                        //最下坐标
        }
        public struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }
        public class Pos
        {
            public string name;

            public float lng;
            public float lat;
            [JsonIgnore]
            public int x => (int)Math.Round((lng * DataInfo.PixelPerIng * 0.1f + DataInfo.IngBias));
            [JsonIgnore]                                               
            public int y => (int)Math.Round((lat * DataInfo.PixelPerLat * 0.1f + DataInfo.LatBias));

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
