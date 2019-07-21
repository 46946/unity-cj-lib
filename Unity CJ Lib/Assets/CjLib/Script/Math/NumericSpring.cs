﻿using System.Runtime.InteropServices;

using UnityEngine;

namespace CjLib
{
  [StructLayout(LayoutKind.Sequential, Pack = 0)]
  public struct SpringFloat
  {
    public static readonly int Stride = 2 * sizeof(float);

    public float Value;
    public float Velocity;

    public void Reset()
    {
      Value = 0.0f;
      Velocity = 0.0f;
    }

    public void Reset(float initValue)
    {
      Value = initValue;
      Velocity = 0.0f;
    }

    public void Reset(float initValue, float initVelocity)
    {
      Value = initValue;
      Velocity = initVelocity;
    }

    public float TrackDampingRatio(float targetValue, float angularFrequency, float dampingRatio, float deltaTime)
    {
      if (angularFrequency < MathUtil.Epsilon)
      {
        Velocity = 0.0f;
        return Value;
      }

      float delta = targetValue - Value;

      float f = 1.0f + 2.0f * deltaTime * dampingRatio * angularFrequency;
      float oo = angularFrequency * angularFrequency;
      float hoo = deltaTime * oo;
      float hhoo = deltaTime * hoo;
      float detInv = 1.0f / (f + hhoo);
      float detX = f * Value + deltaTime * Velocity + hhoo * targetValue;
      float detV = Velocity + hoo * delta;

      Velocity = detV * detInv;
      Value = detX * detInv;

      if (Velocity < MathUtil.Epsilon && delta < MathUtil.Epsilon)
      {
        Velocity = 0.0f;
        Value = targetValue;
      }

      return Value;
    }

    public float TrackHalfLife(float targetValue, float frequencyHz, float halfLife, float deltaTime)
    {
      if (halfLife < MathUtil.Epsilon)
      {
        Velocity = 0.0f;
        Value = targetValue;
        return Value;
      }

      float angularFrequency = frequencyHz * MathUtil.TwoPi;
      float dampingRatio = 0.6931472f / (angularFrequency * halfLife);
      return TrackDampingRatio(targetValue, angularFrequency, dampingRatio, deltaTime);
    }

    public float TrackExponential(float targetValue, float halfLife, float deltaTime)
    {
      if (halfLife < MathUtil.Epsilon)
      {
        Velocity = 0.0f;
        Value = targetValue;
        return Value;
      }

      float angularFrequency = 0.6931472f / halfLife;
      float dampingRatio = 1.0f;
      return TrackDampingRatio(targetValue, angularFrequency, dampingRatio, deltaTime);
    }
  }


  [StructLayout(LayoutKind.Sequential, Pack = 0)]
  public struct SpringVector2
  {
    public static readonly int Stride = 4 * sizeof(float);

    public Vector2 Value;
    public Vector2 Velocity;

    public void Reset()
    {
      Value = Vector2.zero;
      Velocity = Vector2.zero;
    }

    public void Reset(Vector2 initValue)
    {
      Value = initValue;
      Velocity = Vector2.zero;
    }

    public void Reset(Vector2 initValue, Vector2 initVelocity)
    {
      Value = initValue;
      Velocity = initVelocity;
    }

    public Vector2 TrackDampingRatio(Vector2 targetValue, float angularFrequency, float dampingRatio, float deltaTime)
    {
      if (angularFrequency < MathUtil.Epsilon)
      {
        Velocity = Vector2.zero;
        return Value;
      }

      Vector2 delta = targetValue - Value;

      float f = 1.0f + 2.0f * deltaTime * dampingRatio * angularFrequency;
      float oo = angularFrequency * angularFrequency;
      float hoo = deltaTime * oo;
      float hhoo = deltaTime * hoo;
      float detInv = 1.0f / (f + hhoo);
      Vector2 detX = f * Value + deltaTime * Velocity + hhoo * targetValue;
      Vector2 detV = Velocity + hoo * delta;

      Velocity = detV * detInv;
      Value = detX * detInv;

      if (Velocity.magnitude < MathUtil.Epsilon && delta.magnitude < MathUtil.Epsilon)
      {
        Velocity = Vector2.zero;
        Value = targetValue;
      }

      return Value;
    }

    public Vector2 TrackHalfLife(Vector2 targetValue, float frequencyHz, float halfLife, float deltaTime)
    {
      if (halfLife < MathUtil.Epsilon)
      {
        Velocity = Vector2.zero;
        Value = targetValue;
        return Value;
      }

      float angularFrequency = frequencyHz * MathUtil.TwoPi;
      float dampingRatio = 0.6931472f / (angularFrequency * halfLife);
      return TrackDampingRatio(targetValue, angularFrequency, dampingRatio, deltaTime);
    }

