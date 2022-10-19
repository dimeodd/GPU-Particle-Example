using UnityEngine;
using Helpers;

public class Main : MonoBehaviour
{
    [Header("Property")]
    public int ParticleCount = 1_000_000;
    public SO_GenerateProperty StartProperty;
    [Range(-200, 200)] public float TimeMultipler = 1;
    [Header("Shaderes")]
    public Material Material;
    public ComputeShader GravityCompute;

    ComputeBuffer _starBuffer;
    ComputeBuffer _argsBuffer;
    Mesh _mesh;
    Bounds _bounds;
    int _kernel;
    int _numberOfGroups;

    public void SetTimeMultipler(float value)
    {
        TimeMultipler = value;
    }

    private void Start()
    {
        // Boundary surrounding the meshes we will be drawing.  Used for occlusion.
        _bounds = new Bounds(transform.position, Vector3.one * (StartProperty.Range + 1));
        _mesh = HelperMesh.CreateD8();

        _argsBuffer = InitializeMeshArgsBuffer(_mesh);
        _starBuffer = InitializeStarBuffer();

        //Set shader values
        Material.SetBuffer("_stars", _starBuffer);

        //Set computeShader values
        _kernel = GravityCompute.FindKernel("DemoGravity");
        GravityCompute.SetBuffer(_kernel, "_Stars", _starBuffer);
        GravityCompute.SetFloat("deltaTime", 1f);

        _numberOfGroups = Mathf.CeilToInt((float)ParticleCount / 128);
    }
    private ComputeBuffer InitializeMeshArgsBuffer(Mesh mesh)
    {
        // Argument buffer used by DrawMeshInstancedIndirect.
        uint[] args = new uint[5];
        // Arguments for drawing mesh.
        // 0 == number of triangle indices, 1 == population, others are only relevant if drawing submeshes.
        args[0] = (uint)mesh.GetIndexCount(0);
        args[1] = (uint)ParticleCount;
        args[2] = (uint)mesh.GetIndexStart(0);
        args[3] = (uint)mesh.GetBaseVertex(0);

        var argsBuffer = new ComputeBuffer(1, args.Length * sizeof(uint), ComputeBufferType.IndirectArguments);
        argsBuffer.SetData(args);

        return argsBuffer;
    }
    private ComputeBuffer InitializeStarBuffer()
    {
        // Initialize buffer with the given population.
        Star[] properties = new Star[ParticleCount];

        HelperGalaxy.CreateGalaxyY(ref properties,
            0, properties.Length,
            StartProperty.StartPosition,
            StartProperty.Range,
            StartProperty.MainVelocity,
            Color.yellow * 0.5f);

        var starBuffer = new ComputeBuffer(ParticleCount, Star.Size());
        starBuffer.SetData(properties);

        return starBuffer;
    }

    private void Update()
    {
        GravityCompute.SetFloat("deltaTime", Time.deltaTime * TimeMultipler);
        GravityCompute.Dispatch(_kernel, _numberOfGroups, 1, 1);

        Graphics.DrawMeshInstancedIndirect(_mesh, 0, Material, _bounds, _argsBuffer);

        Debug.DrawLine(Vector3.forward * StartProperty.Range, Vector3.back * StartProperty.Range);
        Debug.DrawLine(Vector3.left * StartProperty.Range, Vector3.right * StartProperty.Range);
    }

    private void OnDisable()
    {
        // Release gracefully.
        _starBuffer?.Release();
        _starBuffer = null;

        _argsBuffer?.Release();
        _argsBuffer = null;
    }
}