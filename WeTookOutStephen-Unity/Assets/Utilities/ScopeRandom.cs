using UnityEngine;

public class ScopeRandom : System.IDisposable
{
    private int _oldSeed;
    
    public ScopeRandom(int seed)
    {
        _oldSeed = Random.seed;
        Random.seed = seed;
    }

    public int Range(int min, int max)
    {
        return Random.Range(min, max);
    }

    public void Dispose()
    {
        Random.seed = _oldSeed;
    }
}
