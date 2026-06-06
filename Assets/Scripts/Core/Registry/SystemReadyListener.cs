using System.Collections.Generic;
using UnityEngine;

public static class SystemReadyListener
{
    static readonly List<ISystemReady> _pausableObjects = new List<ISystemReady>();

    [RuntimeInitializeOnLoadMethod]
    public static void Initialize()
    {
        _pausableObjects.Clear();

        foreach (var mb in Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
        {
            if (mb is ISystemReady p)
                _pausableObjects.Add(p);
        }
    }

    public static void OnSystemReady()
    {
        foreach (ISystemReady p in _pausableObjects)
        {
            p.OnSystemReady();
        }
    }
}
