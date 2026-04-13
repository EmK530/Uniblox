using System;
using System.Collections;
using static Enum;

public class Vector3
{
    public readonly double X, Y, Z;
    public override string ToString() => $"{X}, {Y}, {Z}";

    public double Magnitude
    {
        get
        {
            double product = Dot(this);
            double magnitude = Math.Sqrt(product);
            return magnitude;
        }
    }
    public double magnitude
    {
        get { return Magnitude; }
    }

    public Vector3 Unit
    {
        get { return this / Magnitude; }
    }

    public Vector3(double x = 0, double y = 0, double z = 0)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public Vector3(params double[] coords)
    {
        X = coords.Length > 0 ? coords[0] : 0;
        Y = coords.Length > 1 ? coords[1] : 0;
        Z = coords.Length > 2 ? coords[2] : 0;
    }

    public static Vector3 FromAxis(Axis axis)
    {
        double[] coords = new double[3] { 0d, 0d, 0d };

        int index = (int)axis;
        coords[index] = 1f;

        return new Vector3(coords);
    }

    public static Vector3 FromNormalId(NormalId normalId)
    {
        double[] coords = new double[3] { 0d, 0d, 0d };

        int index = (int)normalId;
        coords[index % 3] = (index > 2 ? -1f : 1f);

        return new Vector3(coords);
    }

    private delegate Vector3 Operator(Vector3 a, Vector3 b);

    private static Vector3 UpcastDoubleOp(Vector3 vec, double num, Operator upcast)
    {
        Vector3 numVec = new Vector3(num, num, num);
        return upcast(vec, numVec);
    }

    private static Vector3 UpcastDoubleOp(double num, Vector3 vec, Operator upcast)
    {
        Vector3 numVec = new Vector3(num, num, num);
        return upcast(numVec, vec);
    }

    private static readonly Operator add = (a, b) => new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    private static readonly Operator sub = (a, b) => new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    private static readonly Operator mul = (a, b) => new Vector3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
    private static readonly Operator div = (a, b) => new Vector3(a.X / b.X, a.Y / b.Y, a.Z / b.Z);

    public static Vector3 operator +(Vector3 a, Vector3 b) => add(a, b);
    public static Vector3 operator +(Vector3 v, double n) => UpcastDoubleOp(v, n, add);
    public static Vector3 operator +(double n, Vector3 v) => UpcastDoubleOp(n, v, add);

    public static Vector3 operator -(Vector3 a, Vector3 b) => sub(a, b);
    public static Vector3 operator -(Vector3 v, double n) => UpcastDoubleOp(v, n, sub);
    public static Vector3 operator -(double n, Vector3 v) => UpcastDoubleOp(n, v, sub);

    public static Vector3 operator *(Vector3 a, Vector3 b) => mul(a, b);
    public static Vector3 operator *(Vector3 v, double n) => UpcastDoubleOp(v, n, mul);
    public static Vector3 operator *(double n, Vector3 v) => UpcastDoubleOp(n, v, mul);

    public static Vector3 operator /(Vector3 a, Vector3 b) => div(a, b);
    public static Vector3 operator /(Vector3 v, double n) => UpcastDoubleOp(v, n, div);
    public static Vector3 operator /(double n, Vector3 v) => UpcastDoubleOp(n, v, div);

    public static Vector3 operator -(Vector3 v) => new Vector3(-v.X, -v.Y, -v.Z);

    public static implicit operator UnityEngine.Vector3(Vector3 v)
    {
        return new UnityEngine.Vector3((float)v.X, (float)v.Y, (float)v.Z);
    }

    public static implicit operator Vector3(UnityEngine.Vector3 v)
    {
        return new Vector3(v.x, v.y, v.z);
    }

    public static readonly Vector3 zero = new Vector3(0, 0, 0);
    public static readonly Vector3 one = new Vector3(1, 1, 1);

    public static readonly Vector3 xAxis = new Vector3(1, 0, 0);
    public static readonly Vector3 yAxis = new Vector3(0, 1, 0);
    public static readonly Vector3 zAxis = new Vector3(0, 0, 1);

    public static Vector3 Right => xAxis;
    public static Vector3 Up => yAxis;
    public static Vector3 Back => zAxis;

    public double Dot(Vector3 other)
    {
        double dotX = X * other.X;
        double dotY = Y * other.Y;
        double dotZ = Z * other.Z;

        return dotX + dotY + dotZ;
    }

    public Vector3 Cross(Vector3 other)
    {
        double crossX = Y * other.Z - other.Y * Z;
        double crossY = Z * other.X - other.Z * X;
        double crossZ = X * other.Y - other.X * Y;

        return new Vector3(crossX, crossY, crossZ);
    }

    public Vector3 Lerp(Vector3 other, double t)
    {
        return this + (other - this) * t;
    }

    public bool IsClose(Vector3 other, double epsilon = 0.0d)
    {
        return (other - this).Magnitude <= Math.Abs(epsilon);
    }

    public override int GetHashCode()
    {
        int hash = X.GetHashCode()
                 ^ Y.GetHashCode()
                 ^ Z.GetHashCode();

        return hash;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Vector3 other))
            return false;

        if (!X.Equals(other.X))
            return false;

        if (!Y.Equals(other.Y))
            return false;

        if (!Z.Equals(other.Z))
            return false;

        return true;
    }

    [StaticOnly] public static Vector3 @new() => new Vector3();
    [StaticOnly] public static Vector3 @new(double x) => new Vector3(x);
    [StaticOnly] public static Vector3 @new(double x, double y) => new Vector3(x, y);
    [StaticOnly] public static Vector3 @new(double x, double y, double z) => new Vector3(x, y, z);
}