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

        public IInteractionResult Interact()
            => new UIInteractionResult("crafting");

        public Vector3 GetPosition()
            => transform.position;

        public void Highlight()
        {
        }

        public void Unhighlight()
        {
        }

        public string GetText()
            => "Craft";
    }
}