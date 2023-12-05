using PirateGame.AI.Navigation;
using PirateGame.Data.Combat;
using PirateGame.Health;
using UnityEngine;

namespace PirateGame.AI.Enemy
{
    public abstract class EnemyAI : MonoBehaviour
    {
        private float _timeSinceLastAttack = 0f;

        [SerializeField] protected ShipCombatData shipCombatData;
        [SerializeField] protected NavigationAgent navigationAgent;

        protected Target target;
        protected ShipHealth targetHealth;
        protected bool isReadyToAttackPlayer = false;

        public Vector2 SpawnOrigin { get; private set; }

        public NavigationAgent NavigationAgent { get { return navigationAgent; } }

        private void Awake()
        {
            target = FindObjectOfType<Target>();
            targetHealth = target.GetComponent<ShipHealth>();
        }

        protected virtual void Update()
        {
            navigationAgent.Move();
            CheckAttack();
        }

        protected virtual void OnEnable()
        {
            NavigationAgent.NewPathRequested += GetDestination;
        }

        protected virtual void OnDisable()
        {
            NavigationAgent.NewPathRequested -= GetDestination;
        }

        private void CheckAttack()
        {
            if (isReadyToAttackPlayer)
            {
                _timeSinceLastAttack += Time.deltaTime;

                if (_timeSinceLastAttack >= shipCombatData.ReloadingTime)
                {
                    AttackTarget();
                    isReadyToAttackPlayer = false;
                    _timeSinceLastAttack = 0f;
                }
            }
        }

        protected abstract Transform GetDestination();
        protected abstract void AttackTarget();
    }
}

