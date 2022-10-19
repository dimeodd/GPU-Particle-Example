struct Cluster
{
    uint count;
    float3 position;
};

struct Star {
    float3 position;
    float3 velocity;
    float4 color;
};

float sqrlength(float3 vec){
    return vec.x * vec.x + vec.y * vec.y + vec.z * vec.z;
}

float mhtlength(float3 vec){
    return abs(vec.x) + abs(vec.y) + abs(vec.z);
}

// #define G 6.67300e-11f
// #define DefaultMass 1000000.0f
// #define GMM G * DefaultMass * DefaultMass