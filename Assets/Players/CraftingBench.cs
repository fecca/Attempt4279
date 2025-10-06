using System.Collections.Generic;
using Interactions;
using Items.Scripts;
using UnityEngine;
using VContainer;

namespace Players
{
    public class CraftingBench : MonoBehaviour, IInteractable
    {
        [SerializeField] private List<CraftingRecipeBlueprint> craftingRecipes;

        private PlayerInventory _playerInventory;

        public IInteractionResult Interact()
        {
            return new UIInteractionResult("crafting");
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
        {
            return "Craft";
        }

        [Inject]
        public void Construct(PlayerInventory playerInventory)
        {
            _playerInventory = playerInventory;
        }
    }
}