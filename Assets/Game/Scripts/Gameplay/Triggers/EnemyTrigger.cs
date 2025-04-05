using System;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    [RequireComponent(typeof(Collider))]
    public sealed class EnemyTrigger : MonoBehaviour
    {
        [SerializeField]
        private SceneEntity[] _enemies;

        private void OnTriggerEnter(Collider other)
        {
            if (!TryGetTarget(other, out var target))
            {
                return;
            }

            SetAttackTarget(target);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!TryGetTarget(other, out var target))
            {
                return;
            }

            SetAttackTarget(null);
        }

        private bool TryGetTarget(Collider other, out IEntity target)
        {
            if (!other.TryGetEntity(out target) || !target.HasPlayerTag())
            {
                return false;
            }

            return true;
        }

        private void SetAttackTarget(IEntity target)
        {
            foreach (var enemy in _enemies)
            {
                EnemyUseCase.SetAttackTarget(enemy, target);
            }
        }
    }
}
