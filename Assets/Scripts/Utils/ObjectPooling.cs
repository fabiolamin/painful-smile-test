using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace PirateGame.Utils
{
    public class ObjectPooling : MonoBehaviour
    {
        [SerializeField] private GameObject _objectPrefab;
        [SerializeField] private int _amount = 10;

        public List<GameObject> PooledObjects { get; private set; } = new List<GameObject>();

        private void Awake()
        {
            InstantiateObjects();
        }

        private void InstantiateObjects()
        {
            for (int i = 0; i < _amount; i++)
            {
                GameObject pooledObject = Instantiate(_objectPrefab);
                pooledObject.SetActive(false);
                PooledObjects.Add(pooledObject);
            }
        }

        public GameObject GetObject()
        {
            GameObject pooledObject = PooledObjects.FirstOrDefault(o => !o.activeSelf);
            if (pooledObject == null)
            {
                pooledObject = Instantiate(_objectPrefab);
                PooledObjects.Add(pooledObject);
            }

            pooledObject.SetActive(true);
            return pooledObject;
        }
    }
}

