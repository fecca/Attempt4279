using System;
using System.Collections.Generic;
using System.Linq;
using Interactables;
using UnityEngine;

namespace Players
{
    [RequireComponent(typeof(SphereCollider))]
    public class InteractionArea : MonoBehaviour
    {
        [SerializeField] private float sphereRadius = 5.0f;

        private readonly List<IInteractable> _interactables = new();
        private IInteractable _closestInteractable;
        private SphereCollider _collider;

        private void Awake()
        {
            _collider = GetComponent<SphereCollider>();
        }

        private void Update()
        {
            _collider.radius = sphereRadius;

            if (!_interactables.Any())
            {
                NewInteractableFound?.Invoke(null);
                return;
            }

            var closestInteractable = GetClosestInteractable();
            if (closestInteractable == _closestInteractable) return;

            _closestInteractable?.Unhighlight();
            _closestInteractable = closestInteractable;
            _closestInteractable.Highlight();

            NewInteractableFound?.Invoke(_closestInteractable);
        }

        private void OnTriggerEnter(Collider other)
        {
            var interactable = other.GetComponent<IInteractable>();
            if (interactable == null) return;
            if (_interactables.Contains(interactable)) return;

            _interactables.Add(interactable);
        }

        private void OnTriggerExit(Collider other)
        {
            var interactable = other.GetComponent<IInteractable>();
            if (interactable == null) return;
            if (!_interactables.Contains(interactable)) return;

            _interactables.Remove(interactable);
            if (_interactables.Any()) return;

            _closestInteractable.Unhighlight();
            _closestInteractable = null;
        }

        public event Action<IInteractable> NewInteractableFound = _ => { };

        public IInteractable GetClosestInteractable()
        {
            return _interactables.Aggregate((curMin, x)
                => curMin == null || GetDistanceToInteractable(x) < GetDistanceToInteractable(curMin)
                    ? x
                    : curMin);
        }

        private float GetDistanceToInteractable(IInteractable interactable)
        {
            return Vector3.Distance(interactable.GetPosition(), transform.position);
        }

        public bool CanInteract()
        {
            return _closestInteractable != null;
        }

        public IInteractionAction InteractWithClosestTarget()
        {
            var result = _closestInteractable.Interact();
            _interactables.Remove(_closestInteractable);
            _closestInteractable = null;

            return result;
        }
    }
}