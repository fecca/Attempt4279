using Interactions;
using Players;
using TMPro;
using UnityEngine;
using VContainer;

namespace UI
{
    public class WorldUI : MonoBehaviour
    {
        [SerializeField] private new Camera camera;
        [SerializeField] private Canvas canvas;
        [SerializeField] private TMP_Text interactLabel;

        private IInteractable _interactable;
        private PlayerSpawner _spawner;
        private InteractableObserver _interactableObserver;

        [Inject]
        public void Construct(InteractableObserver interactableObserver)
            => _interactableObserver = interactableObserver;

        private void Start()
        {
            _interactableObserver.NewInteractableFound += OnNewInteractableFound;
        }

        private void LateUpdate()
        {
            if (_interactable == null) return;

            var p = camera.WorldToScreenPoint(_interactable.GetPosition());
            interactLabel.rectTransform.position = p;
        }

        private void OnNewInteractableFound(IInteractable interactable)
        {
            _interactable = interactable;
            if (_interactable == null)
            {
                interactLabel.text = "";
                return;
            }

            interactLabel.text = _interactable.GetText();
        }
    }
}