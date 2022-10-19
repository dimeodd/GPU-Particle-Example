Shader "Custom/ParticleRendererShader" {
    SubShader {
        Tags { "RenderType" = "Opaque" }

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
            };

            struct v2f {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
            }; 

            struct Star {
                float3 position;
                float3 velocity;
                float4 color;
            };

            StructuredBuffer<Star> _stars;

            v2f vert(appdata_t i, uint instanceID: SV_InstanceID) {
                v2f o;

                float3 pos = _stars[instanceID].position;
                float4 pos4 = float4(pos.x,pos.y,pos.z,0) + i.vertex;
                o.vertex = UnityObjectToClipPos(pos4);
                
                o.color = _stars[instanceID].color;

                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                return i.color;
            }

            ENDCG
        }
    }
}