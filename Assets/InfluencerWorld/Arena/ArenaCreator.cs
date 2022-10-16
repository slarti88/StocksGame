using System;
using System.Collections;
using System.Collections.Generic;
using InfluencerWorld.Simulator;
using Shapes;
using UnityEngine;
using Random = UnityEngine.Random;

[DefaultExecutionOrder(-1)]
public class ArenaCreator : ImmediateModeShapeDrawer
{
    private List<Vector3> discPositions = new List<Vector3>();
    private List<Color> discColors = new List<Color>();

    private void Start()
    {
        SetPositions();
    }

    public override void DrawShapes(Camera cam)
    {
        using (Draw.Command(cam))
        {
           CreateArena();
        }
    }

    void SetPositions()
    {
        for (int j = 1; j < 4; ++j)
        {
            for (int i = 0; i < 5 + j*2; ++i)
            {
                float radius = j;
                float theta  = 2*Mathf.PI * i /(5+j*2);
                discPositions.Add(new Vector3(radius *Mathf.Cos(theta),radius *Mathf.Sin(theta),0));
                discColors.Add(Color.white);
            }
        }
    }

    private void CreateArena()
    {
        Draw.DiscGeometry   = DiscGeometry.Flat2D;
        Draw.ThicknessSpace = ThicknessSpace.Pixels;
        Draw.Thickness      = 4;
            
        Draw.Matrix = transform.localToWorldMatrix;

        for (int i = 0; i < discPositions.Count; ++i)
        {
            Draw.Disc(discPositions[i],.2F,discColors[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDiscs(List<Affinities> circVals)
    {
        for (int i = 0; i < circVals.Count; ++i)
        {
            discColors[i] = circVals[i].likeCount > 5 ? Color.cyan:circVals[i].didLike?Color.green : Color.red;
        }
    }
}
