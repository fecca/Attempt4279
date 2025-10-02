using UnityEngine;

namespace Interactions
{
    public interface IInteractable
    {
        IInteractionAction Interact();
        Vector3 GetPosition();
        void Highlight();
        void Unhighlight();
        string GetText();
    }
}