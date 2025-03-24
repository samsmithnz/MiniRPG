using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public static class Utility
    {
        public static string CreateName(string prefix, Vector3 location)
        {
            StringBuilder sb = new();
            sb.Append(prefix);
            sb.Append("_x");
            sb.Append(location.x.ToString());
            sb.Append("_y");
            sb.Append(location.y.ToString());
            sb.Append("_z");
            sb.Append(location.z.ToString());
            return sb.ToString();
        }


        public static UnityEngine.Vector3 ConvertToUnity3DV3(System.Numerics.Vector3 vector3)
        {
            return new UnityEngine.Vector3(vector3.X, vector3.Y, vector3.Z);
        }

        public static System.Numerics.Vector3 ConvertToNumericsV3(UnityEngine.Vector3 vector3)
        {
            return new System.Numerics.Vector3(vector3.x, vector3.y, vector3.z);
        }

        public static List<UnityEngine.Vector3> ConvertToUnity3DV3List(List<System.Numerics.Vector3> vector3List)
        {
            List<UnityEngine.Vector3> results = new();
            foreach (System.Numerics.Vector3 item in vector3List)
            {
                results.Add(ConvertToUnity3DV3(item));
            }
            return results;
        }

        public static List<KeyValuePair<Vector3, int>> ConvertToUnity3DV3List(List<KeyValuePair<System.Numerics.Vector3, int>> vector3List)
        {
            List<KeyValuePair<Vector3, int>> results = new();
            foreach (KeyValuePair<System.Numerics.Vector3, int> item in vector3List)
            {
                results.Add(new KeyValuePair<Vector3, int>(ConvertToUnity3DV3(item.Key), item.Value));
            }
            return results;
        }

        public static List<System.Numerics.Vector3> ConvertToNumericsV3List(List<UnityEngine.Vector3> vector3List)
        {
            List<System.Numerics.Vector3> results = new();
            foreach (UnityEngine.Vector3 item in vector3List)
            {
                results.Add(ConvertToNumericsV3(item));
            }
            return results;
        }
    }
}
