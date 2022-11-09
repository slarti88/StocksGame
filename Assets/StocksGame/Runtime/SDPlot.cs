using System.Collections.Generic;
using UnityEngine;

namespace StocksGame.Runtime
{
    public static class SDPlot
    {
        private static Matrix4x4 Matrix = Matrix4x4.identity;
        
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
            for (int i = 0; i < xPoints.Count; ++i)
            {
                SDDraw.Circle(ConvertToFrameSpace(new Vector3(xPoints[i],yPoints[i],0)),.2f);
            }
            for (int i = 0; i < xPoints.Count -1; ++i)
            {
                SDDraw.Line(ConvertToFrameSpace(new Vector3(xPoints[i],yPoints[i],0)),
                    ConvertToFrameSpace(new Vector3(xPoints[i +1],yPoints[i +1],0)));
            }
        }

        //TODO Conversion can be done via matrices?
        static Vector3 ConvertToFrameSpace(Vector3 input)
        {
            return Vector3.Scale(input, new Vector3(.25f, 1, 1));
        }
    }
}
