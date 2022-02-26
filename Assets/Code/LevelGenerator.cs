using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private List<Transform> _segments;
        [SerializeField] private float _minDistance;
        [SerializeField] private Transform _player;

        private void Update()
        {
            Transform lastSegment = _segments[_segments.Count - 1];
            float distance = Vector3.Distance(lastSegment.position, _player.position);
            if (distance < _minDistance)
            {
                Transform firstSegment = _segments[0];
                firstSegment.position = lastSegment.position;
                Vector3 offset = lastSegment.GetComponent<Collider>().bounds.extents +
                                 firstSegment.GetComponent<Collider>().bounds.extents;
                firstSegment.position += Vector3.forward * offset.z;
                _segments.Remove(firstSegment);
                _segments.Add(firstSegment);
            }
        }
    }
}