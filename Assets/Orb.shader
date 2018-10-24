Shader "Custom/Orb"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Color("Color", Color) = (1, 1, 1, 1)
        _Alpha("Alpha", Range(0, 1)) = 1
        _FresnelBias("Rim Bias", Float) = 0
        _FresnelScale("Rim Scale", Float) = 1
        _FresnelPower("Rim Power", Float) = 1
        _RimColor("Rim Color",Color) = (1,1,1,1)
        _Saturation("Saturation", Float) = 1
    }

        SubShader
        {
            Tags
            {
                "Queue" = "Transparent"
                "IgnoreProjector" = "True"
                "RenderType" = "Transparent"
            }

            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha
        
            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float3 normal : NORMAL;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float4 vertex : SV_POSITION;
                    float2 uv : TEXCOORD0;
                    fixed4 worldPos : TEXCOORD1;
                    fixed fresnel : TEXCOORD2;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                fixed4 _Color;
                fixed _Alpha;
                fixed _Contours;
                fixed _Distortion;

                // Fresnel
                fixed _FresnelBias;
                fixed _FresnelScale;
                fixed _FresnelPower;
                fixed4 _RimColor;
                fixed _Saturation;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.worldPos = mul(unity_ObjectToWorld, v.vertex);

                    float4 vert = v.vertex;

                    o.vertex = UnityObjectToClipPos(vert);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                    // Vertex normals in world-space
                    fixed3 worldNrm = normalize(mul((float3x3)unity_ObjectToWorld, v.normal));

                    // Fresnel effect
                    fixed3 I = normalize(o.worldPos - _WorldSpaceCameraPos.xyz);
                    o.fresnel = _FresnelBias + _FresnelScale * pow(1.0 + dot(I, worldNrm), _FresnelPower);

                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    // Main texture (R)
                    fixed tex = tex2D(_MainTex, i.uv * float2(2, 1)).r;

                    // Blend between input colour and ground color, based on main texture value
                    fixed4 col = _Color * (tex.r + 0.5);

                    // Light textures (G,B)
                    fixed4 light_mask = tex2D(_MainTex, i.uv);
                    col = lerp(col, _RimColor, saturate(i.fresnel * 0.7));
                    col.rgb *= _Saturation;
                    col.a *= _Alpha;


                    return col;
                }
                ENDCG
            }
        }
}
