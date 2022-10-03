using UnityEngine;

namespace Assets.UI.Scripts {
    internal sealed class SoundsSlider : SliderBehaviour {

        #region Data

        #endregion

        private void Start() {
            p_slider.value = PlayerPrefs.GetFloat("SoundsVolume", 0);
            SliderOnChange(p_slider.value);
        }

        private protected override void SliderOnChange(float value) {
            PlayerPrefs.SetFloat("SoundsVolume", value);
            PlayerPrefs.Save();
            foreach (var s in p_manager.Sounds) {
                s.Volume = PlayerPrefs.GetFloat("SoundsVolume", 0);
                s.Mute = value == 0f;
            }
        }
    }
}
