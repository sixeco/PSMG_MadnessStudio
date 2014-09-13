Shader "Custom/ResponsiveShieldShader" {
	Properties {
	  _Color ("Main Color", COLOR) = (1,1,1,0)
      _RimColor ("Rim Color", Color) = (0.26,0.19,0.16,0.0)
      _RimPower ("Rim Power", Range(0.1,10.0)) = 3.0
      
    }
    SubShader {
               
      Tags {"QUEUE"="Transparent" "RenderType" = "Transparent" }
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		AlphaTest Greater 0
		ColorMask RGB
  
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float3 viewDir;
      };
      

      float4 _Color;
      float4 _RimColor;
      float _RimPower;
      
      void surf (Input IN, inout SurfaceOutput o) 
      {
		o.Albedo = _Color.rbga * 1;
		half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));
		o.Emission = _RimColor.rgb * pow (rim, _RimPower);
		o.Alpha = _RimColor.a;
		
      }
      ENDCG
    } 
    Fallback "Diffuse"
}
