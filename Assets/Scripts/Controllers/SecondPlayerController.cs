using Movement;
using UnityEngine;

namespace Controllers
{
    public class SecondPlayerController : MonoBehaviour
    {
        private PlayerActionControl _playerActionControl;
        
        [SerializeField]
        private MoveLogic moveLogic;

        private void Awake()
        {
            _playerActionControl = new PlayerActionControl();
            _playerActionControl.Player1.Jump.performed += context => moveLogic.Jump();
        }

        private void OnEnable()
        {
            _playerActionControl.Enable();
        }

        private void FixedUpdate()
        {
            float direction =  _playerActionControl.Player1.Move.ReadValue<float>();
            moveLogic.Move(direction);
        }
    }
}
