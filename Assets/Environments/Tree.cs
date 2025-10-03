using System.Collections.Generic;
using Interactions;
using Items;
using UnityEngine;
using VContainer;

namespace Environments
{
    public class Tree : MonoBehaviour, IInteractable
    {
        [SerializeField] private ItemBlueprint itemBlueprint;

        private Vector3 _originalScale;
        private InteractionActionFactory _interactionActionFactory;

        private void Awake()
        {
            _originalScale = transform.localScale;
        }

        public IInteractionAction Interact()
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().AddForce(Vector3.one, ForceMode.Impulse);
            transform.localScale = _originalScale;
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
            => "Chop";
    }
}