using Players;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text amount;

        public void Initialize(PlayerItem item)
        {
            amount.text = item.Amount.ToString();
            image.sprite = item.Blueprint.icon;
        }
    }
}