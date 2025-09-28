using Commons;
using UnityEngine;

namespace Players
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private InteractionArea interactionArea;

        private void Start()
        {
            ServiceLocator<InputHandler>.Service.InteractActionTriggered += OnInteraction;
        }

        private void OnInteraction()
        {
            if (!interactionArea.CanInteract()) return;

            var interactionResult = interactionArea.InteractWithClosestTarget();
            interactionResult.Execute();
        }
    }
}