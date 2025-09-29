using Players;
using TMPro;
using UnityEngine;

namespace Interactables
{
    public class WorldUI : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private Canvas canvas;
        [SerializeField] private TMP_Text interactLabel;
        [SerializeField] private InteractionArea interactionArea;
        private IInteractable _interactable;

        private void Start()
        {
            interactionArea.NewInteractableFound += NewInteractableFound;
        }

        private void LateUpdate()
        {
            if (_interactable == null) return;

            var p = camera.WorldToScreenPoint(_interactable.GetPosition());
            interactLabel.rectTransform.position = p;
        }

        private void NewInteractableFound(IInteractable interactable)
        {
            _interactable = interactable;
            if (_interactable == null)
            {
                interactLabel.text = "";
                return;
            }

            interactLabel.text = "Interact";
        }
    }
}