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
        public static int ToMapPosX(this float ing) => (int)Math.Round((ing * DataInfo.PixelPerIng * 0.1f + DataInfo.IngBias));
        public static int ToMapPosY(this float lat) => (int)Math.Round((lat * DataInfo.PixelPerLat * 0.1f + DataInfo.LatBias));
        public static int ToMapPosX(this int ing, Rectangle targetRect, Size size)
        {
            int x = (int)Math.Round((ing * DataInfo.PixelPerIng * 0.1f + DataInfo.IngBias));
            return (int)((x - targetRect.X) * (size.Width * 1.0f / targetRect.Width));
        }

        public static int ToMapPosY(this int lat, Rectangle targetRect, Size size)
        {
            int y = (int)Math.Round((lat * DataInfo.PixelPerLat * 0.1f + DataInfo.LatBias));
            return (int)((y - targetRect.Y) * (size.Height * 1.0f / targetRect.Height));
        }
    }
}
