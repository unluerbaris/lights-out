using UnityEngine.Audio;
using UnityEngine;

namespace LightsOut.Scene
{
    [System.Serializable]
    public class Sound
    {
        public AudioClip clip;
        public string soundName;
        [Range(0f, 1f)] public float volume = 1f;
        [Range(0.1f, 3f)] public float pitch = 1f;
        [HideInInspector] public AudioSource audioSource;
        public bool loop;
    }
}
