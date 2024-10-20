using UnityEngine;

namespace Modules.Pools
{
    public class GameObjectPool : UnityObjectPool<GameObject>
    {
        protected override void OnRelease(GameObject go)
        {
            go.transform.SetParent(_root);
        }

        protected override void OnCleanup(GameObject go)
        {
            Destroy(go);
        }
    }
}
