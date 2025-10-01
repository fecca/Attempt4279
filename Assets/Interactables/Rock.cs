using System.Collections.Generic;
using Players;
using UnityEngine;

namespace Interactables
{
    public class Rock : MonoBehaviour, IInteractable
    {
        private static readonly Item Item = new("Stone", 2);
        private Vector3 _originalScale;

        private void Awake()
        {
            _originalScale = transform.localScale;
        }

        public IInteractionAction Interact()
        {
            transform.localScale = _originalScale * 0.25f;
            Destroy(this);

            return new ItemInteractionAction(new List<Item> { Item });
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
    }
}