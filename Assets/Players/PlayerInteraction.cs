using Interactions;
using UnityEngine;
using VContainer;

namespace Players
{
    public class PlayerInteraction : MonoBehaviour
    {
        private PlayerInputHandler _inputHandler;
        private InteractableObserver _interactableObserver;
        private IInteractable _interactable;
        private InteractionActionFactory _interactionActionFactory;

        [Inject]
        public void Construct(PlayerInputHandler inputHandler, InteractableObserver interactableObserver, InteractionActionFactory interactionActionFactory)
        {
            _interactionActionFactory = interactionActionFactory;
            _interactableObserver = interactableObserver;
            _inputHandler = inputHandler;
        }

        private void Start()
        {
            _inputHandler.InteractActionTriggered += OnInteraction;
            _interactableObserver.NewInteractableFound += OnNewInteractableFound;
        }

        private void OnNewInteractableFound(IInteractable interactable)
            => _interactable = interactable;

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