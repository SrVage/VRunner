using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code
{
    public class CharacterController:MonoBehaviour
    {
        [SerializeField] private GameObject _camera;
        [SerializeField] private float _forwardSpeed=5f;
        [SerializeField] private float _sideSpeed=2f;
        [SerializeField] private float _deadZoneRotation=10f;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private LightingController _lightingController;
        private bool _isDead = false;

        private async void Update()
        {
            if (_isDead)
                return;
            Vector3 currentVelocity = _rigidbody.velocity;
            if (_camera.transform.rotation.eulerAngles.y > _deadZoneRotation &&
                _camera.transform.rotation.eulerAngles.y <= 180)
                currentVelocity.x = _camera.transform.rotation.eulerAngles.y * _sideSpeed * Time.deltaTime;
            if (_camera.transform.rotation.eulerAngles.y > 180 &&
                _camera.transform.rotation.eulerAngles.y <= 360-_deadZoneRotation)
                currentVelocity.x = -1*(360- _camera.transform.rotation.eulerAngles.y) * _sideSpeed * Time.deltaTime;
            currentVelocity.z = _forwardSpeed;
            _rigidbody.velocity = currentVelocity;
            if (_rigidbody.velocity.y < -10)
            {
                _lightingController.Loose();
                await Task.Delay(2000);
                SceneManager.LoadScene(0);
            }

            if (transform.position.z > 100)
            {
                _lightingController.Win();
                await Task.Delay(2000);
                SceneManager.LoadScene(0);
            }
        }

        public void Dead()
        {
            _isDead = true;
            _lightingController.Loose();
        }
    }
}