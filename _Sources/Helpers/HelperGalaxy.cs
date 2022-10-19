using UnityEngine;

namespace Helpers
{
    public static class HelperGalaxy
    {
        public static void CreateGalaxy(ref Star[] univerce, int startIndex, int lenght, Vector3 pos, float range)
        => CreateGalaxyY(ref univerce, startIndex, lenght, pos, range, new Vector3(), Color.white);
        public static void CreateGalaxyY(
            ref Star[] univerce,
            int startIndex, int endIndex,
            Vector3 pos, float range, Vector3 a_velocity,
            Color a_color)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                Vector3 posRand = Random.insideUnitCircle.normalized * Random.Range(40, range);
                posRand = new Vector3(posRand.x, 0, posRand.y);

                univerce[i] = new Star()
                {
                    pos = posRand + pos + Vector3.up * Random.Range(-20.0f, 20.0f),
                    velocity = a_velocity + Vector3.Cross(Vector3.up, posRand) * 0.01f,
                    color = a_color
                };
            }
        }

        public static void CreateGalaxyZ(
            ref Star[] univerce,
            int startIndex, int endIndex,
            Vector3 pos, float range, Vector3 a_velocity,
            Color a_color)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                Vector3 posRand = Random.insideUnitCircle * range;

                univerce[i] = new Star()
                {
                    pos = posRand + pos,
                    velocity = a_velocity + Vector3.Cross(Vector3.up, posRand) * 0.5f,
                    color = a_color
                };
            }
        }

    }
}
