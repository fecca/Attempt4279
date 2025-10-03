using System;
using Interactions;

namespace Players
{
    public class InteractableObserver
    {
        public event Action<IInteractable> NewInteractableFound = _ => { };
        public event Action<IInteractable> Interacted = _ => { };

        public void NotifyNewInteractableFound(IInteractable interactable)
            => NewInteractableFound(interactable);

        public void NotifyInteraction(IInteractable interactable)
            => Interacted(interactable);
    }
}