//Author: Small Hedge Games
//Updated: 13/06/2024

using System;
using UnityEngine;
using UnityEngine.Audio;

namespace SmallHedge.SoundManager
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private SoundsSO SO;
        private static SoundManager instance = null;
        private bool isMuted = false;
        private AudioSource audioSource;
        public AudioMixer audioMixer;
        public string ambienceVolumeParameter = "AmbienceVolume"; // Must match exposed name
        public string effectsVolumeParameter = "EffectsVolume";

        private void Awake()
        {
            if(!instance)
            {
                instance = this;
                audioSource = GetComponent<AudioSource>();
            }
        }

        void Update()
        {
            // Check if the M key is pressed
            if (Input.GetKeyDown(KeyCode.M))
            {
                ToggleSound();
            }
        }

        public static void PlaySound(SoundType sound, AudioSource source = null, float volume = 1)
        {
            SoundList soundList = instance.SO.sounds[(int)sound];
            AudioClip[] clips = soundList.sounds;
            AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];

            Debug.Log("Playing sound: " + sound);

            if(source)
            {
                source.outputAudioMixerGroup = soundList.mixer;
                source.clip = randomClip;
                source.volume = volume * soundList.volume;
                source.Play();
            }
            else
            {
                instance.audioSource.outputAudioMixerGroup = soundList.mixer;
                instance.audioSource.PlayOneShot(randomClip, volume * soundList.volume);
            }
        }

        private void ToggleSound()
        {
            if(!isMuted)
            {
                audioMixer.SetFloat(ambienceVolumeParameter, -80f);
                audioMixer.SetFloat(effectsVolumeParameter, -80f);
                isMuted = true;
            }
            else
            {
                audioMixer.SetFloat(ambienceVolumeParameter, 0f);
                audioMixer.SetFloat(effectsVolumeParameter, 0f);
                isMuted = false;
            }
        }
    }

    [Serializable]
    public struct SoundList
    {
        [HideInInspector] public string name;
        [Range(0, 1)] public float volume;
        public AudioMixerGroup mixer;
        public AudioClip[] sounds;
    }
}