using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helpers
{
    public static class HelperMesh
    {

        public static Mesh CreateQuad(float width = 1f, float height = 1f)
        {
            var m = new Mesh();
            m.vertices = new Vector3[]
            {
            new Vector3(),
            new Vector3(width,0,0),
            new Vector3(width,height,0),
            new Vector3(0,height,0)
            };

            m.uv = new Vector2[]
            {
            new Vector2(),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,0)
            };

            m.triangles = new int[] { 0, 1, 2, 0, 2, 3 };

            return m;
        }

        public static Mesh CreateTris(float width = 1f, float height = 1f)
        {
            var m = new Mesh();

            m.vertices = new Vector3[]
            {
            new Vector3(0,0,0),
            new Vector3(width/2,height,0),
            new Vector3(height,0,0)
            };

            m.uv = new Vector2[]
            {
            new Vector2(0,0),
            new Vector2(0.5f,1),
            new Vector2(1,0)
            };

            m.triangles = new int[] { 0, 1, 2 };

            return m;
        }

        public static Mesh CreateD8(float size = 1)
        {
            var m = new Mesh();

            m.vertices = new Vector3[]
            {
            new Vector3(0,0,0),
            new Vector3(size/2,size,0),
            new Vector3(size,0,0),
            new Vector3(0,size,size),
            new Vector3(size/2,0,size),
            new Vector3(size,size,size)
            };

            m.uv = new Vector2[]
            {
                new Vector2(0,0),
                new Vector2(0.5f,1),
                new Vector2(1,0),
                new Vector2(1,0),
                new Vector2(0.5f,1),
                new Vector2(0,0)
            };

            m.triangles = new int[] {
                0,1,2, 0,2,4, 0,4,3, 0,3,1,
                5,3,4, 5,4,2, 5,2,1, 5,1,3
                };

            return m;
        }
    }
}