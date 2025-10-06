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
        private UI.UserInterfaceController _userInterfaceController;

        private void Start()
        {
            _playerInputHandler.Initialize();
            _uiInputHandler.Initialize();
            _inputHandler = _playerInputHandler;

            // _playerInputHandler.OpenMenuActionTriggered += OnUiOpened;
            // _uiInputHandler.CloseMenuActionTriggered += OnUiClosed;
            _userInterfaceController.UiOpened += OnUserInterfaceControllerOpened;
            _userInterfaceController.UiClosed += OnUserInterfaceControllerClosed;
        }

        private void Update()
        {
            _inputHandler.Update();
        }

        [Inject]
        public void Construct(PlayerInputHandler playerInputHandler, UIInputHandler uiInputHandler, UI.UserInterfaceController userInterfaceController)
        {
            _userInterfaceController = userInterfaceController;
            _playerInputHandler = playerInputHandler;
            _uiInputHandler = uiInputHandler;
        }

        private void OnUserInterfaceControllerClosed()
        {
            _inputHandler.Disable();
            _inputHandler = _playerInputHandler;
            _inputHandler.Enable();
        }

        private void OnUserInterfaceControllerOpened()
        {
            _inputHandler.Disable();
            _inputHandler = _uiInputHandler;
            _inputHandler.Enable();
        }
    }
}