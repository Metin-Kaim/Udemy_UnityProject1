using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Abstracts.Utilities;
using UnityEngine;

namespace UdemyProject1.Managers
{
    public class SoundManager : SingletonThisObject<SoundManager>
    {
        AudioSource[] _audioSource;

        private void Awake()
        {
            SingletonThisGameObject(this);
            _audioSource = GetComponentsInChildren<AudioSource>();
        }

        public void PlaySound(int index)
        {
            if (!_audioSource[index].isPlaying)
                _audioSource[index].Play();
        }

        public void StopSound(int index)
        {
            if (_audioSource[index].isPlaying)
                _audioSource[index].Stop();
        }


    }

}
