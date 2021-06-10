using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public class EndLevelEvent : MonoBehaviour
    {
        [SerializeField] private UnityEvent endLevel;
        private int _numPlayers;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player")) _numPlayers++;
            if (_numPlayers == 2) endLevel.Invoke();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player")) _numPlayers--;
        }
    }
}
