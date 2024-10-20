using UnityEngine;

namespace Modules.Level
{
    public sealed class LevelBackground : MonoBehaviour
    {
        [SerializeField]
        private float _startPositionY;

        [SerializeField]
        private float _endPositionY;

        [SerializeField]
        private float _movingSpeedY;

        private Transform _transform;
        private float _positionX;
        private float _positionZ;


        private void Awake()
        {
            _transform = transform;

            var position = _transform.position;
            _positionX = position.x;
            _positionZ = position.z;
        }

        private void FixedUpdate()
        {
            ScrollBackgroundVertically(Time.deltaTime);
        }

        private void ScrollBackgroundVertically(float dt)
        {
            if (_transform.position.y <= _endPositionY)
            {
                _transform.position = new Vector3(
                    _positionX,
                    _startPositionY,
                    _positionZ
                );
            }

            _transform.position -= new Vector3(
                _positionX,
                _movingSpeedY * dt,
                _positionZ
            );
        }
    }
}
