using UnityEngine;
using UnityEngine.Events;

namespace PirateGame.AI.Navigation
{
    public class NavigationAgent : MonoBehaviour
    {
        private bool _isReadyToMove;

        [SerializeField] private PathFinder _pathFinder;
        [SerializeField] private UnityEvent<Vector2> _onAgentMoved;
        [SerializeField] private Collider2D _collider;

        public Transform Destination { get; set; }
        public PathFinder PathFinder { get { return _pathFinder; } }

        public void StartMovement()
        {
            Waypoint startingWaypoint = PathFinder.WaypointData.GetStartingWaypoint(transform.position);
            PathFinder.GetReadyToFindNewPath(startingWaypoint, Destination);
            _isReadyToMove = true;
        }

        public void Move()
        {
            if (_isReadyToMove)
            {
                if (!PathFinder.IsReadyToFindNewPath)
                {
                    _onAgentMoved.Invoke(GetNewPosition());
                    CheckNewPath();
                }
            }
        }

        private Vector2 GetNewPosition()
        {
            if (_pathFinder.HasReachedNextWaypoint(transform.position))
            {
                _pathFinder.UpdateNextWaypoint();
            }

            Vector2 newPosition = (_pathFinder.NextWaypoint.transform.position - transform.position).normalized;

            return newPosition;
        }

        private void CheckNewPath()
        {
            if (PathFinder.IsPathComplete(_collider))
            {
                Waypoint startingWaypoint = PathFinder.WaypointData.GetStartingWaypoint(transform.position);
                PathFinder.GetReadyToFindNewPath(startingWaypoint, Destination);
            }
        }
    }
}

