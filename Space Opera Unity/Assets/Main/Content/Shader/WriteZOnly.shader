Shader "inr/Base/Write Z Only"
{
	SubShader
	{
		Tags { "RenderType"="Transparent" "Queue"="Transparent-5" }
		Cull back
		ZWrite On
		ZTest Lequal

		Pass
		{
			ColorMask 0
		}
	}
}
