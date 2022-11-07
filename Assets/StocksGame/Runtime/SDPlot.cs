using System.Collections.Generic;
using UnityEngine;

namespace StocksGame.Runtime
{
    public static class SDPlot
    {
        public static void DrawLineGraph(List<float> xPoints, List<float> yPoints)
        {
            for (int i = 0; i < xPoints.Count; ++i)
            {
                SDDraw.Circle(new Vector3(xPoints[i],yPoints[i],0),.2f);
            }
            for (int i = 0; i < xPoints.Count-1; ++i)
            {
                SDDraw.Line(new Vector3(xPoints[i],yPoints[i],0),new Vector3(xPoints[i+1],yPoints[i+1],0));
            }
            // SDDraw.Line(Vector3.zero,Vector3.one);
        }
    }
}
