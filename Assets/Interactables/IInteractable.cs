using Players;
using UnityEngine;

namespace Interactables
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