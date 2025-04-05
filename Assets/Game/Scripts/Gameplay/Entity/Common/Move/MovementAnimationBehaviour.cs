using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    //TODO в будущем надо неймиг делать вида MoveXXXBehaviour, чтобы все было однообразно и было проще искать
    //либо папку надо было в Movement переименовать
    public class MovementAnimationBehaviour : IEntityInit, IEntityUpdate
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        private Animator _animator;

        public void Init(in IEntity entity)
        {
            _animator = entity.GetAnimator();
        }

        //TODO я чет вообще не могу понять, как это работает)))
        //обычно же для перемещения через root motion нужно вручную "ловить" дельту от аниматора
        //и применять к рутовому трансформу. а тут это как будто само по себе делается?
        //думал может какие хитрые constraints есть, но они только для коллайдеров и vfx стоят
        //у меня кода никакого нет для трансфера рутмоушена, заметил это когда чисто проверял анимации, самого перемещения еще не было написано
        //никаких других "готовых" компонентов, что делали бы это тоже не нашел
        //TODO позже эта штука заставила все равно писать костыльное применение root motion, иначе вращение сделать не получалось
        //плюс как-то странно оно работает. трансформ вьюшки меняет свой position, но визуально остается по центру
        //рутового объекта
        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            _animator.SetBool(IsMoving, MovementUseCase.IsMoving(entity));
        }
    }
}
