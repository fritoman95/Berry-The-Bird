using UnityEngine;

public class Tester : MonoBehaviour, IPausable
{
    void IPausable.OnPause()
    {
        Debug.LogWarning($"Paused: Called on Gameobject: {name}");
    }

    void IPausable.OnResume()
    {
        Debug.LogWarning($"UnPaused: Called on Gameobject: {name}");
    }
}