using UnityEngine;

namespace Utilities
{
    public static class UnityTypeExtensions
    {
        public static void WorldX(this Transform t, float x)
        {
            t.position = new Vector3(x, t.position.y, t.position.z);
        }
        public static void WorldY(this Transform t, float y)
        {
            t.position = new Vector3(t.position.x, y, t.position.z);
        }
        public static void WorldZ(this Transform t, float z)
        {
            t.position = new Vector3(t.position.x, t.position.y, z);
        }
        public static void WorldXY(this Transform t, float x, float y)
        {
            t.position = new Vector3(x, y, t.position.z);
        }
        public static void WorldYZ(this Transform t, float y, float z)
        {
            t.position = new Vector3(t.position.x, y, z);
        }
        public static void WorldXZ(this Transform t,float x, float z)
        {
            t.position = new Vector3(x, t.position.y, z);
        }

        public static Rect ToRect(this Bounds b)
        {
            return new Rect(b.min.x, b.min.y, b.size.x, b.size.y);
        }
    }
}
