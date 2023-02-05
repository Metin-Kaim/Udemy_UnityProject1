using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProject1.Controllers
{
    public class FinishFloorController : MonoBehaviour
    {
        [SerializeField] GameObject _fireWork;
        [SerializeField] GameObject _magicLight;

        private void OnCollisionEnter(Collision collision)
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if (player == null || !player.CanMove) return;

            if (collision.GetContact(0).normal.y == -1) //player floor'a tepeden aþaðýya dogru mu geliyor
            {
                _fireWork.SetActive(true);
                _magicLight.SetActive(true);
                GameManager.Instance.MissionSucced();
            }
            else
            {
                //GameOver
                GameManager.Instance.GameOver();
            }
        }
    }
}
