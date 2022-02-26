using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _obstacles;
        [SerializeField] private float _spawnStep;
        [SerializeField] private float _spawnDistance;
        [SerializeField] private Vector2 _segmentWidth;
        private Transform _myTrans;
        private Vector3 _lastPosition;
        private List<Transform> _spawnedObstacles = new List<Transform>();

        public List<Transform> SpawnedObstacles
        {
            get
            {
                _spawnedObstacles.RemoveAll(_trasformIsNull);
                return _spawnedObstacles;
            }
        }
        private bool _trasformIsNull(Transform transform)
        {
            return transform == null;
        }

        private void Start()
        {
            _myTrans = transform;
            _lastPosition = _myTrans.position;
        }

        private void Update()
        {
            if (_myTrans.position.z > (_lastPosition.z + _spawnStep))
            {
                _lastPosition.z += _spawnStep;
                Transform newObstacle = _obstacles[Random.Range(0, _obstacles.Length)];
                var newObject = Instantiate(newObstacle,
                    new Vector3(Random.Range(_segmentWidth.x, _segmentWidth.y), 0, _lastPosition.z + _spawnDistance),
                    Quaternion.identity);
                _spawnedObstacles.Add(newObject);
            }
        }
    }
}