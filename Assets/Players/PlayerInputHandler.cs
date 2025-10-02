using System;
using Commons;
using Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Players
{
    public class PlayerInputHandler : IInputHandler
    {
        private InputAction _attackAction;
        private InputAction _interactAction;
        private InputAction _jumpAction;
        private InputAction _moveAction;
        private InputAction _openMenuAction;

        public void Enable()
        {
            _moveAction.Enable();
            _interactAction.Enable();
            _jumpAction.Enable();
            _attackAction.Enable();
            _openMenuAction.Enable();
        }

        public void Disable()
        {
            _moveAction.Disable();
            _interactAction.Disable();
            _jumpAction.Disable();
            _attackAction.Disable();
            _openMenuAction.Disable();
        }

        public void Update()
        {
            MoveAction.Invoke(_moveAction.ReadValue<Vector2>());
            if (_interactAction.triggered) InteractActionTriggered.Invoke();
            if (_jumpAction.triggered) JumpActionTriggered.Invoke();
            if (_attackAction.triggered) AttackActionTriggered.Invoke();
            if (_openMenuAction.triggered) OpenMenuActionTriggered.Invoke();
        }

        public void Initialize()
        {
            _moveAction = InputSystem.actions.FindAction("Move");
            _interactAction = InputSystem.actions.FindAction("Interact");
            _jumpAction = InputSystem.actions.FindAction("Jump");
            _attackAction = InputSystem.actions.FindAction("Attack");
            _openMenuAction = InputSystem.actions.FindAction("OpenMenu");
        }

        private void Awake()
        {
            ServiceLocator<PlayerInputHandler>.Service = this;
        }

        public event Action<Vector2> MoveAction = _ => { };
        public event Action InteractActionTriggered = () => { };
        public event Action JumpActionTriggered = () => { };
        public event Action AttackActionTriggered = () => { };
        public event Action OpenMenuActionTriggered = () => { };
    }
}