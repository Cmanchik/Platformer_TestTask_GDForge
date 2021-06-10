using System;
using UnityEngine;

namespace Monument
{
    public class PushPlateScript : MonoBehaviour
    {
        [SerializeField] private MonumentMoveLogic monumentMoveLogic;
        private int _objectRaiseId = 0;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Player") || _objectRaiseId != 0) return;
            
            _objectRaiseId = other.gameObject.GetInstanceID();

        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (_objectRaiseId != 0) monumentMoveLogic.IsUp = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.GetInstanceID() != _objectRaiseId) return;
            monumentMoveLogic.IsUp = false;
            _objectRaiseId = 0;
        }
    }
}
