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
    }
}
