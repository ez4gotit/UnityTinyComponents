using UnityEngine;
namespace Global.Tools
{
    public static class Vectors
    {
        public static Vector3 VectorConvert(Vector2 vector)
        {
            return new Vector3(vector.x, 0, vector.y);
        }

        public static Vector3 Abs(Vector3 vector)
        {
            return new Vector3(Mathf.Abs(vector.x),Mathf.Abs( vector.y),Mathf.Abs( vector.z));
        }
    }
}