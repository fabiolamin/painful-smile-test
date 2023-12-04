using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using PirateGame.AI.Navigation;

namespace PirateGame.Data.AI
{
    [CreateAssetMenu(fileName = "Waypoint Data", menuName = "AI/new Waypoint Data")]
    public class WaypointData : ScriptableObject
    {
        private List<Waypoint> _waypoints = new List<Waypoint>();

        [SerializeField] private float _width;
        [SerializeField] private float _height;
        [SerializeField] private float _maxWaypointDistance = 5f;
        [SerializeField] private float _minRandomWaypointDistance = 10f;
        [SerializeField] Waypoint _waypointPrefab;

        public float Width { get { return _width; } }
        public float Height { get { return _height; } }
        public float MaxWaypointDistance { get { return _maxWaypointDistance; } }
        public Waypoint WaypointPrefab { get { return _waypointPrefab; } }

        public void AddWaypoint(Waypoint waypoint)
        {
            if (!_waypoints.Contains(waypoint))
            {
                _waypoints.Add(waypoint);
            }
        }

        public void Clear()
        {
            _waypoints.Clear();
        }

        public Waypoint GetRandomWaypoint(Vector2 position)
        {
            var waypoints = _waypoints.Where(w => Vector2.Distance(position, w.transform.position) >= _minRandomWaypointDistance);

            return waypoints.ElementAt(Random.Range(0, waypoints.Count()));
        }

        public Waypoint GetStartingWaypoint(Vector2 position)
        {
            return _waypoints.FirstOrDefault(w => Vector2.Distance(w.transform.position, position) <= _maxWaypointDistance);
        }

        public bool AreAllWaypointsReady()
        {
            return _waypoints.All(w => w._neighbors.Count > 0);
        }
    }
}

