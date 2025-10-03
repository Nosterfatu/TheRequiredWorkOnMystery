using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Pool;

namespace Source
{
    public class AudioManager : MonoBehaviour, IAudioManager
    {
        [SerializeField] private AudioSource _soundSource;
        [SerializeField] private AudioSource _musicSource;

        // Better to move to some audio bank or resources folder but for simplification stays here as there are less 10
        [SerializeField] private AudioClip _musicClip;
        [SerializeField] private AudioClip ButtonClickClip;
        [SerializeField] private AudioClip CardDrowClip;
        [SerializeField] private AudioClip CardHideClip;
        [SerializeField] private AudioClip CardClearClip;
        [SerializeField] private AudioClip WinClip;
        [SerializeField] private AudioClip LoseClip;
        [SerializeField] private AudioClip LevelStartedClip;

        private Queue<AudioSource> _audioSources = new Queue<AudioSource>();


        public void PlaySound(SFX sfx, float delay = 0)
        {
            StartCoroutine(PlayWithDelay(sfx, delay));
        }

        private IEnumerator PlayWithDelay(SFX sfx, float delay)
        {
            var clone =
                _audioSources.Count > 0
                    ? _audioSources.Dequeue()
                    : Instantiate(_soundSource, _soundSource.transform.position, _soundSource.transform.rotation);

            yield return new WaitForSeconds(delay);
            clone.gameObject.SetActive(true);
            clone.clip = GetClip(sfx);
            clone.Play();
            yield return new WaitForSeconds(clone.clip.length);
            clone.Stop();
            clone.gameObject.SetActive(false);
            _audioSources.Enqueue(clone);
        }

        private AudioClip GetClip(SFX sfx)
        {
            switch (sfx)
            {
                case SFX.ButtonClick:
                    return ButtonClickClip;
                case SFX.CardDrow:
                    return CardDrowClip;
                case SFX.CardHide:
                    return CardHideClip;
                case SFX.CardClear:
                    return CardClearClip;
                case SFX.Win:
                    return WinClip;
                case SFX.Lose:
                    return LoseClip;
                case SFX.LevelStarted:
                    return LevelStartedClip;
            }

            return null;
        }


        public void PlayMusic()
        {
            _musicSource.Play();
        }
    }
}