using System.Collections.Generic;
using UnityEngine;

namespace PirateGame.AI.Navigation
{
    public class Waypoint : MonoBehaviour
    {
        public List<Waypoint> _neighbors = new List<Waypoint>();

        [SerializeField] private BoxCollider2D _boxCollider;

        public WaypointSpawner WaypointSpawner { get; set; }
        public BoxCollider2D BoxCollider2D { get { return _boxCollider; } }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            CheckNeighbor(collision);
        }

        private void CheckNeighbor(Collider2D collision)
        {
            if (!WaypointSpawner.AreAllWaypointsChecked)
            {
                Waypoint waypoint = collision.GetComponent<Waypoint>();

                if (waypoint != null)
                {
                    AddNeighbor(waypoint);
                }

                WaypointSpawner.CheckIfAllWaypointsAreReady();
            }
        }

        private void AddNeighbor(Waypoint waypoint)
        {
            if (!_neighbors.Contains(waypoint))
            {
                _neighbors.Add(waypoint);
            }
        }

        public Waypoint GetNearestNeighbor(Vector2 targetPosition)
        {
            Waypoint nearestWaypoint = _neighbors[0];

            foreach (Waypoint neighbor in _neighbors)
            {
                if (GetDistanceFromTarget(neighbor, targetPosition) <= GetDistanceFromTarget(nearestWaypoint, targetPosition))
                {
                    nearestWaypoint = neighbor;
                }
            }

            return nearestWaypoint;
        }

        public float GetDistanceFromTarget(Waypoint waypoint, Vector2 targetPosition)
        {
            return Vector2.Distance(waypoint.transform.position, targetPosition);
        }
    }
}

