using Interactions;
using Items.Scripts;
using UnityEngine;

namespace Environments
{
    public class Rock : MonoBehaviour, IInteractable
    {
        [SerializeField] private ItemBlueprint itemBlueprint;

        private Vector3 _originalScale;

        private void Awake()
            => _originalScale = transform.localScale;

        public IInteractionResult Interact()
        {
            transform.localScale = _originalScale * 0.25f;
            Destroy(this);

            return new ItemInteractionResult(new ItemInstance(itemBlueprint, 1));
        }

        public Vector3 GetPosition()
            => transform.position;

        public void Highlight()
            => transform.localScale = _originalScale * 1.1f;

        public void Unhighlight()
            => transform.localScale = _originalScale;

        public string GetText()
            => "Smash";
    }
}