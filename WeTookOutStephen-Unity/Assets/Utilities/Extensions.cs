using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Extensions {

    /// <summary>
    /// Transparent white. RGBA is (1, 1, 1, 0).
    /// </summary>
    public static readonly Color clearWhite = new Color(1f, 1f, 1f, 0f);

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

    /// <summary>
    /// Scales and translates this SpriteRenderer so that its bounds fit given bounds.
    /// </summary>
    /// <param name="sr"></param>
    /// <param name="bounds"></param>
    /// <param name="space"></param>
    public static void FitToBounds(this SpriteRenderer sr, Bounds bounds, Space space, bool keepAspect)
    {
        Bounds currentBounds = sr.bounds;
        Vector3 cbs = currentBounds.size;
        Vector3 nbs = bounds.size;
        Transform tr = sr.transform;
        Vector3 cs = tr.localScale;

        tr.localScale = new Vector3(
            cs.x * nbs.x / cbs.x,
            cs.y * nbs.y / cbs.y,
            1f);

        if (keepAspect)
        {
            tr.localScale = Vector3.one * Mathf.Max(tr.localScale.x, tr.localScale.y, tr.localScale.z);
        }

        Vector3 center = bounds.center.ReplaceZ(tr.position.z);
        if (space == Space.World)
        {
            tr.position = center;
        }
        else
        {
            tr.localPosition = center;
        }
    }

    /// <summary>
    /// Gets this camera's orthographic bounds in world space.
    /// </summary>
    /// <param name="camera"></param>
    /// <returns></returns>
    public static Bounds GetOrthographicBounds(this Camera camera)
    {
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * camera.aspect, cameraHeight, 0));
        return bounds;
    }
}
