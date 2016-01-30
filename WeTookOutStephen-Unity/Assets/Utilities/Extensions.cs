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

    /// <summary>
    /// Gets a color representing this type.
    /// </summary>
    /// <param name="behavior"></param>
    /// <returns></returns>
    public static Color GetTypeColor(this MonoBehaviour behavior)
    {
        int i = Mathf.Abs(behavior.GetType().FullName.GetHashCode());
        using (ScopeRandom r = new ScopeRandom(i))
        {
            return new Color((float)(i % r.Range(0, 256) + i % 42) / 256f, (float)(i % r.Range(0, 256) + i % 23) / 256f, (float)(i % r.Range(0, 256)) / 256f, 1f);
        }
    }

    /// <summary>
    /// Returns an array of components of a certain type that can be found in this
    /// Component's direct children (not itself, and not its grandchildren).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="c"></param>
    /// <returns></returns>
    public static T[] GetComponentsInDirectChildren<T>(this Component c, bool includeSelf = true) where T : Component
    {
        List<T> compos = new List<T>();

        foreach (Transform tr in c.transform)
        {
            T t = tr.GetComponent<T>();

            if (t != null && (includeSelf || t != c))
            {
                compos.Add(t);
            }
        }

        return compos.ToArray();
    }
}
