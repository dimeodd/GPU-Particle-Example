using UnityEngine;

[CreateAssetMenu(fileName = "SO_GenerateProperty", menuName = "Particles/SO_GenerateProperty", order = 0)]
public class SO_GenerateProperty : ScriptableObject
{
    public Vector3 StartPosition;
    public Vector3 MainVelocity;
    [Min(1)] public float Range = 500f;
}
