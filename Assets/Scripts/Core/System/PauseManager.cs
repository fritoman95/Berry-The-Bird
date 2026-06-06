using UnityEngine;

public class PauseManager : Singleton<PauseManager>, ISystemReady
{
    public static bool IsPaused {  get { return _isPaused; } }
    static bool _isPaused;
    void ISystemReady.OnSystemReady()
    {
        Debug.LogWarning($"PauseManager Called on OnSystemReady");
    }

    public void DeterminePause()
    {
        if (_isPaused)
            PauseSystemListener.Resume();
        else
            PauseSystemListener.Pause();

        _isPaused = !_isPaused;
    }
}