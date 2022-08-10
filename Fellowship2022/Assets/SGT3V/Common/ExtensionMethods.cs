using UnityEngine;

namespace SGT3V.Common
{
    public static class ExtensionMethods
    {
        public static int Mod(this int value, int mod)
        {
            return (value % mod + mod) % mod;
        }

        public static void DestroyChildren(this Transform transform)
        {
            GameObject[] children = new GameObject[transform.childCount];

            for (int i = 0; i < children.Length; i++)
            {
                children[i] = transform.GetChild(i).gameObject;
            }

            for (int i = 0; i < children.Length; i++)
            {
                Object.DestroyImmediate(children[i]);
            }
        }
    }
}