    public Vector2 TrackExponential(Vector2 targetValue, float halfLife, float deltaTime)
    {
      if (halfLife < MathUtil.Epsilon)
      {
        Velocity = Vector2.zero;
        Value = targetValue;
        return Value;
      }

      float angularFrequency = 0.6931472f / halfLife;
      float dampingRatio = 1.0f;
      return TrackDampingRatio(targetValue, angularFrequency, dampingRatio, deltaTime);
    }
  }


  [StructLayout(LayoutKind.Sequential, Pack = 0)]
  public struct SpringVector3
  {
    public static readonly int Stride = 8 * sizeof(float);

    public Vector3 Value;
    private float m_padding0;
    public Vector3 Velocity;
    private float m_padding1;

    public void Reset()
    {
      Value = Vector3.zero;
      Velocity = Vector3.zero;
    }

    public void Reset(Vector3 initValue)
    {
      Value = initValue;
      Velocity = Vector3.zero;
    }

    public void Reset(Vector3 initValue, Vector3 initVelocity)
    {
      Value = initValue;
      Velocity = initVelocity;
    }

    public Vector3 TrackDampingRatio(Vector3 targetValue, float angularFrequency, float dampingRatio, float deltaTime)
    {
      if (angularFrequency < MathUtil.Epsilon)
      {
        Velocity = Vector3.zero;
        return Value;
      }

      Vector3 delta = targetValue - Value;

      float f = 1.0f + 2.0f * deltaTime * dampingRatio * angularFrequency;
      float oo = angularFrequency * angularFrequency;
      float hoo = deltaTime * oo;
      float hhoo = deltaTime * hoo;
      float detInv = 1.0f / (f + hhoo);
      Vector3 detX = f * Value + deltaTime * Velocity + hhoo * targetValue;
      Vector3 detV = Velocity + hoo * delta;

      Velocity = detV * detInv;
      Value = detX * detInv;

      if (Velocity.magnitude < MathUtil.Epsilon && delta.magnitude < MathUtil.Epsilon)
      {
        Velocity = Vector3.zero;
        Value = targetValue;
      }

      return Value;
    }

    public Vector3 TrackHalfLife(Vector3 targetValue, float frequencyHz, float halfLife, float deltaTime)
    {
      if (halfLife < MathUtil.Epsilon)
      {
        Velocity = Vector3.zero;
        Value = targetValue;
        return Value;
      }

      float angularFrequency = frequencyHz * MathUtil.TwoPi;
      float dampingRatio = 0.6931472f / (angularFrequency * halfLife);
      return TrackDampingRatio(targetValue, angularFrequency, dampingRatio, deltaTime);
    }

    public Vector3 TrackExponential(Vector3 targetValue, float halfLife, float deltaTime)
    {
      if (halfLife < MathUtil.Epsilon)
      {
        Velocity = Vector3.zero;
        Value = targetValue;
        return Value;
      }

      float angularFrequency = 0.6931472f / halfLife;
      float dampingRatio = 1.0f;
      return TrackDampingRatio(targetValue, angularFrequency, dampingRatio, deltaTime);
    }
  }


  [StructLayout(LayoutKind.Sequential, Pack = 0)]
  public struct SpringVector4
  {
    public static readonly int Stride = 8 * sizeof(float);

    public Vector4 Value;
    public Vector4 Velocity;

    public void Reset()
    {
      Value = Vector4.zero;
      Velocity = Vector4.zero;
    }

    public void Reset(Vector4 initValue)
    {
      Value = initValue;
      Velocity = Vector4.zero;
    }

    public void Reset(Vector4 initValue, Vector4 initVelocity)
    {
      Value = initValue;
      Velocity = initVelocity;
    }

    public Vector4 TrackDampingRatio(Vector4 targetValue, float angularFrequency, float dampingRatio, float deltaTime)
    {
      if (angularFrequency < MathUtil.Epsilon)
      {
        Velocity = Vector4.zero;
        return Value;
      }

      Vector4 delta = targetValue - Value;

      float f = 1.0f + 2.0f * deltaTime * dampingRatio * angularFrequency;
      float oo = angularFrequency * angularFrequency;
      float hoo = deltaTime * oo;
      float hhoo = deltaTime * hoo;
      float detInv = 1.0f / (f + hhoo);
      Vector4 detX = f * Value + deltaTime * Velocity + hhoo * targetValue;
      Vector4 detV = Velocity + hoo * delta;

      Velocity = detV * detInv;
      Value = detX * detInv;

      if (Velocity.magnitude < MathUtil.Epsilon && delta.magnitude < MathUtil.Epsilon)
      {
        Velocity = Vector4.zero;
        Value = targetValue;
      }

      return Value;
    }

