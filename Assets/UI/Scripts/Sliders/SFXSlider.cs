using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.UI.Scripts {
    internal sealed class SFXSlider : SliderBehaviour, IPointerUpHandler {

        #region Data

        #endregion
        private void Start() {
            p_slider.value = PlayerPrefs.GetFloat("SFXVolume", 0);
            SliderOnChange(p_slider.value);
        }

        private protected override void SliderOnChange(float value) {
            PlayerPrefs.SetFloat("SFXVolume", value);
            PlayerPrefs.Save();
            foreach (var s in p_manager.SFX) {
                s.Volume = PlayerPrefs.GetFloat("SFXVolume", 0);
                s.Mute = value == 0f;
            }
        }

        public void OnPointerUp(PointerEventData eventData) {
            p_manager.PlaySFX("UIButtonDown");
        }
    }
}
