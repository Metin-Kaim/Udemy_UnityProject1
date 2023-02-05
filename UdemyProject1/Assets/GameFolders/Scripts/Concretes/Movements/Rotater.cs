using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Controllers;
using UnityEngine;
namespace UdemyProject1.Movements
{
    public class Rotater
    {
        Rigidbody _rigidbody;
        PlayerController _playerController;
        public Rotater(PlayerController playerController)
        {
            _playerController = playerController;
            _rigidbody = _playerController.GetComponent<Rigidbody>();
        }

        public void fixedTick(float direction)
        {
            if (direction == 0)
            {
                if (_rigidbody.freezeRotation) _rigidbody.freezeRotation = false;
                return;
            }

            if(!_rigidbody.freezeRotation)
            {
                _rigidbody.freezeRotation = true;
            }

            _playerController.transform.Rotate(Vector3.back * Time.deltaTime * direction * _playerController.TurnSpeed);

        }
    }

}
