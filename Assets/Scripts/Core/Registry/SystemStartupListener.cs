using System.Collections.Generic;
using UnityEngine;

public class SystemStartupListener
{
    static readonly List<ISystemStartup> _pausableObjects = new List<ISystemStartup>();

    [RuntimeInitializeOnLoadMethod]
    public static void Initialize()
    {
        _pausableObjects.Clear();

        foreach (var mb in Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
        {
            if (mb is ISystemStartup p)
                _pausableObjects.Add(p);
        }
    }

    public static void OnSystemStartUp()
    {
        foreach (ISystemStartup p in _pausableObjects)
        {
            p.OnSystemStartUp();
        }
    }
}
