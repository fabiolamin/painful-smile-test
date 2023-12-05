using UnityEngine;

namespace PirateGame.Data.Game
{
    [CreateAssetMenu(fileName = "Game Session Data", menuName = "Game/new Game Session Data")]
    public class GameSessionData : ScriptableObject
    {
        private int _currentNumberOfEnemies = 0;

        [Tooltip("Minutes")]
        [Range(1f, 3f)]
        [SerializeField] private float _sessionTime = 3f;

        [Tooltip("Seconds")]
        [Range(1f, 60f)]
        [SerializeField] private float _enemySpawnTime = 5f;

        [Range(5, 10)]
        [SerializeField] private int _maxNumberOfEnemies = 5;

        [SerializeField] private string _sessionTimeID = "Session";
        [SerializeField] private string _enemySpawnTimeID = "EnemySpawn";

        public float SessionTime { get { return _sessionTime; } }
        public float EnemySpawnTime { get { return _enemySpawnTime; } }
        public int MaxNumberOfEnemies { get { return _maxNumberOfEnemies; } }
        public int CurrentNumberOfEnemies { get; set; }
        public string SessionTimeID { get { return _sessionTimeID; } }
        public string EnemySpawnTimeID { get { return _enemySpawnTimeID; } }

        public void ResetCurrentNumberOfEnemies()
        {
            _currentNumberOfEnemies = 0;
        }

        public void AddEnemyToGameSession()
        {
            _currentNumberOfEnemies += 1;
            _currentNumberOfEnemies = Mathf.Min(_maxNumberOfEnemies, _currentNumberOfEnemies);
        }

        public void RemoveEnemyFromGameSession()
        {
            _currentNumberOfEnemies -= 1;
            _currentNumberOfEnemies = Mathf.Max(0, _currentNumberOfEnemies);
        }

        public bool CanSpawnEnemiesOnGameSession()
        {
            return _currentNumberOfEnemies < MaxNumberOfEnemies;
        }
    }
}

