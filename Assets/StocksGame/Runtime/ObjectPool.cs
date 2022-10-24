using System.Collections.Generic;
using Shapes;
using StocksGame.Runtime.Data;
using UnityEngine;

namespace StocksGame.Runtime
{
    internal static class ObjectPool<T> where T : new() 
    {
        static readonly Stack<T> pool = new Stack<T>();

        public static T Alloc()
        {
            if (pool.Count == 0)
            {
                return new T();
            }
            return pool.Pop();
        }
        public static   void     Free( T obj ) => pool.Push( obj );
    }

    internal static class SDMaterials
    {
        public static readonly Material Circle = new Material(Shader.Find("SD/SDCircle"));
        public static readonly Material Line = new Material(Shader.Find("SD/SDLine"));
    }
    
    internal static class SDMesh
    {
        public static readonly Mesh QuadMesh = SDObjects.Instance.Quad;
    }
}
