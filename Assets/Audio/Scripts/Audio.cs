using System;
using UnityEngine;

namespace Assets.Audio.Scripts {
    [Serializable]
    public class Audio {

        #region Data

        [SerializeField]
        private string p_name;
        public string Name {
            get {
                return p_name;
            }
        }

        [SerializeField]
        private AudioClip p_clip;
        public AudioClip Clip {
            get {
                return p_clip;
            }
        }

        [SerializeField]
        [Range(0f, 1f)]
        private float p_volume;
        public float Volume {
            get {
                return p_volume;
            }
            set {
                if (p_source != null)
                    p_source.volume = value;
                p_volume = value;
            }
        }

        [SerializeField]
        private bool p_loop;
        public bool Loop {
            get {
                return p_loop;
            }
            set {
                if (p_source != null)
                    p_source.loop = value;
                p_loop = value;
            }
        }

        [SerializeField]
        private bool p_mute;
        public bool Mute {
            get {
                return p_mute;
            }
            set {
                if (p_source != null)
                    p_source.mute = value;
                p_mute = value;
            }
        }


        private AudioSource p_source;
        public AudioSource Source {
            get {
                return p_source;
            }
            set {
                p_source = value;
            }
        }

        #endregion
    }
}
