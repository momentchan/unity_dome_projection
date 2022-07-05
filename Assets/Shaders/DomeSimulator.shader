Shader "Unlit/DomeSimulator"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _FOV("FOV", Range(0,360)) = 180
    }
    SubShader
    {
        Cull Front
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define PI 3.1415926535

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float4 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 normal : TEXCOORD0;
            };

            sampler2D _MainTex;
            float _FOV;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = v.normal;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float dir = atan2(-i.normal.z, i.normal.x);
                float radius = (1 - asin(i.normal.y) / (PI * 0.5)) * 180 / _FOV;
                
                clip(1 - radius);
                return tex2D(_MainTex, float2(radius * cos(dir) * 0.5 + 0.5, 
                                              radius * sin(dir) * 0.5 + 0.5));
            }
            ENDCG
        }
    }
}
