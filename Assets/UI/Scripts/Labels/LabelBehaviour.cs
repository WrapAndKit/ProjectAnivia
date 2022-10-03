using TMPro;
using UnityEngine;

namespace Assets.UI.Scripts {

    [RequireComponent(typeof(TextMeshProUGUI))]
    internal abstract class LabelBehaviour : MonoBehaviour {
        #region Data

        private TextMeshProUGUI p_label;

        #endregion

        private void Awake() {
            p_label = GetComponent<TextMeshProUGUI>();
        }

        private protected void SetText(string text) {
            p_label.SetText(text);
        }
    }
}
