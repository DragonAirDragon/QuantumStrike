using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class UnitMoverAuthoring : MonoBehaviour
{
   public float moveSpeed;
   public float rotationSpeed;
   public Vector3 targetPosition;
   public class Baker: Baker<UnitMoverAuthoring>
   {
      public override void Bake(UnitMoverAuthoring authoring)
      {
         Entity entity = GetEntity(TransformUsageFlags.Dynamic);
         AddComponent(entity, new UnitMover { 
            moveSpeed = authoring.moveSpeed,
            rotationSpeed = authoring.rotationSpeed,
            targetPosition = authoring.targetPosition,
            });
      }
   }
}
public struct UnitMover : IComponentData
{
   public float moveSpeed;
   public float rotationSpeed;
   public float3 targetPosition;
}
