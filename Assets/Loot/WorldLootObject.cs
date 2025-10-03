using System.Collections.Generic;
using System.Linq;
using Interactions;
using Items;
using UnityEngine;
using VContainer;

namespace Loot
{
    public class WorldLootObject : MonoBehaviour, IInteractable
    {
        private List<LootItem> _lootItems;
        private InteractionActionFactory _interactionActionFactory;

        public void Initialize(InteractionActionFactory interactionActionFactory, Vector3 position, List<LootItem> item)
        {
            _interactionActionFactory = interactionActionFactory;
            _lootItems = item;

            gameObject.AddComponent<BoxCollider>();
            gameObject.AddComponent<Rigidbody>();
            transform.position = position;

            var primitive = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            primitive.transform.localScale = Vector3.one * 0.4f;
            primitive.transform.SetParent(transform);
            primitive.transform.localPosition = Vector3.zero;
        }

        public IInteractionAction Interact()
        {
            var items = new ItemInteractionAction(_lootItems
                .Select(lootItem => new ItemInstance(lootItem.Blueprint, lootItem.Amount)).ToList());
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

        public string GetText()
            => "Pick Up";
    }
}