    public Vector4 TrackHalfLife(Vector4 targetValue, float frequencyHz, float halfLife, float deltaTime)
    {
      if (halfLife < MathUtil.Epsilon)
      {
        Velocity = Vector4.zero;
        Value = targetValue;
        return Value;
      }

      float angularFrequency = frequencyHz * MathUtil.TwoPi;
      float dampingRatio = 0.6931472f / (angularFrequency * halfLife);
      return TrackDampingRatio(targetValue, angularFrequency, dampingRatio, deltaTime);
    }

    public Vector4 TrackExponential(Vector4 targetValue, float halfLife, float deltaTime)
    {
      if (halfLife < MathUtil.Epsilon)
      {
        Velocity = Vector4.zero;
        Value = targetValue;
        return Value;
      }

      float angularFrequency = 0.6931472f / halfLife;
      float dampingRatio = 1.0f;
      return TrackDampingRatio(targetValue, angularFrequency, dampingRatio, deltaTime);
    }
  }


  [StructLayout(LayoutKind.Sequential, Pack = 0)]
  public struct SpringQuaternionLinear
  {
    public static readonly int Stride = 8 * sizeof(float);

    private Vector4 m_value;
    private Vector4 m_velocity;

    public Quaternion Value
    {
      get { return QuaternionUtil.FromVector4(m_value); }
      set { m_value = QuaternionUtil.ToVector4(value); }
    }

    public Quaternion Velocity
    {
      get { return QuaternionUtil.FromVector4(m_velocity, false); }
      set { m_velocity = QuaternionUtil.ToVector4(value); }
    }

    public void Reset()
    {
      m_value = Vector4.zero;
      m_velocity = Vector4.zero;
    }

    public void Reset(Quaternion initValue)
    {
      m_value = QuaternionUtil.ToVector4(initValue);
      m_velocity = Vector4.zero;
    }

    public void Reset(Quaternion initValue, Quaternion initVelocity)
    {
      m_value = QuaternionUtil.ToVector4(initValue);
      m_velocity = QuaternionUtil.ToVector4(initVelocity);
    }

    public Quaternion TrackDampingRatio(Quaternion targetValue, float angularFrequency, float dampingRatio, float deltaTime)
    {
      Vector4 targetValueVec = QuaternionUtil.ToVector4(targetValue);

      if (angularFrequency < MathUtil.Epsilon)
      {
        m_velocity = QuaternionUtil.ToVector4(Quaternion.identity);
        return QuaternionUtil.FromVector4(m_value);
      }

      Vector4 delta = targetValueVec - m_value;

      float f = 1.0f + 2.0f * deltaTime * dampingRatio * angularFrequency;
      float oo = angularFrequency * angularFrequency;
      float hoo = deltaTime * oo;
      float hhoo = deltaTime * hoo;
      float detInv = 1.0f / (f + hhoo);
      Vector4 detX = f * m_value + deltaTime * m_velocity + hhoo * targetValueVec;
      Vector4 detV = m_velocity + hoo * delta;

      m_velocity = detV * detInv;
      m_value = detX * detInv;

      if (m_velocity.magnitude < MathUtil.Epsilon && delta.magnitude < MathUtil.Epsilon)
      {
        m_velocity = QuaternionUtil.ToVector4(Quaternion.identity);;
        m_value = targetValueVec;
      }

      return QuaternionUtil.FromVector4(m_value);
    }

    public Quaternion TrackHalfLife(Quaternion targetValue, float frequencyHz, float halfLife, float deltaTime)
    {
      if (halfLife < MathUtil.Epsilon)
      {
        m_velocity = QuaternionUtil.ToVector4(Quaternion.identity);
        m_value = QuaternionUtil.ToVector4(targetValue);
        return targetValue;
      }

      float angularFrequency = frequencyHz * MathUtil.TwoPi;
      float dampingRatio = 0.6931472f / (angularFrequency * halfLife);
      return TrackDampingRatio(targetValue, angularFrequency, dampingRatio, deltaTime);
    }

    public Quaternion TrackExponential(Quaternion targetValue, float halfLife, float deltaTime)
    {
      if (halfLife < MathUtil.Epsilon)
      {
        m_velocity = QuaternionUtil.ToVector4(Quaternion.identity);
        m_value = QuaternionUtil.ToVector4(targetValue);
        return targetValue;
      }

      float angularFrequency = 0.6931472f / halfLife;
      float dampingRatio = 1.0f;
      return TrackDampingRatio(targetValue, angularFrequency, dampingRatio, deltaTime);
    }
  }
}
