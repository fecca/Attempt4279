using System;
using Commons;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Players
{
    public class InputHandler : MonoBehaviour
    {
        private InputAction _moveAction;
        private InputAction _interactAction;
        private InputAction _jumpAction;
        private InputAction _attackAction;

        private void Awake()
        {
            _moveAction = InputSystem.actions.FindAction("Move");
            _interactAction = InputSystem.actions.FindAction("Interact");
            _jumpAction = InputSystem.actions.FindAction("Jump");
            _attackAction = InputSystem.actions.FindAction("Attack");
            ServiceLocator<InputHandler>.Service = this;
        }

        private void Update()
        {
            MoveAction.Invoke(_moveAction.ReadValue<Vector2>());
            if (_interactAction.triggered) InteractActionTriggered.Invoke();
            if (_jumpAction.triggered) JumpActionTriggered.Invoke();
            if (_attackAction.triggered) AttackActionTriggered.Invoke();
        }

        private void OnEnable()
        {
            _moveAction.Enable();
            _interactAction.Enable();
            _jumpAction.Enable();
            _attackAction.Enable();
        }

        private void OnDisable()
        {
            _moveAction.Disable();
            _interactAction.Disable();
            _jumpAction.Disable();
            _attackAction.Disable();
        }

        public event Action<Vector2> MoveAction = _ => { };
        public event Action InteractActionTriggered = () => { };
        public event Action JumpActionTriggered = () => { };
        public event Action AttackActionTriggered = () => { };
    }
}