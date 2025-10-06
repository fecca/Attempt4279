using System.Collections.Generic;
using System.Linq;
using Items.Scripts;
using Players;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace UI
{
    public class CraftingRecipeItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private GameObject border;
        [SerializeField] private GridLayoutGroup grid;
        [SerializeField] private CraftingRecipeItemRequirement craftingRequirementPrefab;

        public void Initialize(IObjectResolver objectResolver, string itemName,
            List<CraftingRecipeRequirement> blueprintRequirements,
            PlayerInventory playerInventory)
        {
            foreach (var recipeRequirement in blueprintRequirements)
            {
                var requirementItem = objectResolver.Instantiate(craftingRequirementPrefab, grid.transform);
                var inventoryItem = playerInventory.GetItems()
                    .FirstOrDefault(i => i.Blueprint.id == recipeRequirement.resource.id);
                var hasRequirement = inventoryItem != null && inventoryItem.Amount >= recipeRequirement.amount;
                requirementItem.Initialize(recipeRequirement, hasRequirement);
            }

            text.text = itemName;
        }

        public void HighLight()
            => border.SetActive(true);

        public void UnHighLight()
            => border.SetActive(false);
    }
}