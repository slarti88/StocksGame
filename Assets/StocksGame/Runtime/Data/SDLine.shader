Shader "SD/SDLine"
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

            fixed AALine(fixed dist)
            {
                fixed alpha = 1 - smoothstep(.02,.05,dist);
                return alpha;
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
                // sample the texture
                fixed2 uv = i.uv-fixed2(.5,.5);
                fixed p = clamp(-.4,.4,uv.y);

                fixed2 xy = uv - fixed2(0,p);
                fixed dist = length(xy);
                fixed4 col = 1 - step(.05,dist);
                
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);

                col.a = AALine(dist);
                return col;
            }
            ENDCG
        }
    }
}
