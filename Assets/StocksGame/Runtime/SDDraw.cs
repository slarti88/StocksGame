using UnityEngine;

namespace StocksGame.Runtime
{
    public static class SDDraw
    {
        private static readonly int Thickness = Shader.PropertyToID("_Thickness");

        public static void Circle(Vector3 pos, float radius)
        {
            Material  mat    = SDMaterials.Circle;
            Matrix4x4 matrix = Matrix4x4.TRS(pos,Quaternion.identity,Vector3.one*radius);
            Graphics.DrawMesh(SDMesh.QuadMesh,matrix,mat,LayerMask.NameToLayer("Default"));
        }

        public static void Line(Vector3 start, Vector3 end)
        {
            Material  mat    = SDMaterials.Line;
            SDMaterials.MaterialPropertyBlock.SetFloat(Thickness,(end -start).magnitude);
            Matrix4x4 matrix = Matrix4x4.TRS((start + end)*.5f,Quaternion.FromToRotation(Vector3.up,end-start),
                                            (end-start).magnitude*Vector3.one);
            Graphics.DrawMesh(SDMesh.QuadMesh,matrix,mat,LayerMask.NameToLayer("Default"),
                Camera.main,0,SDMaterials.MaterialPropertyBlock);
        }
    }
}
