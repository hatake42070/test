using VContainer;
using VContainer.Unity;

public class StageSelectLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<StageSelectUI>();
    }
}
