Shader "Hidden/SimpleChromaticAberration"
{
    Properties
    {
        _MainTex("Base", 2D) = "" {}
    }

    CGINCLUDE

#include "UnityCG.cginc"

sampler2D _MainTex;
float4 _MainTex_TexelSize;
half _Amount;

half4 frag(v2f_img i) : SV_Target
{
    half2 d = (i.uv - 0.5f) * 2.0f;
    half l = dot(d, d) * _Amount;

    half2 uv2 = i.uv - _MainTex_TexelSize.xy * d * l;

    half4 c1 = tex2D(_MainTex, i.uv);
    half4 c2 = tex2D(_MainTex, uv2);

    c1.g = c2.g;
    return c1;
}

    ENDCG

    Subshader
    {
        Pass
        {
            ZTest Always Cull Off ZWrite Off
            Fog { Mode off }
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            ENDCG
        }
    }
}
