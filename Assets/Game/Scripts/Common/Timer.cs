using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Common
{
    [Serializable]
    public class Timer
    {
        [SerializeField]
        public float _time;

        [ShowInInspector]
        private float _timer;

        public bool IsTimerUp => _timer <= 0;

        public Timer(float time)
        {
            _time = time;
        }

        public void Tick(float dt)
        {
            _timer -= dt;
        }

        public void Reset()
        {
            _timer = _time;
        }
    }
}
