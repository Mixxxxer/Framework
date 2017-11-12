// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Mobile/OptimisedUI"
{
	Properties
	{
		_MainTex("Base (RGB), Alpha (A)", 2D) = "white" {}
		_ColorMask("Color Mask", Float) = 15

		_StencilComp("Stencil Comparison", Float) = 8
		_Stencil("Stencil ID", Float) = 0
		_StencilOp("Stencil Operation", Float) = 0
		_StencilWriteMask("Stencil Write Mask", Float) = 255
		_StencilReadMask("Stencil Read Mask", Float) = 255
	}

	SubShader
		{
			LOD 100

			Tags
			{
				"Queue" = "Transparent"
				"IgnoreProjector" = "True"
				"RenderType" = "Transparent"
				"PreviewType" = "Plane"
			}

			Cull Off
			Lighting Off
			ZWrite Off
			Fog{ Mode Off }
			Blend SrcAlpha OneMinusSrcAlpha
			ColorMask[_ColorMask]

			Pass
				{
					CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

					struct appdata_t
					{
						float4 vertex : POSITION;
						float2 texcoord : TEXCOORD0;
						fixed4 color : COLOR;
					};

					struct v2f
					{
						float4 vertex : SV_POSITION;
						half2 texcoord : TEXCOORD0;
						fixed4 color : COLOR;
					};

					sampler2D _MainTex;
					float4 _MainTex_ST;

					v2f vert(appdata_t v)
					{
						v2f o;
						o.vertex = UnityObjectToClipPos(v.vertex);
						o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
						o.color = v.color;
						return o;
					}

					fixed4 frag(v2f i) : COLOR
					{
						return tex2D(_MainTex, i.texcoord) * i.color;
					}
						ENDCG
				}
		}
}
