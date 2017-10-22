﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

/******************************************************************************/
// Upgrade NOTE: excluded shader from DX11; has structs without semantics (struct v2f members normal)
#pragma exclude_renderers d3d11
/*
  Project - Unity CJ Lib
            https://github.com/TheAllenChou/unity-cj-lib

  Author  - Ming-Lun "Allen" Chou
  Web     - http://AllenChou.net
  Twitter - @TheAllenChou
*/
/******************************************************************************/

#ifndef PRIMITIVE_FLAT_COLOR_CORE
#define PRIMITIVE_FLAT_COLOR_CORE

#include "UnityCG.cginc"

struct appdata
{
  float4 vertex : POSITION;

#ifdef NORMAL_ON
  float3 normal : NORMAL;
#endif
};

struct v2f
{
  float4 vertex : SV_POSITION;

#ifdef NORMAL_ON
  float3 normalDotView : NORMAL;
#endif
};

float4 _Color;

// (x, y, z) == (dimensionX, dimensionY, dimensionZ)
// w == shiftY (0.0 -> no shif;, >0.0 -> shift 0.5 towards origin, scale by dimensions, and then shoft back 0.5 * offsetY)
float4 _Dimensions;

float _ZBias;

sampler2D _MainTex;
float4 _MainTex_ST;

v2f vert (appdata v)
{
  v2f o;

#ifdef NORMAL_ON
  o.normalDotView = dot(v.normal, normalize(ObjSpaceViewDir(v.vertex)));
  o.normalDotView = 0.8f * o.normalDotView + 0.2f; // darkest at 0.2f
#endif

  const float ySign = sign(v.vertex.y) * sign(_Dimensions.w);
  v.vertex.y -= ySign * 0.5f;
  v.vertex.xyz *= _Dimensions.xyz;
  v.vertex.y += ySign * 0.5f * _Dimensions.w;
  o.vertex = UnityObjectToClipPos(v.vertex);
  o.vertex.z += _ZBias;

  return o;
}

fixed4 frag (v2f i) : SV_Target
{
  fixed4 color = _Color;

#ifdef NORMAL_ON
  color.rgb *= i.normalDotView;
#endif

  return color;
}

#endif