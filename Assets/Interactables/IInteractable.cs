using UnityEngine;

namespace Interactables
{
    public interface IInteractable
    {
        void Interact();
        Vector3 GetPosition();
        void Highlight();
        void Unhighlight();
    }
}