using UnityEngine;
using UnityEngine.Events;

namespace PirateGame.AI.Enemy
{
    public class EnemyShooterAI : EnemyAI
    {
        [SerializeField] private UnityEvent<Vector2> _onShootingTriggered;

        protected new void Update()
        {
            base.Update();

            if (IsTargetNear())
            {
                isReadyToAttackPlayer = true;
            }
        }
        private bool IsTargetNear()
        {
            return Vector2.Distance(transform.position, target.transform.position) <= shipCombatData.MinShootingDistance;
        }

        protected override Transform GetDestination()
        {
            return navigationAgent.PathFinder.WaypointData.GetRandomWaypoint(transform.position).transform;
        }

        protected override void AttackTarget()
        {
            Vector2 targetDirection = target.transform.position - transform.position;
            _onShootingTriggered.Invoke(targetDirection);
        }
    }
}

