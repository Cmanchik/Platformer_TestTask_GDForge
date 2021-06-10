using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    public class ChangingActionPath : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        public void ChangeActionMap(string nameMap)
        {
            playerInput.SwitchCurrentActionMap(nameMap);
        }
    }
}
