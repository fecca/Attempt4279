using System.Collections.Generic;
using Players;
using UnityEngine;

namespace Interactables
{
    public class Tree : MonoBehaviour, IInteractable
    {
        private static readonly Item Item = new("Wood", 1);
        private Vector3 _originalScale;

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

        public string GetText()
            => "Chop";
    }
}