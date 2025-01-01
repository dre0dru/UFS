using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class WaypointMovementComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform _root;

        [SerializeField]
        private List<Transform> _waypoints;

        [SerializeField]
        private MovementComponent _movementComponent;

        [SerializeField]
        private float _stoppingDistance;

        private int _currentWaypoint;

        private void Update()
        {
            TryChangeWaypoint();

            _movementComponent.SetMovementDirection(GetDirectionToWaypoint());
        }

        private void TryChangeWaypoint()
        {
            if (Vector2.Distance(_root.position, _waypoints[_currentWaypoint].position) > _stoppingDistance)
            {
                return;
            }

            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Count;
        }

        private Vector2 GetDirectionToWaypoint()
        {
            return _waypoints[_currentWaypoint].position - _root.position;
        }
    }
}
