Shader "Unlit/ColorWireframe"
{
	Properties
	{
		_UVTex("Ignored", 2D) = "White" {}
		_LineColor("LineColor", Vector) = (0, 1, 0, 1)
		_LineThickness("LineThickness", float) = 0.2
	}
	SubShader
	{
		Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
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
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _UVTex;
			float4 _LineColor;
			float _LineThickness;
			float4 _UVTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _UVTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float topBar = step(1 - _LineThickness, i.uv.y);
				float leftBar = step(1 - _LineThickness, i.uv.x);
				float bottomBar = step(i.uv.y, _LineThickness);
				float rightBar = step(i.uv.x, _LineThickness);

				float val = min(1, topBar + leftBar + bottomBar + rightBar);

				fixed4 col = fixed4(_LineColor.x, _LineColor.y, _LineColor.z, val);

				return col;
			}
			ENDCG
		}
	}
}
