using System.Collections.Generic;
using UnityEngine;

public static class PauseSystemListener
{
    static readonly HashSet<IPausable> _pausableObjects = new HashSet<IPausable>();

    [RuntimeInitializeOnLoadMethod]
    static internal void Initialize()
    {
        _pausableObjects.Clear();

        foreach(var mb in Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
        {
            if (mb is IPausable p)
                _pausableObjects.Add(p);
        }
    }

    internal static void Pause()
    {
        foreach (IPausable p in _pausableObjects)
        {
            p.OnPause();
        }
    }

    internal static void Resume()
    {
        foreach (IPausable p in _pausableObjects)
        {
            p.OnResume();
        }
    }
}