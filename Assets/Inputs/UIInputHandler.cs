using System;
using UnityEngine.InputSystem;

namespace Inputs
{
    public class UIInputHandler : IInputHandler
    {
        private InputAction _closeMenuAction;
        private InputAction _backMenuAction;
        private InputAction _pageLeftAction;
        private InputAction _pageRightAction;
        private InputAction _leftArrowAction;
        private InputAction _rightArrowAction;
        private InputAction _upArrowAction;
        private InputAction _downArrowAction;
        private InputAction _submitAction;

        public void Enable()
        {
            _closeMenuAction.Enable();
            _backMenuAction.Enable();
            _pageLeftAction.Enable();
            _pageRightAction.Enable();
            _leftArrowAction.Enable();
            _rightArrowAction.Enable();
            _upArrowAction.Enable();
            _downArrowAction.Enable();
            _submitAction.Enable();
        }

        public void Disable()
        {
            _closeMenuAction.Disable();
            _backMenuAction.Disable();
            _pageLeftAction.Disable();
            _pageRightAction.Disable();
            _leftArrowAction.Disable();
            _rightArrowAction.Disable();
            _upArrowAction.Disable();
            _downArrowAction.Disable();
            _submitAction.Disable();
        }

        public void Update()
        {
            if (_pageLeftAction.triggered) PageLeftActionTriggered.Invoke();
            if (_pageRightAction.triggered) PageRightActionTriggered.Invoke();
            if (_closeMenuAction.triggered) CloseMenuActionTriggered.Invoke();
            if (_backMenuAction.triggered) BackMenuActionTriggered.Invoke();
            if (_leftArrowAction.triggered) LeftArrowActionTriggered.Invoke();
            if (_rightArrowAction.triggered) RightArrowActionTriggered.Invoke();
            if (_upArrowAction.triggered) UpArrowActionTriggered.Invoke();
            if (_downArrowAction.triggered) DownArrowActionTriggered.Invoke();
            if (_submitAction.triggered) SubmitActionTriggered.Invoke();
        }

        public event Action CloseMenuActionTriggered = () => { };
        public event Action BackMenuActionTriggered = () => { };
        public event Action PageLeftActionTriggered = () => { };
        public event Action PageRightActionTriggered = () => { };
        public event Action LeftArrowActionTriggered = () => { };
        public event Action RightArrowActionTriggered = () => { };
        public event Action UpArrowActionTriggered = () => { };
        public event Action DownArrowActionTriggered = () => { };
        public event Action SubmitActionTriggered = () => { };

        public void Initialize()
        {
            _closeMenuAction = InputSystem.actions.FindAction("CloseMenu");
            _backMenuAction = InputSystem.actions.FindAction("Back");
            _pageLeftAction = InputSystem.actions.FindAction("PageLeft");
            _pageRightAction = InputSystem.actions.FindAction("PageRight");
            _leftArrowAction = InputSystem.actions.FindAction("LeftArrow");
            _rightArrowAction = InputSystem.actions.FindAction("RightArrow");
            _upArrowAction = InputSystem.actions.FindAction("UpArrow");
            _downArrowAction = InputSystem.actions.FindAction("DownArrow");
            _submitAction = InputSystem.actions.FindAction("Submit");
        }
    }
}