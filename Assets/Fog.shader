Shader "Unlit/Fog"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _Height("Height", float) = 20
        _Size("Size", float) = 70
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Transparent"
            "Queue" = "Transparent"
            "LightMode" = "Always"
        }

        Cull Back

        CGPROGRAM
        #pragma surface surf Lambert vertex:vert alpha:fade
        
        fixed4 _Color;
        fixed _Height;
        fixed _Size;

        struct Input
        {
            float4 color : COLOR;
            float3 localPos;
        };

        void vert(inout appdata_full v, out Input o)
        {
            UNITY_INITIALIZE_OUTPUT(Input, o);
            v.normal.xyz = -v.normal;
            v.vertex.xyz += v.normal.xyz * _Size;
            o.localPos = v.vertex.xyz;
        }

        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = _Color;
            o.Alpha = _Color.a * step(IN.localPos.y, _Height);
        }
        ENDCG
    }
}
