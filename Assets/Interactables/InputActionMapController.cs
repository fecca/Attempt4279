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

            ServiceLocator<InputHandler>.Service.MenuActionTriggered += OnMenuActionTriggered;
        }

        private void OnMenuActionTriggered()
        {
            if (_playerActionMap.enabled)
            {
                _playerActionMap.Disable();
                _uiActionMap.Enable();
            }
            else
            {
                _playerActionMap.Enable();
                _uiActionMap.Disable();
            }
        }
    }
}