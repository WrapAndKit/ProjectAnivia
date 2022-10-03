using Assets.Audio.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UI.Scripts {
    [RequireComponent(typeof(Slider))]
    internal abstract class SliderBehaviour : MonoBehaviour {

        #region Data

        private protected Slider p_slider;

        private protected AudioManager p_manager;

        #endregion

        private void Awake() {
            p_slider = GetComponent<Slider>();
            p_slider.onValueChanged.AddListener(SliderOnChange);
            p_manager = GameInfo.AudioManager;
        }


        private protected abstract void SliderOnChange(float value);
    }
}
