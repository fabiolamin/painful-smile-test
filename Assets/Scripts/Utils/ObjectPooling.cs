using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace PirateGame.Utils
{
    public class ObjectPooling : MonoBehaviour
    {
        private const string _pooledObjectsTagName = "Pooled Objects";

        private Transform _pooledObjectTransform;

        [SerializeField] private GameObject _objectPrefab;
        [SerializeField] private int _amount = 10;

        public List<GameObject> PooledObjects { get; private set; } = new List<GameObject>();

        private void Awake()
        {
            _pooledObjectTransform = GameObject.FindGameObjectWithTag(_pooledObjectsTagName).transform;

            StartInstantiatingObjects();
        }

        private void StartInstantiatingObjects()
        {
            for (int i = 0; i < _amount; i++)
            {
                InstantiateObject();
            }
        }

        private GameObject InstantiateObject()
        {
            GameObject pooledObject = Instantiate(_objectPrefab);
            pooledObject.SetActive(false);
            PooledObjects.Add(pooledObject);
            pooledObject.transform.SetParent(_pooledObjectTransform);

            return pooledObject;
        }

        public GameObject GetObject()
        {
            GameObject pooledObject = PooledObjects.FirstOrDefault(o => !o.activeSelf);
            if (pooledObject == null)
            {
                pooledObject = InstantiateObject();
            }

            pooledObject.SetActive(true);
            return pooledObject;
        }
    }
}

