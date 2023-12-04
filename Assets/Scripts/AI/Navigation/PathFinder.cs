using PirateGame.Data.AI;
using System.Collections.Generic;
using UnityEngine;

namespace PirateGame.AI.Navigation
{
    public class PathFinder : MonoBehaviour
    {
        private int _waypointIndex = 0;
        private List<Waypoint> _path = new List<Waypoint>();
        private Waypoint _startingWaypoint;
        private Vector2 _targetPosition;

        [SerializeField] private WaypointData _waypointData;
        [SerializeField] private float _minWaypointDistance = 0.5f;

        public WaypointData WaypointData { get { return _waypointData; } }
        public Waypoint NextWaypoint { get; private set; }
        public bool IsReadyToFindNewPath { get; private set; } = false;

        private void Update()
        {
            FindNewPath();
        }

        private void FindNewPath()
        {
            if (IsReadyToFindNewPath)
            {
                Waypoint waypoint = _path[_path.Count - 1].GetNearestNeighbor(_targetPosition);
                AddWaypointToPath(waypoint);
            }
        }

        private void AddWaypointToPath(Waypoint waypoint)
        {
            if (_path.Contains(waypoint))
            {
                IsReadyToFindNewPath = false;
                
            }
            else
            {
                _path.Add(waypoint);
            }
        }

        public void UpdateNextWaypoint()
        {
            _waypointIndex++;
            _waypointIndex %= _path.Count;
            NextWaypoint = _path[_waypointIndex];
        }

        public void GetReadyToFindNewPath(Waypoint startingWaypoint, Transform target)
        {
            if (!IsReadyToFindNewPath)
            {
                IsReadyToFindNewPath = true;
                _startingWaypoint = startingWaypoint;
                _targetPosition = target.transform.position;

                _waypointIndex = 0;
                _path.Clear();

                AddWaypointToPath(_startingWaypoint);
                NextWaypoint = _path[0];
            }
        }

        public bool HasReachedNextWaypoint(Vector2 currentPosition)
        {
            return Vector3.Distance(currentPosition, NextWaypoint.transform.position) <= _minWaypointDistance;
        }

        public bool IsPathComplete(Collider2D collider)
        {
            return collider.IsTouching(_path[_path.Count - 1].BoxCollider2D);
        }
    }
}

