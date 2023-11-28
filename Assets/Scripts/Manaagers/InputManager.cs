using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;

public class InputManager : SingleTon<InputManager> , PlayerInput.IPlayerActions
{
    private PlayerInput _playerInput;
    public Vector3 InputVector { get; private set; }
    public new void Awake()
    {
        base.Awake();
    }

    public void Init()
    {
        if (_playerInput == null)
        {
            _playerInput = new PlayerInput();
            _playerInput.Player.SetCallbacks(this);
            _playerInput.Player.Enable();
        }
    }
    

    public void OnMove(InputAction.CallbackContext context)
    {
        InputVector = context.ReadValue<Vector3>();
    }
}
