Shader "HorizontalBar" {
    Properties {
        _Frac ("Progress Bar Value", Range(0,1)) = 1.0
        [NoScaleOffset] _AlphaTex ("Alpha", 2D) = "White" {}
        _FillColor ("Fill Color", Color) = (1,1,1,1)
        _BackColor ("Back Color", Color) = (0,0,0,1)
        [Toggle(NO_ANTI_ALIASING)] _NoAntiAliasing ("Disable Anti-Aliasing", Float) = 0.0
    }

    SubShader {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane"}

        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #pragma shader_feature NO_ANTI_ALIASING

            #include "UnityCG.cginc"

            half _Frac;
            fixed4 _FillColor;
            fixed4 _BackColor;

            sampler2D _AlphaTex;

            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float gradient : TEXCOORD1;
            };

            v2f vert (appdata_full v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);

                o.uv = float2(v.texcoord1.x, v.texcoord1.y); // Use Y component for UV
                o.gradient = v.texcoord1.x; // Use X component for gradient
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                half gradient = i.gradient;

            #if defined(NO_ANTI_ALIASING)
                fixed4 col = _Frac > gradient ? _FillColor : _BackColor;
            #else
                half gradientDeriv = fwidth(i.gradient) * 1.5;
                half barProgress = smoothstep(_Frac, _Frac + gradientDeriv, gradient);
                fixed4 col = lerp(_FillColor, _BackColor, barProgress);
            #endif                

                fixed alpha = tex2D(_AlphaTex, i.uv).a;
                col.a *= alpha;

                return col;
            }
            ENDCG
        }
    }
}