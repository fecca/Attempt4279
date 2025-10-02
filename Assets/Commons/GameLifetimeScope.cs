using Loot;
using VContainer;
using VContainer.Unity;

namespace Commons
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<LootSystem>(Lifetime.Scoped);
        }
    }
}