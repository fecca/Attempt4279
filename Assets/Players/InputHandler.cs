using System;
using Commons;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Players
{
    public class InputHandler : MonoBehaviour
    {
        private InputAction _attackAction;
        private InputAction _interactAction;
        private InputAction _jumpAction;
        private InputAction _menuAction;
        private InputAction _moveAction;

        private void Awake()
        {
            _moveAction = InputSystem.actions.FindAction("Move");
            _interactAction = InputSystem.actions.FindAction("Interact");
            _jumpAction = InputSystem.actions.FindAction("Jump");
            _attackAction = InputSystem.actions.FindAction("Attack");
            _menuAction = InputSystem.actions.FindAction("Menu");
            ServiceLocator<InputHandler>.Service = this;
        }

        private void Update()
        {
            MoveAction.Invoke(_moveAction.ReadValue<Vector2>());
            if (_interactAction.triggered) InteractActionTriggered.Invoke();
            if (_jumpAction.triggered) JumpActionTriggered.Invoke();
            if (_attackAction.triggered) AttackActionTriggered.Invoke();
            if (_menuAction.triggered)
            {
                MenuActionTriggered.Invoke();
                _menuAction = InputSystem.actions.FindAction("Menu");
            }
        }

        private void OnEnable()
        {
            _moveAction.Enable();
            _interactAction.Enable();
            _jumpAction.Enable();
            _attackAction.Enable();
            _menuAction.Enable();
        }

        private void OnDisable()
        {
            _moveAction.Disable();
            _interactAction.Disable();
            _jumpAction.Disable();
            _attackAction.Disable();
            _menuAction.Disable();
        }

        public event Action<Vector2> MoveAction = _ => { };
        public event Action InteractActionTriggered = () => { };
        public event Action JumpActionTriggered = () => { };
        public event Action AttackActionTriggered = () => { };
        public event Action MenuActionTriggered = () => { };
    }
}