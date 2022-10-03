using System;
using UnityEngine;


namespace Assets.Audio.Scripts {

    public class AudioManager : MonoBehaviour {

        #region Data

        [SerializeField]
        private Audio[] p_sounds;
        public Audio[] Sounds {
            get {
                return p_sounds;
            }
        }

        [SerializeField]
        private Audio[] p_environment;
        public Audio[] Environment {
            get {
                return p_environment;
            }
        }

        [SerializeField]
        private Audio[] p_sfx;
        public Audio[] SFX {
            get {
                return p_sfx;
            }
        }

        private static AudioManager p_instance;

        #endregion

        private void Awake() {
            if (p_instance is null) {
                DontDestroyOnLoad(this);
                p_instance = this;
                CreateAudioSource(Sounds, PlayerPrefs.GetFloat("SoundsVolume", float.NaN));
                CreateAudioSource(Environment, PlayerPrefs.GetFloat("EnvironmentVolume", float.NaN));
                CreateAudioSource(SFX, PlayerPrefs.GetFloat("SFXVolume", float.NaN));
                PlayAll(p_sounds);
                PlayAll(p_environment);
            }
        }

        private void CreateAudioSource(Audio[] audio, float volume) {
            foreach (var a in audio) {
                a.Source = gameObject.AddComponent<AudioSource>();
                a.Source.playOnAwake = false;
                a.Source.clip = a.Clip;
                a.Source.loop = a.Loop;
                a.Source.mute = a.Mute;
                a.Source.volume = (volume is float.NaN) ? a.Volume : volume;
            }
        }

        private void PlayAll(Audio[] audio) {
            foreach (var a in audio) {
                a.Source.Play();
            }
        }

        public void Play(string name) {
            var s = Array.Find(p_sounds, sound => sound.Name.Equals(name));
            s.Source.Play();
        }

        public void PlaySFX(string name) {
            var s = Array.Find(p_sfx, sfx => sfx.Name.Equals(name));
            s?.Source.Play();
        }
    }
}
