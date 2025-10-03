using System.Collections.Generic;
using Interactions;
using Items;
using UnityEngine;
using VContainer;

namespace Environments
{
    public class Rock : MonoBehaviour, IInteractable
    {
        [SerializeField] private ItemBlueprint itemBlueprint;

        private Vector3 _originalScale;
        private InteractionActionFactory _interactionActionFactory;

        [Inject]
        public void Construct(InteractionActionFactory interactionActionFactory)
        {
            _interactionActionFactory = interactionActionFactory;
        }

        private void Awake()
        {
            _originalScale = transform.localScale;
        }

        public IInteractionAction Interact()
        {
            transform.localScale = _originalScale * 0.25f;
            Destroy(this);

            return new ItemInteractionAction(new List<ItemInstance> { new(itemBlueprint, 1) });
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public void Highlight()
        {
            transform.localScale = _originalScale * 1.1f;
        }

        public void Unhighlight()
        {
            transform.localScale = _originalScale;
        }

        public string GetText()
            => "Smash";
    }
}