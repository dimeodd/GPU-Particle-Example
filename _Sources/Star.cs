using UnityEngine;

public struct Star
{
    public Vector3 pos;
    public Vector3 velocity;
    public Vector4 color;

    public static int Size()
    {
        return
            sizeof(float) * 3 + // pos;
            sizeof(float) * 3 + // velocity;
            sizeof(float) * 4;  // color;
    }
}