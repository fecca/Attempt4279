using Interactions;
using UnityEngine;
using VContainer;

namespace Players
{
    public class PlayerInteraction : MonoBehaviour
    {
        private PlayerInputHandler _inputHandler;
        private IInteractable _interactable;
        private InteractableObserver _interactableObserver;
        private InteractionActionFactory _interactionActionFactory;

        private void Start()
        {
            _inputHandler.InteractActionTriggered += OnInteraction;
            _interactableObserver.NewInteractableFound += OnNewInteractableFound;
        }

        [Inject]
        public void Construct(PlayerInputHandler inputHandler, InteractableObserver interactableObserver,
            InteractionActionFactory interactionActionFactory)
        {
            _interactionActionFactory = interactionActionFactory;
            _interactableObserver = interactableObserver;
            _inputHandler = inputHandler;
        }

        private void OnNewInteractableFound(IInteractable interactable)
        {
            _interactable = interactable;
        }

        private void OnInteraction()
        {
            if (_interactable == null) return;

            var interactionAction = _interactable.Interact();
            var executableAction = _interactionActionFactory.Create(interactionAction);
            executableAction.Execute();
            _interactableObserver.NotifyInteraction(_interactable);
        }
    }
}