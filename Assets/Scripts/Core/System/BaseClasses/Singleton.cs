using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance;

    protected virtual void Awake()
    {
        if (Instance == null)
            Instance = this as T;
        else
        {
            Debug.LogWarning($"Another instance of {this as T} in the scene");
            Destroy(gameObject);
        }
    }
}