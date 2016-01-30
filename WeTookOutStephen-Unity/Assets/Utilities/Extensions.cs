using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Extensions {

    /// <summary>
    /// Returns a random element from the enumerable, or the default value for
    /// the type if none is found.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="e"></param>
    /// <returns></returns>
    public static T RandomOrDefault<T>(this IEnumerable<T> e)
    {
        if (!e.Any())
        {
            return default(T);
        }

        return e.ElementAtOrDefault(UnityEngine.Random.Range(0, e.Count()));
    }

    /// <summary>
    /// Returns a vector equals to this vector, with the specific value as Z coordinate.
    /// </summary>
    /// <param name="v"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    public static Vector3 ReplaceZ(this Vector3 v, float z)
    {
        Vector3 val = v;
        val.z = z;
        return val;
    }

}
