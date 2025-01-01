using System;
using Game.Scripts.Common;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class GroundCheckComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform _raycastOrigin;

        [SerializeField]
        private LayerMask _raycastLayer;

        [SerializeField]
        private float _raycastDistance;

        [SerializeField]
        private Timer _ungroundTimer = new(0.1f);

        private readonly RaycastHit2D[] _raycastCache = new RaycastHit2D[1];

        public Transform GroundTransform {get; private set;}

        public bool IsGrounded => GroundTransform != null;

        private void Update()
        {
            _ungroundTimer.Tick(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            if (!_ungroundTimer.IsTimerUp)
            {
                return;
            }

            var count = Physics2D.RaycastNonAlloc(_raycastOrigin.position, Vector3.down, _raycastCache, _raycastDistance, _raycastLayer);

            GroundTransform = count > 0 ? _raycastCache[0].transform : null;
        }

        public void Unground()
        {
            _ungroundTimer.Reset();
            GroundTransform = null;
        }
    }
}
