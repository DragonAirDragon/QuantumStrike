using Unity.Entities;
using UnityEngine;

class SelecterAuthoring : MonoBehaviour
{
    public GameObject selectionVisual;
    public float showScale;
    class Baker : Baker<SelecterAuthoring>
    {
        public override void Bake(SelecterAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Selected
            {
                visualEntity = GetEntity(authoring.selectionVisual, TransformUsageFlags.Dynamic),
                showScale = authoring.showScale
            });
            SetComponentEnabled<Selected>(entity, false);
        }
    }
}
public struct Selected : IComponentData, IEnableableComponent
{
    public Entity visualEntity;
    public float showScale;
}