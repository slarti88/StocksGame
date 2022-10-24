using UnityEngine;

namespace StocksGame.Runtime
{
    public class SDDraw : MonoBehaviour
    {
        
        public static void Circle(Vector3 pos, float radius)
        {
            Material  mat    = SDMaterials.Circle;
            Matrix4x4 matrix = Matrix4x4.TRS(pos,Quaternion.identity,Vector3.one*.2f);
            Graphics.DrawMesh(SDMesh.QuadMesh,matrix,mat,LayerMask.NameToLayer("Default"));
        }

        public static void Line(Vector3 start, Vector3 end)
        {
            Material  mat    = SDMaterials.Line;
            Matrix4x4 matrix = Matrix4x4.TRS((start + end)*.5f,Quaternion.identity,Vector3.one *.2f);
            Graphics.DrawMesh(SDMesh.QuadMesh,matrix,mat,LayerMask.NameToLayer("Default"));
        }
    }
}
