using Enemies;
using Inputs;
using Interactions;
using Loot;
using Players;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Commons
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private UI.UserInterfaceController userInterfaceController;
        [SerializeField] private PlayerAttributes playerAttributes;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInNewPrefab(userInterfaceController, Lifetime.Scoped);
            builder.RegisterInstance(playerAttributes);
            builder.Register<LootSystem>(Lifetime.Scoped);
            builder.Register<PlayerInputHandler>(Lifetime.Scoped);
            builder.Register<UIInputHandler>(Lifetime.Scoped);
            builder.Register<PlayerInventory>(Lifetime.Scoped);
            builder.Register<PlayerObserver>(Lifetime.Scoped);
            builder.Register<InteractionActionFactory>(Lifetime.Scoped);
            builder.Register<InteractableObserver>(Lifetime.Scoped);
        }
    }
}