using UnityEngine;
using UnityEngine.Rendering;

namespace StocksGame.Runtime.Test
{
	public class SDLineTest : MonoBehaviour
	{
		void OnCameraPreRender(Camera cam)
		{
			SDDraw.Line(new Vector3(0,0,0),new Vector3(0,1,0));
			
			SDDraw.Line(new Vector3(1,0,0),new Vector3(1,3,0));
		}
    
		#if (SHAPES_URP || SHAPES_HDRP)
		#if UNITY_2019_1_OR_NEWER
		public virtual void OnEnable() => RenderPipelineManager.beginCameraRendering += Draw;
		public virtual void OnDisable() => RenderPipelineManager.beginCameraRendering -= Draw;
		void                Draw( ScriptableRenderContext ctx, Camera cam ) => OnCameraPreRender( cam );
		#else
				public virtual void OnEnable() => Debug.LogWarning( "URP/HDRP immediate mode doesn't really work pre-Unity 2019.1, as there is no OnPreRender or beginCameraRendering callback" );
		#endif
		#else
		public virtual void OnEnable() => Camera.onPreRender += OnCameraPreRender;
		public virtual void OnDisable() => Camera.onPreRender -= OnCameraPreRender;
		#endif
	}
}
