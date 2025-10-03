using Players;
using UnityEngine.InputSystem;

namespace Inputs
{
    public class InputActionMapController
    {
        private readonly InputActionMap _playerActionMap;
        private readonly InputActionMap _uiActionMap;

        private bool _isMenuActive;

        public InputActionMapController(PlayerInputHandler playerInputHandler, UIInputHandler uiInputHandler)
        {
            _uiActionMap = InputSystem.actions.FindActionMap("UI");
            _uiActionMap.Disable();
            _playerActionMap = InputSystem.actions.FindActionMap("Player");
            _playerActionMap.Enable();

            playerInputHandler.OpenMenuActionTriggered += OnOpenMenuActionTriggered;
            uiInputHandler.CloseMenuActionTriggered += OnCloseMenuActionTriggered;
        }

        private void OnOpenMenuActionTriggered()
        {
            _playerActionMap.Disable();
            _uiActionMap.Enable();
        }

        private void OnCloseMenuActionTriggered()
        {
            _playerActionMap.Enable();
            _uiActionMap.Disable();
        }
    }
}