using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

public class CompassNavigationBehavior : EntityBehavior
{
    private Vec3d targetPosition;
    private bool targetSet;
    private double targetDistanceThreshold = 1.0;

    public CompassNavigationBehavior(Entity entity) : base(entity)
    {
    }

    public override void OnEntityTick(float deltaTime)
    {
        if (targetSet)
        {
            PointTowardsTarget();
            CheckIfTargetReached();
        }
    }

    public void SetTarget(Vec3d position)
    {
        targetPosition = position;
        targetSet = true;
    }

    public void ResetTarget()
    {
        targetSet = false;
    }

    private void PointTowardsTarget()
    {
        Vec3d entityPosition = entity.Pos.XYZ;
        Vec3d direction = targetPosition.Subtract(entityPosition).Normalized();
        entity.Pos.Yaw = (float)System.Math.Atan2(direction.X, direction.Z);
    }

    private void CheckIfTargetReached()
    {
        Vec3d entityPosition = entity.Pos.XYZ;
        double distanceToTarget = entityPosition.DistanceTo(targetPosition);

        if (distanceToTarget <= targetDistanceThreshold)
        {
            OnTargetReached();
        }
    }

    private void OnTargetReached()
    {
        ResetTarget();
    }

    public override string PropertyName()
    {
        return "compassnavigationbehavior";
    }
}