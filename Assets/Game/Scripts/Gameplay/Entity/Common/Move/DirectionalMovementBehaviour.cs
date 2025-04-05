using Atomic.Entities;

namespace Game.Gameplay
{

    public class DirectionalMovementBehaviour : IEntityFixedUpdate
    {
        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            var direction = entity.GetMovementDirection();
            MovementUseCase.MoveDirection(entity, direction.Value, deltaTime);
        }
    }
}
