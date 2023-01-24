Shader "Unlit/Fog"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _Height("Color", float) = 20
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Transparent"
            "Queue" = "Transparent"
        }

        Cull Front

        CGPROGRAM
        #pragma surface surf Lambert vertex:vert alpha:fade

        fixed4 _Color;
        fixed _Height;

        struct Input
        {
            float4 color : COLOR;
            float3 localPos;
        };

        void vert(inout appdata_full v, out Input o)
        {
            v.normal.xyz = v.normal * -1;
            UNITY_INITIALIZE_OUTPUT(Input,o);
            o.localPos = v.vertex.xyz;
        }

        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = _Color;
            o.Alpha = _Color.a * step(IN.localPos.z * 100, _Height);
        }
        ENDCG

    }

    Fallback "Diffuse"
}
