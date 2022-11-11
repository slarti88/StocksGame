using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StocksGame.Runtime
{
    public static class SDPlot
    {
        private static Matrix4x4 Matrix = Matrix4x4.identity;

        public static Rect Frame
        {
            get;
            set;
        }
        
        public static void DrawLineGraph(List<float> xPoints, List<float> yPoints)
        {
            DrawLineGraphInternal(xPoints,yPoints);
        }
        public static void DrawLineGraph(List<float> yPoints)
        {
            List<float> xPoints = new List<float>();
            for (int i = 0; i < yPoints.Count; ++i)
            {
                xPoints.Add(i);
            }
            DrawLineGraphInternal(xPoints,yPoints);
        }

        private static void DrawLineGraphInternal(List<float> xPoints, List<float> yPoints)
        {
            Rect inputFrame = Rect.MinMaxRect(xPoints.Min(), yPoints.Min(), xPoints.Max(), yPoints.Max());
            for (int i = 0; i < xPoints.Count; ++i)
            {
                SDDraw.Circle(ConvertToFrameSpace(new Vector3(xPoints[i],yPoints[i],0),inputFrame),.2f);
            }
            for (int i = 0; i < xPoints.Count -1; ++i)
            {
                SDDraw.Line(ConvertToFrameSpace(new Vector3(xPoints[i],yPoints[i],0),inputFrame),
                    ConvertToFrameSpace(new Vector3(xPoints[i +1],yPoints[i +1],0),inputFrame));
            }
        }

        //TODO Conversion can be done via matrices?
        public static Vector3 ConvertToFrameSpace(Vector3 input, Rect inputFrame)
        {
            input = Vector3.Scale(input, new Vector3(Frame.size.x /inputFrame.size.x, 
                Frame.size.y                                      /inputFrame.size.y, 1));
            input -= new Vector3(inputFrame.xMin - Frame.xMin,inputFrame.yMin - Frame.yMin,0);
            return input;
        }
    }
}
