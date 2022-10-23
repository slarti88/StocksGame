using UnityEngine;

namespace StocksGame.Runtime.Data
{
    [CreateAssetMenu(menuName = "SD/SDObject")]
    public class SDObjects : ScriptableObject
    {
        public Mesh Quad;

        private static SDObjects _instance;
        public static SDObjects Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<SDObjects>( "SD Objects" );
                }

                return _instance;
            }
        }
    }
}
