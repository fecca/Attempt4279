using Commons;
using Players;
using UnityEngine.InputSystem;

namespace Interactables
{
    public class InputActionMapController
    {
        private readonly InputActionMap _playerActionMap;
        private readonly InputActionMap _uiActionMap;

        private bool _isMenuActive;

        public InputActionMapController()
        {
            _uiActionMap = InputSystem.actions.FindActionMap("UI");
            _uiActionMap.Disable();
            _playerActionMap = InputSystem.actions.FindActionMap("Player");
            _playerActionMap.Enable();

            ServiceLocator<PlayerInputHandler>.Service.OpenMenuActionTriggered += OnOpenMenuActionTriggered;
            ServiceLocator<UIInputHandler>.Service.CloseMenuActionTriggered += OnCloseMenuActionTriggered;
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