using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject1.Controllers
{
    public class StartFloorController : MonoBehaviour
    {
        private void OnCollisionExit(Collision collision)
        {
            PlayerController player=collision.gameObject.GetComponent<PlayerController>();

            if(player != null )
            {
                Destroy(gameObject);
            }
        }
    }

}
