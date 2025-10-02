using Commons;
using UnityEngine;

namespace Players
{
    public class InputHandler : MonoBehaviour
    {
        private IInputHandler _inputHandler;
        private PlayerInputHandler _playerInputHandler;
        private UIInputHandler _uiInputHandler;

        private void Awake()
        {
            _playerInputHandler = new PlayerInputHandler();
            _playerInputHandler.Initialize();
            ServiceLocator<PlayerInputHandler>.Service = _playerInputHandler;

            _uiInputHandler = new UIInputHandler();
            _uiInputHandler.Initialize();
            ServiceLocator<UIInputHandler>.Service = _uiInputHandler;

            _inputHandler = _playerInputHandler;

            _playerInputHandler.OpenMenuActionTriggered += OnPlayerOpenMenuActionTriggered;
            _uiInputHandler.CloseMenuActionTriggered += OnUiCloseMenuActionTriggered;
        }

        private void Update()
        {
            _inputHandler.Update();
        }

        private void OnUiCloseMenuActionTriggered()
        {
            _inputHandler.Disable();
            _inputHandler = _playerInputHandler;
            _inputHandler.Enable();
        }

        private void OnPlayerOpenMenuActionTriggered()
        {
            _inputHandler.Disable();
            _inputHandler = _uiInputHandler;
            _inputHandler.Enable();
        }
    }
}