using UnityEngine;

namespace Assets.UI.Scripts {
    internal sealed class EnvironmentSlider : SliderBehaviour {

        #region Data

        #endregion
        private void Start() {
            p_slider.value = PlayerPrefs.GetFloat("EnvironmentVolume", 0);
            SliderOnChange(p_slider.value);
        }

        private protected override void SliderOnChange(float value) {
            PlayerPrefs.SetFloat("EnvironmentVolume", value);
            PlayerPrefs.Save();
            foreach (var s in p_manager.Environment) {
                s.Volume = PlayerPrefs.GetFloat("EnvironmentVolume", 0);
                s.Mute = value == 0f;
            }
        }
    }
}
