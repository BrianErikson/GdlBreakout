Shader "Unlit/ColorWireframe"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
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

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture

				//fixed4 col = tex2D(_MainTex, i.uv);
				//float val = min(i.uv.x + i.uv.y, 1);
				float r = step(0.8, 1 - sin((i.uv.x) * 3.15));
				float g = step(0.8, 1 - sin((i.uv.y) * 3.15));
				float val = max(r, g);
				fixed4 col = fixed4(0, val, 0, val);

				return col;
			}
			ENDCG
		}
	}
}
