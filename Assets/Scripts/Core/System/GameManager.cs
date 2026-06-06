using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    void Awake()
    {
        Debug.LogWarning($"GameManager Called on Awake");
        //Important early start up
        SystemReadyListener.Initialize();
        SystemStartupListener.Initialize();

        //On system startup?

        PauseSystemListener.Initialize();


        SystemReadyListener.OnSystemReady();
    }

    void Start()
    {
        SystemStartupListener.OnSystemStartUp();
    }
}