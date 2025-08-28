using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class InputHandler : MonoBehaviour
    {
        private InputAction _attackAction;
        private InputAction _jumpAction;
        private InputAction _moveAction;

        private void Awake()
        {
            _moveAction = InputSystem.actions.FindAction("Move");
            _jumpAction = InputSystem.actions.FindAction("Jump");
            _attackAction = InputSystem.actions.FindAction("Attack");
            ServiceLocator<InputHandler>.Service = this;
        }

        private void Update()
        {
            MoveAction.Invoke(_moveAction.ReadValue<Vector2>());
            if (_jumpAction.triggered) JumpActionTriggered.Invoke();
            if (_attackAction.triggered) AttackActionTriggered.Invoke();
        }

        private void OnEnable()
        {
            _moveAction.Enable();
            _jumpAction.Enable();
        }

        private void OnDisable()
        {
            _moveAction.Disable();
            _jumpAction.Disable();
        }

        public event Action<Vector2> MoveAction = _ => { };
        public event Action JumpActionTriggered = () => { };
        public event Action AttackActionTriggered = () => { };
    }
}