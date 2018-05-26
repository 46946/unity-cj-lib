﻿/******************************************************************************/
/*
  Project - Unity CJ Lib
            https://github.com/TheAllenChou/unity-cj-lib
  
  Author  - Ming-Lun "Allen" Chou
  Web     - http://AllenChou.net
  Twitter - @TheAllenChou
*/
/******************************************************************************/

using UnityEngine;

namespace CjLib
{
  public class RandomNoiseVector
  {
    private static bool s_randomVecInit = false;
    private static ComputeShader s_randomVec;
    private static int s_randomVec2KernelId;
    private static int s_randomVec3KernelId;
    private static void InitRandomVec()
    {
      NoiseCommon.InitCsId();

      if (s_randomVecInit)
        return;

      s_randomVec = (ComputeShader) Resources.Load("RandomNoiseVectorCs");
      s_randomVec2KernelId = s_randomVec.FindKernel("RandomVec2");
      s_randomVec3KernelId = s_randomVec.FindKernel("RandomVec3");
    }

    private static void GetRandomVec2(out ComputeShader shader, out int kernelId)
    {
      InitRandomVec();
      shader = s_randomVec;
      kernelId = s_randomVec2KernelId;
    }

    private static void GetRandomVec3(out ComputeShader shader, out int kernelId)
    {
      InitRandomVec();
      shader = s_randomVec;
      kernelId = s_randomVec3KernelId;
    }

    public static void Compute(Vector2[] output, int seed = 0)
    {
      ComputeShader shader;
      int kernelId;
      GetRandomVec2(out shader, out kernelId);
      int[] dimension = new int[] { output.GetLength(0), 1, 1 };
      NoiseCommon.Compute(output, shader, kernelId, seed, dimension, sizeof(float) * 2);
    }

    public static void Compute(Vector2[,] output, int seed = 0)
    {
      ComputeShader shader;
      int kernelId;
      GetRandomVec2(out shader, out kernelId);
      int[] dimension = new int[] { output.GetLength(0), output.GetLength(1), 1 };
      NoiseCommon.Compute(output, shader, kernelId, seed, dimension, sizeof(float) * 2);
    }

    public static void Compute(Vector3[] output, int seed = 0)
    {
      ComputeShader shader;
      int kernelId;
      GetRandomVec3(out shader, out kernelId);
      int[] dimension = new int[] { output.GetLength(0), 1, 1 };
      NoiseCommon.Compute(output, shader, kernelId, seed, dimension, sizeof(float) * 3);
    }

    public static void Compute(Vector3[,] output, int seed = 0)
    {
      ComputeShader shader;
      int kernelId;
      GetRandomVec3(out shader, out kernelId);
      int[] dimension = new int[] { output.GetLength(0), output.GetLength(1), 1 };
      NoiseCommon.Compute(output, shader, kernelId, seed, dimension, sizeof(float) * 3);
    }

    public static void Compute(Vector3[,,] output, int seed = 0)
    {
      ComputeShader shader;
      int kernelId;
      GetRandomVec3(out shader, out kernelId);
      int[] dimension = new int[] { output.GetLength(0), output.GetLength(1), output.GetLength(2) };
      NoiseCommon.Compute(output, shader, kernelId, seed, dimension, sizeof(float) * 3);
    }
  }
}