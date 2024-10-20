using UnityEngine;
using UnityEngine.Pool;

namespace Modules.Pools
{
    public abstract class UnityObjectPool<T> : MonoBehaviour
        where T : Object
    {
        [SerializeField]
        private T _prefab;

        [SerializeField]
        protected Transform _root;

        [SerializeField]
        private bool _prewarm;

        [SerializeField]
        private int _prewarmCount;

        private ObjectPool<T> _pool;

        private void Awake()
        {
            _pool = new ObjectPool<T>(Create, actionOnRelease: OnRelease, actionOnDestroy: OnCleanup);

            if (_prewarm)
            {
                Prewarm(_prewarmCount);
            }
        }

        public void Prewarm(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _pool.Release(Create());
            }
        }

        public T Get()
        {
            return _pool.Get();
        }

        public void Release(T pooled)
        {
            _pool.Release(pooled);
        }

        private T Create()
        {
            return Instantiate(_prefab, _root);
        }

        protected abstract void OnRelease(T pooled);

        protected abstract void OnCleanup(T pooled);
    }
}
