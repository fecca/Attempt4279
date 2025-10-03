using System.Collections.Generic;
using System.Linq;
using Interactions;
using Items.Scripts;
using UnityEngine;
using VContainer;

namespace Players
{
    public class CraftingBench : MonoBehaviour, IInteractable
    {
        [SerializeField] private List<CraftingRecipe> craftingRecipes;

        private PlayerInventory _playerInventory;

        public IInteractionAction Interact()
        {
            var playerItems = _playerInventory.GetItems();
            foreach (var craftingRecipe in craftingRecipes)
            {
                var canCraft = true;
                foreach (var requirement in craftingRecipe.requirements)
                {
                    var resource = playerItems.FirstOrDefault(i => i.Blueprint.id == requirement.resource.id);
                    if (resource == null || resource.Amount < requirement.amount)
                    {
                        canCraft = false;
                        break;
                    }
                }

                if (canCraft)
                {
                    var cost = craftingRecipe.requirements.Select(r => new ItemInstance(r.resource, r.amount)).ToList();
                    return new CraftingInteractionAction(new ItemInstance(craftingRecipe.result, 1), cost);
                }
            }

            return null;
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