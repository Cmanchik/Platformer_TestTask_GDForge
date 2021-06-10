using System;
using UnityEngine;
using UnityEngine.UI;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private Slider volumeSlider;
        [SerializeField] private AudioSource audioSource;

        private void Start()
        {
            volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
        }

        private void ChangeVolume()
        {
            audioSource.volume = volumeSlider.value;
        }
    }
}
