using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Inputs;
using UdemyProject1.Managers;
using UdemyProject1.Movements;
using UnityEngine;
namespace UdemyProject1.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        DefaultInput _input;
        Mover _mover;
        Rotater _rotater;
        Fuel _fuel;

        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] float _force = 55f;


        bool _canMove;
        bool _canForceUp;
        float _leftRight;

        public float TurnSpeed => _turnSpeed;
        public float Force => _force;

        public bool CanMove => _canMove;

        private void Awake()
        {
            _input = new DefaultInput();
            _mover=new Mover(this);
            _rotater = new Rotater(this);
            _fuel=GetComponent<Fuel>();
        }

        private void Start()
        {
            _canMove = true;
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameOver += HandleOnEventTriggered;    
            GameManager.Instance.OnMissionSucced += HandleOnEventTriggered;    
        }

        
        private void OnDisable()
        {
            GameManager.Instance.OnGameOver -= HandleOnEventTriggered;
            GameManager.Instance.OnMissionSucced -= HandleOnEventTriggered;
        }

        private void Update()
        {
            if(!_canMove) return;

            if (_input.IsForceUp && !_fuel.IsEmpty)
            {
                _canForceUp = true;
            }
            else
            {
                _canForceUp = false;
                _fuel.FuelIncrease(.015f);
            }

            _leftRight=_input.LeftRight;
        }

        private void FixedUpdate()
        {
            if (_canForceUp)
            {
                _mover.FixedTick();
                _fuel.FuelDecrease(.2f);
            }

            _rotater.fixedTick(_leftRight);

        }

        private void HandleOnEventTriggered()
        {
            _canMove= false;
            _canForceUp=false;
            _leftRight = 0f;

            _fuel.FuelIncrease(0f);
        }

    }
}

