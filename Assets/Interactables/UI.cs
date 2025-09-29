using Commons;
using Players;
using TMPro;
using UnityEngine;

namespace Interactables
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private TMP_Text woodText;
        [SerializeField] private TMP_Text stoneText;

        private void Start()
        {
            ServiceLocator<InputHandler>.Service.MenuActionTriggered += OnMenuActionTriggered;
        }

        private void Update()
        {
            woodText.text = ServiceLocator<PlayerInventory>.Service.GetAmount("Wood").ToString();
            stoneText.text = ServiceLocator<PlayerInventory>.Service.GetAmount("Stone").ToString();
        }

        private void OnMenuActionTriggered()
        {
            panel.SetActive(!panel.activeInHierarchy);
        }
    }
}