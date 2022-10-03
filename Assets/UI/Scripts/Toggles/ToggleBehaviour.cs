using UnityEngine;
using UnityEngine.UI;

namespace Assets.UI.Scripts.Toggles {
    internal abstract class ToggleBehaviour : MonoBehaviour {
        #region Data

        private Toggle p_toggle;

        #endregion

        private void Awake() {
            p_toggle = GetComponent<Toggle>();
            p_toggle.onValueChanged.AddListener(ValueChanged);
            p_toggle.isOn = PlayerPrefs.GetInt("ViewMode", 0) == 1;
        }

        private protected abstract void ValueChanged(bool value);
    }
}
