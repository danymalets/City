Shader "DShaders/DiffuseChangeColor"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _SourceIndex ("SourceIndex", Int) = 3
        _TargetIndex ("TargetIndex", Int) = 4
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
        }
        LOD 150

        CGPROGRAM
        #pragma surface surf Lambert noforwardadd

        sampler2D _MainTex;
        int _SourceIndex;
        int _TargetIndex;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf(Input IN, inout SurfaceOutput o)
        {
            float2 t = IN.uv_MainTex;

            int x = IN.uv_MainTex.x * 10;
            int y = IN.uv_MainTex.y * 10;

            int cur_index = x + (9 - y) * 10 + 1;
            
            fixed4 c;
            if (cur_index == _SourceIndex)
            {
                int new_x = (_TargetIndex - 1) % 10;
                int new_y = 9 - (_TargetIndex - 1) / 10;
                c = tex2D(_MainTex, float2(new_x / 10.0 + 0.05, new_y / 10.0 + 0.05));
            }
            else
            {
                c = tex2D(_MainTex, t);
            }

            o.Albedo = c;
            o.Alpha = c.a;
        }
        ENDCG
    }
    Fallback "Mobile/Diffuse"
}