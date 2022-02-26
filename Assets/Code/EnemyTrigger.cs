using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code
{
    public class EnemyTrigger:MonoBehaviour
    {
        private async void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<CharacterController>(out var controller))
            {
                controller.Dead();
                await Task.Delay(2000);
                SceneManager.LoadScene(0);
            }
        }
    }
}