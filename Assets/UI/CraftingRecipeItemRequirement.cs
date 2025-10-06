using Items.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CraftingRecipeItemRequirement : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text text;

        public void Initialize(CraftingRecipeRequirement recipeRequirement, bool hasRequirement)
        {
            image.sprite = recipeRequirement.resource.icon;
            text.color = hasRequirement ? Color.black : Color.red;
            text.text = recipeRequirement.amount.ToString();
        }
    }
}