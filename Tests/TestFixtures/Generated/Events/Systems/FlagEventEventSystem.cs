//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class FlagEventEventSystem : Entitas.ReactiveSystem<TestEntity> {

    readonly Entitas.IGroup<TestEntity> _listeners;

    public FlagEventEventSystem(Contexts contexts) : base(contexts.test) {
        _listeners = contexts.test.GetGroup(TestMatcher.FlagEventListener);
    }

    protected override Entitas.ICollector<TestEntity> GetTrigger(Entitas.IContext<TestEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.AddedOrRemoved(TestMatcher.FlagEvent)
        );
    }

    protected override bool Filter(TestEntity entity) {
        return true;
    }

    protected override void Execute(System.Collections.Generic.List<TestEntity> entities) {
        foreach (var e in entities) {
            var isFlagEvent = e.isFlagEvent;
            foreach (var listener in _listeners) {
                listener.flagEventListener.value.OnFlagEvent(e, isFlagEvent);
            }
        }
    }
}