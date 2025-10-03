using Players;
using UnityEngine;
using VContainer;

namespace Inputs
{
    public class InputHandler : MonoBehaviour
    {
        private IInputHandler _inputHandler;
        private PlayerInputHandler _playerInputHandler;
        private UIInputHandler _uiInputHandler;

        private void Start()
        {
            _playerInputHandler.Initialize();
            _uiInputHandler.Initialize();
            _inputHandler = _playerInputHandler;

            _playerInputHandler.OpenMenuActionTriggered += OnPlayerOpenMenuActionTriggered;
            _uiInputHandler.CloseMenuActionTriggered += OnUiCloseMenuActionTriggered;
        }

        private void Update()
        {
            _inputHandler.Update();
        }

        [Inject]
        public void Construct(PlayerInputHandler playerInputHandler, UIInputHandler uiInputHandler)
        {
            _playerInputHandler = playerInputHandler;
            _uiInputHandler = uiInputHandler;
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