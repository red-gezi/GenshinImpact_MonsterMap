using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 原神地图辅助器
{
    static class Extension
    {
        public static int ToMapPosX(this int ing, Rectangle targetRect, Size size)
        {
            int x = (int)Math.Round((ing * DataInfo.PixelPerIng * 0.1f + DataInfo.IngBias));
            return (int)((x - targetRect.X) * (size.Width * 1.0f / targetRect.Width));
        }

        public static int ToMapPosY(this int lat, Rectangle targetRect, Size size)
        {
            int y = (int)Math.Round((lat * DataInfo.PixelPerLat * 0.1f + DataInfo.LatBias));
            //因为是wiki地图球所以要做一个直线到曲面的映射
            var scale =lat==0?1: (lat * Math.PI) / (180 * Math.Sin(lat / 180 * Math.PI));
            y=(int)(y*scale);
            return (int)((y - targetRect.Y) * (size.Height * 1.0f / targetRect.Height));
        }
    }
}
