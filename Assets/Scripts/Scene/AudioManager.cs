using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

namespace LightsOut.Scene
{
    public class AudioManager : MonoBehaviour
    {
        public Sound[] sounds;
        public static AudioManager instance;

        void Awake()
        {
            if (instance == null) // if there is no other instance use this gameobject
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject); // otherwise destroy this gameobject
                return;
            }

            foreach (Sound sound in sounds)
            {
                sound.audioSource = gameObject.AddComponent<AudioSource>();
                sound.audioSource.clip = sound.clip;
                sound.audioSource.volume = sound.volume;
                sound.audioSource.pitch = sound.pitch;
                sound.audioSource.loop = sound.loop;
            }
        }

        private void Start()
        {
            PlaySound("Theme"); // play theme 
        }

        public void PlaySound(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.soundName == name);
            if (s == null) { return; }
            s.audioSource.Play();
        }

        public void StopPlaySound(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.soundName == name);
            if (s == null) { return; }
            s.audioSource.Stop();
        }
    }
}
