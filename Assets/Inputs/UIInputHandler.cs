using System;
using Commons;
using UnityEngine.InputSystem;

namespace Inputs
{
    public class UIInputHandler : IInputHandler
    {
        private InputAction _closeMenuAction;
        private InputAction _pageLeftAction;
        private InputAction _pageRightAction;

        public event Action CloseMenuActionTriggered = () => { };
        public event Action PageLeftActionTriggered = () => { };
        public event Action PageRightActionTriggered = () => { };

        public void Initialize()
        {
            _closeMenuAction = InputSystem.actions.FindAction("CloseMenu");
            _pageLeftAction = InputSystem.actions.FindAction("PageLeft");
            _pageRightAction = InputSystem.actions.FindAction("PageRight");
        }

        public void Enable()
        {
            _closeMenuAction.Enable();
            _pageLeftAction.Enable();
            _pageRightAction.Enable();
        }

        public void Disable()
        {
            _closeMenuAction.Disable();
            _pageLeftAction.Disable();
            _pageRightAction.Disable();
        }

        public void Update()
        {
            if (_pageLeftAction.triggered) PageLeftActionTriggered.Invoke();
            if (_pageRightAction.triggered) PageRightActionTriggered.Invoke();
            if (_closeMenuAction.triggered) CloseMenuActionTriggered.Invoke();
        }
    }
}