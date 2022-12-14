Shader "SD/SDCircle"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }        
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            fixed AACircle(fixed2 uv)
            {
                float dist = 1 - length(uv)/.5;
                dist = .45 - dist;
                float2 ddist = float2(ddx(uv.x), ddy(uv.y));                
                float pixelDist = dist / length(ddist);                
                return saturate(.5 - pixelDist);
            }

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed2 uv = i.uv-fixed2(.5,.5);
                float dist = length(uv);
                fixed col = 1 - step(.5,dist);
                
                UNITY_APPLY_FOG(i.fogCoord, col);
                fixed alpha = AACircle(uv);
                return fixed4(col,col,col,alpha);
            }
            ENDCG
        }
    }
}
