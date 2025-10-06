using UnityEngine;

namespace Interactions
{
    public interface IInteractable
    {
        IInteractionResult Interact();
        Vector3 GetPosition();
        void Highlight();
        void Unhighlight();
        string GetText();
    }
}