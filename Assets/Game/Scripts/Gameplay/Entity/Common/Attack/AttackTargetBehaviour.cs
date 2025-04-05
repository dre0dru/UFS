using Atomic.Entities;

namespace Game.Gameplay
{
    //TODO опять же, с одной стороны атака, поэтому лежит в папке Attack
    //с другой стороны чисто для Enemy написано, поэтому можно и в Enemy положить
    public class AttackTargetBehaviour: IEntityFixedUpdate
    {
        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            if (!EnemyUseCase.HasAttackTarget(entity, out var target))
            {
                return;
            }

            if (EnemyUseCase.IsAttackTargetAlive(entity) && EnemyUseCase.IsAttackTargetReached(entity))
            {
                entity.GetAttackAction().Invoke();
            }
        }
    }
}
