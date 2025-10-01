using System.Collections.Generic;
using Interactables;
using Players;
using UnityEngine;

namespace Enemies
{
    public class WorldLootObject : MonoBehaviour, IInteractable
    {
        private List<Item> _items;

        public IInteractionAction Interact()
        {
            var items = new ItemInteractionAction(_items);
            Destroy(gameObject);
            return items;
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public void Highlight()
        {
        }

        public void Unhighlight()
        {
        }

        public void Initialize(Vector3 position, List<Item> item)
        {
            _items = item;

            gameObject.AddComponent<BoxCollider>();
            gameObject.AddComponent<Rigidbody>();
            transform.position = position;

            var primitive = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            primitive.transform.localScale = Vector3.one * 0.4f;
            primitive.transform.SetParent(transform);
            primitive.transform.localPosition = Vector3.zero;
        }
    }
}