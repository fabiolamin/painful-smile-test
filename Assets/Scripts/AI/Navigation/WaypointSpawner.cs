using PirateGame.Data.AI;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace PirateGame.AI.Navigation
{
    public class WaypointSpawner : MonoBehaviour
    {
        private Obstacle[] _obstacles;

        private int _rows;
        private int _columns;

        [SerializeField] private WaypointData _waypointData;
        [SerializeField] private Transform _pathOrigin;
        [SerializeField] private UnityEvent _onWaypointsSpawned;

        public bool AreAllWaypointsChecked { get; private set; } = false;

        private void Awake()
        {
            SetUpWaypoints();
            SpawnWaypoints();
        }

        private void SetUpWaypoints()
        {
            _waypointData.Clear();
            _obstacles = FindObjectsOfType<Obstacle>();

            _columns = (int)(_waypointData.Width / _waypointData.MaxWaypointDistance);
            _rows = (int)(_waypointData.Height / _waypointData.MaxWaypointDistance);
        }

        private void SpawnWaypoints()
        {
            for (int c = 0; c < _columns; c++)
            {
                for (int r = 0; r < _rows; r++)
                {
                    float x = c * _waypointData.MaxWaypointDistance;
                    float y = r * _waypointData.MaxWaypointDistance;
                    Vector2 position = new Vector2(_pathOrigin.position.x + x, _pathOrigin.position.y - y);

                    if (!IsAnObstacleNear(position))
                    {
                        Waypoint waypoint = Instantiate(_waypointData.WaypointPrefab);
                        waypoint.WaypointSpawner = this;
                        waypoint.transform.position = new Vector3(position.x, position.y, waypoint.transform.position.z);
                        waypoint.BoxCollider2D.size = Vector2.one * _waypointData.MaxWaypointDistance;
                        waypoint.transform.SetParent(transform);
                        _waypointData.AddWaypoint(waypoint);
                    }
                }
            }
        }

        private bool IsAnObstacleNear(Vector2 position)
        {
            return _obstacles.Any(o => Vector2.Distance(position, o.transform.position) < o.Distance);
        }

        public void CheckIfAllWaypointsAreReady()
        {
            if(_waypointData.AreAllWaypointsReady())
            {
                AreAllWaypointsChecked = true;
                _onWaypointsSpawned.Invoke();
            }
        }
    }
}

