using System;
using UnityEngine;

namespace Code
{
    public class LightingController:MonoBehaviour
    {
        [SerializeField] private Light _light;
        [SerializeField] private Color _loose;
        [SerializeField] private Color _finish;
        private bool _win = false;
        private bool _die = false;
        
        private void Update()
        {
            if (_win)
            {
                _light.color = Color.Lerp(_light.color, _finish, Time.deltaTime);
                _light.intensity = Mathf.Lerp(_light.intensity, 1, Time.deltaTime);
            }

            if (_die)
            {
                _light.color = Color.Lerp(_light.color, _loose, Time.deltaTime);
                _light.intensity = Mathf.Lerp(_light.intensity, 0, Time.deltaTime);
            }
        }

        public void Loose()
        {
            _die = true;
        }

        public void Win()
        {
            _win = true;
        }
    }
}