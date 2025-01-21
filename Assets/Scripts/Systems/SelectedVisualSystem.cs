using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;


partial struct SelectedVisualSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach (var selected in SystemAPI.Query<RefRO<Selected>>().WithDisabled<Selected>())
        {
            var selectedTransform = SystemAPI.GetComponentRW<LocalTransform>(selected.ValueRO.visualEntity);
            selectedTransform.ValueRW.Scale = 0f;
        }
        foreach (var selected in SystemAPI.Query<RefRO<Selected>>())
        {
            var selectedTransform = SystemAPI.GetComponentRW<LocalTransform>(selected.ValueRO.visualEntity);
            selectedTransform.ValueRW.Scale = selected.ValueRO.showScale;

        }
    }
}
