using Movement;
using UnityEngine;

namespace Controllers
{
    public class FirstPlayerController : MonoBehaviour
    {
        private PlayerActionControl _playerActionControl;
        
        [SerializeField]
        private MoveLogic moveLogic;

        private void Awake()
        {
            _playerActionControl = new PlayerActionControl();
            _playerActionControl.Player.Jump.performed += context => moveLogic.Jump();
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
