using UnityEngine;
using UnityEngine.InputSystem;

public class InputsController : Singleton<InputsController>, ISystemReady
{
    public Inputs Inputs {  get { return _inputs; } }

    Inputs _inputs;

    void ISystemReady.OnSystemReady()
    {
        Debug.LogWarning($"InputsController Called on OnSystemReady");

        InitializeInputs();
    }

    void InitializeInputs()
    {
        _inputs = new Inputs();
        _inputs.Enable();

        InitializeCore();
        InitializeGameplay();
    }

    void InitializeCore()
    {
        Inputs.Core.Pause.performed += DeterminePausing;
    }

    void InitializeGameplay()
    {
        Inputs.Gameplay.Movement.performed += ReadingMovement;
    }

    void InitializeMenu()
    {

    }

    void DeterminePausing(InputAction.CallbackContext ctx)
    {
        PauseManager.Instance.DeterminePause();
    }

    void ReadingMovement(InputAction.CallbackContext ctx)
    {
        Vector2 movement = ctx.ReadValue<Vector2>();

        Debug.LogWarning($"Movement: {movement}");
    }

    public void OnEnable()
    {
        if(_inputs != null)
            _inputs.Enable();
    }

    public void OnDisable()
    {
        if (_inputs != null)
            _inputs.Disable();
    }
}