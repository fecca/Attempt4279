using System.Collections.Generic;
using System.Linq;
using Interactions;
using UnityEngine;
using VContainer;

namespace Players
{
    [RequireComponent(typeof(SphereCollider))]
    public class InteractionArea : MonoBehaviour
    {
        [SerializeField] private float sphereRadius = 5.0f;

        private readonly List<IInteractable> _interactables = new();
        private IInteractable _closestInteractable;
        private SphereCollider _collider;
        private InteractableObserver _interactableObserver;

        [Inject]
        public void Construct(InteractableObserver interactableObserver)
            => _interactableObserver = interactableObserver;

        private void Awake()
            => _collider = GetComponent<SphereCollider>();

        private void Start()
            => _interactableObserver.Interacted += OnInteracted;

        private void Update()
        {
            _collider.radius = sphereRadius;

            if (!_interactables.Any())
            {
                _interactableObserver.NotifyNewInteractableFound(null);
                return;
            }

            var closestInteractable = GetClosestInteractable();
            if (closestInteractable == _closestInteractable) return;

            _closestInteractable?.Unhighlight();
            _closestInteractable = closestInteractable;
            _closestInteractable.Highlight();

            _interactableObserver.NotifyNewInteractableFound(_closestInteractable);
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

        private IInteractable GetClosestInteractable()
        {
            return _interactables.Aggregate((curMin, x)
                => curMin == null || GetDistanceToInteractable(x) < GetDistanceToInteractable(curMin)
                    ? x
                    : curMin);
        }

        private float GetDistanceToInteractable(IInteractable interactable)
            => Vector3.Distance(interactable.GetPosition(), transform.position);

        private void OnInteracted(IInteractable interactable)
        {
            _interactables.Remove(_closestInteractable);
            _closestInteractable = null;
        }
    }
}