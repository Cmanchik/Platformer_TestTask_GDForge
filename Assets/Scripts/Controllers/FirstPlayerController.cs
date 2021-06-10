using System;
using Movement;
using Shooting;
using UnityEngine;

namespace Controllers
{
    public class FirstPlayerController : MonoBehaviour
    {
        private PlayerActionControl _playerActionControl;
        
        [SerializeField]
        private MoveLogic moveLogic;

        [SerializeField] private ShootingLogic shootingLogic;

        private void Awake()
        {
            _playerActionControl = new PlayerActionControl();
        }

        private void Start()
        {
            _playerActionControl.Player.Jump.performed += context => moveLogic.Jump();
            _playerActionControl.Player.Shoot.performed += context => shootingLogic.Shoot();
        }

        private void OnEnable()
        {
            _playerActionControl.Enable();
        }

        private void FixedUpdate()
        {
            float direction =  _playerActionControl.Player.Move.ReadValue<float>();
            moveLogic.Move(direction);
        }
    }
}
